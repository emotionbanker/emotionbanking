using System;
using System.Collections;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace compucare.Enquire.Legacy.Umfrage2Lib.System
{
    /// <summary>
    /// Holds Question Results
    /// </summary>
    /// 


    public delegate void IncludedChangedEventHandler(TargetData sender);


    [Serializable]
    public class TargetData : ISerializable
    {
        /// <summary>
        /// Target ID as in Database
        /// </summary>
        public string iD;
        /// <summary>
        /// Target Name as in Database
        /// </summary>
        public string name;
        /// <summary>
        /// Target Class as in Database
        /// </summary>
        public string Class;
        public bool Test = false;
        public bool WasCombo = false;
        public TargetCombo OriginalCombo = null;

        [DllImport("kernel32.dll")]
        static extern bool AttachConsole(int dwProcessId);
        private const int ATTACH_PARENT_PROCESS = -1;

        [NonSerialized]
        private bool included = true;

        public TargetSplit masterSplit;

        public TargetData Clone
        {
            get { return (TargetData)this.MemberwiseClone(); }
        }

        public bool Included
        {
            get { return included; }
            set
            {
                bool ev = false;
                if (included != value)
                {
                    ev = true;
                    included = value;
                }
                if (ev) includedChanged(this);
            }
        }

        [NonSerialized]
        private IncludedChangedEventHandler includedChanged;
        public event IncludedChangedEventHandler IncludedChanged
        {
            add { includedChanged += value; }
            remove { includedChanged -= value; }
        }

        [NonSerialized]
        private string NameOverload;

        public Survey[] Surveys;

        public string Name
        {
            get
            {
                if (NameOverload != null)
                    return NameOverload;
                else
                    return name;
            }
            set
            {
                name = value;
            }
        }

        public string CleanName
        {
            get
            {
                return Name;
                //return Name.Replace("ь","ue").Replace("ö","oe").Replace("ä","ae").Replace("Ь","Ue").Replace("Ö","Oe").Replace("Ä","Ae").Replace("/","_").Replace("\\","_");
            }
        }

        public string ID
        {
            get
            {
                return iD.ToLower();
            }
            set
            {
                iD = value;
            }
        }

        public int ResultCount
        {
            get
            {
                int c = 0;
                foreach (Question q in Questions)
                    c += q.Results.Count;

                return c;
            }
        }

        public static Question[] selectedQuestions;

        public Question[] Questions;

        public ArrayList Splits;

        public Hashtable QuestionAndTargetList;

        public ArrayList Children; //create via Splits

        public TargetData(string TargetID, string TargetName, string TargetClass)
        {
            ID = TargetID;
            Name = TargetName;
            Class = TargetClass;

            Surveys = new Survey[0];

            Questions = new Question[0];
            selectedQuestions = new Question[0];

            this.IncludedChanged += new IncludedChangedEventHandler(TargetData_IncludedChanged);

            Splits = new ArrayList();
            QuestionAndTargetList = new Hashtable();

            masterSplit = null;

            //Included = true;
        }

        public TargetData()
        {
            ID = Name = Class = string.Empty;

            Surveys = new Survey[0];

            Questions = new Question[0];
            selectedQuestions = new Question[0];

            Splits = new ArrayList();
            QuestionAndTargetList = new Hashtable();

            this.IncludedChanged += new IncludedChangedEventHandler(TargetData_IncludedChanged);

            masterSplit = null;

            //Included = true;
        }

        /// <summary>
        /// serialization functions
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("ID", iD);
            info.AddValue("name", name);
            info.AddValue("Class", Class);
            info.AddValue("Surveys", Surveys);
            //info.AddValue("Questions",Questions);

            info.AddValue("Test", Test);
            info.AddValue("Splits", Splits);

            info.AddValue("masterSplit", masterSplit);
            info.AddValue("WasCombo", WasCombo);
            info.AddValue("OriginalCombo", OriginalCombo);

            info.AddValue("QuestionAndTargetList", QuestionAndTargetList);
        }


        public TargetData(SerializationInfo info, StreamingContext ctxt)
        {
            iD = info.GetString("ID");
            name = info.GetString("name");
            Class = info.GetString("Class");

            Surveys = (Survey[])info.GetValue("Surveys", typeof(Survey[]));

            try
            {
                Questions = (Question[])info.GetValue("Questions", typeof(Question[]));
            }
            catch
            {
                Questions = null;
            }

            try
            {
                Test = info.GetBoolean("Test");
            }
            catch
            {
                Test = false;
            }

            try { this.Splits = (ArrayList)info.GetValue("Splits", typeof(ArrayList)); }
            catch { this.Splits = new ArrayList(); }

            try { this.QuestionAndTargetList = (Hashtable)info.GetValue("QuestionAndTargetList", typeof(Hashtable)); }
            catch { this.QuestionAndTargetList = new Hashtable(); }

            try { this.masterSplit = (TargetSplit)info.GetValue("masterSplit", typeof(TargetSplit)); }
            catch { this.masterSplit = null; }

            try { this.WasCombo = info.GetBoolean("WasCombo"); }
            catch { this.WasCombo = false; }

            try { this.OriginalCombo = (TargetCombo)info.GetValue("OriginalCombo", typeof(TargetCombo)); }
            catch { this.OriginalCombo = null; }
        }


        public Question GetQuestionById(int id)
        {
            foreach (Question q in Questions)
                if (q.ID == id) return q;

            return null;
        }

        public void setSelectedQuestions(Question[] q)
        {
            selectedQuestions = q;
        }

        public Question[] getSelectedQuestions()
        {
            return selectedQuestions;
        }

        public void ComputeSplits(Evaluation eval)
        {
            Children = new ArrayList();
            foreach (TargetSplit s in Splits)
            {
                try
                {
                    Children.AddRange(s.ComputeSplitTarget(eval));
                }
                catch
                {

                }
            }
        }

        public string GetLastHeader(Question q, PersonSetting person)
        {
            //Console.WriteLine("getting header for " + q.ID );//+ " (" + person + ")");

            string header = string.Empty;

            Survey s;
            if (person.GetType() == typeof(Person))
                s = GetSurvey((Person)person);
            else
                s = GetSurvey((PersonCombo)person);

            if (s == null)
                return "";

            //string comm = "";

            foreach (string command in s.QuestionList)
            {
                if (command.Length > 0 && command.Substring(0, 1).Equals("#")) //found a header!
                {
                    //Console.WriteLine(command);

                    header = command.Substring(1);

                    continue;
                }


                int quid = -1;
                try { quid = Int32.Parse(command); }
                catch { }

                if (quid != -1 && quid == q.ID)
                    break;
            }

            //Console.WriteLine(": '" + header + "' (" + comm + ")");

            return header;
        }

        public Survey GetSurvey(int PID)
        {
            foreach (Survey s in Surveys)
                if (s.PID == PID)
                    return s;

            return null;
        }

        public Survey GetSurvey(Person p)
        {
            return GetSurvey(p.ID);
        }

        public Survey GetSurvey(PersonCombo p)
        {
            if (p.Persons.Length > 0)
                return GetSurvey(p.Persons[0].ID);
            else return null;
        }

        public void AddSurvey(Survey s)
        {
            Survey[] ns = new Survey[Surveys.Length + 1];

            int i = 0;
            foreach (Survey os in Surveys)
                ns[i++] = os;

            ns[i] = s;

            Surveys = ns;
        }

        public QuestionCombo GetCombo(int QuestionID, Evaluation eval)
        {
            if (QuestionID <= -100 && QuestionID > -5000)
            {
                int cid = (QuestionID + 100) * -1;
                foreach (QuestionCombo combo in eval.QuestionCombos)
                    if (cid == combo.ID)
                        return combo;
            }
            return null;
        }

        public Question GetQuestionbyId(int QuestionID, Evaluation eval)
        {
            //MessageBox.Show(QuestionID.ToString());
            try
            {
                Question ret = null;
                if (QuestionID <= -100 && QuestionID > -5000)
                {
                    int cid = (QuestionID + 100) * -1;
                    foreach (QuestionCombo combo in eval.QuestionCombos)
                    {
                        if (cid == combo.ID)
                        {
                            ret = combo.GetQuestion(this);
                            break;
                        }
                    }
                }
                else if (QuestionID <= -5000 && QuestionID > -100000)
                {
                    //alternate
                    int cid = (QuestionID + 5000) * -1;
                    foreach (QuestionAlternate al in eval.QuestionAlternates)
                    {
                        if (cid == al.Master)
                        {
                            ret = al.GetQuestion(this);
                            break;
                        }
                    }
                }
                else if (QuestionID <= -100000)
                {
                    //alternate
                    int cid = (QuestionID + 100000) * -1;

                    foreach (QuestionPlaceholder al in eval.QuestionPlaceholders)
                    {
                        if (cid == al.PID)
                        {
                            ret = al.GetQuestion(this, eval);
                            break;
                        }
                    }

                }

                else if (QuestionID > 10000)
                {
                    foreach (Question al in eval.QuestionConvert)
                    {
                        if (QuestionID == al.ID)
                        {
                            ret = al;
                            break;
                        }
                    }
                }
                else
                {
                    //MessageBox.Show(Questions.Length.ToString());
                    foreach (Question q in eval.Global.Questions)
                    {
                        if (q.ID == QuestionID)
                        {
                            //MessageBox.Show("Gefunden");
                            return q;
                        }
                    }
                }
                return ret;
            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                return null;
            }
        }


        public Question GetQuestion(int QuestionID, Evaluation eval)
        {
            AttachConsole(ATTACH_PARENT_PROCESS);
            Console.WriteLine("QuestionID: " + QuestionID);
            Question ret = null;
            //try
            //{
            if (QuestionID <= -100 && QuestionID > -5000)
            {
                int cid = (QuestionID + 100) * -1;
                //if(cid == 461)
                //MessageBox.Show("QuestionID: " + QuestionID+"\ncid: "+cid);
                foreach (QuestionCombo combo in eval.QuestionCombos)
                {
                    if (cid == combo.ID)
                    {
                        ret = combo.GetQuestion(this);
                        break;
                    }
                }//end foreach
            }
            else if (QuestionID <= -5000 && QuestionID > -100000)
            {
                //alternate
                int cid = (QuestionID + 5000) * -1;
                foreach (QuestionAlternate al in eval.QuestionAlternates)
                {
                    if (cid == al.Master)
                    {
                        ret = al.GetQuestion(this);
                        break;
                    }
                }
            }
            else if (QuestionID <= -100000)
            {
                //alternate
                int cid = (QuestionID + 100000) * -1;

                foreach (QuestionPlaceholder al in eval.QuestionPlaceholders)
                {
                    if (cid == al.PID)
                    {
                        ret = al.GetQuestion(this, eval);
                        break;
                    }
                }

            }
            else if (QuestionID > 10000)
            {
                foreach (Question al in eval.QuestionConvert)
                {
                    if (QuestionID == al.ID)
                    {
                        ret = al;
                        break;
                    }
                }
            }
            else
            {
                foreach (Question q in Questions)
                {
                    if (q == null)
                        continue;

                    if (q.ID == QuestionID)
                    {
                        ret = q;
                        break;
                    }
                }
            }

            //fill alternates

            if (ret == null) return null;

            ret.ClearAlternates();
            foreach (int aid in ret.Alternates)
            {
                if (ret.ID == aid) continue;
                ret.LoadAlternate(GetQuestion(aid, eval));
            }

            return ret;
            //}catch(Exception e){
            //   // MessageBox.Show(e.Message);
            //    return ret;
            //}
        }

        public Question GetQuestion(Question Template, Evaluation eval)
        {
            try
            {
                if (Template == null) return null;

                return GetQuestion(Template.ID, eval);
            }
            catch (Exception e)
            {
                e.StackTrace.ToString();
                return null;
            }
        }

        public void Debug(Evaluation eval)
        {
            /*
            Console.WriteLine("[td]\t" + Name + "\n\t/children=" + Children.Count + "\n\t/wascombo=" + WasCombo + "\n\t/parent=" + this.masterSplit);
            Console.WriteLine("\t147 results= " + this.GetQuestion(147, eval).Results.Count);
            Console.WriteLine("\t147=" + this.GetQuestion(147, eval).GetAverageByPersonAsMark(eval, eval.CombinedPersons[2],8));
             * */
        }

        public override string ToString()
        {
            if (!Test)
                return Name;
            else
                return "(" + Name + ")";
        }

        public void AddQuestion(Question q)
        {
            Questions[Questions.Length - 1] = q;
        }

        public void Quicksort(int lo, int hi)
        {
            if (Questions.Length == 0)
                return;

            int i = lo, j = hi;
            int x = Questions[(lo + hi) / 2].ID;
            Question h;

            do
            {
                while (Questions[i].ID < x) i++;
                while (Questions[j].ID > x) j--;
                if (i <= j)
                {
                    h = Questions[i];
                    Questions[i] = Questions[j];
                    Questions[j] = h;
                    i++;
                    j--;
                }
            } while (i <= j);

            if (lo < j) Quicksort(lo, j);
            if (i < hi) Quicksort(i, hi);
        }

        public void OverloadName(string newName)
        {
            NameOverload = newName;
        }

        private void TargetData_IncludedChanged(TargetData sender)
        {
            //do nothing
        }
    }
}
