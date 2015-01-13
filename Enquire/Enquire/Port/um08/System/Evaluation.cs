using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.circular;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using Compucare.Enquire.Common.Tools.Logging;
using Compucare.Frontends.Common.Forms;
using log4net;
using MySql.Data.MySqlClient;
using umfrage2._2008;

namespace compucare.Enquire.Legacy.Umfrage2Lib.System
{
    /// <summary>
    /// Contains all Information about a Database Evaluation,
    /// </summary>
    /// 

    public delegate void EvaluationEventHandler(object source);

    public enum GlobalCompute
    {
        Combine, Average
    }

    public class EvalDeserializer
    {
        private string Filename;
        private Evaluation eval;
        private FileStream read;
        private bool working;
        //private DialogLoad dl;

        public EvalDeserializer(string Filename)
        {
            this.Filename = Filename;
            working = false;
        }
        /*
		public void monitor()
		{
			dl = new DialogLoad(this);
			dl.Show();
			dl.Refresh();
			dl.statusBar.MaxValue = read.Length;
			while (working)
			{
				try
				{
					dl.statusBar.Value = read.Position;
					Thread.Sleep(500);
				}
				catch{Console.Write("ex!");}
			}
		}*/

        private void DoDe()
        {

        }

        internal sealed class VersionConfigToNamespaceAssemblyObjectBinder : SerializationBinder
        {
            private readonly SerializationBinder _binder;

            public VersionConfigToNamespaceAssemblyObjectBinder(SerializationBinder binder)
            {
                _binder = binder;
            }

            /// </summary>
            /// <param name="assemblyName">Specifies the <see cref="T:System.Reflection.Assembly"/> name of the serialized object.</param>
            /// <param name="typeName">Specifies the <see cref="T:System.Type"/> name of the serialized object.</param>
            /// <returns>
            /// The type of the object the formatter creates a new instance of.
            /// </returns>
            public override Type BindToType(string assemblyName, string typeName)
            {
                try
                {
                    return _binder.BindToType(assemblyName, typeName);
                }
                catch (Exception ex)
                {
                    string simpleAssemblyName = assemblyName.Split(',').FirstOrDefault();
                    string simpleTypeName = typeName.Substring(typeName.IndexOf(".") + 1);
                    if (simpleAssemblyName == "umfrage2")
                    {
                        foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
                        {
                            if (asm.GetName().Name == "Compucare.Enquire.Legacy.Umfrage2Lib")
                            {
                                Type t = asm.GetType("compucare.Enquire.Legacy.Umfrage2Lib.System." + simpleTypeName);
                                if (t != null) return t;

                                t = asm.GetType("compucare.Enquire.Legacy.Umfrage2Lib.Output." + simpleTypeName);
                                if (t != null) return t;

                                t = asm.GetType("compucare.Enquire.Legacy.Umfrage2Lib.Output.Star." + simpleTypeName);
                                if (t != null) return t;

                                t = asm.GetType("compucare.Enquire.Legacy.Umfrage2Lib.Output.DNCGeneric" + simpleTypeName);
                                if (t != null) return t;

                                t = asm.GetType("compucare.Enquire.Legacy.Umfrage2Lib.Output.Polarity2008" + simpleTypeName);
                                if (t != null) return t;

                                t = asm.GetType("compucare.Enquire.Legacy.Umfrage2Lib.Output.Table" + simpleTypeName);
                                if (t != null) return t;
                                return asm.GetType(typeName);
                            }


                        }
                    }
                }
                return null;
            }
            /*
            public override Type BindToType(string assemblyName, string typeName)
            {
                Type typeToDeserialize = null;
                try
                {
                    string ToAssemblyName = assemblyName.Split(',')[0];

                    Assembly[] Assemblies = AppDomain.CurrentDomain.GetAssemblies();
                    foreach (Assembly ass in Assemblies)
                    {
                        if (ass.FullName.Split(',')[0] == ToAssemblyName)
                        {
                            typeToDeserialize = ass.GetType(typeName);
                            break;
                        }
                    }
                }
                catch (System.Exception exception)
                {
                    throw exception;
                }
                return typeToDeserialize;
            }*/
        }

        public Evaluation Deserialize()
        {
            working = true;
            eval = new Evaluation(); //neue Auswertung

            //Thread t = new Thread(new ThreadStart(monitor));
            //t.Start();

            try
            {
                read = new FileStream(Filename, FileMode.Open);

                BinaryFormatter bf = new BinaryFormatter();
                //bf.AssemblyFormat = FormatterAssemblyStyle.Simple;
                bf.Binder = new VersionConfigToNamespaceAssemblyObjectBinder(bf.Binder);
                eval = (Evaluation)bf.Deserialize(read);
                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim laden der Datei!\n" + ex.Message + "\n\n" + ex.StackTrace, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                read.Close();
            }
            working = false;
            return eval;
        }
    }

    [Serializable]
    public class Evaluation : ISerializable
    {
        private static readonly ILog _logger = LogHelper.GetLogger();


        public enum SaveMethod { Classic, Multipart }

        /// <summary>
        /// Database Host
        /// </summary>
        public string DatabaseHost;

        /// <summary>
        /// Database User
        /// </summary>
        public string DatabaseUser;

        /// <summary>
        /// Database Password
        /// </summary>
        public string DatabasePassword;

        /// <summary>
        /// Name of Database
        /// </summary>
        public string DatabaseName;

        /// <summary>
        /// Prefix for simulated Database
        /// </summary>
        public string DatabasePrefix;


        /// <summary>
        /// Last saved at:
        /// </summary>
        public string FileName;

        /// <summary>
        /// Daten
        /// </summary>
        public TargetData[] Targets;

        /// <summary>
        /// Personendaten und Einstellungen
        /// </summary>
        public Person[] Persons;


        public Color TlbColor1 = Color.Red;
        public Color TlbColor2 = Color.Yellow;
        public Color TlbColor3 = Color.FromArgb(0, 217, 0);
        public Color TlbValCol = Color.Gray;

        public Color TlbAllCol = Color.Black;
        public Color TlbThisCol = Color.Black;

        public float TlbVal1 = 0.63f;
        public float TlbVal2 = 0.12f;

        public Column[] Columns;

        public Hashtable PieColors;

        public Hashtable TextOverloads = new Hashtable();

        /// <summary>
        /// User data
        /// </summary>
        public User[] Users;

        /// <summary>
        /// Reports
        /// </summary>
        /// 
        public Report[] Reports;

        public Evaluation Clone
        {
            get { return (Evaluation)this.MemberwiseClone(); }
        }

        private int benchmarkindex;
        private Object sokdVal;

        public string SavedResultData;
        public SaveMethod SavedAs;

        public Object GetSokdValues()
        {
            return this.sokdVal;
        }

        public void SetSokdValues(Object val)
        {
            this.sokdVal = val;
        }

        public int CountIncludedCombinedTargets
        {
            get
            {
                int c = 0;
                foreach (TargetData td in CombinedTargets)
                    if (td.Included) c++;
                return c;
            }
        }

        public PersonSetting[] CombinedPersons
        {
            get
            {
                PersonSetting[] ps = new PersonSetting[Persons.Length + PersonCombos.Length];

                int i = 0;
                foreach (Person p in Persons)
                    ps[i++] = p;
                foreach (PersonCombo p in PersonCombos)
                    ps[i++] = p;

                return ps;
            }
        }

        public void RemoveTarget(TargetData td, ArrayList add)
        {
            add.Remove(td);
        }

        private void AddTarget(TargetData td, ArrayList add)
        {
            add.Add(td);
            if (td != null && td.Children != null)
            {
                foreach (TargetData ct in td.Children)
                    AddTarget(ct, add);
            }
        }

        public void InvalidateCombos()
        {
            global = null;
            ComboData = new ArrayList();
        }
        public TargetData[] CombinedTargetList; 
        public TargetData[] CombinedTargets
        {
            get
            {
                //return Targets;

                ArrayList ts = new ArrayList();

                ts.Add(Global);

                foreach (TargetData t in Targets)
                {
                    
                    AddTarget(t, ts);
                }

                foreach (TargetData c in GetComboTargets())
                {
                    
                    AddTarget(c, ts);
                }

                TargetData[] ct = new TargetData[ts.Count];
                int i = 0;
                foreach (TargetData td in ts)
                {
                    ct[i++] = td;
                  
                }
                CombinedTargetList = ct;
                return CombinedTargetList;
            }
            set
            {
                CombinedTargetList = value;
            }
        }

        public PersonCombo[] PersonCombos;

        public TargetCombo[] TargetCombos;

        [NonSerialized]
        private ArrayList ComboData;

        [NonSerialized]
        private EvaluationEventHandler outputDataChanged;
        public event EvaluationEventHandler OutputDataChanged
        {
            add { outputDataChanged += value; }
            remove { outputDataChanged -= value; }
        }

        [NonSerialized]
        public EvaluationEventHandler reportDataChanged;
        public event EvaluationEventHandler ReportDataChanged
        {
            add { reportDataChanged += value; }
            remove { reportDataChanged -= value; }
        }

        [NonSerialized]
        public EvaluationEventHandler targetCombosChanged;
        public event EvaluationEventHandler TargetCombosChanged
        {
            add { targetCombosChanged += value; }
            remove { targetCombosChanged -= value; }
        }

        [NonSerialized]
        public EvaluationEventHandler personDataChanged;
        public event EvaluationEventHandler PersonDataChanged
        {
            add { personDataChanged += value; }
            remove { personDataChanged -= value; }
        }

        [NonSerialized]
        public EvaluationEventHandler resultDataChanged;
        public event EvaluationEventHandler ResultDataChanged
        {
            add { resultDataChanged += value; }
            remove { resultDataChanged -= value; }
        }

        public QuestionCombo[] QuestionCombos;

        public QuestionAlternate[] QuestionAlternates;

        public List<Question> QuestionConvert;

        public List<QuestionPlaceholder> QuestionPlaceholders;

        public int TargetCount
        {
            get { return Targets.Length; }
        }

        public int PersonCount
        {
            get
            {
                return Persons.Length;
            }
        }

        public int ResultCount
        {
            get
            {
                int c = 0;

                foreach (TargetData t in Targets)
                    foreach (Question q in t.Questions)
                        c += q.Results.Count;

                return c;
            }
        }


        public void setBenchmarkIndex(int index)
        {
            this.benchmarkindex = index;
        }

        public int getBenchmarkIndex()
        {
            return this.benchmarkindex;
        }

        public int QuestionCount
        {
            get
            {
                int c = 0;

                foreach (TargetData t in Targets)
                    c += t.Questions.Length;

                return c;
            }
        }

        public int UserCount
        {
            get
            {
                return Users.Length;
            }
        }


        //		[NonSerialized]
        public HistoricData[] History;

        public DateTime lastResultUpdate;

        private DateTime lastSettingsUpdate;

        public string LastResultUpdate
        {
            get
            {
                if (lastResultUpdate == DateTime.MinValue)
                    return "unbekannt";
                else
                    return lastResultUpdate.Day + ". " +
                        lastResultUpdate.Month + ". " +
                        lastResultUpdate.Year + ", " +
                        lastResultUpdate.Hour + ":" +
                        lastResultUpdate.Minute + ":" +
                        lastResultUpdate.Second;
            }
        }

        public string LastSettingsUpdate
        {
            get
            {
                if (lastSettingsUpdate == DateTime.MinValue)
                    return "unbekannt";
                else
                    return lastSettingsUpdate.Day + ". " +
                        lastSettingsUpdate.Month + ". " +
                        lastSettingsUpdate.Year + ", " +
                        lastSettingsUpdate.Hour + ":" +
                        lastSettingsUpdate.Minute + ":" +
                        lastSettingsUpdate.Second;
            }
        }

        public Evaluation EmptyCopy
        {
            get
            {
                Evaluation e2 = new Evaluation();
                e2.Persons = this.Persons;
                e2.Targets = new TargetData[0];
                e2.Users = this.Users;

                return e2;
            }
        }

        [NonSerialized]
        public TargetData global;


        public TargetData Global
        {
            get
            {
                if (global != null)
                    return global;

                TargetData g = new TargetData("GL", "Global", "");
                g.WasCombo = true;
                g.OriginalCombo = null;

                ArrayList IDs = new ArrayList();

                ArrayList Questions = new ArrayList();

                foreach (TargetData target in Targets)
                {
                    //skip testtargets
                    if (target.Test)
                        continue;

                    foreach (Survey s in target.Surveys)
                        g.AddSurvey(s);

                    foreach (Question q in target.Questions)
                    {
                        if (q == null) continue;

                        bool add = true;
                        foreach (int i in IDs)
                            if (i == q.ID) add = false;
                        if (add)
                        {
                            IDs.Add(q.ID);
                            Questions.Add(new Question(q));
                        }
                    }
                }

                g.Questions = new Question[Questions.Count];

                for (int i = 0; i < Questions.Count; i++)
                    g.Questions[i] = (Question)Questions[i];

                foreach (TargetData target in Targets)
                {
                    //skip testtargets
                    if (target.Test)
                        continue;

                    foreach (Question q in target.Questions)
                    {
                        foreach (Question gq in g.Questions)
                        {

                            if (gq == null)
                                continue;

                            if (gq.ID == q.ID)
                            {
                                gq.NullAnswers += q.NullAnswers;

                                foreach (Result r in q.Results)
                                    gq.Results.Add(r.Copy);
                            }
                        }
                    }
                }

                global = g;

                //now quicksort global for question selects
                global.Quicksort(0, global.Questions.Length - 1);

                return global;
            }
        }

        public TargetData ResetGlobal()
        {
            global = null;
            Console.WriteLine("global reset");
            return Global;

        }

        public void ComputeTargetSplits(Evaluation eval, MultipartStatus status)
        {
            status.MultiBar.Value = 0;
            status.MultiBar.Maximum = this.CombinedTargets.Length;

            foreach (TargetData td in this.CombinedTargets)
            {
                td.ComputeSplits(eval);
                status.MultiBar.Increment(1);
                status.Invalidate(true);
            }
        }

        public void ComputeTargetSplits2(Evaluation eval, string targetName)
        {
            foreach (TargetData td in this.CombinedTargets)
            {
                if (td.Name.Equals(targetName))
                {
                    td.ComputeSplits(eval);
                }
            }
        }

        public void ComputeTargetSplits(Evaluation eval)
        {
            foreach (TargetData td in this.CombinedTargets)
            {
                //MessageBox.Show("1. " + td.name+" und Kinder: "+td.QuestionsList.Count.ToString());
                td.ComputeSplits(eval);

            }
        }//void ComputeTargetSplits

        public bool GlobalIncluded
        {
            get
            {
                return global.Included;
            }
            set
            {
                global.Included = value;
            }
        }

        public Evaluation()
        {
            DatabaseHost = DatabaseUser = DatabasePassword = DatabaseName = DatabasePrefix = string.Empty;

            FileName = string.Empty;

            Targets = new TargetData[0];

            Persons = new Person[0];

            Users = new User[0];

            PersonCombos = new PersonCombo[0];

            TargetCombos = new TargetCombo[0];

            ComboData = new ArrayList();

            PieColors = new Hashtable();

            QuestionCombos = new QuestionCombo[0];

            QuestionAlternates = new QuestionAlternate[0];

            History = new HistoricData[0];

            Columns = new Column[0];

            lastResultUpdate = DateTime.MinValue;
            lastSettingsUpdate = DateTime.MinValue;

            SavedAs = SaveMethod.Classic;
            SavedResultData = string.Empty;

            QuestionPlaceholders = new List<QuestionPlaceholder>();
            QuestionConvert = new List<Question>();
        }

        public QuestionPlaceholder GetPlaceholder(int qid)
        {
            foreach (QuestionPlaceholder ph in QuestionPlaceholders)
                if (ph.PID + 100000 * -1 == qid) return ph;

            return null;
        }

        public Question GetNewQuestion(int qid)
        {
            foreach (Question q in QuestionConvert)
            {
                if (q.ID == qid)
                {
                    return q;
                }
            }
            return null;
        }

        public Question[] GlobalQ = null;

        public Question[] CloneGlobalQ()
        {
            List<Question> clones = new List<Question>();
            foreach (Question q in GlobalQ)
            {
                clones.Add(new Question(q));
            }
            return clones.ToArray();
        }

        public ArrayList TargetChilds;
        public ArrayList TargetChildsParent;

        public void setTargets(TargetCombo [] td)
        {
            TargetCombos = td;
        }

        public TargetCombo[] getTargets()
        {
            return TargetCombos;
        }


        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("DatabaseHost", DatabaseHost);
            info.AddValue("DatabaseUser", DatabaseUser);
            info.AddValue("DatabasePassword", DatabasePassword);
            info.AddValue("DatabaseName", DatabaseName);
            info.AddValue("DatabasePrefix", DatabasePrefix);
            info.AddValue("FileName", FileName);
            info.AddValue("Targets", Targets);
            info.AddValue("Persons", Persons);
            info.AddValue("TlbColor1", TlbColor1);
            info.AddValue("TlbColor2", TlbColor2);
            info.AddValue("TlbColor3", TlbColor3);
            info.AddValue("TlbValCol", TlbValCol);
            info.AddValue("TlbAllCol", TlbAllCol);
            info.AddValue("TlbThisCol", TlbThisCol);
            info.AddValue("TlbVal1", TlbVal1);
            info.AddValue("TlbVal2", TlbVal2);
            info.AddValue("Columns", Columns);
            info.AddValue("PieColors", PieColors);
            info.AddValue("TextOverloads", TextOverloads);
            info.AddValue("Users", Users);
            info.AddValue("Reports", Reports);
            info.AddValue("PersonCombos", PersonCombos);
            info.AddValue("TargetCombos", TargetCombos);
            info.AddValue("QuestionCombos", QuestionCombos);
            info.AddValue("lastResultUpdate", lastResultUpdate);
            info.AddValue("lastSettingsUpdate", lastSettingsUpdate);
            info.AddValue("History", History);
            info.AddValue("QuestionAlternates", QuestionAlternates);
            info.AddValue("SavedResultData", SavedResultData);
            info.AddValue("SavedAs", SavedAs);

            info.AddValue("QuestionPlaceholders", QuestionPlaceholders);
            info.AddValue("QuestionConvert", QuestionConvert);
            info.AddValue("_GlobalQ", Global.Questions);
            info.AddValue("TargetChilds", TargetChilds);
            info.AddValue("TargetChildsParent", TargetChildsParent);
        }

        public Evaluation(SerializationInfo info, StreamingContext ctxt)
        {
            DatabaseHost = info.GetString("DatabaseHost");
            DatabaseUser = info.GetString("DatabaseUser");
            DatabasePassword = info.GetString("DatabasePassword");
            DatabaseName = info.GetString("DatabaseName");
            DatabasePrefix = info.GetString("DatabasePrefix");
            FileName = info.GetString("FileName");

            Targets = (TargetData[])info.GetValue("Targets", typeof(TargetData[]));
            Persons = (Person[])info.GetValue("Persons", typeof(Person[]));

            TlbColor1 = (Color)info.GetValue("TlbColor1", typeof(Color));
            TlbColor2 = (Color)info.GetValue("TlbColor2", typeof(Color));
            TlbColor3 = (Color)info.GetValue("TlbColor3", typeof(Color));
            TlbValCol = (Color)info.GetValue("TlbValCol", typeof(Color));
            TlbAllCol = (Color)info.GetValue("TlbAllCol", typeof(Color));
            TlbThisCol = (Color)info.GetValue("TlbThisCol", typeof(Color));

            TlbVal1 = (float)info.GetValue("TlbVal1", typeof(float));
            TlbVal2 = (float)info.GetValue("TlbVal2", typeof(float));

            Columns = (Column[])info.GetValue("Columns", typeof(Column[]));

            PieColors = (Hashtable)info.GetValue("PieColors", typeof(Hashtable));
            TextOverloads = (Hashtable)info.GetValue("TextOverloads", typeof(Hashtable));

            Users = (User[])info.GetValue("Users", typeof(User[]));

            Reports = (Report[])info.GetValue("Reports", typeof(Report[]));

            PersonCombos = (PersonCombo[])info.GetValue("PersonCombos", typeof(PersonCombo[]));
            TargetCombos = (TargetCombo[])info.GetValue("TargetCombos", typeof(TargetCombo[]));

            QuestionCombos = (QuestionCombo[])info.GetValue("QuestionCombos", typeof(QuestionCombo[]));

            try { QuestionAlternates = (QuestionAlternate[])info.GetValue("QuestionAlternates", typeof(QuestionAlternate[])); }
            catch { QuestionAlternates = new QuestionAlternate[0]; }


            try
            {
                lastResultUpdate = info.GetDateTime("lastResultUpdate");
            }
            catch
            {
                lastResultUpdate = DateTime.MinValue;
            }

            try
            {
                lastSettingsUpdate = info.GetDateTime("lastSettingsUpdate");
            }
            catch
            {
                lastSettingsUpdate = DateTime.MinValue;
            }

            try { this.History = (HistoricData[])info.GetValue("History", typeof(HistoricData[])); }
            catch { this.History = new HistoricData[0]; }


            try { this.SavedResultData = info.GetString("SavedResultData"); }
            catch { this.SavedResultData = string.Empty; }

            try { this.SavedAs = (SaveMethod)info.GetValue("SavedAS", typeof(SaveMethod)); }
            catch { this.SavedAs = SaveMethod.Classic; }

            try
            {
                QuestionPlaceholders = (List<QuestionPlaceholder>)info.GetValue("QuestionPlaceholders", typeof(List<QuestionPlaceholder>));
            }
            catch
            {
                QuestionPlaceholders = new List<QuestionPlaceholder>();
            }

            try
            {
                QuestionConvert = (List<Question>)info.GetValue("QuestionConvert", typeof(List<Question>));
            }
            catch
            {
                QuestionConvert = new List<Question>();
            }

            try
            {
                GlobalQ = (Question[])info.GetValue("_GlobalQ", typeof(Question[]));
            }
            catch
            {
                GlobalQ = null;
            }

            try { this.TargetChilds = (ArrayList)info.GetValue("TargetChilds", typeof(ArrayList)); }
            catch { this.TargetChilds = new ArrayList(); }
            try { this.TargetChildsParent = (ArrayList)info.GetValue("TargetChildsParent", typeof(ArrayList)); }
            catch { this.TargetChildsParent = new ArrayList(); }

        }


        public Column GetColumnByName(string name)
        {
            foreach (Column c in Columns)
                if (c.Name.Equals(name)) return c;

            return null;
        }

        ///


        public void RemoveData()
        {
            Targets = new TargetData[0];
            RemoveQuestionConvertResults();
        }

        public void RemoveQuestionConvertResults()
        {
            try
            {
                foreach (Question q in QuestionConvert)
                {
                    q.Results.Clear();
                }
            }
            catch
            {

            }
        }

        public TargetData[] GetData()
        {
            return Targets;
        }

        public void SetData(TargetData[] data)
        {
            Targets = new TargetData[0];
            Targets = data;
        }

        public void AddColumn(Column c)
        {
            if (Columns == null)
                Columns = new Column[0];

            Column[] nc = new Column[Columns.Length + 1];

            int i = 0;
            foreach (Column oc in Columns)
                nc[i++] = oc;

            nc[i] = c;

            Columns = nc;
        }

        public void RemoveColumn(Column c)
        {
            if (Columns == null || Columns.Length == 0 || Columns.Length == 1)
            {
                Columns = new Column[0];
                return;
            }

            Column[] nc = new Column[Columns.Length - 1];

            int i = 0;
            foreach (Column oc in Columns)
                if (oc != c)
                    nc[i++] = oc;

            Columns = nc;
        }

        public void AddHistoricData(HistoricData h)
        {
            if (History == null) History = new HistoricData[0];

            HistoricData[] nhd = new HistoricData[History.Length + 1];

            int i = 0;
            foreach (HistoricData hd in History)
                nhd[i++] = hd;

            nhd[i] = h;

            History = nhd;
        }

        public void RemoveHistoricData(HistoricData h)
        {
            if (History == null || History.Length == 1 || History.Length == 0)
            {
                History = new HistoricData[0];
                return;
            }

            HistoricData[] nhd = new HistoricData[History.Length - 1];

            Console.Write("len = " + (History.Length - 1));
            int i = 0;
            try
            {
                foreach (HistoricData hd in History)
                {
                    if (!hd.Equals(h))
                    {
                        Console.Write("adding" + hd.ToString());
                        nhd[i++] = hd;
                    }
                }
            }
            catch
            {
                nhd = new HistoricData[0];
            }

            History = nhd;
        }

        public string getTextOverload(int QID)
        {
            if (TextOverloads == null)
                TextOverloads = new Hashtable();

            if (TextOverloads.ContainsKey(QID))
                return (string)TextOverloads[QID];
            else
            {
                Question q = Global.GetQuestion(QID, this);
                if (q != null)
                    return q.Text;
                else
                    return "";
            }
        }

        public string getTextOverload(Question q)
        {
            if (q == null) return "unbekannte frage";

            return getTextOverload(q.ID);
        }

        public void Anonymise()
        {
            int num = 1;
            foreach (TargetData td in Targets)
            {
                td.OverloadName("Ziel " + num);
                num++;
            }
        }

        public void AddQuestionCombo(QuestionCombo combo)
        {
            if (QuestionCombos == null)
                QuestionCombos = new QuestionCombo[0];

            QuestionCombo[] old = QuestionCombos;

            QuestionCombos = new QuestionCombo[QuestionCombos.Length + 1];

            int i = 0;
            int hid = 0;
            foreach (QuestionCombo qc in old)
            {
                QuestionCombos[i++] = qc;
                if (qc.ID > hid)
                    hid = qc.ID;
            }

            combo.ID = hid + 1;
            QuestionCombos[i] = combo;
        }

        public void RemoveQuestionCombo(QuestionCombo combo)
        {
            if (QuestionCombos == null || QuestionCombos.Length == 1)
            {
                QuestionCombos = new QuestionCombo[0];
                return;
            }

            bool found = false;
            foreach (QuestionCombo o in QuestionCombos)
            {
                if (o == combo)
                    found = true;
            }

            if (!found)
                return;

            QuestionCombo[] old = QuestionCombos;

            QuestionCombos = new QuestionCombo[QuestionCombos.Length - 1];

            int i = 0;
            foreach (QuestionCombo qc in old)
                if (qc != combo)
                    QuestionCombos[i++] = qc;
        }


        public void AddQuestionAlternate(QuestionAlternate combo)
        {
            if (QuestionAlternates == null)
                QuestionAlternates = new QuestionAlternate[0];

            QuestionAlternate[] old = QuestionAlternates;

            QuestionAlternates = new QuestionAlternate[QuestionAlternates.Length + 1];

            int i = 0;
            foreach (QuestionAlternate qc in old)
            {
                QuestionAlternates[i++] = qc;
            }

            QuestionAlternates[i] = combo;
        }

        public void RemoveQuestionAlternate(QuestionAlternate combo)
        {
            if (QuestionAlternates == null || QuestionAlternates.Length == 1)
            {
                QuestionAlternates = new QuestionAlternate[0];
                return;
            }

            bool found = false;
            foreach (QuestionAlternate o in QuestionAlternates)
            {
                if (o == combo)
                    found = true;
            }

            if (!found)
                return;

            QuestionAlternate[] old = QuestionAlternates;

            QuestionAlternates = new QuestionAlternate[QuestionAlternates.Length - 1];

            int i = 0;
            foreach (QuestionAlternate qc in old)
                if (qc != combo)
                    QuestionAlternates[i++] = qc;
        }



        public void AddReport(Report report)
        {
            if (Reports == null)
                Reports = new Report[0];

            Report[] old = Reports;

            Reports = new Report[Reports.Length + 1];

            int i = 0;
            foreach (Report o in old)
                Reports[i++] = o;

            Reports[i] = report;

            report.OutputDataChanged += new ReportEventHandler(report_OutputDataChanged);

            this.reportDataChanged(this);
        }

        public void RemoveReport(Report report)
        {
            if (Reports == null)
                Reports = new Report[0];

            if (Reports.Length == 0)
                return;

            if (Reports.Length == 1)
            {
                Reports = new Report[0];
                this.reportDataChanged(this);
                return;
            }

            bool found = false;
            foreach (Report o in Reports)
            {
                if (o == report)
                    found = true;
            }

            if (!found)
                return;

            Report[] old = Reports;

            Reports = new Report[Reports.Length - 1];

            int i = 0;
            foreach (Report o in old)
            {
                if (o != report)
                    Reports[i++] = o;
            }

            this.reportDataChanged(this);
        }

        public void AddTargetCombo(TargetCombo combo)
        {
            if (TargetCombos == null)
                TargetCombos = new TargetCombo[0];

            TargetCombo[] old = TargetCombos;

            TargetCombos = new TargetCombo[TargetCombos.Length + 1];

            int i = 0;
            foreach (TargetCombo p in old)
            {
                p.Index = i;
                TargetCombos[i++] = p;
            }

            combo.Index = i;
            TargetCombos[i] = combo;

            targetCombosChanged(this);
        }

        public TargetData[] GetComboTargets()
        {

            if (TargetCombos == null)
                return new TargetData[0];

            if (ComboData == null)
                ComboData = new ArrayList();

            TargetData[] targets = new TargetData[TargetCombos.Length];

            int c = 0;
            foreach (TargetCombo tc in TargetCombos)
            {
                Console.WriteLine("[combo]\t" + tc.Name);
                bool found = false;

                foreach (TargetData td in ComboData)
                    if (td.ID.Equals(tc.CombinedID))
                    {
                        targets[c] = td;
                        found = true;
                    }

                if (found)
                {
                    c++;
                    continue;
                }

                //create
                Console.WriteLine("\t\tcreate");
                TargetData g = new TargetData(tc.CombinedID, tc.Name, "");

                //wennswahris
                g.WasCombo = true;
                g.OriginalCombo = tc;

                ArrayList IDs = new ArrayList();

                ArrayList Questions = new ArrayList();

                foreach (TargetData target in Targets)
                {
                    if (tc.ContainsTarget(target))
                    {
                        Console.WriteLine("\t\tcontains " + target.Name);
                        foreach (Survey s in target.Surveys)
                            g.AddSurvey(s);

                        foreach (Question q in target.Questions)
                        {
                            bool add = true;
                            foreach (int i in IDs)
                                if (i == q.ID) add = false;
                            if (add)
                            {
                                IDs.Add(q.ID);
                                Questions.Add(new Question(q));
                            }
                        }
                    }
                }

                g.Questions = new Question[Questions.Count];

                for (int i = 0; i < Questions.Count; i++)
                    g.Questions[i] = (Question)Questions[i];

                //results
                foreach (TargetData target in Targets)
                {
                    if (tc.ContainsTarget(target))
                    {
                        foreach (Question q in target.Questions)
                        {
                            foreach (Question gq in g.Questions)
                            {
                                if (gq.ID == q.ID)
                                {
                                    gq.NullAnswers += q.NullAnswers;
                                    foreach (Result r in q.Results)
                                        gq.Results.Add(r.Copy);
                                }
                            }
                        }
                    }
                }

                g.Splits.Clear();

                Console.WriteLine("\t\tsplits: " + tc.Splits.Count);

                foreach (TargetSplit ts in tc.Splits)
                {
                    ts.master = g;
                    ts.splitter = g.GetQuestion(ts.splitter, this);
                    g.Splits.Add(ts);
                }

                g.ComputeSplits(this);

                targets[c++] = g;
                ComboData.Add(g);
            }

            return targets;
        }

        public void AddPersonCombo(PersonCombo combo)
        {
            if (PersonCombos == null)
                PersonCombos = new PersonCombo[0];

            PersonCombo[] old = PersonCombos;

            PersonCombos = new PersonCombo[PersonCombos.Length + 1];

            int i = 0;
            foreach (PersonCombo p in old)
            {
                p.Index = i;
                PersonCombos[i++] = p;
            }

            combo.Index = i;
            PersonCombos[i] = combo;
        }

        public void RemovePersonCombo(PersonCombo combo)
        {
            PersonCombo[] old = PersonCombos;

            PersonCombos = new PersonCombo[PersonCombos.Length - 1];

            int i = 0;
            foreach (PersonCombo p in old)
            {
                if (p.Index != combo.Index)
                {
                    p.Index = i;
                    PersonCombos[i++] = p;
                }
            }
        }

        public void RemoveTargetCombo(TargetCombo combo)
        {
            TargetCombo[] old = TargetCombos;

            TargetCombos = new TargetCombo[TargetCombos.Length - 1];

            int i = 0;
            foreach (TargetCombo p in old)
            {
                if (p.Index != combo.Index)
                {
                    p.Index = i;
                    TargetCombos[i++] = p;
                }
            }

            i = 0;
            foreach (TargetData td in ComboData)
            {
                if (td.ID.Equals(combo.CombinedID))
                    break;
                i++;
            }

            if (i < ComboData.Count)
                ComboData.RemoveAt(i);

            targetCombosChanged(this);
        }


        public void RemoveTarget(TargetData combo)
        {
            try
            {
                if (combo == null) return;

                TargetData[] old = Targets;

                Targets = new TargetData[Targets.Length - 1];

                int i = 0;
                foreach (TargetData p in old)
                {
                    if (p != combo)
                    {
                        Targets[i++] = p;
                    }
                }

                i = 0;
            }
            catch
            {

            }
        }

        public void FinishResultUpdate()
        {
            //			lastResultUpdate = DateTime.Now;
            //resultDataChanged(this);
        }

        [NonSerialized]
        //private DialogUpdateResults dar;
        private umfrage2._2007.Controls.LoadDataControl dar;

        /*
		public void UpdateData(DialogUpdateResults dar)
		{
			this.dar = dar;
			Thread t = new Thread(new ThreadStart(this.UpdateDataThread));
			t.Start();
		}
         * */


        public void UpdateData(umfrage2._2007.Controls.LoadDataControl ldar)
        {
            this.dar = ldar;
            Thread t = new Thread(new ThreadStart(this.UpdateDataThread));
            t.Start();
        }

        public int UsersByPerson(Person p)
        {
            int c = 0;
            foreach (User u in this.Users)
                if (u.PersonID == p.ID)
                    c++;

            return c;
        }

        public void DebugUsers()
        {
            StringCollection tids = new StringCollection();
            foreach (User u in this.Users)
                if (!tids.Contains(u.TargetID))
                    tids.Add(u.TargetID);

            foreach (string t in tids)
                Console.WriteLine(t);
        }

        public ArrayList UsersByTarget(TargetData td, Person p)
        {
            ArrayList users = new ArrayList();

            foreach (User u in this.Users)
            {
                if (u.PersonID == p.ID)
                {
                    if (u.TargetID.Equals(td.ID))
                        users.Add(u);
                }
            }

            return users;
        }

        public ArrayList GetUsersByPerson(Person p)
        {
            ArrayList users = new ArrayList();

            foreach (User u in this.Users)
                if (u.PersonID == p.ID)
                    users.Add(u);

            return users;
        }

        private void UpdateDataThread()
        {
            dar.Status("öffne Datenbank");

            var sqlConnectionStringBuilder = new MySqlConnectionStringBuilder();
            sqlConnectionStringBuilder.Server = DatabaseHost;
            sqlConnectionStringBuilder.Database = DatabaseName;
            sqlConnectionStringBuilder.UserID = DatabaseUser;
            sqlConnectionStringBuilder.Password = DatabasePassword;

            MySqlConnection db = new MySqlConnection(sqlConnectionStringBuilder.ConnectionString);

            try
            {
                db.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim öffnen der Datenbank!\n" + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dar.Status("Lade Zieldaten");

            LoadTargetData(db, dar);

            dar.Status("Lade Ergebnisdaten");

            LoadResultData(db, dar);

            dar.Status("Lade Personendaten und Zugangsdaten...");
            LoadPersonData();


            dar.Status("beende Datenbankverbindung");
            db.Close();

            dar.Status("Vorgang abgeschlossen");

            dar.GlobalStatus.Value = dar.GlobalStatus.Maximum;
            dar.LocalStatus.Value = dar.LocalStatus.Maximum;
            dar.Refresh();

            dar.TimeRemainingLabel.Text = "";

            //dar.DoneButton.Enabled = true;
        }

        public void LoadConvertQuestions()
        {
            if (QuestionConvert != null)
            {
                List<Question> QuestionsConvert2 = new List<Question>();
                foreach (Question q in QuestionConvert)
                {
                    QuestionsConvert2.Add(q);
                }
                QuestionConvert.Clear();
                QuestionConvert = QuestionsConvert2;
            }
        }


        public void LoadConvertQuestions2()
        {
            try
            {
                List<Question> QuestionsConvert2 = new List<Question>();
                if (QuestionConvert.Count > 0)
                {

                    foreach (Question q in QuestionConvert)
                    {
                        ArrayList newResults = new ArrayList();
                        int Question_Id = q.NullAnswers; //welcher id 

                        string[] split = q.Shortcut.Split(';'); //spaltenbereiche
                        int[] split2 = new int[split.Length];

                        Question temp = null;
                        foreach (Question x in Global.Questions)
                        {
                            if (x.ID == Question_Id)
                            {
                                temp = x;
                                break;
                            }
                        }

                        for (int i = 0; i < split.Length; i++)
                        {
                            split2[i] = int.Parse(split[i].ToString().Trim());
                        }

                        if (temp != null)
                        {
                            foreach (Result r in temp.Results)
                            {
                                int textToInt = -1;
                                try
                                {
                                    if (r.TextAnswer != null && r.TextAnswer.Length > 0)
                                    {
                                        textToInt = int.Parse(r.TextAnswer.ToString().Trim());
                                    }
                                }
                                catch
                                {
                                    textToInt = -1;
                                }
                                int selektor = -1;

                                for (int i = 0; i < split2.Length; i++)
                                {
                                    if (textToInt <= split2[i] && textToInt != -1)
                                    {
                                        selektor = i;
                                        break;
                                    }
                                }

                                if (selektor > -1)
                                {
                                    Result tmp = new Result();
                                    tmp = Result.Create(selektor, r.UserID);
                                    newResults.Add(tmp);
                                }
                            }//end foreach Results
                        }//end if
                        q.Results = newResults;
                        QuestionsConvert2.Add(q);
                        //global.AddQuestion(q);
                    }//end foreach Question
                    QuestionConvert.Clear();
                    QuestionConvert = QuestionsConvert2;
                }//end if

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n" + ex.Message);
            }
        }


        public void DebugResultStats()
        {
            foreach (TargetData td in this.Targets)
            {
                Console.WriteLine("---- (" + td.iD + ")" + td.name);

                long mx = 0;

                foreach (Question q in td.Questions)
                {
                    if (q.Results.Count > mx) mx = q.Results.Count;
                }

                Console.WriteLine("\t[max res q]\t" + mx);

                Hashtable ugs = new Hashtable();

                ArrayList uuser = new ArrayList();
                foreach (Question q in td.Questions)
                {
                    foreach (Result r in q.Results)
                    {
                        if (!uuser.Contains(r.UserID)) uuser.Add(r.UserID);

                        int pid = GetPersonIdByUser(r.UserID);

                        if (!ugs.ContainsKey(pid))
                        {
                            ugs[pid] = new Hashtable();
                        }

                        Hashtable ures = (Hashtable)ugs[pid];

                        if (ures.ContainsKey(r.UserID))
                            ures[r.UserID] = (int)ures[r.UserID] + 1;
                        else
                            ures[r.UserID] = 1;
                    }
                }

                foreach (int pid in ugs.Keys)
                {
                    Hashtable ug = (Hashtable)ugs[pid];

                    int max = int.MinValue;
                    int min = int.MaxValue;
                    foreach (int uid in ug.Keys)
                    {
                        int val = (int)ug[uid];

                        if (val > max) max = val;
                        if (val < min) min = val;
                    }

                    Console.WriteLine("\t[ug]\t" + pid + "\t" + min + "-" + max);
                }

                Console.WriteLine("\t[unique users]\t" + uuser.Count);

            }
        }


        public void Load2007_Init(umfrage2._2007.Controls.LoadDataControl dar)
        {
            this.dar = dar;

            Thread t = new Thread(new ThreadStart(Load2007_Init_Thread));
            t.Start();
        }

        public void Load2007_Process(umfrage2._2007.Controls.LoadDataControl dar)
        {
            this.dar = dar;

            Thread t = new Thread(new ThreadStart(Load2007_Process_Thread));
            t.Start();
        }

        MySqlConnection db;

        public void Load2007_Init_Thread()
        {
            var sqlConnectionStringBuilder = new MySqlConnectionStringBuilder();
            sqlConnectionStringBuilder.Server = DatabaseHost;
            sqlConnectionStringBuilder.Database = DatabaseName;
            sqlConnectionStringBuilder.UserID = DatabaseUser;
            sqlConnectionStringBuilder.Password = DatabasePassword;

            db = new MySqlConnection(sqlConnectionStringBuilder.ConnectionString);

            try
            {
                db.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim öffnen der Datenbank!\n" + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (db.State != ConnectionState.Open) return;


            //0. begin

            MySqlCommand cmd;
            MySqlDataReader d;

            //1. Info holen - db

            dar.Status("Erfrage Datenbankstatus");


            cmd = new MySqlCommand("select * from " + DatabasePrefix + "bank", db);
            
            d = cmd.ExecuteReader();
            
            ArrayList nTargets = new ArrayList();

            while (d.Read())
            {

                string first = "";
                string second = "";
                string third = "";
                if (d.IsDBNull(0)) first = ""; else first = d.GetString(0);
                if (d.IsDBNull(1)) second = ""; else second = d.GetString(1);
                if (d.IsDBNull(2)) third = ""; else third = d.GetString(2);

                TargetData td = new TargetData(first, second, third);
                nTargets.Add(td);

                dar.ChooseTarget.Items.Add(td);

                //dar.ctc = new ChooseTargetControl(
            }
            d.Close();
            dar.ControlButton.Enabled = true;
            dar.Loadfix();
            dar.Status("Warte auf Zielauswahl");
        }

        private int sek2 = 0;
        private int sek = 0;

        public void Load2007_Process_Thread()
        {

            dar.Status("Download Start");
         
            if (dar.datumAktiv)
            {
                DateTime date1 = new DateTime(1970, 1, 1).ToUniversalTime();  //Refernzdatum (festgelegt)
                DateTime date2 = dar.datumVon.ToUniversalTime(); ;              //jetztiges Datum / Uhrzeit
                TimeSpan ts = new TimeSpan(date2.Ticks - date1.Ticks);  // das Delta ermitteln
                // Das Delta als gesammtzahl der sekunden ist der Timestamp
                sek = Convert.ToInt32(ts.TotalSeconds);
                //DateTime date2 = DateTime.Now.ToUniversalTime();

                DateTime date3 = new DateTime(1970, 1, 1).ToUniversalTime();  //Refernzdatum (festgelegt)
                DateTime date4 = dar.datumBis.ToUniversalTime();              //jetztiges Datum / Uhrzeit
                TimeSpan ts2 = new TimeSpan(date4.Ticks - date3.Ticks);  // das Delta ermitteln
                // Das Delta als gesammtzahl der sekunden ist der Timestamp
                sek2 = Convert.ToInt32(ts2.TotalSeconds);
                sek2 += 86000;
            }
            //MessageBox.Show("Sekunden Von: "+sek+"\nSekunden Bis: "+sek2);

            if (db.State != ConnectionState.Open) return;

            MySqlCommand cmd;
          
            MySqlDataReader d;

            Evaluation enew = new Evaluation();

            ArrayList qnew = new ArrayList();

            int qCount = 0;

            //2. Zielunabhängige Daten laden
            //2.1 - Fragen

            dar.Status("Lade Fragen...");
                   
            cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "frage", db);

            //cmd.CommandText = "select count(*) from " + DatabasePrefix + "frage";
            
            d = cmd.ExecuteReader();
          
            d.Read();

            if (!d.IsDBNull(0))
                qCount = d.GetInt32(0);
            else
                qCount = 0;

            
            dar.LocalStatus.Maximum = qCount;
            dar.LocalStatus.Value = 0;

            cmd = new MySqlCommand("select * from " + DatabasePrefix + "frage", db);

            d.Close();
            d = cmd.ExecuteReader();
           

            while (d.Read())//Fragen mit Alias laden und speichern
            {
                
                int first = 0;
                string second = "";
                string third = "";
                string four = "";
                string five = "";
                if (!d.IsDBNull(0)) first = d.GetInt32(0);
                if (!d.IsDBNull(1)) second = d.GetString(1);
                if (!d.IsDBNull(2)) third = d.GetString(2);
                if (!d.IsDBNull(3)) four = d.GetString(3);
                if (!d.IsDBNull(4)) five = d.GetString(4);

                
                Question q = Question.Create(first, second, third, four, five, 0);

                try
                {
                    MySqlCommand ac = new MySqlCommand("select * from " + DatabasePrefix + "qalias where a_fr_id='" + q.ID + "'", db);
                    MySqlDataReader ar = ac.ExecuteReader();

                    while (ar.Read())
                    {
                        int alias = 0;
                        if (!ar.IsDBNull(1)) alias = ar.GetInt32(1);
                        string str = "";
                        if (!ar.IsDBNull(2)) str = ar.GetString(2); 
                        q.TextAlii[alias] = str;
                    }
                }
                catch
                {
                    Console.WriteLine(q.ID + " has alias select err - old db format or fucked up?");
                }

                /*bool add = true;
                foreach (string a in q.AnswerList)
                    if (a.Equals("Keine Antwort")) add = false;

                if (add) q.Answers += ";Keine Antwort";*/

                qnew.Add(q);
                dar.LocalStatus.Value++;
            }//end while

            dar.LocalStatus.Value = 0;

            //2.2 Personen

            dar.Status("Lade Personengruppen...");
            cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "personen", db);
            d.Close();
            d = cmd.ExecuteReader();

            d.Read();

            int persons = 0;
            if(!d.IsDBNull(0)) persons = d.GetInt32(0);

            enew.Persons = new Person[persons];
            dar.LocalStatus.Maximum = persons;

            cmd = new MySqlCommand("select * from " + DatabasePrefix + "personen", db);
            d.Close();
            d = cmd.ExecuteReader();

            int i = 0;

            while (d.Read())
            {
                int first = 0;
                string second = "";
                if(!d.IsDBNull(0)) first = d.GetInt32(0);
                if (!d.IsDBNull(1)) second = d.GetString(1);

                Person person = new Person(second, first);
                enew.Persons[i++] = person;

                /*bool found = false;
                foreach (Person po in Persons)
                {
                    if (po.ID == person.ID && person.Name.Equals(person.Name))
                    {
                        found = true;
                        enew.Persons[i++] = person;
                        break;
                    }
                }

                if (!found) enew.Persons[i++] = person;*/
                dar.LocalStatus.Value++;
            }
            dar.LocalStatus.Value = 0;
            //existing persons?

            //2.3 User

            dar.Status("Lade Benutzer/Zugangsdaten...");

            if (dar.datumAktiv == true && dar.percentAktiv == true)
            {
                cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "zugangsdaten, " + DatabasePrefix + "meta where z_id = m_z_id and (used = '1' or status > " + dar.percentValue + ") and time_start >= " + sek + " and time_end <= " + sek2, db);
            }
            else if (dar.datumAktiv == true)
            {
                cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "zugangsdaten, " + DatabasePrefix + "meta where z_id = m_z_id and (used = '1' or status > 49) and time_start >= " + sek + " and time_end <= " + sek2, db);
            }
            else if (dar.percentAktiv == true)
            {
                cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "zugangsdaten where (used = '1' or status > " + dar.percentValue + ")", db);
            }
            else
            {
                cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "zugangsdaten where (used = '1' or status > 49)", db);
            }
            d.Close();
            d = cmd.ExecuteReader();

            d.Read();
            int xx = 0;
            if(!d.IsDBNull(0)) xx = d.GetInt32(0);


            /*MessageBox.Show("Anzahl der Fragen: " + qCount + "DatabasePrefix: " + DatabasePrefix 
                + "\nAnzahl der Zugangsdaten: " + xx);*/
            enew.Users = new User[xx];  //Anzahl der Zugangsdaten

            if (dar.datumAktiv==true && dar.percentAktiv==true)
            {
                cmd = new MySqlCommand("select * from " + DatabasePrefix + "zugangsdaten, " + DatabasePrefix + "meta where z_id = m_z_id and (used = '1' or status > " + dar.percentValue + ") and time_start >= " + sek + " and time_end <= " + sek2, db);
            }
            else if (dar.datumAktiv==true)
            {
                cmd = new MySqlCommand("select * from " + DatabasePrefix + "zugangsdaten, " + DatabasePrefix + "meta where z_id = m_z_id and (used = '1' or status > 49) and time_start >= " + sek + " and time_end <= " + sek2, db);
            }
            else if (dar.percentAktiv==true)
            {
                cmd = new MySqlCommand("select * from " + DatabasePrefix + "zugangsdaten where (used = '1' or status > " + dar.percentValue + ")", db);
            }
            else
            {
                cmd = new MySqlCommand("select * from " + DatabasePrefix + "zugangsdaten where (used = '1' or status > 49)", db);
            }
            d.Close();
            d = cmd.ExecuteReader();

            i = 0;
            dar.LocalStatus.Maximum = xx;
            
            while (d.Read())
            {
                int first = 0;
                string second = "";
                int third = 0;

                if(!d.IsDBNull(0)) first = d.GetInt32(0);
                if(!d.IsDBNull(2)) second = d.GetString(2);
                if (!d.IsDBNull(3)) third = d.GetInt32(3);

                User user = new User(first, second, third);
                enew.Users[i++] = user;
                dar.LocalStatus.Value++;
            }

            ArrayList listEnewUser = new ArrayList();

            dar.LocalStatus.Value = 0;

            cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "meta", db);
            d.Close();
            d = cmd.ExecuteReader();
            d.Read();
            int firstone = 0;
            if (!d.IsDBNull(0)) firstone = d.GetInt32(0);
            dar.LocalStatus.Maximum = firstone;

            int counter = 0;
            dar.Status("Lade Metadaten");
            cmd = new MySqlCommand("select * from " + DatabasePrefix + "meta", db);
            d.Close();
            d = cmd.ExecuteReader();
            try
            {
                while (d.Read()) //hier werden die meta Daten von jeweiligen Personen zugeteilt
                {
                    User set = null;

                    foreach (User u in enew.Users)
                    {
                        int first = 0;
                        if (!d.IsDBNull(0)) first = d.GetInt32(0);
                        
                        if (u.ID == first)
                        {
                            set = u;
                        }

                        if (set != null)
                        {
                            if (!d.IsDBNull(2))
                            {
                                set.Start = d.GetInt32(2);
                            }

                            if (!d.IsDBNull(3))
                            {
                                set.End = d.GetInt32(3);
                            }
                        }
                    }//endEnewUsers
                    dar.LocalStatus.Value++;

                }//endRead
            }
            catch
            {
                MessageBox.Show("Meta Download Exception");
            }
            dar.LocalStatus.Value=0;
            dar.Status("Lade Zieldaten");



            lastSettingsUpdate = DateTime.Now;

            //3. Info holen - benutzer, was laden?


            //3.1 zählen
            int[] maxE = new int[dar.ChooseTarget.CheckedItems.Count];
            int maxTotal = 0;

            i = 0;
            
            if (dar.datumAktiv==true && dar.percentAktiv==true)
            {
                foreach (TargetData td in dar.ChooseTarget.CheckedItems)
                {

                    try
                    {
                        cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten, " + DatabasePrefix + "meta where z_id = e_z_id and z_id = m_z_id and z_b_id = '" + td.ID + "' and (used = '1' or status > " + dar.percentValue + ") and time_start >= " + sek + " and time_end <= " + sek2, db);
                        d.Close();
                        d = cmd.ExecuteReader();
                        d.Read();

                        int first = 0;
                        if (!d.IsDBNull(0)) first = d.GetInt32(0);
                        maxE[i] = first;
                        maxTotal += maxE[i];

                        i++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.StackTrace);
                    }
                }


            }
            else if (dar.datumAktiv==true)
            {
                foreach (TargetData td in dar.ChooseTarget.CheckedItems)
                {

                    try
                    {
                        cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten, " + DatabasePrefix + "meta where z_id = e_z_id and z_id = m_z_id and z_b_id = '" + td.ID + "' and (used = '1' or status > 49) and time_start >= " + sek + " and time_end <= " + sek2, db);
                        d.Close();
                        d = cmd.ExecuteReader();
                        d.Read();

                        int first = 0;
                        if (!d.IsDBNull(0)) first = d.GetInt32(0);
                        maxE[i] = first;

                        maxTotal += maxE[i];

                        i++;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.StackTrace);
                    }
                }


            }
            else if (dar.percentAktiv==true)
            {
                foreach (TargetData td in dar.ChooseTarget.CheckedItems)
                {
                    cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten where z_id = e_z_id and z_b_id = '" + td.ID + "' and (used = '1' or status > " + dar.percentValue + ")", db);

                    d.Close();
                    d = cmd.ExecuteReader();
                    d.Read();

                    int first = 0;
                    if (!d.IsDBNull(0)) first = d.GetInt32(0);
                    maxE[i] = first;

                    maxTotal += maxE[i];

                    i++;
                }
            }
            else
            {

                foreach (TargetData td in dar.ChooseTarget.CheckedItems)
                {
                    cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten where z_id = e_z_id and z_b_id = '" + td.ID + "' and (used = '1' or status > 49)", db);
                    d.Close();
                    d = cmd.ExecuteReader();
                    d.Read();

                    int first = 0;
                    if (!d.IsDBNull(0)) first = d.GetInt32(0);
                    maxE[i] = first;

                    maxTotal += maxE[i];

                    i++;
                }
            }


            dar.GlobalStatus.Maximum = maxTotal;
            dar.Status("Ende Zieldaten");
            DateTime Start = DateTime.Now;

            int j = 0;
            foreach (TargetData td in dar.ChooseTarget.CheckedItems)
            {
                dar.Status("Lade Ergebnisse für " + td + "...");
                td.Questions = new Question[qnew.Count];
                i = 0;
                foreach (Question q in qnew) td.Questions[i++] = new Question(q);

                dar.LocalStatus.Value = 0;
                dar.LocalStatus.Maximum = maxE[j];

                dar.Status("Lade Ergebnisse für " + td + "... (DB- Abfrage - Kann einige Zeit beanspruchen)");

                /*
                try
                {
                    
                    dar.Status("a");
                    cmd = new MySQLCommand("select * from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten where z_id = e_z_id and z_b_id = '" + td.ID + "' and (used = '1' or status > 49)", db);
                    cmd.ServerCursor = true;
                    cmd.FetchSize = 100;
                    d = cmd.ExecuteReaderEx();
                     
                }
                catch
                {
                    dar.Status("b");
                    cmd = new MySQLCommand("select * from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten where z_id = e_z_id and z_b_id = '" + td.ID + "' and (used = '1' or status > 49)", db);
                    d = cmd.ExecuteReaderEx();
                }
                */

                if (dar.datumAktiv && dar.percentAktiv)
                    cmd = new MySqlCommand("select * from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten, " + DatabasePrefix + "meta where z_id = e_z_id and z_id = m_z_id and z_b_id = '" + td.ID + "' and (used = '1' or status > " + dar.percentValue + ") and time_start >= " + sek + " and time_end <= " + sek2, db);
                else if (dar.datumAktiv)
                    cmd = new MySqlCommand("select * from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten, " + DatabasePrefix + "meta where z_id = e_z_id and z_id = m_z_id and z_b_id = '" + td.ID + "' and (used = '1' or status > 49) and time_start >= " + sek + " and time_end <= " + sek2, db);
                else if (dar.percentAktiv)
                    cmd = new MySqlCommand("select * from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten where z_id = e_z_id and z_b_id = '" + td.ID + "' and (used = '1' or status > " + dar.percentValue + ")", db);
                else
                    cmd = new MySqlCommand("select * from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten where z_id = e_z_id and z_b_id = '" + td.ID + "' and (used = '1' or status > 49)", db);

                d.Close();
                d = cmd.ExecuteReader();


                dar.Status("Lade Ergebnisse für " + td + "... (Verarbeite Daten)");
                while (d.Read())
                {

                    int first = 0;
                    if (!d.IsDBNull(1)) first = d.GetInt32(1);
                    
                    int nID = 0;
                    if (!d.IsDBNull(2)) nID = d.GetInt32(2);

                    string third = "";
                    if (!d.IsDBNull(3)) third = d.GetString(3);

                    foreach (Question q in td.Questions)
                    {
                        if (q.ID == nID)
                        {
                            //found question
                            
                            if (third.Trim().Equals(string.Empty) && d.IsDBNull(4))
                            {
                                // Console.WriteLine("Null!");
                                q.NullAnswers++;
                            }

                            if (q.Display.Equals("radio"))
                            {
                                //possible new format

                                if (!d.IsDBNull(4)) //new 
                                {
                                    q.Results.Add(Result.Create(d.GetInt32(4), first));
                                }
                                else //old
                                {
                                    q.Results.Add(Result.Create(q.GetAnswerId(third), first));
                                }
                            }
                            else
                            {
                                q.Results.Add(Result.Create(third, first));
                            }
                            break;
                        }
                    }

                    if (dar.LocalStatus.Value < dar.LocalStatus.Maximum) dar.LocalStatus.Value++;
                    if (dar.GlobalStatus.Value < dar.GlobalStatus.Maximum) dar.GlobalStatus.Value++;

                    if (dar.GlobalStatus.Value % 100 == 0)
                    {
                        if (dar.GlobalStatus.Value > 0)
                        {
                            TimeSpan elapsed = DateTime.Now - Start;
                            long ticks = (long)(((double)elapsed.Ticks) / (((double)dar.GlobalStatus.Value / (double)dar.GlobalStatus.Maximum)));
                            TimeSpan remaining = new TimeSpan(ticks) - elapsed;
                            dar.TimeRemainingLabel.Text = remaining.Hours + "h " + remaining.Minutes + "m " + remaining.Seconds + "s ";
                            dar.TimeElapsedLabel.Text = elapsed.Hours + "h " + elapsed.Minutes + "m " + elapsed.Seconds + "s ";
                            Console.WriteLine(td.ID + ":\t" + dar.LocalStatus.Value + "/" + dar.LocalStatus.Maximum);
                            dar.Status("Lade Ergebnisse für " + td + "... (" + dar.LocalStatus.Value + "/" + dar.LocalStatus.Maximum + ")");
                        }
                    }
                }

                j++;
            }

            dar.Status("Abgleichen...");

            //fill old eval

            this.Users = enew.Users;
            this.Persons = enew.Persons;

            //overwrite old?
            for (int x = 0; x < Targets.Length; x++)
            {
                foreach (TargetData td in dar.ChooseTarget.CheckedItems)
                {
                    if (td.iD.Equals(Targets[x].iD))
                        Targets[x] = td;
                }
            }

            //any new?
            foreach (TargetData td in dar.ChooseTarget.CheckedItems)
            {
                bool found = false;
                for (int x = 0; x < Targets.Length; x++)
                {
                    if (td.iD.Equals(Targets[x].iD)) found = true;
                }

                if (!found) //zach
                {
                    TargetData[] ntd = new TargetData[Targets.Length + 1];
                    int y = 0;
                    foreach (TargetData otd in Targets)
                        ntd[y++] = otd;
                    ntd[y] = td;

                    Targets = ntd;
                }
            }

            dar.Status("Alias...");

            d.Close();
            try
            {
                QuestionEnrichment enr = new QuestionEnrichment(db, DatabasePrefix);
                foreach (TargetData target in Targets)
                {
                    enr.EnrichQuestionTexts(this, target);
                }
            }
            catch (Exception ex)
            {
                ExceptionVisualiser.Show(ex);
            }

            global = null;
            //LoadConvertQuestions();

            dar.Status("Vorgang abgeschlossen");
            dar.ControlButton.Enabled = true;
            dar.ChooseTarget.Enabled = true;
            
            lastResultUpdate = DateTime.Now;

            //resultDataChanged(this);
            //personDataChanged(this);
            //reportDataChanged(this);

            db.Close();

            ComputeTargetSplits(this);
            dar.LocalStatus.Maximum = 10;
            dar.LocalStatus.Value = 10;
            dar.GlobalStatus.Maximum = 10;
            dar.GlobalStatus.Value = 10;
            dar.Status("Vorgang abgeschlossen");
        }

        public void LoadTargetData(MySqlConnection db, umfrage2._2007.Controls.LoadDataControl dar)
        {
            if (db.State != ConnectionState.Open)
                return;

            dar.Status("Zähle Ziele...");
            MySqlCommand cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "bank", db);
            MySqlDataReader d = cmd.ExecuteReader();
            d.Read();

            dar.Status("Erstelle Zieltabelle...");


            Targets = new TargetData[d.GetInt32(0)];


            dar.Status("Lade Zieldaten...");
            cmd = new MySqlCommand("select * from " + DatabasePrefix + "bank", db);
            d.Close();
            d = cmd.ExecuteReader();

            int i = 0;
            while (d.Read())
            {
                string first = "";
                string second = "";
                string third = "";

                if (!d.IsDBNull(0)) first = d.GetString(0);
                if (!d.IsDBNull(1)) second = d.GetString(1);
                if (!d.IsDBNull(2)) third = d.GetString(2);

                Console.WriteLine("Lade " + second + "...");
                TargetData td = new TargetData(first, second, third);
                Targets[i++] = td;
            }

            global = null;
        }

        public void LoadResultData(MySqlConnection db, umfrage2._2007.Controls.LoadDataControl dialog)
        {
            try
            {
                DateTime Start = DateTime.Now;

                dialog.Status("Zähle Ergebnisse...");
                MySqlCommand cmd;

                if (dar.datumAktiv && dar.percentAktiv)
                {
                    cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten where z_id = e_z_id and (used = '1' or status > " + dar.percentValue + ") and time_start >= " + sek + " and time_end <= " + sek2, db);
                }
                else if (dar.datumAktiv)
                {
                    cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten where z_id = e_z_id and (used = '1' or status > 49) and time_start >= " + sek + " and time_end <= " + sek2, db);
                }
                else if (dar.percentAktiv)
                {
                    cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten where z_id = e_z_id and (used = '1' or status > " + dar.percentValue + ")", db);
                }
                else
                {
                    cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten where z_id = e_z_id and (used = '1' or status > 49)", db);
                }

                MySqlDataReader d = cmd.ExecuteReader();

                d.Read();
                int max = 0;
                if (!d.IsDBNull(0)) max = d.GetInt32(0);

                dialog.GlobalStatus.Maximum = max;

                dialog.Status("Lade Fragebögen...");
                cmd = new MySqlCommand("select * from " + DatabasePrefix + "fragebogen", db);
                d.Close();
                d = cmd.ExecuteReader();

                int[] TargetQuestions = new int[Targets.Length];

                int j = 0;

                for (int ti = 0; ti < Targets.Length; ti++)//each (TargetData t in Targets)
                {
                    dialog.Status("Lade Fragebögen für ..." + Targets[ti].Name);
                    cmd = new MySqlCommand("select * from " + DatabasePrefix + "fragebogen", db);
                    d.Close();
                    d = cmd.ExecuteReader();

                    ArrayList IDs = new ArrayList();

                    while (d.Read())
                    {
                        if (d.GetString(1) != "" && d.GetString(1).ToLower() != "null")
                        {
                            string[] elements = d.GetString(3).Split(';');

                            for (int i = 0; i < elements.Length; i++)
                            {
                                if (elements[i].Length > 0)
                                {
                                    if (elements[i][0] == '#')
                                    {
                                        //TODO: HEADER
                                    }
                                    else if (elements[i][0] == '@')
                                    {
                                        // do nothing
                                    }
                                    else
                                    {
                                        MySqlCommand cmd2 = new MySqlCommand("select * from " + DatabasePrefix + "frage where fr_id='" + elements[i] + "' ", db);
                                        MySqlDataReader d2 = cmd2.ExecuteReader();

                                        if (d2.Read())
                                        {
                                            bool add = true;
                                            foreach (int ii in IDs)
                                            {
                                                if (ii == d2.GetInt32(0)) add = false;
                                            }
                                            if (add)
                                            {
                                                IDs.Add(d2.GetInt32(0));
                                                TargetQuestions[j]++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    j++;
                }

                //

                int TargetCounter = 0;

                foreach (TargetData target in Targets)
                {
                    //questions
                    dialog.Status("Lade Fragen für " + target.Name);


                    dialog.LocalStatus.Value = 0;
                    dialog.LocalStatus.Maximum = TargetQuestions[TargetCounter];

                    target.Questions = new Question[TargetQuestions[TargetCounter]];

                    int qi = 0;

                    cmd = new MySqlCommand("select * from " + DatabasePrefix + "fragebogen", db);
                    d.Close();
                    d = cmd.ExecuteReader();

                    ArrayList IDs = new ArrayList();

                    while (d.Read())
                    {
                        if (d.GetString(1) != "" && d.GetString(1).ToLower() != "null")
                        {
                            string[] elements = d.GetString(3).Split(';');

                            Survey s = new Survey();
                            s.QuestionList = elements;
                            s.PID = d.GetInt32(2);

                            target.AddSurvey(s);

                            for (int i = 0; i < elements.Length; i++)
                            {
                                if (elements[i].Length > 0)
                                {
                                    if (elements[i][0] == '#')
                                    {
                                        //TODO: HEADER
                                    }
                                    else if (elements[i][0] == '@')
                                    {
                                        // do nothing
                                    }
                                    else
                                    {

                                        MySqlCommand cmd2 = new MySqlCommand("select * from " + DatabasePrefix + "frage where fr_id='" + elements[i] + "' ", db);
                                        MySqlDataReader d2 = cmd2.ExecuteReader();

                                        if (d2.Read())
                                        {
                                            bool add = true;
                                            foreach (int ii in IDs)
                                            {
                                                if (ii == d2.GetInt32(0)) add = false;
                                            }
                                            if (add)
                                            {
                                                IDs.Add(d2.GetInt32(0));
                                                target.Questions[qi++] = Question.Create(d2.GetInt32(0), d2.GetString(1), d2.GetString(2), d2.GetString(3), d2.GetString(4), 0);

                                                dialog.LocalStatus.Value++;
                                                dialog.GlobalStatus.Value++;

                                                if (dialog.GlobalStatus.Value % 20 == 0)
                                                {
                                                    if (dialog.GlobalStatus.Value > 0)
                                                    {
                                                        TimeSpan elapsed = DateTime.Now - Start;
                                                        long ticks = (long)(((double)elapsed.Ticks) / ((double)dialog.GlobalStatus.Value));
                                                        TimeSpan remaining = new TimeSpan(ticks) - elapsed;
                                                        dialog.TimeRemainingLabel.Text = remaining.Hours + "h " + remaining.Minutes + "m " + remaining.Seconds + "s ";
                                                        dialog.TimeElapsedLabel.Text = elapsed.Hours + "h " + elapsed.Minutes + "m " + elapsed.Seconds + "s ";
                                                    }
                                                    dialog.Refresh();
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }

                    dialog.LocalStatus.Value = dialog.LocalStatus.Minimum;

                    //results
                    dialog.Status("lade Ergebnisse für " + target.Name);

                    if (dar.datumAktiv && dar.percentAktiv)
                        cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten where z_id = e_z_id and z_b_id = '" + target.ID + "' and (used = '1' or status > " + dar.percentValue + ") and time_start >= " + sek + " and time_end <= " + sek2, db);
                    else if (dar.datumAktiv)
                        cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten where z_id = e_z_id and z_b_id = '" + target.ID + "' and (used = '1' or status > 49) and time_start >= " + sek + " and time_end <= " + sek2, db);
                    else if (dar.percentAktiv)
                        cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten where z_id = e_z_id and z_b_id = '" + target.ID + "' and (used = '1' or status > " + dar.percentValue + ")", db);
                    else
                        cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten where z_id = e_z_id and z_b_id = '" + target.ID + "' and (used = '1' or status > 49)", db);
                    d.Close();
                    d = cmd.ExecuteReader();
                    d.Read();

                    dialog.LocalStatus.Maximum = d.GetInt32(0);

                    if (dar.datumAktiv && dar.percentAktiv)
                        cmd = new MySqlCommand("select * from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten where z_id = e_z_id and z_b_id = '" + target.ID + "' and (used = '1' or status > " + dar.percentValue + ") and time_start >= " + sek + " and time_end <= " + sek2, db);
                    else if (dar.datumAktiv)
                        cmd = new MySqlCommand("select * from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten where z_id = e_z_id and z_b_id = '" + target.ID + "' and (used = '1' or status > 49) and time_start >= " + sek + " and time_end <= " + sek2, db);
                    else if (dar.percentAktiv)
                        cmd = new MySqlCommand("select * from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten where z_id = e_z_id and z_b_id = '" + target.ID + "' and (used = '1' or status > " + dar.percentValue + ")", db);
                    else
                        cmd = new MySqlCommand("select * from " + DatabasePrefix + "ergebnisse, " + DatabasePrefix + "zugangsdaten where z_id = e_z_id and z_b_id = '" + target.ID + "' and (used = '1' or status > 49)", db);

                    d.Close();
                    d = cmd.ExecuteReader();

                    while (d.Read())
                    {
                        foreach (Question q in target.Questions)
                        {
                            if (q.ID == d.GetInt32(2))
                            {
                                //found question
                                if (q.Display.Equals("radio"))
                                    q.Results.Add(Result.Create(q.GetAnswerId(d.GetString(3)), d.GetInt32(1)));
                                else
                                    q.Results.Add(Result.Create(d.GetString(3), d.GetInt32(1)));
                                break;
                            }
                        }

                        dialog.LocalStatus.Value++;
                        dialog.GlobalStatus.Value++;

                        if (dialog.GlobalStatus.Value % 100 == 0)
                        {
                            if (dialog.GlobalStatus.Value > 0)
                            {
                                TimeSpan elapsed = DateTime.Now - Start;
                                long ticks = (long)(((double)elapsed.Ticks) / ((double)dialog.GlobalStatus.Value));
                                TimeSpan remaining = new TimeSpan(ticks) - elapsed;
                                dialog.TimeRemainingLabel.Text = remaining.Hours + "h " + remaining.Minutes + "m " + remaining.Seconds + "s ";
                                dialog.TimeElapsedLabel.Text = elapsed.Hours + "h " + elapsed.Minutes + "m " + elapsed.Seconds + "s ";
                            }
                            dialog.Refresh();
                        }
                    }
                    TargetCounter++;
                }
                global = null;
            }catch(Exception e){
                
            }

        }

        public void LoadResults()
        {
            //Thread loadThread = new Thread(new ThreadStart(DoLoadResults));
            //loadThread.Start();
            DoLoadResults();
        }

        private void DoLoadResults()
        {
            DialogUpdateResults dur = new DialogUpdateResults(this);
            dur.ShowDialog();
            //FinishResultUpdate();
        }

        public void LoadPersonData()
        {
            var sqlConnectionStringBuilder = new MySqlConnectionStringBuilder();
            sqlConnectionStringBuilder.Server = DatabaseHost;
            sqlConnectionStringBuilder.Database = DatabaseName;
            sqlConnectionStringBuilder.UserID = DatabaseUser;
            sqlConnectionStringBuilder.Password = DatabasePassword;

            MySqlConnection db = new MySqlConnection(sqlConnectionStringBuilder.ConnectionString);

            try
            {
                db.Open();

                MySqlCommand cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "personen", db);
                MySqlDataReader d = cmd.ExecuteReader();

                d.Read();

                Person[] old = Persons;
                Persons = new Person[d.GetInt32(0)];

                cmd = new MySqlCommand("select * from " + DatabasePrefix + "personen", db);
                d.Close();
                d = cmd.ExecuteReader();

                int i = 0;

                while (d.Read())
                {
                    Person o = null;
                    foreach (Person p in old)
                    {
                        if (p.ID == d.GetInt32(0))
                            o = p;
                    }
                    if (o != null)
                        Persons[i++] = o;
                    else
                    {
                        Person person = new Person(d.GetString(1), d.GetInt32(0));
                        Persons[i++] = person;
                    }
                }


                //zugangsdaten

                if (dar.datumAktiv && dar.percentAktiv)
                    cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "zugangsdaten where (used = '1' or status > " + dar.percentValue + ") and time_start >= " + sek + " and time_end <= " + sek2, db);
                else if (dar.datumAktiv)
                    cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "zugangsdaten where (used = '1' or status > 49) and time_start >= " + sek + " and time_end <= " + sek2, db);
                else if (dar.percentAktiv)
                    cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "zugangsdaten where (used = '1' or status > " + dar.percentValue + ")", db);
                else
                    cmd = new MySqlCommand("select count(*) from " + DatabasePrefix + "zugangsdaten where (used = '1' or status > 49)", db);
                d.Close();
                d = cmd.ExecuteReader();

                d.Read();

                Users = new User[d.GetInt32(0)];

                if (dar.datumAktiv && dar.percentAktiv)
                    cmd = new MySqlCommand("select * from " + DatabasePrefix + "zugangsdaten where (used = '1' or status > " + dar.percentValue + ") and time_start >= " + sek + " and time_end <= " + sek2, db);
                else if (dar.datumAktiv)
                    cmd = new MySqlCommand("select * from " + DatabasePrefix + "zugangsdaten where (used = '1' or status > 49) and time_start >= " + sek + " and time_end <= " + sek2, db);
                else if (dar.percentAktiv)
                    cmd = new MySqlCommand("select * from " + DatabasePrefix + "zugangsdaten where (used = '1' or status > " + dar.percentValue + ")", db);
                else
                    cmd = new MySqlCommand("select * from " + DatabasePrefix + "zugangsdaten where (used = '1' or status > 49)", db);
                d.Close();
                d = cmd.ExecuteReader();

                i = 0;

                while (d.Read())
                {
                    User user = new User(d.GetInt32(0), d.GetString(2), d.GetInt32(3));
                    Users[i++] = user;
                }

                db.Close();

                lastSettingsUpdate = DateTime.Now;

                //personDataChanged(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datenbank konnte nicht geöffnet werden!\n" + ex.Message + "\n" + ex.StackTrace, "Fehler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int GetPersonIdByUser(int UserID)
        {
            foreach (User u in Users)
                if (u.ID == UserID)
                    return u.PersonID;

            return -2;
        }

        public void Serialize()
        {
            try
            {
                /*
                Stream write = new FileStream(FileName, FileMode.Create);

                StreamWriter sr = new StreamWriter(write);
 
                //database
                sr.WriteLine(DatabaseHost);
                sr.WriteLine(DatabaseUser);
                sr.WriteLine(DatabasePassword);
                sr.WriteLine(DatabaseName);
                sr.WriteLine(DatabasePrefix);
                sr.WriteLine(FileName);
                //targets


                //users

                //persons


                sr.Close();
                */

                Stream write = new FileStream(FileName, FileMode.Create);

                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(write, this);

                write.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim speichern!\n" + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static Evaluation Deserialize(string FileName)
        {
            EvalDeserializer ed = new EvalDeserializer(FileName);
            Evaluation eval = ed.Deserialize();

            return eval;

        }

        private void report_OutputDataChanged()
        {
            outputDataChanged(this);
        }

        public override string ToString()
        {
            return this.DatabaseName + " (" + this.LastResultUpdate + ")";
        }

    }
}
