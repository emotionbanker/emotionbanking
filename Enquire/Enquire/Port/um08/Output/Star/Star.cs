using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output.Star
{
	[Serializable]
	public class Star : Output
	{
        public enum StarType {One, Two};
		
        public Bitmap StarImage;
        			
		public StarType SType;

        public ArrayList Elements;


		public Star(Evaluation eval)
		{
            this.eval = eval;

            this.height = this.width = 500; 

            Elements = new ArrayList();
		}

        public override void LoadGlobalQ()
        {
            foreach (StarElement el in Elements)
                LoadQ(el.q);
        }

        public override void LoadTargetQ(TargetData td)
        {
           foreach (StarElement el in Elements)
             LoadTQ(td, el.q);
        }

		/// <summary>
		/// serialization functions
		/// </summary>
		/// <param name="info"></param>
		/// <param name="ctxt"></param>
		    public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		    {
			    LoadSerData(info, ctxt);

                info.AddValue("SType", SType);
                info.AddValue("Elements", Elements);
		    }

		    public Star(SerializationInfo info, StreamingContext ctxt)
		    {
			    base.ReadSerData(info, ctxt);

                try // v0
                {
                    SType = (StarType)info.GetValue("SType", typeof(StarType));
                    Elements = (ArrayList)info.GetValue("Elements", typeof(ArrayList));
                }
                catch
                {
                    SType = StarType.One;
                    Elements = new ArrayList();
                }
		    }

	
	
        public override void Compute()
        {
            //compute

            float rad = 15;

            rad = 2000f * (15f / 1250f);

            Bitmap img = null;

            //System.Windows.Forms.MessageBox.Show(SystemTools.GetAppPath(), "Suche nach Vorlagen in:");

            //if (SType == StarType.One) img = new Bitmap(SystemTools.GetAppPath() + "starOne.png");
            //else if (SType == StarType.Two) img = new Bitmap(SystemTools.GetAppPath() + "starTwo.png");

            if (SType == StarType.One) img = new Bitmap(SystemTools.GetAppPath() + "Stern_1.png");
            else if (SType == StarType.Two) img = new Bitmap(SystemTools.GetAppPath() + "Stern_2.png");

            Graphics g = Graphics.FromImage(img);

            g.SmoothingMode = SmoothingMode.HighQuality;
            
            float[,] zero = new float[17,2];
            float[,] top = new float[17, 2];
            
            if (SType == StarType.One)
            {
                zero[1, 0] = 970; zero[1, 1] = 831;
                zero[2, 0] = 1044; zero[2, 1] = 831;

                zero[3, 0] = 1098; zero[3, 1] = 858;
                zero[4, 0] = 1153; zero[4, 1] = 909;

                zero[5, 0] = 1172; zero[5, 1] = 960;
                zero[6, 0] = 1172; zero[6, 1] = 1035;

                zero[7, 0] = 1151; zero[7, 1] = 1090;
                zero[8, 0] = 1096; zero[8, 1] = 1143;

                zero[9, 0] = 1046; zero[9, 1] = 1160;
                zero[10, 0] = 968; zero[10, 1] = 1160;

                zero[11, 0] = 919; zero[11, 1] = 1143;
                zero[12, 0] = 865; zero[12, 1] = 1086;

                zero[13, 0] = 841; zero[13, 1] = 1037;
                zero[14, 0] = 841; zero[14, 1] = 962;

                zero[15, 0] = 863; zero[15, 1] = 907;
                zero[16, 0] = 917; zero[16, 1] = 853;



                top[1, 0] = 970; top[1, 1] = 180;
                top[2, 0] = 1044; top[2, 1] = 180;

                top[3, 0] = 1560; top[3, 1] = 393;
                top[4, 0] = 1611; top[4, 1] = 449;

                top[5, 0] = 1828; top[5, 1] = 964;
                top[6, 0] = 1828; top[6, 1] = 1037;

                top[7, 0] = 1615; top[7, 1] = 1550;
                top[8, 0] = 1558; top[8, 1] = 1602;

                top[9, 0] = 1046; top[9, 1] = 1815;
                top[10, 0] = 970; top[10, 1] = 1815;

                top[11, 0] = 458; top[11, 1] = 1602;
                top[12, 0] = 401; top[12, 1] = 1550;

                top[13, 0] = 188; top[13, 1] = 1035;
                top[14, 0] = 188; top[14, 1] = 962;

                top[15, 0] = 401; top[15, 1] = 450;
                top[16, 0] = 456; top[16, 1] = 397;

                /*** old
                zero[1,0] = 613; zero[1,1] = 523;
                zero[2, 0] = 670; zero[2, 1] = 523;
                
                zero[3, 0] = 706; zero[3, 1] = 539;
                zero[4, 0] = 745; zero[4, 1] = 575;
                
                zero[5, 0] = 760; zero[5, 1] = 616;
                zero[6, 0] = 760; zero[6, 1] = 673;

                zero[7, 0] = 745; zero[7, 1] = 707;
                zero[8, 0] = 704; zero[8, 1] = 747;

                zero[9, 0] = 668; zero[9, 1] = 763;
                zero[10, 0] = 611; zero[10, 1] = 765;

                zero[11, 0] = 574; zero[11, 1] = 748;
                zero[12, 0] = 535; zero[12, 1] = 709;

                zero[13, 0] = 521; zero[13, 1] = 673;
                zero[14, 0] = 521; zero[14, 1] = 617;

                zero[15, 0] = 535; zero[15, 1] = 580;
                zero[16, 0] = 575; zero[16, 1] = 539;



                top[1, 0] = 613; top[1, 1] = 48;
                top[2, 0] = 670; top[2, 1] = 48;

                top[3, 0] = 1043; top[3, 1] = 202;
                top[4, 0] = 1081; top[4, 1] = 241;

                top[5, 0] = 1236; top[5, 1] = 617;
                top[6, 0] = 1236; top[6, 1] = 672;

                top[7, 0] = 1081; top[7, 1] = 1046;
                top[8, 0] = 1042; top[8, 1] = 1084;

                top[9, 0] = 668; top[9, 1] = 1240;
                top[10, 0] = 611; top[10, 1] = 1240;

                top[11, 0] = 238; top[11, 1] = 1085;
                top[12, 0] = 198; top[12, 1] = 1046;

                top[13, 0] = 43; top[13, 1] = 673;
                top[14, 0] = 43; top[14, 1] = 617;

                top[15, 0] = 198; top[15, 1] = 242;
                top[16, 0] = 238; top[16, 1] = 203;
                 * */
            }

            if (SType == StarType.Two)
            {
                zero[1, 0] = 1035; zero[1, 1] = 694;
                zero[2, 0] = 1050; zero[2, 1] = 717;

                zero[3, 0] = 1049; zero[3, 1] = 743;
                zero[4, 0] = 1034; zero[4, 1] = 768;

                zero[5, 0] = 1004; zero[5, 1] = 767;
                zero[6, 0] = 989; zero[6, 1] = 745;

                zero[7, 0] = 987; zero[7, 1] = 719;
                zero[8, 0] = 1003; zero[8, 1] = 696;


                top[1, 0] = 1260; top[1, 1] = 143;
                top[2, 0] = 1606; top[2, 1] = 487;

                top[3, 0] = 1606; top[3, 1] = 975;
                top[4, 0] = 1257; top[4, 1] = 1319;

                top[5, 0] = 773; top[5, 1] = 1319;
                top[6, 0] = 432; top[6, 1] = 975;

                top[7, 0] = 432; top[7, 1] = 487;
                top[8, 0] = 774; top[8, 1] = 146;

                /*** old
                zero[1, 0] = 1042; zero[1, 1] = 722;
                zero[2, 0] = 1044; zero[2, 1] = 742;

                zero[3, 0] = 1056; zero[3, 1] = 770;
                zero[4, 0] = 1040; zero[4, 1] = 792;

                zero[5, 0] = 1010; zero[5, 1] = 794;
                zero[6, 0] = 998; zero[6, 1] = 772;

                zero[7, 0] = 996; zero[7, 1] = 744;
                zero[8, 0] = 1012; zero[8, 1] = 720;

               
                top[1, 0] = 1270; top[1, 1] = 174;
                top[2, 0] = 1614; top[2, 1] = 514;

                top[3, 0] = 1614; top[3, 1] = 1000;
                top[4, 0] = 1268; top[4, 1] = 1344;

                top[5, 0] = 788; top[5, 1] = 1342;
                top[6, 0] = 440; top[6, 1] = 1000;

                top[7, 0] = 444; top[7, 1] = 518;
                top[8, 0] = 784; top[8, 1] = 174;
                */
            }

            foreach (StarElement el in this.Elements)
            {
                if (el.q == null || el.p == null) continue;


                if (this.SType == StarType.Two && el.Axis > 8) continue;

                float avg = el.q.GetAverageByPerson(eval, el.p);
                float mw = 1 - ( avg / 4);

                float px = 0;
                float py = 0;

              
                px = zero[el.Axis, 0] - (zero[el.Axis, 0] - top[el.Axis, 0]) * mw;
                py = zero[el.Axis, 1] + (top[el.Axis, 1] - zero[el.Axis, 1]) * mw;                

                Console.WriteLine("[" + el.Axis + "]\t" + avg + "\t" + mw + "\t" + px + "/" + py);
                g.FillEllipse(new SolidBrush(el.ElementColor), px - rad, py - rad, rad * 2, rad * 2);
            }

            OutputImage = new Bitmap(this.width, this.height);

            Graphics gr = Graphics.FromImage(OutputImage);
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gr.PixelOffsetMode = PixelOffsetMode.HighQuality;

            gr.DrawImage(img, 0, 0, width, height);
        }

		public override void EditDialog()
		{
		}

        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_Star(eval, false, this);
        }


		public override void Save(string name, string path)
		{
			Question[] qs = new Question[Elements.Count];
            int i = 0;
			foreach (StarElement el in Elements)
            {
                qs[i++] = el.q;
            }

			//cross?
			Evaluation seval;
			if (CrossTargets(qs))
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

                foreach (StarElement el in Elements)
                {
				    el.q = td.GetQuestion(el.q, Eval);
                }

				Compute();

				FileStream myFileOut = new FileStream(path + "\\" + SystemTools.Savable(name + " ("+td.Name+").png"), FileMode.Create );
				OutputImage.Save( myFileOut, ImageFormat.Png );
				myFileOut.Close();			
            }

			seval = null;
			OutputImage = null;
		}
	}
}
