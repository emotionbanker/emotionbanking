using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Collections;
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
	public class Tacho : Output
	{
        public enum BarSide {left, right}
        public enum TachoStyle {Dark, Light}

		public Question QLeft;
		public Question QRight;

		public PersonSetting PLeft;
		public PersonSetting PRight;

		public string Heading;
        public string HLeft;
        public string HRight;

        private Color TRed
        {
            get
            {
                if (Style == TachoStyle.Dark) return Color.FromArgb(210, 35, 42);
                else return Color.FromArgb(206, 33, 33);
            }
        }
        private Color TYellow
        {
            get
            {
                if (Style == TachoStyle.Dark) return Color.FromArgb(255, 242, 0);
                else return Color.FromArgb(247, 140, 33);
            }
        }

        private Color TGreen
        {
            get
            {
                if (Style == TachoStyle.Dark) return Color.FromArgb(64, 174, 73);
                else return Color.FromArgb(66, 165, 66);
            }
        }

        public Font FontS;
        public Font FontT;

        public TachoStyle Style = TachoStyle.Dark;

		public Bitmap Raw
		{
			get
			{
                Bitmap bmp = new Bitmap(1,1);
				if (Style == TachoStyle.Dark) bmp = new Bitmap(SystemTools.GetAppPath() + "tacho_raw.png");
                else if (Style == TachoStyle.Light) bmp = new Bitmap(SystemTools.GetAppPath() + "tacho_raw_light.png");

                Bitmap two = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format16bppRgb555);

                Graphics g = Graphics.FromImage(two);
                g.DrawImage(bmp, new Rectangle(0,0,bmp.Width,bmp.Height));

                return two;
			}
		}


        public Tacho(Evaluation eval)
        {
            this.eval = eval;
			HLeft = HRight = Heading = string.Empty;

			this.width = 886;   //original image size
			this.height = 1752;

            FontT = new Font("Arial", 70, FontStyle.Regular, GraphicsUnit.Pixel);
            FontS = new Font("Arial", 20, FontStyle.Regular, GraphicsUnit.Pixel);
		}

        public override void LoadGlobalQ()
        {
            LoadQ(QLeft);
            LoadQ(QRight);
        }

        public override void LoadTargetQ(TargetData td)
        {
            LoadTQ(td, QLeft);
            LoadTQ(td, QRight);
        }

		/// <summary>
		/// serialization functions
		/// </summary>
		/// <param name="info"></param>
		/// <param name="ctxt"></param>
		public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			LoadSerData(info,ctxt);

            Question.SetMultipart(QLeft, Multipart);
            Question.SetMultipart(QRight, Multipart);

			info.AddValue("QLeft", this.QLeft);
			info.AddValue("QRight", this.QRight);
			info.AddValue("PLeft", this.PLeft);
			info.AddValue("PRight", this.PRight);
			info.AddValue("Heading", this.Heading);
			info.AddValue("HLeft", this.HLeft);
			info.AddValue("HRight", this.HRight);

            info.AddValue("FontT", this.FontT);
            info.AddValue("FontS", this.FontS);

            info.AddValue("Style", this.Style);
		}

		public Tacho(SerializationInfo info, StreamingContext ctxt)
		{
			ReadSerData(info, ctxt);

            this.QLeft = (Question)info.GetValue("QLeft", typeof(Question));
            this.QRight = (Question)info.GetValue("QRight", typeof(Question));

			this.Heading = info.GetString("Heading");
            this.HLeft = info.GetString("HLeft");
            this.HRight = info.GetString("HRight");


            this.PLeft = (PersonSetting)info.GetValue("PLeft", typeof(PersonSetting));
            this.PRight = (PersonSetting)info.GetValue("PRight", typeof(PersonSetting));

            try
            {
                FontT = (Font)info.GetValue("FontT", typeof(Font));
                FontS = (Font)info.GetValue("FontS", typeof(Font));
            }
            catch
            {
                FontT = new Font("Arial", 70, FontStyle.Regular, GraphicsUnit.Pixel);
                FontS = new Font("Arial", 20, FontStyle.Regular, GraphicsUnit.Pixel);
            }

            try { this.Style = (TachoStyle)info.GetValue("Style", typeof(TachoStyle)); }
            catch { this.Style = TachoStyle.Dark; }
		}

        private void FloodFill(Bitmap bmp, Color fillCol, Point start)
        {
            FloodFiller ff = new FloodFiller();
            ff.FillStyle = FloodFillStyle.Linear;

            ff.FillColor = fillCol; // ColorTranslator.FromWin32(FloodFiller.RGB((byte)fillCol.R, (byte)fillCol.G, (byte)fillCol.B));
            ff.FloodFill(bmp, start);
            //DoFloodFill(bmp, fillCol, bmp.GetPixel(start.X, start.Y), start);
        }

       
        private void FillBar(Bitmap bmp, BarSide side, float val)
        {
            int num = (int)(((val - 1) * 5) + 1);

            ArrayList fill = new ArrayList();

            if (num >= 1) fill.Add(new Point(277, 1205));
            if (num >= 2) fill.Add(new Point(277, 1139));
            if (num >= 3) fill.Add(new Point(277, 1097));
            if (num >= 4) fill.Add(new Point(277, 1051));
            if (num >= 5) fill.Add(new Point(277, 1007));
            if (num >= 6) fill.Add(new Point(277, 945));
            if (num >= 7) fill.Add(new Point(277, 887));
            if (num >= 8) fill.Add(new Point(277, 843));
            if (num >= 9) fill.Add(new Point(277, 795));
            if (num >= 10) fill.Add(new Point(277, 749));
            if (num >= 11) fill.Add(new Point(277, 689));
            if (num >= 12) fill.Add(new Point(277, 627));
            if (num >= 13) fill.Add(new Point(277, 583));
            if (num >= 14) fill.Add(new Point(277, 537));
            if (num >= 15) fill.Add(new Point(277, 491));
            if (num >= 16) fill.Add(new Point(277, 437));
            if (num >= 17) fill.Add(new Point(277, 369));
            if (num >= 18) fill.Add(new Point(277, 327));
            if (num >= 19) fill.Add(new Point(277, 279));
            if (num >= 20) fill.Add(new Point(277, 233));
            if (num >= 21) fill.Add(new Point(277, 169));

            int i = 1;
            foreach (Point p in fill)
            {
                int x = p.X;
                int y = p.Y;

                if (side == BarSide.right) x = 640;

                Color c = Color.Black;

                if (i >= 1 && i <= 5) c = TGreen;
                if (i >= 6 && i <= 15) c = TYellow;
                if (i >= 16 && i <= 21) c = TRed;

                FloodFill(bmp, c, new Point(x, y));

                i++;
            }

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

            g.DrawString(s, f, new SolidBrush(c), new PointF(x - ss.Width, y - ss.Height / 2));
        }

		public override void Compute()
		{
            Bitmap raw = Raw;

            Bitmap img = raw;

			Graphics g = Graphics.FromImage(img);

			g.SmoothingMode = SmoothingMode.AntiAlias;

            if (QLeft != null && PLeft != null)
                FillBar(img, BarSide.left, QLeft.GetAverageByPersonAsMark(eval, PLeft));
            if (QRight != null && PRight != null)
                FillBar(img, BarSide.right, QRight.GetAverageByPersonAsMark(eval, PRight));

            
            Font bF = FontT; 
            Font sF = FontS; 

            PutString(g, Heading, bF, Color.Black, 443, 1638);
            PutString(g, HLeft, sF, Color.Black, 283, 1440);
            PutString(g, HRight, sF, Color.Black, 619, 1440);

            this.OutputImage = GraphicTools.ResizeBitmap(img, this.width, this.height); ;
		}

		public override void EditDialog()
		{
			// wrong version
		}

        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_Tacho(eval, false, this);
        }

		public override void Save(string name, string path)
		{
			//
			Question[] baseq = new Question[2];
			
			baseq[0] = this.QLeft;
			baseq[1] = this.QRight;
			
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

                this.QLeft = td.GetQuestion(QLeft, Eval);
                this.QRight = td.GetQuestion(QRight, Eval);

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
