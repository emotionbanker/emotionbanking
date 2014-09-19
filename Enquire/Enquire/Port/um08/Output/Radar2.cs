using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using dotnetCHARTING.WinForms;
using umfrage2._2007;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{
    [Serializable]
    public class Radar2 : Output
    {
        public DNCSettings dnc;
        public ArrayList Questions;
        public ArrayList Questions2;
        public ArrayList Questions3;
        public ArrayList Questions4;
        public ArrayList Questions5;
        public Person person1;
        public Person person2;
        public Person person3;
        public Person person4;
        public Person person5;
        public PersonCombo personcombo1;
        public PersonCombo personcombo2;
        public PersonCombo personcombo3;
        public PersonCombo personcombo4;
        public PersonCombo personcombo5;
        public int ebeneCounter;

        public Radar2(Evaluation eval)
        {
            this.eval = eval;
            dnc = new DNCSettings();

            width = height = 500;

            Questions = new ArrayList();
            Questions2 = new ArrayList();
            Questions3 = new ArrayList();
            Questions4 = new ArrayList();
            Questions5 = new ArrayList();
            person1 = new Person();
            person2 = new Person();
            person3 = new Person();
            person4 = new Person();
            person5 = new Person();
            personcombo1 = new PersonCombo();
            personcombo2 = new PersonCombo();
            personcombo3= new PersonCombo();
            personcombo4= new PersonCombo();
            personcombo5= new PersonCombo();
            ebeneCounter = 0;
        }

        public override void LoadGlobalQ()
        {
            //LoadQArray(Questions);
        }

        public override void LoadTargetQ(TargetData td)
        {
            //LoadTQArray(td, Questions);
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			LoadSerData(info, ctxt);

            //Question.SetMultipartArray(Questions, Multipart);

            //MessageBox.Show("Writer");
            info.AddValue("dnc", this.dnc);
            info.AddValue("Questions", this.Questions);
            info.AddValue("Questions2", this.Questions2);
            info.AddValue("Questions3", this.Questions3);
            info.AddValue("Questions4", this.Questions4);
            info.AddValue("Questions5", this.Questions5);

            info.AddValue("ebeneCounter", this.ebeneCounter);

            info.AddValue("person1", this.person1);
            info.AddValue("person2", this.person2);
            info.AddValue("person3", this.person3);
            info.AddValue("person4", this.person4);
            info.AddValue("person5", this.person5);

            info.AddValue("personcombo1", this.personcombo1);
            info.AddValue("personcombo2", this.personcombo2);
            info.AddValue("personcombo3", this.personcombo3);
            info.AddValue("personcombo4", this.personcombo4);
            info.AddValue("personcombo5", this.personcombo5);
            
		}

		public Radar2(SerializationInfo info, StreamingContext ctxt)
		{
            
            ReadSerData(info, ctxt);
            //MessageBox.Show("Reader");
            this.Questions = (ArrayList)info.GetValue("Questions", typeof(ArrayList));
            this.Questions2 = (ArrayList)info.GetValue("Questions2", typeof(ArrayList));
            this.Questions3 = (ArrayList)info.GetValue("Questions3", typeof(ArrayList));
            this.Questions4 = (ArrayList)info.GetValue("Questions4", typeof(ArrayList));
            this.Questions5 = (ArrayList)info.GetValue("Questions5", typeof(ArrayList));

            this.person1 = (Person)info.GetValue("person1", typeof(Person));
            this.person2 = (Person)info.GetValue("person2", typeof(Person));
            this.person3 = (Person)info.GetValue("person3", typeof(Person));
            this.person4 = (Person)info.GetValue("person4", typeof(Person));
            this.person5 = (Person)info.GetValue("person5", typeof(Person));

            this.personcombo1 = (PersonCombo)info.GetValue("personcombo1", typeof(PersonCombo));
            this.personcombo2 = (PersonCombo)info.GetValue("personcombo2", typeof(PersonCombo));
            this.personcombo3 = (PersonCombo)info.GetValue("personcombo3", typeof(PersonCombo));
            this.personcombo4 = (PersonCombo)info.GetValue("personcombo4", typeof(PersonCombo));
            this.personcombo5 = (PersonCombo)info.GetValue("personcombo5", typeof(PersonCombo));
         
            try {  this.ebeneCounter = (Int32)info.GetValue("ebeneCounter", typeof(Int32)); }
            catch {  this.ebeneCounter = 0;}

            try { dnc = (DNCSettings)info.GetValue("dnc", typeof(DNCSettings)); }
            catch { dnc = new DNCSettings(); }
		}

        public SeriesCollection Compute(SeriesCollection sc, Hashtable qid, PersonSetting per, ArrayList Questions, int point){
                Series s = new Series();

                s.Name = per.ToString();

                s.DefaultElement.Color = per.Color1;
                s.DefaultElement.SecondaryColor = per.Color2;
                //qid = new Hashtable();
                
                foreach (Question q in Questions)
                {
                   
                        Element e = new Element();

                        e.YValue = 6 - (q.GetAverageByPerson(eval, per) + 1);

                        e.Marker.Type = ElementMarkerType.Circle;
                        e.Marker.Size = 5;

                        if (!qid.ContainsKey(q)) { qid[q] = point++; }
                        e.Name = ((int)qid[q]).ToString();
                        //e.ShowValue = true;

                        s.AddElements(e);
                    
                }

                sc.Add(s);
            
            return sc;
        }

        public override void Compute()
        {
            OutputImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            Chart bc = new Chart();

            dnc.Apply(bc);

            bc.Title = this.Name;

            bc.Type = ChartType.Radar;

            SeriesCollection sc = new SeriesCollection();

            Hashtable qid = new Hashtable();
            int marker = 1;
            
            if(ebeneCounter==1){
                if (person1 != null) sc = Compute(sc, qid, person1, Questions,  marker); else sc = Compute(sc, qid, personcombo1, Questions, marker);
                
            }
            else if (ebeneCounter == 2)
            {
                if (person1 != null) sc = Compute(sc, qid, person1, Questions,  marker); else sc = Compute(sc, qid, personcombo1, Questions, marker); 
                if (person2 != null) sc = Compute(sc, qid, person2, Questions2,  marker); else sc = Compute(sc, qid, personcombo2, Questions2, marker);
            }
            else if (ebeneCounter == 3)
            {
                if (person1 != null) sc = Compute(sc, qid, person1, Questions, marker); else sc = Compute(sc, qid, personcombo1, Questions, marker);
                if (person2 != null) sc = Compute(sc, qid, person2, Questions2, marker); else sc = Compute(sc, qid, personcombo2, Questions2, marker);
                if (person3 != null) sc = Compute(sc, qid, person3, Questions3, marker); else sc = Compute(sc, qid, personcombo3, Questions3, marker);    
            }
            else if (ebeneCounter == 4)
            {
                if (person1 != null) sc = Compute(sc, qid, person1, Questions, marker); else sc = Compute(sc, qid, personcombo1, Questions, marker);
                if (person2 != null) sc = Compute(sc, qid, person2, Questions2, marker); else sc = Compute(sc, qid, personcombo2, Questions2, marker);
                if (person3 != null) sc = Compute(sc, qid, person3, Questions3, marker); else sc = Compute(sc, qid, personcombo3, Questions3, marker);
                if (person4 != null) sc = Compute(sc, qid, person4, Questions4, marker); else sc = Compute(sc, qid, personcombo4, Questions4, marker);
            }
            else if (ebeneCounter == 5)
            {
                if (person1 != null) sc = Compute(sc, qid, person1, Questions, marker); else sc = Compute(sc, qid, personcombo1, Questions, marker);
                if (person2 != null) sc = Compute(sc, qid, person2, Questions2, marker); else sc = Compute(sc, qid, personcombo2, Questions2, marker);
                if (person3 != null) sc = Compute(sc, qid, person3, Questions3, marker); else sc = Compute(sc, qid, personcombo3, Questions3, marker);
                if (person4 != null) sc = Compute(sc, qid, person4, Questions4, marker); else sc = Compute(sc, qid, personcombo4, Questions4, marker);
                if (person5 != null) sc = Compute(sc, qid, person5, Questions5, marker); else sc = Compute(sc, qid, personcombo5, Questions5, marker);
            }

            bc.Width = width;
            bc.Height = height;

            bc.SeriesCollection.Add(sc);

            bc.Title = "";

            bc.XAxis.Label.Text = dnc.XLabel = "";
            bc.YAxis.Label.Text = dnc.YLabel = "";

            //bc.XAxis.ClearValues = bc.YAxis.ClearValues = true;

            bc.XAxis.ScaleRange.ValueLow = bc.YAxis.ScaleRange.ValueLow = 1;
            bc.XAxis.ScaleRange.ValueHigh = bc.YAxis.ScaleRange.ValueHigh = 5;
            bc.XAxis.Interval = bc.YAxis.Interval = 1d;

            //bc.XAxis.ClearValues = true;
            bc.YAxis.ClearValues = true;

            for (int i = 1; i <= 5; i ++)
            {
                AxisTick at = new AxisTick(i, (6-i).ToString());
                bc.XAxis.ExtraTicks.Add(at);
                bc.YAxis.ExtraTicks.Add(at);
            }
            //bc.XAxis.InvertScale = bc.YAxis.InvertScale = true;
            

            bc.RadarLabelMode = RadarLabelMode.None;//.Outside;
            //bc.YAxis.Maximum = bc.XAxis.Maximum = 5;

            bc.Application = "itcIidhdhyk+bW1OOBTArpfNOr3GopKuOit20bU6/G4MlNN6vnk4wkfGB+NlXC+EWdY1Rm4vJ0qKOQOmw7d7gw==";

            bc.DrawToBitmap(OutputImage, new Rectangle(0, 0, OutputImage.Width, OutputImage.Height));

            bc.Dispose();
        }

        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_Radar2(eval, false, this);
        }

        public override void EditDialog()
        {
            throw new Exception("Falsche Version (<2007)");
        }

        public override void Save(string name, string path)
        {
            //MessageBox.Show("Save");

            int count = Questions.Count + Questions2.Count + Questions3.Count + Questions4.Count + Questions5.Count;


            Question[] baseq = new Question[Questions.Count];
            Question[] baseq2 = new Question[Questions2.Count];
            Question[] baseq3 = new Question[Questions3.Count];
            Question[] baseq4 = new Question[Questions4.Count];
            Question[] baseq5 = new Question[Questions5.Count];

            if (person1 != null || personcombo1 != null) { 
                for (int i = 0; i < baseq.Length; i++)  
                    baseq[i] = (Question)Questions[i]; 
            }

            if (person2 != null || personcombo2 != null)
            { 
                for (int i = 0; i < baseq2.Length; i++) 
                    baseq2[i] = (Question)Questions2[i]; 
            }

            if (person3 != null || personcombo3 != null)
            { 
                for (int i = 0; i < baseq3.Length; i++) 
                    baseq3[i] = (Question)Questions3[i]; 
            }

            if (person4 != null || personcombo4 != null)
            { 
                for (int i = 0; i < baseq4.Length; i++) 
                    baseq4[i] = (Question)Questions4[i]; 
            }

            if (person5 != null || personcombo5 != null)
            { 
                for (int i = 0; i < baseq5.Length; i++) 
                baseq5[i] = (Question)Questions5[i]; 
            }


            Evaluation seval = this.eval;


            foreach (TargetData td in seval.CombinedTargets)
            {
                if (!td.Included)
                    continue;

                int i = 0;
                if (person1 != null || personcombo1 != null)
                {
                    foreach (Question q in baseq) 
                        Questions[i++] = td.GetQuestion(q, Eval);
                }
                i = 0;
                if (person2 != null || personcombo2 != null) 
                    foreach (Question q in baseq2) Questions2[i++] = td.GetQuestion(q, Eval);
                i = 0;
                if (person3 != null || personcombo3 != null) 
                    foreach (Question q in baseq3) Questions3[i++] = td.GetQuestion(q, Eval);
                i = 0;
                if (person4 != null || personcombo4 != null) 
                    foreach (Question q in baseq4) Questions4[i++] = td.GetQuestion(q, Eval);
                i = 0;
                if (person5 != null || personcombo5 != null) 
                    foreach (Question q in baseq5) Questions5[i++] = td.GetQuestion(q, Eval);


                Compute();

                FileStream myFileOut = new FileStream(path + "\\" + SystemTools.Savable(name + " (" + td.Name + ").png"), FileMode.Create);
                OutputImage.Save(myFileOut, ImageFormat.Png);
                myFileOut.Close();
            }

            seval = null;
            OutputImage = null;
        }

        public void Save2(string name, string path)
        {

            int count = Questions.Count + Questions2.Count + Questions3.Count + Questions4.Count + Questions5.Count;
            int count2 = Questions.Count;
            Question[] baseq = new Question[count2];

            for (int i = 0; i < baseq.Length; i++)
            {
                baseq[i] = (Question)Questions[i];
            }

            //cross?
            Evaluation seval;
            /*if (CrossTargets(Questions))
            {
                seval = this.CrEval;
            }
            else if (this.OvEval != null)
            {
                seval = OvEval;
            }
            else
            {*/
            seval = this.eval;
            //}
            //Targets

            foreach (TargetData td in seval.CombinedTargets)
            {
                if (!td.Included)
                    continue;

                int i = 0;
                foreach (Question q in baseq)
                    Questions[i++] = td.GetQuestion(q, Eval);

                Compute();

                FileStream myFileOut = new FileStream(path + "\\" + SystemTools.Savable(name + " (" + td.Name + ").png"), FileMode.Create);
                OutputImage.Save(myFileOut, ImageFormat.Png);
                myFileOut.Close();
            }

            seval = null;
            OutputImage = null;
        }
    }


}
