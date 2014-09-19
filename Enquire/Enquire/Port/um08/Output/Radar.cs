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
    public class Radar : Output
    {
        public DNCSettings dnc;
        public Question[] Questions;

        public Radar(Evaluation eval)
        {
            this.eval = eval;
            dnc = new DNCSettings();

            width = height = 500;

            Questions = new Question[0];
        }

        public override void LoadGlobalQ()
        {
            LoadQArray(Questions);
        }

        public override void LoadTargetQ(TargetData td)
        {
            LoadTQArray(td, Questions);
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			LoadSerData(info, ctxt);

            Question.SetMultipartArray(Questions, Multipart);

            info.AddValue("dnc", this.dnc);
            info.AddValue("Questions", this.Questions);
		}

		public Radar(SerializationInfo info, StreamingContext ctxt)
		{
            ReadSerData(info, ctxt);

            this.Questions = (Question[])info.GetValue("Questions", typeof(Question[]));

            try { dnc = (DNCSettings)info.GetValue("dnc", typeof(DNCSettings)); }
            catch { dnc = new DNCSettings(); }
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

            if (Questions.Length > 1)
            {
                foreach (PersonSetting ps in CombinedPersons)
                {
                    Series s = new Series();
                    s.Name = ps.ToString();
                    s.DefaultElement.Color = ps.Color1;
                    s.DefaultElement.SecondaryColor = ps.Color2;

                    foreach (Question q in Questions)
                    {
                        Element e = new Element();

                        e.YValue = 6 - (q.GetAverageByPerson(eval, ps) + 1);

                        e.Marker.Type = ElementMarkerType.Circle;
                        e.Marker.Size = 5;

                        if (!qid.ContainsKey(q)) { qid[q] = marker++; }
                        e.Name = ((int)qid[q]).ToString();
                        //e.ShowValue = true;

                        s.AddElements(e);
                    }

                    sc.Add(s);
                }
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

            /*
            ArrayList list = new ArrayList();
            foreach (Question q in qid.Keys)
            {
                list.Add(new string[]{qid[q].ToString(), q.Text});
            }

            Bitmap lim = GraphicTools.ImageTable(list, new int[]{50, OutputImage.Width-50}, new string[]{"Frage", "Text"}, new Color[]{Color.LightGray, Color.Gray});

            Bitmap nim = new Bitmap(OutputImage.Width, OutputImage.Height + lim.Height);

            Graphics mg = Graphics.FromImage(nim);
            mg.DrawImage(OutputImage, new Point(0, 0));
            mg.DrawImage(lim, new Point(0, OutputImage.Height));

            OutputImage = nim;
             */

            bc.Dispose();
        }

        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_Radar(eval, false, this);
        }

        public override void EditDialog()
        {
            throw new Exception("Falsche Verision (<2007)");
        }

        public override void Save(string name, string path)
        {
            //
            Question[] baseq = Questions;


            //cross?
            Evaluation seval;
            if (CrossTargets(Questions))
            {
                seval = this.CrEval;
            }
            else if (this.OvEval != null)
            {
                seval = OvEval;
            }
            else
            {
                seval = this.eval;
            }
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
