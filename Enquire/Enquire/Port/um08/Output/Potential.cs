using System;
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
    public class Potential : Output
    {
        public DNCSettings dnc;
        public Question Quest;
        public Question Master;
        public SortOrder sort;

        public bool Inverted = false;
        public bool Percent = false;
        
        public bool EnableMin = false;
        public int Min = 0;

        public bool EnableRef = false;
        public int RefID = -1;


        public Potential(Evaluation eval)
        {
            this.eval = eval;
            dnc = new DNCSettings();

            width = height = 500;

            Quest = null;
            Master = null;

            sort = SortOrder.Descending;
        }

        public override void LoadGlobalQ()
        {
            LoadQ(Quest);
            LoadQ(Master);
        }

        public override void LoadTargetQ(TargetData td)
        {
            LoadTQ(td, Quest);
            LoadTQ(td, Master);
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			LoadSerData(info, ctxt);

            Question.SetMultipart(Quest, Multipart);
            Question.SetMultipart(Master, Multipart);

            info.AddValue("dnc", this.dnc);
            info.AddValue("Quest", this.Quest);
            info.AddValue("Master", this.Master);
            info.AddValue("sort", this.sort);

            info.AddValue("Inverted", this.Inverted);

            info.AddValue("Percent", this.Percent);

            info.AddValue("EnableMin", this.EnableMin);
            info.AddValue("Min", this.Min);

            info.AddValue("EnableRef", this.EnableRef);
            info.AddValue("RefID", this.RefID);
		}

        public Potential(SerializationInfo info, StreamingContext ctxt)
		{
            ReadSerData(info, ctxt);

            this.Quest = (Question)info.GetValue("Quest", typeof(Question));

            try { dnc = (DNCSettings)info.GetValue("dnc", typeof(DNCSettings)); }
            catch { dnc = new DNCSettings(); }

            try { Master = (Question)info.GetValue("Master", typeof(Question)); }
            catch { Master = null; }

            try { this.sort = (SortOrder)info.GetValue("sort", typeof(SortOrder)); }
            catch { sort = SortOrder.None; }

            try { this.Inverted = info.GetBoolean("Inverted"); }
            catch { Inverted = false; }


            try { this.Percent = info.GetBoolean("Percent"); }
            catch { Percent = false; }

            try { this.EnableMin = info.GetBoolean("EnableMin"); this.Min = info.GetInt32("Min"); }
            catch { EnableMin = false; Min = 0; }

            try { this.EnableRef = info.GetBoolean("EnableRef"); this.RefID = info.GetInt32("RefID"); }
            catch { EnableRef = false; RefID = 0; }
		}

        private void Debug(object d)
        {
            Console.WriteLine("[POTENTIAL]\t" + d);
        }

        public override void Compute()
        {
            if (width < 1 || height < 1)
            {
                width = height = 500;
            }

            OutputImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            if (CombinedPersons.Length < 1) return;

            if (Quest == null || Master == null) return;

            Chart bc = new Chart();

            dnc.Apply(bc);

            bc.Title = this.Name;

            bc.Type = ChartType.ComboHorizontal;

            SeriesCollection sc = new SeriesCollection();

            //Debug("total avg=" + Quest.GetAverageByPersons(eval, CombinedPersons));

            QuestionSplit qs = new QuestionSplit(Quest, Master);

            Question[] qlist = qs.ComputeQuestionSplits(eval);

            float totavg;

            if (EnableRef && RefID != -1)
            {
                totavg = qlist[RefID].GetAverageByPersons(eval, CombinedPersons);
            }
            else
            {
                totavg = Quest.GetAverageByPersons(eval, CombinedPersons);
            }


            
            
            
            double hi, lo;

            if (Percent)
            {
                hi = -100;
                lo = 100;
            }
            else
            {
                hi = -5;
                lo = 5;
            }

            foreach (PersonSetting ps in CombinedPersons)
            {
                Series s = new Series();
                s.Name = ps.ToString();
                s.DefaultElement.Color = ps.Color1;
                s.DefaultElement.SecondaryColor = ps.Color2;

                foreach (Question q in qlist)
                {
                    if (q.NAnswersByPerson(eval, ps) < Min) continue;

                    if (q.GetAverageByPerson(eval, ps) == -1) continue;

                    Element e = new Element();
                    e.Name = q.Text;

                    if (!Percent)
                        e.YValue = q.GetAverageByPerson(eval, ps) - totavg;
                    else
                    {
                        float tot = totavg;
                        float myavg = q.GetAverageByPerson(eval, ps);

                        e.YValue = ((myavg - tot) / tot) * 100;
                    }

                    if (e.YValue < lo) lo = e.YValue;
                    if (e.YValue > hi) hi = e.YValue;

                    int round = 1;
                    if (Percent) round = 0;

                    if (!Inverted)
                        e.SmartLabel.Text = Math.Round(e.YValue, round).ToString();
                    else
                        e.SmartLabel.Text = (Math.Round(e.YValue, round) * -1).ToString();

                    if (e.YValue > 0)
                    {
                        if (!Inverted)
                        {
                            e.SmartLabel.Alignment = LabelAlignment.Top;
                            e.SmartLabel.Text = "+" + e.SmartLabel.Text;
                        }
                        else e.SmartLabel.Alignment = LabelAlignment.Bottom;
                    }
                    else 
                    {
                        if (Inverted)
                        {
                            e.SmartLabel.Alignment = LabelAlignment.Top;
                            e.SmartLabel.Text = "+" + e.SmartLabel.Text;
                        }
                        else e.SmartLabel.Alignment = LabelAlignment.Bottom;
                    }
                    e.ShowValue = true;

                    s.Elements.Add(e);
                }

                if (sort == SortOrder.Ascending) s.Sort(ElementValue.YValue, "Asc");
                else if (sort == SortOrder.Descending) s.Sort(ElementValue.YValue, "Desc");

                sc.Add(s);
            }

            bc.SeriesCollection.Add(sc);

            if (!Percent)
            {
                //bc.XAxis.ScaleRange = new ScaleRange(totavg - 1.8, totavg);
                bc.XAxis.Interval = 0.5d;
            }
            else
            {
                //bc.XAxis.ScaleRange = new ScaleRange( totavg - 110, totavg + 100);
                bc.XAxis.Interval = 10d;
            }
            

            Console.WriteLine("totalavg = " + totavg);
            //overrides
            
            /*
            for (double i = 5; i >= -5; i--)
            {
                bc.XAxis.AddLabelOverride(i.ToString(), Math.Round(totavg+i+1,1).ToString());
                Console.WriteLine("ovveride '" + i.ToString() + "' with '" + Math.Round(totavg + i + 1, 1) + "'");
            }
            */
            //bc.XAxis.l

            bc.XAxis.InvertScale = Inverted;

            bc.Width = width;
            bc.Height = height;

            bc.Title = "";
            
            bc.LegendBox.DefaultEntry.Value = "";

            bc.XAxis.Label.Text = dnc.XLabel;
            bc.YAxis.Label.Text = dnc.YLabel;

            bc.Application = "itcIidhdhyk+bW1OOBTArpfNOr3GopKuOit20bU6/G4MlNN6vnk4wkfGB+NlXC+EWdY1Rm4vJ0qKOQOmw7d7gw==";

            bc.DrawToBitmap(OutputImage, new Rectangle(0, 0, OutputImage.Width, OutputImage.Height));

            bc.Dispose();
        }

        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_Potential(eval, false, this);
        }

        public override void EditDialog()
        {
            throw new Exception("Falsche Verision (<2007)");
        }

        public override void Save(string name, string path)
        {
            //
            Question baseq = Quest;


            //cross?
            Evaluation seval;
            if (CrossTargets(Quest))
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

                Quest = td.GetQuestion(Quest, Eval);
                Master = td.GetQuestion(Master, Eval);

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
