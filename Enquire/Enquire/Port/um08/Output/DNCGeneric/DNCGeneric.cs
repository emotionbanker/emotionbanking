using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.Serialization;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using dotnetCHARTING.WinForms;
using umfrage2._2007;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output.DNCGeneric
{
    [Serializable]
    public class DNCGeneric : Output
    {
        public enum SeriesType { UserGroup, Split }

        [NonSerialized]
        private Evaluation eval;

        public DNCSettings dnc;
        public SeriesType SType;
        public Question SeriesSplit;

        public ChartType DNCType;

        public ArrayList Elements;

        public DNCGeneric(Evaluation eval)
        {
            this.eval = eval;

            dnc = new DNCSettings();
            SType = SeriesType.UserGroup;
            SeriesSplit = null;

            Elements = new ArrayList();
        }

        public override void LoadGlobalQ()
        {
            // ADD: loadReport logic

            // LoadQArray(Questions);
        }

        public override void LoadTargetQ(TargetData td)
        {
            // ADD: loadReport logic

            // LoadTQArray(td, Questions);
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			LoadSerData(info, ctxt);

            // ADD: Serialization logic

            info.AddValue("dnc", dnc);
            info.AddValue("SType", SType);
            info.AddValue("SeriesSplit", SeriesSplit);

            info.AddValue("DNCType", DNCType);

            info.AddValue("Elements", Elements);
		}

		public DNCGeneric(SerializationInfo info, StreamingContext ctxt)
		{
			ReadSerData(info, ctxt);

			// ADD: Deserialization logic

            try // v0
            {
                dnc = (DNCSettings)info.GetValue("dnc", typeof(DNCSettings));
                SType = (SeriesType)info.GetValue("SType", typeof(SeriesType));
                SeriesSplit = (Question)info.GetValue("SeriesSplit", typeof(Question));
                DNCType = (ChartType)info.GetValue("DNCType", typeof(ChartType));
                Elements = (ArrayList)info.GetValue("Elements", typeof(ArrayList));
            }
            catch
            {
                dnc = new DNCSettings();
                SType = SeriesType.UserGroup;
                SeriesSplit = null;
                DNCType = ChartType.Pie;
                Elements = new ArrayList();
            }
		}

        public override void Compute()
        {
            // ADD: computation logic
            OutputImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            Chart bc = new Chart();

            dnc.Apply(bc);

            bc.Title = this.Name;
            bc.TitleBox.Visible = false;

            /*
             */

            bc.Type = DNCType;

            //bc.DefaultSeries.

            //dotnetCHARTING.WinForms.cha


            SeriesCollection sc = new SeriesCollection();

            Console.WriteLine("TYPE: " + SType);

            if (SType == SeriesType.UserGroup)
            {
                foreach (PersonSetting ps in CombinedPersons)
                {
                    Console.WriteLine("series:\t" + ps);

                    Series s = new Series();
                    
                    s.Name = ps.ToString();
                    s.DefaultElement.Color = ps.Color1;
                    s.DefaultElement.ShowValue = true;
                    foreach (DNCElement el in Elements)
                    {
                        Element e = new Element();

                        switch (el.Type)
                        {
                            case DNCElement.DNCElementType.Mittelwert:
                                e.YValue = el.q.GetAverageByPerson(eval, ps);
                                break;
                        }

                        Console.WriteLine("\telement:\t" + el.Type);

                        s.Elements.Add(e);
                    }

                    sc.Add(s);
                }
            }

            /*
             */

            bc.SeriesCollection.Add(sc);

            bc.Application = "itcIidhdhyk+bW1OOBTArpfNOr3GopKuOit20bU6/G4MlNN6vnk4wkfGB+NlXC+EWdY1Rm4vJ0qKOQOmw7d7gw==";


            bc.DrawToBitmap(OutputImage, new Rectangle(0, 0, OutputImage.Width, OutputImage.Height));

            bc.Dispose();
        }



        // FIXME: anpassen an dncg


        public override void EditDialog()
        {
            //no dialogue
        }

        public override Control EditControl()
        {
            //return new umfrage2._2007.Controls.OutputControl_Bar(eval, false, this);
            return new Control();
        }


        public override void Save(string name, string path)
        {
            /*
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
                OutputImage.Save(myFileOut, System.Drawing.Imaging.ImageFormat.Png);
                myFileOut.Close();
            }

            seval = null;
            OutputImage = null;
            */
        }

    }
}
