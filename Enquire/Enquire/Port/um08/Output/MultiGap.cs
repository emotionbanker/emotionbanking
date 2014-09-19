using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{
	/// <summary>
	/// Summary description for Averages.
	/// </summary>
	/// 

	[Serializable]
	public class MultiGap : Output
	{
		public Question TopLeft;
		public Question TopRight;

		public Question BotLeft;
		public Question BotRight;

		public PersonSetting PTopLeft;
		public PersonSetting PTopRight;

		public PersonSetting PBotLeft;
		public PersonSetting PBotRight;

		public string HeadingLeft;
        public string HeadingRight;
        public string HeadingCenter;

        public Font ValueFont;
        public Color ValueColor;

        public Font HeadFont;
        public Color HeadColor;

        public MultiGap(Evaluation eval)
        {
            this.eval = eval;
			HeadingLeft = HeadingRight = string.Empty;
            HeadingCenter = "GAP";

			this.width = 500;
			this.height = 500;

            ValueFont = new Font("Tahoma", 14);
            HeadFont = new Font("Tahoma", 17);
            HeadColor = ValueColor = Color.Black;
		}

        public override void LoadGlobalQ()
        {
            LoadQ(TopLeft);
            LoadQ(TopRight);
            LoadQ(BotLeft);
            LoadQ(BotRight);
        }

        public override void LoadTargetQ(TargetData td)
        {
            LoadTQ(td, TopLeft);
            LoadTQ(td, TopRight);
            LoadTQ(td, BotLeft);
            LoadTQ(td, BotRight);
        }

		/// <summary>
		/// serialization functions
		/// </summary>
		/// <param name="info"></param>
		/// <param name="ctxt"></param>
		public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			LoadSerData(info,ctxt);
            Question.SetMultipart(TopLeft, Multipart);
            Question.SetMultipart(TopRight, Multipart);
            Question.SetMultipart(BotLeft, Multipart);
            Question.SetMultipart(BotRight, Multipart);

			info.AddValue("TopLeft", this.TopLeft);
			info.AddValue("TopRight", this.TopRight);
            info.AddValue("BotLeft", this.BotLeft);
            info.AddValue("BotRight", this.BotRight);
			
            info.AddValue("HeadingLeft", this.HeadingLeft);
            info.AddValue("HeadingRight", this.HeadingRight);
            info.AddValue("HeadingCenter", this.HeadingCenter);

			info.AddValue("PTopLeft", this.PTopLeft);
			info.AddValue("PTopRight", this.PTopRight);
			info.AddValue("PBotLeft", this.PBotLeft);
			info.AddValue("PBotRight", this.PBotRight);

            info.AddValue("ValueFont", this.ValueFont);
            info.AddValue("ValueColor", this.ValueColor);

            info.AddValue("HeadFont", this.HeadFont);
            info.AddValue("HeadColor", this.HeadColor);
		}

        public MultiGap(SerializationInfo info, StreamingContext ctxt)
		{
			ReadSerData(info, ctxt);
            this.TopLeft = (Question)info.GetValue("TopLeft", typeof(Question));
            this.TopRight = (Question)info.GetValue("TopRight", typeof(Question));
            this.BotLeft = (Question)info.GetValue("BotLeft", typeof(Question));
            this.BotRight = (Question)info.GetValue("BotRight", typeof(Question));

            this.HeadingLeft = info.GetString("HeadingLeft");
            this.HeadingRight = info.GetString("HeadingRight");

			try
			{
                this.PTopLeft = (PersonSetting)info.GetValue("PTopLeft", typeof(PersonSetting));
                this.PTopRight = (PersonSetting)info.GetValue("PTopRight", typeof(PersonSetting));
                this.PBotLeft = (PersonSetting)info.GetValue("PBotLeft", typeof(PersonSetting));
                this.PBotRight = (PersonSetting)info.GetValue("PBotRight", typeof(PersonSetting));
			}
			catch{}


            try { this.ValueFont = (Font)info.GetValue("ValueFont", typeof(Font)); }
            catch { ValueFont = new Font("Tahoma", 14); }

            try { this.ValueColor = (Color)info.GetValue("ValueColor", typeof(Color)); }
            catch { ValueColor = Color.Black; }


            try { this.HeadFont = (Font)info.GetValue("HeadFont", typeof(Font)); }
            catch { HeadFont = new Font("Tahoma", 17); }

            try { this.HeadColor = (Color)info.GetValue("HeadColor", typeof(Color)); }
            catch { HeadColor = Color.Black; }

            try { HeadingCenter = info.GetString("HeadingCenter"); }
            catch { HeadingCenter = "GAP"; }
		}

		public float deg2rad(float grad)
		{
			return grad* (float)(Math.PI/180);
		}

		public float rad2deg(float rad)
		{
			return rad * 57.2957795f;
		}

        private void PutString(Graphics g, string s, Font f, Color c, int x, int y)
        {
            SizeF ss = g.MeasureString(s, f);

            g.DrawString(s, f, new SolidBrush(c), new PointF(x - ss.Width / 2, y - ss.Height / 2));
        }

        private void PutStringL(Graphics g, string s, Font f, Color c, int x, int y)
        {
            SizeF ss = g.MeasureString(s, f);

            g.DrawString(s, f, new SolidBrush(c), new PointF(x, y - ss.Height / 2));
        }

        private void PutStringR(Graphics g, string s, Font f, Color c, int x, int y)
        {
            SizeF ss = g.MeasureString(s, f);

            g.DrawString(s, f, new SolidBrush(c), new PointF(x-ss.Width, y - ss.Height / 2));
        }
		
		public override void Compute()
		{
            Bitmap img = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            int crX = width / 2;
            int crY = height / 2;

            int reX = width/8;
            int reY = height/8;

			Graphics g = Graphics.FromImage(img);
			g.SmoothingMode = SmoothingMode.AntiAlias;

            g.Clear(Color.White);

            //4 colored segments

            Rectangle da = new Rectangle(0, 0, width, height);
            Rectangle inner = new Rectangle(width/2 - crX/2, height/2 - crY/2, crX, crY);
            Rectangle ttb = new Rectangle(width/2 - reX /2, 0, reX, height);
            Rectangle btt = new Rectangle(0, height/2 - reY/2, width, reY);

            LinearGradientBrush b;
            SolidBrush w = new SolidBrush(Color.White);

            if (PTopLeft != null)
            {
                b = new LinearGradientBrush(da, PTopLeft.Color1, PTopLeft.Color2, 45, false);
                g.FillPie(b, da, 180, 90);
            }

            if (PTopRight != null)
            {
                b = new LinearGradientBrush(da, PTopRight.Color1, PTopRight.Color2, 45, false);
                g.FillPie(b, da, 270, 90);
            }

            if (PBotRight != null)
            {
                b = new LinearGradientBrush(da, PBotRight.Color1, PBotRight.Color2, 45, false);
                g.FillPie(b, da, 0, 90);
            }

            if (PBotLeft != null)
            {
                b = new LinearGradientBrush(da, PBotLeft.Color1, PBotLeft.Color2, 45, false);
                g.FillPie(b, da, 90, 90);
            }

            //aussparungen

            g.FillEllipse(w, inner);

            g.FillRectangle(w, ttb);
            g.FillRectangle(w, btt);

            //texte
            int w4 = width / 4;
            int h4 = height / 4;

            if (TopLeft != null)
                PutString(g,TopLeft.GetAverageByPersonAsMark(eval, PTopLeft, 1).ToString(), ValueFont, ValueColor, w4, h4);
            if (TopRight != null)
                PutString(g, TopRight.GetAverageByPersonAsMark(eval, PTopRight, 1).ToString(), ValueFont, ValueColor, w4 * 3, h4);
            if (BotLeft != null)
                PutString(g, BotLeft.GetAverageByPersonAsMark(eval, PBotLeft, 1).ToString(), ValueFont, ValueColor, w4, h4 * 3);
            if (BotRight != null)
                PutString(g, BotRight.GetAverageByPersonAsMark(eval, PBotRight, 1).ToString(), ValueFont, ValueColor, w4 * 3, h4 * 3);

            PutStringL(g, this.HeadingLeft, HeadFont, HeadColor, 0, height / 2);
            PutStringR(g, this.HeadingRight, HeadFont, HeadColor, width, height / 2);

            PutString(g, HeadingCenter, HeadFont, HeadColor, width / 2, height / 2 - height / 7);

            //gaps and averages

            if (TopLeft != null && TopRight != null && PTopLeft != null & PTopRight != null)
                PutString(g, CombineQ(TopLeft, TopRight).GetAverageByPersonAsMark(eval, CombineP(PTopLeft, PTopRight), 1).ToString(), ValueFont, ValueColor, width / 2, h4/2);

            if (BotLeft != null && BotRight != null && PBotLeft != null & PBotRight != null)
                PutString(g, CombineQ(BotLeft, BotRight).GetAverageByPersonAsMark(eval, CombineP(PBotLeft, PBotRight), 1).ToString(), ValueFont, ValueColor, width / 2, height - h4/2);

            if (TopLeft != null && TopRight != null && BotLeft != null && BotRight != null &&
                PTopLeft != null & PTopRight != null && PBotLeft != null & PBotRight != null)
            {
                //gap, finally
                string gap = Math.Round(Math.Abs(CombineQ(TopLeft, TopRight).GetAverageByPersonAsMark(eval, CombineP(PTopLeft, PTopRight), 1) -
                    CombineQ(BotLeft, BotRight).GetAverageByPersonAsMark(eval, CombineP(PBotLeft, PBotRight), 1)),1).ToString();

                PutString(g, gap, ValueFont, ValueColor, width / 2, height / 2);
            }


			this.OutputImage = img;
		}

        private PersonSetting CombineP(PersonSetting a, PersonSetting b)
        {
            PersonCombo c = new PersonCombo();

            if (a.GetType().Equals(typeof(Person))) c.AddPerson((Person)a);
            else { foreach (Person p in ((PersonCombo)a).Persons) c.AddPerson(p); }

            if (b.GetType().Equals(typeof(Person))) c.AddPerson((Person)b);
            else { foreach (Person p in ((PersonCombo)b).Persons) c.AddPerson(p); }

            c.Color1 = a.Color1;
            c.Color2 = a.Color2;


            return c;
        }

        private Question CombineQ(Question a, Question b)
        {
            Question c = new Question(a);

            foreach (Result r in a.Results)
                c.Results.Add(r);

            foreach (Result r in b.Results)
                c.Results.Add(r);

            return c;
        }

		public override void EditDialog()
		{
            throw new Exception("Falsche Version (<2007)");
		}

        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_MultiGap(eval, false, this);
        }

		public override void Save(string name, string path)
		{
			//
			Question[] baseq = new Question[4];
			
			baseq[0] = this.TopLeft;
			baseq[1] = this.TopRight;
			baseq[2] = this.BotLeft;
			baseq[3] = this.BotRight;
			
			//cross?
			Evaluation seval;
			if (CrossTargets(baseq))
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

                this.TopLeft = td.GetQuestion(TopLeft, Eval);
                this.TopRight = td.GetQuestion(TopRight, Eval);
                this.BotLeft = td.GetQuestion(BotLeft, Eval);
                this.BotRight = td.GetQuestion(BotRight, Eval);

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
