using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization;
using System.Collections;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using dotnetCHARTING.WinForms;
using umfrage2;
using umfrage2._2007;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{
	[Serializable]
	public class SingleMatrix : Output
	{
		public const int STYLE_4GRADIENTS = 0;
		public const int STYLE_V05 = 1;
		public const int STYLE_CONE = 2;
		public const int STYLE_BAR = 3;
        public const int STYLE_V07 = 4;
        public const int STYLE_4GRADSIMPLE = 5;
        public const int STYLE_V05SIMPLE = 6;
        public const int STYLE_4GRAD5GRID = 7;
        public const int STYLE_GRAD5GRID = 8;

		public const int PRECISION_9 = 0;
		public const int PRECISION_25 = 1;
        public const int PRECISION_4 = 2;

        public const int SKALA_1 = 0;
        public const int SKALA_2 = 1;
        public const int SKALA_3 = 2;
        public const int SKALA_4 = 3;
        public const int SKALA_5 = 4;
        public const int SKALA_6 = 5;

        /*public const int SKALA_1_2_345 = 1;
        public const int SKALA_1_23_45 = 2;
        public const int SKALA_1_234_5 = 3;
        public const int SKALA_12_34_5 = 4;
        public const int SKALA_123_4_5 = 5;

        public const int SKALA_12_345 = 0;
        public const int SKALA_1_2345 = 1;
        public const int SKALA_123_45 = 2;
        public const int SKALA_1234_5 = 3;*/

        public int matrix1;
        public int matrix2;

		public Question h;
		public Question v;

        public Color ArrowColor = Color.Orange;

		private Color SphereColor1;
		private Color SphereColor2;

		public bool DrawArrow;

		public bool Legend;

        public int Skala;
        public int Skala1;
		public int Style;

        public int Design;

//        public ShadingEffectMode ShadingEffect;
        public DNCSettings dnc;

		public int Precision;

        public bool Invert;
        public bool InvertY = false;

        public bool GlobalRef;

		public SingleMatrix(Evaluation eval)
		{
			PersonList = new Person[0];
			ComboList = new PersonCombo[0];
			this.eval = eval;
			//this.v = v;
			//this.h = h;
			this.DrawArrow = true;
			this.Legend = true;

			this.Style = SingleMatrix.STYLE_4GRADIENTS;
			this.Precision = SingleMatrix.PRECISION_9;
            this.Skala = SingleMatrix.SKALA_1;
            this.Skala1 = SingleMatrix.SKALA_1;
            this.Design = SingleMatrix.Victor2007;
            //this.matrix1 = 1;
            //if (this.Precision == 2) this.matrix2 = 2;
            //else if (this.Precision == 0) this.matrix2 = 3;

            this.Invert = false;
            //ShadingEffect = ShadingEffectMode.One;
            dnc = new DNCSettings();

            GlobalRef = false;
		}

        public override void LoadGlobalQ()
        {
            LoadQ(h);
            LoadQ(v);
        }

        public override void LoadTargetQ(TargetData td)
        {
            LoadTQ(td, h);
            LoadTQ(td, v);
        }

		/// <summary>
		/// serialization functions
		/// </summary>
		/// <param name="info"></param>
		/// <param name="ctxt"></param>
		public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			LoadSerData(info, ctxt);

            Question.SetMultipart(h, Multipart);
            Question.SetMultipart(v, Multipart);
            
			info.AddValue("h", this.h);
			info.AddValue("v", this.v);
			info.AddValue("DrawArrow", this.DrawArrow);
			info.AddValue("Style", this.Style);
			info.AddValue("Precision", this.Precision);

			info.AddValue("Legend", this.Legend);
            info.AddValue("Design", this.Design);

            info.AddValue("DNC", this.dnc);

            info.AddValue("ArrowColor", ArrowColor);

            info.AddValue("Invert", Invert);
			//info.AddValue("SphereColor1", this.SphereColor1);
			//info.AddValue("SphereColor2", this.SphereColor2);
            info.AddValue("InvertY", InvertY);

            info.AddValue("GlobalRef", GlobalRef);
            info.AddValue("Skala", this.Skala);
            info.AddValue("Skala1", this.Skala1);
		}

		public SingleMatrix(SerializationInfo info, StreamingContext ctxt)
		{
			base.ReadSerData(info, ctxt);

			this.h = (Question)info.GetValue("h", typeof(Question));
			this.v = (Question)info.GetValue("v", typeof(Question));
			//this.SphereColor1 = (Color)info.GetValue("SphereColor1", typeof(Color));
			//this.SphereColor2 = (Color)info.GetValue("SphereColor2", typeof(Color));

			try {this.DrawArrow = info.GetBoolean("DrawArrow");}
			catch{DrawArrow=true;}

			try {this.Style = info.GetInt32("Style");}
			catch{Style=SingleMatrix.STYLE_4GRADIENTS;}
                                                 
			try {this.Precision = info.GetInt32("Precision");}
			catch{Precision=SingleMatrix.PRECISION_9;
            }

            try { this.Skala = info.GetInt32("Skala"); }
            catch(Exception){Skala = SingleMatrix.SKALA_1; }

            try { this.Skala1 = info.GetInt32("Skala1"); }
            catch (Exception) { Skala1 = SingleMatrix.SKALA_1; }

			try {this.Legend = info.GetBoolean("Legend");}
			catch{Legend=true;}

            try { this.Design = info.GetInt32("Design"); }
            catch { Design = SingleMatrix.Victor2006; }

            try { this.dnc = (DNCSettings)info.GetValue("DNC", typeof(DNCSettings)); }
            catch { dnc = new DNCSettings(); }

            try { this.ArrowColor = (Color)info.GetValue("ArrowColor", typeof(Color)); }
            catch { ArrowColor = Color.Orange; }

            try { this.Invert = info.GetBoolean("Invert"); }
            catch { Invert = false; }

            try { this.InvertY = info.GetBoolean("InvertY"); }
            catch { InvertY = false; }

            try { this.GlobalRef = info.GetBoolean("GlobalRef"); }
            catch { GlobalRef = false; }
		}

		private void NoValues(Graphics g, float x, float y)
		{
			g.DrawString("keine werte!", new Font("Tahoma", 10), new SolidBrush(Color.Black), x, y);
		}

        public void Compute06()
        {

            OutputImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            float offset = 5;

            float workHeight = ((float)height) - 2 * offset;
            float workWidth = ((float)width) - 2 * offset;

            Graphics g = Graphics.FromImage(OutputImage);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Brush white = new SolidBrush(Color.White);

            Brush black = new SolidBrush(Color.Black);
            Brush red = new SolidBrush(Color.Red);

            Font f1 = new Font("Arial", width / 30, FontStyle.Regular, GraphicsUnit.Pixel);
            Font f2 = new Font("Arial", width / 25, FontStyle.Bold, GraphicsUnit.Pixel);
            Font f3 = new Font("Arial", width / 30, FontStyle.Bold, GraphicsUnit.Pixel);

            Pen whitePen = new Pen(Color.White, width / 200);
            Pen grayPen = new Pen(Color.Gray, width / 200);

            Color arrow = Color.Orange;

            Pen arrowPen = new Pen(arrow, width / 100);
            Brush arrowBrush = new SolidBrush(arrow);

            float x = (workHeight / 8), y = (workHeight / 8);

            //BACKGROUND
            g.Clear(Color.White);

            float len;
            Brush bright, bleft;
            PointF[] tleft, tright;

            int i;

            Brush filler;
            RectangleF fillrect;

            switch (this.Style)
            {
                case SingleMatrix.STYLE_V07:
                case SingleMatrix.STYLE_4GRADIENTS:

                    // fill space rectangles
                    //top left
                    fillrect = new RectangleF(offset, offset, x * 4, y * 4);
                    filler = new LinearGradientBrush(fillrect, Color.DarkGray, Color.White, 45, false);
                    g.FillRectangle(filler, fillrect);
                    //bottom left
                    fillrect = new RectangleF(offset, offset + y * 4, x * 4, y * 4);
                    filler = new LinearGradientBrush(fillrect, Color.Gray, Color.White, 315, false);
                    g.FillRectangle(filler, fillrect);
                    //bottom right
                    fillrect = new RectangleF(offset + x * 4, offset + y * 4, x * 4, y * 4);
                    filler = new LinearGradientBrush(fillrect, Color.DarkGray, Color.White, 225, false);
                    g.FillRectangle(filler, fillrect);
                    //top right
                    fillrect = new RectangleF(offset + x * 4, offset, x * 4, y * 4);
                    filler = new LinearGradientBrush(fillrect, Color.LightGray, Color.White, 135, false);
                    g.FillRectangle(filler, fillrect);

                    for (i = 0; i < 8; i++)
                    {
                        g.DrawLine(whitePen, offset + x * i, offset + 0, offset + x * i, offset + y * 10);
                        g.DrawLine(whitePen, offset + 0, offset + y * i, offset + x * 10, offset + y * i);
                    }
                    break;

                case SingleMatrix.STYLE_BAR:

                    //0:0
                    //1415:371
                    len = ((float)workHeight) * 0.8f;
                    tleft = new PointF[] { new PointF(offset, offset), new PointF(offset + len, offset), new PointF(offset, offset + len) };
                    tright = new PointF[] { new PointF(offset + workHeight, offset + workHeight), new PointF(offset + workHeight - len, offset + workHeight), new PointF(offset + workHeight, offset + workHeight - len) };

                    bleft = new LinearGradientBrush(new RectangleF(offset, offset, len, len), Color.FromArgb(164, 164, 164), Color.FromArgb(40, 40, 40), 45, false);
                    bright = new LinearGradientBrush(new RectangleF(offset + workHeight - len, offset + workHeight - len, len, len), Color.FromArgb(164, 164, 164), Color.FromArgb(40, 40, 40), 225, false);

                    g.FillPolygon(bleft, tleft);
                    g.FillPolygon(bright, tright);


                    break;

                case SingleMatrix.STYLE_CONE:

                    //0:0
                    //1415:371
                    len = ((float)workHeight) * 0.8f;
                    tleft = new PointF[] { new PointF(offset, offset), new PointF(offset + len, offset), new PointF(offset, offset + workHeight) };
                    tright = new PointF[] { new PointF(offset + workHeight, offset + workHeight), new PointF(offset, offset + workHeight), new PointF(offset + workHeight, offset + workHeight - len) };

                    bleft = new LinearGradientBrush(new RectangleF(offset, offset, len, workHeight), Color.FromArgb(164, 164, 164), Color.FromArgb(40, 40, 40), 45, false);
                    bright = new LinearGradientBrush(new RectangleF(offset, offset + workHeight - len, workHeight, len), Color.FromArgb(164, 164, 164), Color.FromArgb(40, 40, 40), 225, false);

                    g.FillPolygon(bleft, tleft);
                    g.FillPolygon(bright, tright);

                    break;

                case SingleMatrix.STYLE_V05:
                    //top left
                    fillrect = new RectangleF(offset, offset, x * 3, y * 3);
                    g.FillRectangle(new SolidBrush(Color.DarkGray), fillrect);

                    //bottom left
                    fillrect = new RectangleF(offset, offset + y * 5, x * 3, y * 3);
                    g.FillRectangle(new SolidBrush(Color.Gray), fillrect);

                    //bottom right
                    fillrect = new RectangleF(offset + x * 5, offset + y * 5, x * 3, y * 3);
                    g.FillRectangle(new SolidBrush(Color.DarkGray), fillrect);

                    //top right
                    fillrect = new RectangleF(offset + x * 5, offset, x * 3, y * 3);
                    g.FillRectangle(new SolidBrush(Color.LightGray), fillrect);

                    for (i = 0; i < 8; i++)
                    {
                        g.DrawLine(whitePen, offset + x * i, offset + 0, offset + x * i, offset + y * 10);
                        g.DrawLine(whitePen, offset + 0, offset + y * i, offset + x * 10, offset + y * i);
                    }

                    for (i = 1; i < 8; i++)
                    {
                        g.DrawLine(grayPen, offset + x * i, offset + y * 3, offset + x * i, offset + y * 5);
                        g.DrawLine(grayPen, offset + x * 3, offset + y * i, offset + x * 5, offset + y * i);
                    }

                    g.DrawLine(grayPen, offset + x * 4, offset, offset + x * 4, offset + y * 8);
                    g.DrawLine(grayPen, offset, offset + y * 4, offset + x * 8, offset + y * 4);
                    break;
            }

            if (DrawArrow)
            {
                //draw arrow lines
                g.DrawLine(arrowPen, offset + x * 4, offset + 0, offset + x * 4, offset + y * 8);
                g.DrawLine(arrowPen, offset + 0, offset + y * 4, offset + x * 8, offset + y * 4);
                //draw arrow heads

                float headsize = workWidth / 50;
                //top
                g.FillPolygon(arrowBrush, new PointF[] {new PointF(offset + x*4-headsize, offset + headsize), 
														  new PointF(offset + x*4+headsize, offset + headsize),
														  new PointF(offset + x*4, offset)});
                //bottom
                g.FillPolygon(arrowBrush, new PointF[] {new PointF(offset + x*4-headsize, offset + y*8-headsize), 
														  new PointF(offset + x*4+headsize, offset + y*8-headsize),
														  new PointF(offset + x*4, offset + y*8)});
                // left
                g.FillPolygon(arrowBrush, new PointF[] {new PointF(offset + headsize, offset + y*4-headsize), 
														  new PointF(offset + headsize, offset + y*4+headsize),
														  new PointF(offset, offset + y*4)});
                //right
                g.FillPolygon(arrowBrush, new PointF[] {new PointF(offset - headsize + x*8, offset + y*4-headsize), 
														  new PointF(offset - headsize +  x*8, offset + y*4+headsize),
														  new PointF(offset + x*8, offset + y*4)});

            }

            if (PersonList.Length == 0 && ComboList.Length == 0)
            {
                //Console.WriteLine("personlist & combolist == 0");
                NoValues(g, x * 3, y * 4);
                return;
            }
            if (h == null || v == null)
            {
//                Console.WriteLine("h || v == 0");
                NoValues(g, x * 3, y * 4);
                return;
            }

            double[,] resultArray = new double[3, 3];
            double[,] resultArray25 = new double[5, 5];

            for (int ri = 0; ri < 3; ri++)
                for (int ro = 0; ro < 3; ro++)
                    resultArray[ri, ro] = 0d;

            for (int ri = 0; ri < 5; ri++)
                for (int ro = 0; ro < 5; ro++)
                    resultArray25[ri, ro] = 0d;

            double counter = 0;
            double noadd = 0;

            foreach (Result r in h.Results)
            {
                noadd++;
                bool add = false;
                int PID;

                PID = Eval.GetPersonIdByUser(r.UserID);
                foreach (Person p in PersonList)
                    if (p.ID == PID)
                        add = true;

                foreach (PersonCombo c in ComboList)
                    if (c.ContainsID(PID))
                        add = true;

                if (add)
                {
                    int yr;

                    if (v.GetResultByUserID(r.UserID) != null)
                        yr = v.GetResultByUserID(r.UserID).SelectedAnswer;
                    else
                        continue;

                    int xr = r.SelectedAnswer;

                    if (xr > 4 || yr > 4 || xr < 0 || yr < 0) continue;
                    resultArray25[xr, yr]++;

                    if (yr == 0 || yr == 1) yr = 0;
                    else if (yr == 2) yr = 1;
                    else if (yr == 3 || yr == 4) yr = 2;
                    else continue;

                    if (xr == 0 || xr == 1) xr = 0;
                    else if (xr == 2) xr = 1;
                    else if (xr == 3 || xr == 4) xr = 2;
                    else continue;

                    resultArray[xr, yr]++;
                    counter++;
                }
            }

            //HERE
//            Console.WriteLine("counter is " + counter);
            if (counter == 0)
            {
                NoValues(g, x * 3, y * 4);
                return;
            }

            double highest = 0;
            double highest25 = 0;
            for (int n = 0; n < 3; n++)
            {
                for (int m = 0; m < 3; m++)
                {
                    resultArray[n, m] = Math.Round(((resultArray[n, m] / counter) * 100d), 0);

                    if (resultArray[n, m] > highest)
                        highest = resultArray[n, m];
                }
            }
            for (int n = 0; n < 5; n++)
            {
                for (int m = 0; m < 5; m++)
                {
                    resultArray25[n, m] = Math.Round(((resultArray25[n, m] / counter) * 100d), 0);

                    if (resultArray25[n, m] > highest25)
                        highest25 = resultArray25[n, m];
                }
            }


            if (ComboList.Length != 0)
            {
                SphereColor1 = ComboList[0].Color1;
                SphereColor2 = ComboList[0].Color2;
            }
            else
            {
                SphereColor1 = PersonList[0].Color1;
                SphereColor2 = PersonList[0].Color2;
            }

            /*switch (this.Precision)
            {
                case SingleMatrix.SKALA_1_2_345:

                    break;
            }*/

            switch (this.Precision)
            {
                case SingleMatrix.PRECISION_9:
                    //radius highest = x*1.8
                    for (int n = 0; n < 3; n++)
                    {
                        for (int m = 0; m < 3; m++)
                        {
                            float radius = (float)((1f * x) / (float)highest) * (float)resultArray[n, m];
                            //circle
                            float dx = 0, dy = 0;
                            if (n == 0) dx = 6.5f * x;
                            if (n == 1) dx = 4f * x;
                            if (n == 2) dx = 1.5f * x;

                            if (m == 0) dy = 1.5f * y;
                            if (m == 1) dy = 4f * y;
                            if (m == 2) dy = 6.5f * y;

                            GraphicTools.Sphere((float)(offset + dx), (float)(offset + dy), radius, SphereColor1, SphereColor2, g);

                            if (Legend)
                                g.DrawString(resultArray[n, m].ToString() + "%", f2, black, offset + dx - width / 25, offset + dy - width / 50);
                        }
                    }
                    break;

                case SingleMatrix.PRECISION_25:
                    for (int n = 0; n < 5; n++)
                    {
                        for (int m = 0; m < 5; m++)
                        {
                            float radius = (float)((0.7f * x) / (float)highest25) * (float)resultArray25[n, m];
                            //circle
                            float dx = 0, dy = 0;
                            if (n == 0) dx = 7f * x;
                            if (n == 1) dx = 5.5f * x;
                            if (n == 2) dx = 4f * x;
                            if (n == 3) dx = 2.5f * x;
                            if (n == 4) dx = 1f * x;

                            if (m == 0) dy = 1f * y;
                            if (m == 1) dy = 2.5f * y;
                            if (m == 2) dy = 4f * y;
                            if (m == 3) dy = 5.5f * y;
                            if (m == 4) dy = 7f * y;

                            GraphicTools.Sphere((float)(offset + dx), (float)(offset + dy), radius, SphereColor1, SphereColor2, g);

                            if (Legend)
                                g.DrawString(resultArray25[n, m].ToString() + "%", f2, black, offset + dx - width / 25, offset + dy - width / 50);
                        }
                    }
                    break;
            }
        }

        private Bitmap CreateCone(int wid, int hei)
        {
            Bitmap oi = new Bitmap(wid, hei, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(oi);

            g.Clear(Color.White);

            float workHeight = (float)hei;
            float offset = 0;
            float len = ((float)hei) * 0.8f;
            
            PointF[] tleft = new PointF[] { new PointF(offset, offset), new PointF(offset + len, offset), new PointF(offset, offset + workHeight) };
            PointF[] tright = new PointF[] { new PointF(offset + workHeight, offset + workHeight), new PointF(offset, offset + workHeight), new PointF(offset + workHeight, offset + workHeight - len) };

            Brush bleft = new LinearGradientBrush(new RectangleF(offset, offset, len, workHeight), Color.FromArgb(164, 164, 164), Color.FromArgb(40, 40, 40), 45, false);
            Brush bright = new LinearGradientBrush(new RectangleF(offset, offset + workHeight - len, workHeight, len), Color.FromArgb(164, 164, 164), Color.FromArgb(40, 40, 40), 225, false);

            g.FillPolygon(bleft, tleft);
            g.FillPolygon(bright, tright);

            return oi;
        }

        private Bitmap CreateBar(int wid, int hei)
        {
            Bitmap oi = new Bitmap(wid, hei, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(oi);

            g.Clear(Color.White);

            float workHeight = (float)hei;
            float offset = 0;
            float len = ((float)hei) * 0.8f;

            PointF[] tleft = new PointF[] { new PointF(offset, offset), new PointF(offset + len, offset), new PointF(offset, offset + len) };
            PointF[] tright = new PointF[] { new PointF(offset + workHeight, offset + workHeight), new PointF(offset + workHeight - len, offset + workHeight), new PointF(offset + workHeight, offset + workHeight - len) };

            Brush bleft = new LinearGradientBrush(new RectangleF(offset, offset, len, len), Color.FromArgb(164, 164, 164), Color.FromArgb(40, 40, 40), 45, false);
            Brush bright = new LinearGradientBrush(new RectangleF(offset + workHeight - len, offset + workHeight - len, len, len), Color.FromArgb(164, 164, 164), Color.FromArgb(40, 40, 40), 225, false);

            g.FillPolygon(bleft, tleft);
            g.FillPolygon(bright, tright);

            return oi;
        }

        private Bitmap CreateV05(int wid, int hei)
        {
            Bitmap oi = new Bitmap(wid, hei, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(oi);

            g.Clear(Color.White);

            float workHeight = (float)hei;
            float offset = 0;
            float len = ((float)hei) * 0.8f;

            Pen whitePen = new Pen(Color.White, width / 200);
            Pen grayPen = new Pen(Color.Gray, width / 200);

            float x = (workHeight / 8), y = (workHeight / 8);

            RectangleF fillrect = new RectangleF(offset, offset, x * 3, y * 3);
            g.FillRectangle(new SolidBrush(Color.DarkGray), fillrect);

            //bottom left
            fillrect = new RectangleF(offset, offset + y * 5, x * 3, y * 3);
            g.FillRectangle(new SolidBrush(Color.Gray), fillrect);

            //bottom right
            fillrect = new RectangleF(offset + x * 5, offset + y * 5, x * 3, y * 3);
            g.FillRectangle(new SolidBrush(Color.DarkGray), fillrect);

            //top right
            fillrect = new RectangleF(offset + x * 5, offset, x * 3, y * 3);
            g.FillRectangle(new SolidBrush(Color.LightGray), fillrect);

            if (Style == SingleMatrix.STYLE_V05)
            {
                int i;
            
                for (i = 0; i < 8; i++)
                {
                    g.DrawLine(whitePen, offset + x * i, offset + 0, offset + x * i, offset + y * 10);
                    g.DrawLine(whitePen, offset + 0, offset + y * i, offset + x * 10, offset + y * i);
                }

                for (i = 1; i < 8; i++)
                {
                    g.DrawLine(grayPen, offset + x * i, offset + y * 3, offset + x * i, offset + y * 5);
                    g.DrawLine(grayPen, offset + x * 3, offset + y * i, offset + x * 5, offset + y * i);
                }

                g.DrawLine(grayPen, offset + x * 4, offset, offset + x * 4, offset + y * 8);
                g.DrawLine(grayPen, offset, offset + y * 4, offset + x * 8, offset + y * 4);
            }

            return oi;
        }

        private Bitmap Create4Grad(int wid, int hei)
        {
            Bitmap oi = new Bitmap(wid, hei, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(oi);

            g.Clear(Color.White);

            float workHeight = (float)hei;
            float offset = 0;
            float len = ((float)hei) * 0.8f;

            float x = (workHeight / 8), y = (workHeight / 8);

            // fill space rectangles
            //top left
            RectangleF fillrect = new RectangleF(offset, offset, x * 4, y * 4);
            Brush filler = new LinearGradientBrush(fillrect, Color.DarkGray, Color.White, 45, false);
            g.FillRectangle(filler, fillrect);
            //bottom left
            fillrect = new RectangleF(offset, offset + y * 4, x * 4, y * 4);
            filler = new LinearGradientBrush(fillrect, Color.Gray, Color.White, 315, false);
            g.FillRectangle(filler, fillrect);
            //bottom right
            fillrect = new RectangleF(offset + x * 4, offset + y * 4, x * 4, y * 4);
            filler = new LinearGradientBrush(fillrect, Color.DarkGray, Color.White, 225, false);
            g.FillRectangle(filler, fillrect);
            //top right
            fillrect = new RectangleF(offset + x * 4, offset, x * 4, y * 4);
            filler = new LinearGradientBrush(fillrect, Color.LightGray, Color.White, 135, false);
            g.FillRectangle(filler, fillrect);

            Pen whitePen = new Pen(Color.White, width / 200);
            Pen grayPen = new Pen(Color.Gray, width / 200);

            //draw line only if classic style
            if (this.Style == SingleMatrix.STYLE_4GRADIENTS)
            {
                int i;
                for (i = 0; i < 8; i++)
                {
                    g.DrawLine(whitePen, offset + x * i, offset + 0, offset + x * i, offset + y * 10);
                    g.DrawLine(whitePen, offset + 0, offset + y * i, offset + x * 10, offset + y * i);
                }
            }
            else if (this.Style == SingleMatrix.STYLE_4GRAD5GRID)
            {
                x = workHeight / 5;
                y = workHeight / 5;
                int i;
                for (i = 0; i < 5; i++)
                {
                    g.DrawLine(whitePen, offset + x * i, offset + 0, offset + x * i, offset + y * 10);
                    g.DrawLine(whitePen, offset + 0, offset + y * i, offset + x * 10, offset + y * i);
                }
            }

            return oi;
        }

        private Bitmap CreateGrad(int wid, int hei)
        {
            Bitmap oi = new Bitmap(wid, hei, PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(oi);

            g.Clear(Color.White);

            float workHeight = (float)hei;
            float offset = 0;
            float len = ((float)hei) * 0.8f;

            float x = (workHeight / 8), y = (workHeight / 8);

            // fill space rectangles
            //top left
            RectangleF fillrect = new RectangleF(offset, offset, x * 4, y * 4);
            Brush filler = new LinearGradientBrush(fillrect, Color.DarkGray, Color.LightGray, 45, false);
            g.FillRectangle(filler, fillrect);
            //bottom left
            fillrect = new RectangleF(offset, offset + y * 4, x * 4, y * 4);
            filler = new LinearGradientBrush(fillrect, Color.DarkGray, Color.LightGray, 315, false);
            g.FillRectangle(filler, fillrect);
            //bottom right
            fillrect = new RectangleF(offset + x * 4, offset + y * 4, x * 4, y * 4);
            filler = new LinearGradientBrush(fillrect, Color.DarkGray, Color.LightGray, 225, false);
            g.FillRectangle(filler, fillrect);
            //top right
            fillrect = new RectangleF(offset + x * 4, offset, x * 4, y * 4);
            filler = new LinearGradientBrush(fillrect, Color.DarkGray, Color.LightGray, 135, false);
            g.FillRectangle(filler, fillrect);

            Pen whitePen = new Pen(Color.White, width / 200);
            Pen grayPen = new Pen(Color.Gray, width / 200);


            x = workHeight / 5;
            y = workHeight / 5;
            int i;
            for (i = 0; i < 5; i++)
            {
                g.DrawLine(whitePen, offset + x * i, offset + 0, offset + x * i, offset + y * 10);
                g.DrawLine(whitePen, offset + 0, offset + y * i, offset + x * 10, offset + y * i);
            }
            

            return oi;
        }

        public double[,] resultArray = new double[3, 3];
        public double[,] resultArray25 = new double[5, 5];
        public double[,] resultArray8 = new double[2, 2];

        public void Compute07()
        {
         
            if (this.Skala == SingleMatrix.SKALA_1 && this.Precision == 0) { matrix1 = 1; matrix2 = 3; }
            else if (this.Skala == SingleMatrix.SKALA_2 && this.Precision == 0) { matrix1 = 0; matrix2 = 2; }
            else if (this.Skala == SingleMatrix.SKALA_3 && this.Precision == 0) { matrix1 = 0; matrix2 = 3; }
            else if (this.Skala == SingleMatrix.SKALA_4 && this.Precision == 0) { matrix1 = 0; matrix2 = 4; }
            else if (this.Skala == SingleMatrix.SKALA_5 && this.Precision == 0) { matrix1 = 1; matrix2 = 4; }
            else if (this.Skala == SingleMatrix.SKALA_6 && this.Precision == 0) { matrix1 = 2; matrix2 = 4; }

            else if (this.Skala1 == SingleMatrix.SKALA_1 && this.Precision == 2) { matrix1 = 1; matrix2 = 2; }
            else if (this.Skala1 == SingleMatrix.SKALA_2 && this.Precision == 2) { matrix1 = 0; matrix2 = 1; }
            else if (this.Skala1 == SingleMatrix.SKALA_3 && this.Precision == 2) { matrix1 = 2; matrix2 = 3; }
            else if (this.Skala1 == SingleMatrix.SKALA_4 && this.Precision == 2) { matrix1 = 3; matrix2 = 4; }

            else { matrix1 = 1; matrix2 = 3; }

            OutputImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            
            float offset = 0;

            float workHeight = ((float)height) - 2 * offset;
            float workWidth = ((float)width) - 2 * offset;

            float x = (workHeight / 8), y = (workHeight / 8);

            //Console.WriteLine("x= " + x);

            Chart bc = new Chart();

         

            dnc.Apply(bc);
            
            bc.Title = this.Name;

            bc.Type = ChartType.Bubble;

            bc.DefaultSeries.Type = SeriesType.Spline;

            bc.DefaultSeries.DefaultElement.Transparency = dnc.Transparency;
            

            bc.Width = this.width;
            bc.Height = this.height;

            SeriesCollection sc = new SeriesCollection();

            Series s = new Series();



            #region compute07

            for (int ri = 0; ri < 3; ri++)
                for (int ro = 0; ro < 3; ro++)
                    resultArray[ri, ro] = 0d;

            for (int ri = 0; ri < 2; ri++)
                for (int ro = 0; ro < 2; ro++)
                    resultArray8[ri, ro] = 0d;

            for (int ri = 0; ri < 5; ri++)
                for (int ro = 0; ro < 5; ro++)
                    resultArray25[ri, ro] = 0d;

            double counter = 0;
            double noadd = 0;
            double highest = 0;
            double highest25 = 0;
            double highest8 = 0;
            //Ьberprьfung ob Personenlist, ComboList, h(horizontale Question) und v (vertikal Question) nicht null bzw. leer sind  
            if (h != null && v != null && (PersonList.Length != 0 || ComboList.Length != 0))
            {
                
                ArrayList users = new ArrayList();

                foreach (Result r in h.Results) //durchlaufe alle horizontale Ergebnisse
                {
                    if (users.Contains(r.UserID)) //ob user id in der userliste (Arraylist) enthalten ist
                    {
                        continue;  //bedeutet zur nächsten index
                    }
                   
                    users.Add(r.UserID);  //user id in die Liste einfuegen

                    noadd++;  //erhoeht counter wenn user in die Liste eingefьgt wurde
                    bool add = false;
                    int PID;

                    PID = Eval.GetPersonIdByUser(r.UserID);  //holt personenid raus
                    foreach (Person p in PersonList) //durchlaeuft ob der userid in der Personenliste enthalten ist
                    {
                        if (p.ID == PID) //ist der id vorhanden setzt die Variable add auf true;
                        {
                            add = true;
                        }
                    }//end foreach

                    foreach (PersonCombo c in ComboList)
                    {
                        if (c.ContainsID(PID))
                        {
                            add = true;
                        }
                    }//end foreach

                    if (add) //ist der personen id vorhanden sprich add == true
                    {
                        int yr = 0;
                        int xr = 0;


                        double cnt = 0;
                        double val = 0;


                        if (v.GetResultByUserID(r.UserID) != null)//ob resultUserId in der liste 
                        {
                            foreach (Result vres in v.Results) //durchlaeuft vertikale Ergebnisse
                            {
                                //might be a combo, get average of multiple results
                                if (vres.UserID == r.UserID)
                                {
                                    cnt++;
                                    val += vres.SelectedAnswer;
                                }
                            }
                            //MessageBox.Show("[vertical]\t" + r.UserID + "\t" + val + "/" + cnt);
                            Console.WriteLine("[vertical]\t" + r.UserID + "\t" + val + "/" + cnt);
                            yr = (int)Math.Round(val / cnt, 0, MidpointRounding.AwayFromZero);
                          
                        }
                        else
                        {
                            continue;
                        }

                        cnt = 0;
                        val = 0;

                        //average for xr
                        foreach (Result rres in h.Results)
                        {
                            //might be a combo, get average of multiple results
                            if (rres.UserID == r.UserID)
                            {
                                cnt++;
                                val += rres.SelectedAnswer;
                            }
                        }
                        //MessageBox.Show("[horizontal]\t" + r.UserID + "\t" + val + "/" + cnt);
                        Console.WriteLine("[horizontal]\t" + r.UserID + "\t" + val + "/" + cnt);
                        xr = (int)Math.Round(val / cnt, 0, MidpointRounding.AwayFromZero);
                        //MessageBox.Show("xr :" + xr + "   ---   yr :" + yr);

                        //int xr = r.SelectedAnswer;

                        if (xr > 4 || yr > 4 || xr < 0 || yr < 0) continue;
                        resultArray25[xr, yr]++;
                      
                        
                        #region 2x2Matrix
                            int sxr = 0, syr = 0;
                            bool ok = true;
                            //int wert1 = 0;
                            //int wert2 = 0;

                            if (yr <= matrix1) { syr = 0; }
                            else if (yr > matrix1) { syr = 1; }
                            else ok = false;

                            if (xr <= matrix1) { sxr = 0; }
                            else if (xr > matrix1) { sxr = 1; }
                            else ok = false;

                            /*if (this.Precision==2)
                            {
                            
                            
                            }*/

                            if (ok)  resultArray8[sxr, syr]++;
                        #endregion

                        #region 3x3Matrix
                        /*if (this.Precision == 0)
                        {
                            
                        }*/

                        if (yr <= matrix1) yr = 0;
                        else if (yr > matrix1 && yr < matrix2) yr = 1;
                        else if (yr >= matrix2) yr = 2;
                        else continue;

                        if (xr <= matrix1) xr = 0;
                        else if (xr > matrix1 && xr < matrix2) xr = 1;
                        else if (xr >= matrix2) xr = 2;
                        else continue;

                        resultArray[xr, yr]++;
                        #endregion


                        counter++;
                    }//end if(add)
                }//end foreach Results


                for (int n = 0; n < 3; n++)
                {
                    for (int m = 0; m < 3; m++)
                    {
                        resultArray[n, m] = Math.Round(((resultArray[n, m] / counter) * 100d), 0);

                        if (resultArray[n, m] > highest)
                        {
                            highest = resultArray[n, m];
                        }
                    }
                }
                for (int n = 0; n < 5; n++)
                {
                    for (int m = 0; m < 5; m++)
                    {
                        resultArray25[n, m] = Math.Round(((resultArray25[n, m] / counter) * 100d), 0);

                        if (resultArray25[n, m] > highest25)
                        {
                            highest25 = resultArray25[n, m];
                        }
                    }
                }
                for (int n = 0; n < 2; n++)
                {
                    for (int m = 0; m < 2; m++)
                    {
                        resultArray8[n, m] = Math.Round(((resultArray8[n, m] / counter) * 100d), 0);
                        //MessageBox.Show("resultArray:"+resultArray8[n, m].ToString());
                        if (resultArray8[n, m] > highest8)
                        {
                            highest8 = resultArray8[n, m];
                        }
                    }
                }


                if (ComboList.Length != 0)
                {
                    SphereColor1 = ComboList[0].Color1;
                    SphereColor2 = ComboList[0].Color2;
                }
                else
                {
                    SphereColor1 = PersonList[0].Color1;
                    SphereColor2 = PersonList[0].Color2;
                }
            }

            #endregion

            #region computearrays
            if (GlobalRef)
            {

                double[,] GresultArray = new double[3, 3];
                double[,] GresultArray25 = new double[5, 5];
                double[,] GresultArray8 = new double[2, 2];

                for (int Gri = 0; Gri < 3; Gri++)
                    for (int Gro = 0; Gro < 3; Gro++)
                        GresultArray[Gri, Gro] = 0d;

                for (int Gri = 0; Gri < 2; Gri++)
                    for (int Gro = 0; Gro < 2; Gro++)
                        GresultArray8[Gri, Gro] = 0d;

                for (int Gri = 0; Gri < 5; Gri++)
                    for (int Gro = 0; Gro < 5; Gro++)
                        GresultArray25[Gri, Gro] = 0d;

                double Gcounter = 0;
                double Gnoadd = 0;

                double Ghighest = 0;
                double Ghighest25 = 0;
                double Ghighest8 = 0;

                if (h != null && v != null && (PersonList.Length != 0 || ComboList.Length != 0))
                {
                    Question Gh = Eval.Global.GetQuestion(h, eval);
                    Question Gv = Eval.Global.GetQuestion(v, eval);

                    foreach (Result Gr in Gh.Results)
                    {
                        Gnoadd++;
                        bool Gadd = false;
                        int GPID;

                        GPID = Eval.GetPersonIdByUser(Gr.UserID);
                        foreach (Person Gp in PersonList)
                            if (Gp.ID == GPID)
                                Gadd = true;

                        foreach (PersonCombo Gc in ComboList)
                            if (Gc.ContainsID(GPID))
                                Gadd = true;

                        if (Gadd)
                        {
                            int Gyr;

                            if (Gv.GetResultByUserID(Gr.UserID) != null)
                                Gyr = Gv.GetResultByUserID(Gr.UserID).SelectedAnswer;
                            else
                                continue;

                            int Gxr = Gr.SelectedAnswer;

                            if (Gxr > 4 || Gyr > 4 || Gxr < 0 || Gyr < 0) continue;
                            GresultArray25[Gxr, Gyr]++;

                            int sGxr = 0, sGyr = 0;
                            bool ok = true;

                            if (Gyr == 0 || Gyr == 1) sGyr = 0;
                            else if (Gyr == 2 || Gyr == 3 || Gyr == 4) sGyr = 1;
                            else ok = false;

                            if (Gxr == 0 || Gxr == 1) sGxr = 0;
                            else if (Gxr == 2 || Gxr == 3 || Gxr == 4) sGxr = 1;
                            else ok = false;

                            if (ok) GresultArray8[sGxr, sGyr]++;

                            if (Gyr == 0 || Gyr == 1) Gyr = 0;
                            else if (Gyr == 2) Gyr = 1;
                            else if (Gyr == 3 || Gyr == 4) Gyr = 2;
                            else continue;

                            if (Gxr == 0 || Gxr == 1) Gxr = 0;
                            else if (Gxr == 2) Gxr = 1;
                            else if (Gxr == 3 || Gxr == 4) Gxr = 2;
                            else continue;

                            GresultArray[Gxr, Gyr]++;



                            Gcounter++;
                        }
                    }


                    for (int n = 0; n < 3; n++)
                    {
                        for (int m = 0; m < 3; m++)
                        {
                            GresultArray[n, m] = Math.Round(((GresultArray[n, m] / Gcounter) * 100d), 0);

                            if (GresultArray[n, m] > Ghighest)
                                Ghighest = GresultArray[n, m];
                        }
                    }
                    for (int n = 0; n < 5; n++)
                    {
                        for (int m = 0; m < 5; m++)
                        {
                            GresultArray25[n, m] = Math.Round(((GresultArray25[n, m] / Gcounter) * 100d), 0);

                            if (GresultArray25[n, m] > Ghighest25)
                                Ghighest25 = GresultArray25[n, m];
                        }
                    }
                    for (int n = 0; n < 2; n++)
                    {
                        for (int m = 0; m < 2; m++)
                        {
                            GresultArray8[n, m] = Math.Round(((GresultArray8[n, m] / Gcounter) * 100d), 0);

                            if (GresultArray8[n, m] > Ghighest8)
                                Ghighest8 = GresultArray8[n, m];
                        }
                    }
                }//end gloref


                for (int n = 0; n < 3; n++)
                {
                    for (int m = 0; m < 3; m++)
                    {
                        resultArray[n, m] = resultArray[n, m] - GresultArray[n, m];

                        if (Math.Abs(resultArray[n, m]) > highest)
                            highest = resultArray[n, m];
                    }
                }

                for (int n = 0; n < 5; n++)
                {
                    for (int m = 0; m < 5; m++)
                    {
                        resultArray25[n, m] = resultArray25[n, m] - GresultArray25[n, m];

                        if (Math.Abs(resultArray25[n, m]) > highest25)
                            highest25 = resultArray25[n, m];
                    }
                }

                for (int n = 0; n < 2; n++)
                {
                    for (int m = 0; m < 2; m++)
                    {
                        resultArray8[n, m] = resultArray8[n, m] - GresultArray8[n, m];

                        if (Math.Abs(resultArray8[n, m]) > highest8)
                            highest8 = resultArray8[n, m];
                    }
                }
            }

            #endregion

            #region draw07

            s.DefaultElement.Color = SphereColor1;
            s.DefaultElement.SecondaryColor = SphereColor2;

            bc.LegendBox.Visible = false;
            bc.XAxis.Label.Text = dnc.XLabel;
            bc.XAxis.ClearValues = true;

            bc.YAxis.Label.Text = dnc.YLabel;
            bc.YAxis.InvertScale = true;
            bc.YAxis.ClearValues = true;

            if (Invert)
            {
                bc.XAxis.InvertScale = true;
                bc.YAxis.InvertScale = false;
            }

            if (InvertY)
            {
                bc.YAxis.InvertScale = false;
            }

            if (this.Precision == SingleMatrix.PRECISION_9)
            {
                bc.XAxis.Maximum = bc.YAxis.Maximum = 6;
                bc.XAxis.Interval = 2;
            }
            else if (this.Precision == SingleMatrix.PRECISION_25)
            {
                bc.XAxis.Maximum = 6;
                bc.YAxis.Maximum = 6;
                bc.XAxis.Interval = 1;
            }
            else if (this.Precision == SingleMatrix.PRECISION_4)
            {
                bc.XAxis.Maximum = 6;
                bc.YAxis.Maximum = 6;
                bc.XAxis.Interval = 3;
            }

            bc.Title = "";

            int chartwid = width;  // (int)((((float)width) / 100f) * bc.ChartArea.WidthPercentage);
            int charthei = height; // (int)((((float)height) / 100f) * bc.ChartArea.HeightPercentage);

            bc.DefaultSeries.EmptyElement.Mode = EmptyElementMode.TreatAsZero;

            if (h != null && v != null && (PersonList.Length != 0 || ComboList.Length != 0))
            {
                switch (this.Precision)
                {
                    case SingleMatrix.PRECISION_4:
                        bc.MaximumBubbleSize = (int)((Math.Min(chartwid, charthei) / 2) * 0.8);
                        
                        for (int n = 0; n < 2; n++) 
                        {
                            for (int m = 0; m < 2; m++)
                            {
                                float radius = (((float)resultArray8[n, m]) / ((float)highest8)) * 1f;

                                //circle
                                float dx = 0, dy = 0;
                                if (n == 0) dx = 4.5f;
                                if (n == 1) dx = 1.5f;

                                if (m == 0) dy = 1.5f;
                                if (m == 1) dy = 4.5f;

                                Element e = new Element();
                                e.XValue = (double)(offset + dx);
                                e.YValue = (double)(offset + dy);

                                if (radius == 0) radius = 0.01f;

                                e.BubbleSize = radius;


                                if (Legend)
                                {
                                    e.SmartLabel.Text = resultArray8[n, m].ToString() + "%";
                                    e.SmartLabel.Alignment = LabelAlignment.Center;

                                    e.ShowValue = true;
                                }

                                Console.WriteLine(e.SmartLabel.Text + " .... " + e.BubbleSize);


                                s.Elements.Add(e);

                                // GraphicTools.Sphere((float)(offset + dx), (float)(offset + dy), radius, SphereColor1, SphereColor2, g);

                                // if (Legend)
                                //     g.DrawString(resultArray[n, m].ToString() + "%", f2, black, offset + dx - width / 25, offset + dy - width / 50);
                            }
                        }
                        break;


                    case SingleMatrix.PRECISION_9:

                        bc.MaximumBubbleSize = (int)((Math.Min(chartwid, charthei) / 3) * 0.8);

                        for (int n = 0; n < 3; n++)
                        {
                            for (int m = 0; m < 3; m++)
                            {
                                float radius = (((float)resultArray[n, m]) / ((float)highest)) * 1f;
                                
                                //circle
                                float dx = 0, dy = 0;
                                if (n == 0) dx = 5f;
                                if (n == 1) dx = 3f;
                                if (n == 2) dx = 1f;

                                if (m == 0) dy = 1f;
                                if (m == 1) dy = 3f;
                                if (m == 2) dy = 5f;

                                Element e = new Element();
                                e.XValue = (double)(offset + dx);
                                e.YValue = (double)(offset + dy);
                                
                                if (radius == 0) radius = 0.01f;
                                
                                e.BubbleSize = radius;

                                
                                if (Legend)
                                {
                                    e.SmartLabel.Text = resultArray[n, m].ToString() + "%";
                                    e.SmartLabel.Alignment = LabelAlignment.Center;
                                    
                                    e.ShowValue = true;
                                    
                                }

                                Console.WriteLine(e.SmartLabel.Text + " .... " + e.BubbleSize);


                                s.Elements.Add(e);

                                // GraphicTools.Sphere((float)(offset + dx), (float)(offset + dy), radius, SphereColor1, SphereColor2, g);

                                // if (Legend)
                                //     g.DrawString(resultArray[n, m].ToString() + "%", f2, black, offset + dx - width / 25, offset + dy - width / 50);
                            }
                        }
                        break;

                    case SingleMatrix.PRECISION_25:


                        bc.MaximumBubbleSize = (int)((Math.Min(chartwid, charthei) / 5) * 0.7);

                        for (int n = 0; n < 5; n++)
                        {
                            for (int m = 0; m < 5; m++)
                            {
                                //float radius = (float)((0.7f * x) / (float)highest25) * (float)resultArray25[n, m];

                                float radius = (((float)resultArray25[n, m]) / ((float)highest)) * 1f;

                                //float bsize = 500f;

                                //float ver = ((float)Math.Min(this.width, this.height)) / bsize;

                                //radius *= ver;

                                //circle
                                float dx = 0, dy = 0;
                                if (n == 0) dx = 5f;
                                if (n == 1) dx = 4f;
                                if (n == 2) dx = 3f;
                                if (n == 3) dx = 2f;
                                if (n == 4) dx = 1f;

                                if (m == 0) dy = 1f;
                                if (m == 1) dy = 2f;
                                if (m == 2) dy = 3f;
                                if (m == 3) dy = 4f;
                                if (m == 4) dy = 5f;

                                Element e = new Element();
                                e.XValue = (double)(offset + dx);
                                e.YValue = (double)(offset + dy);
                                if (radius == 0) radius = 0.01f;
                                e.BubbleSize = radius;
                                //e.Volume = radius;
                                
                                if (Legend)
                                {
                                    e.SmartLabel.Text = resultArray25[n, m].ToString() + "%";
                                    e.SmartLabel.Alignment = LabelAlignment.Center;
                                    e.ShowValue = true;
                                }

                                s.Elements.Add(e);
                            }
                        }
                        break;
                }
            }
            #endregion

            sc.Add(s);

            if (this.DrawArrow)
            {
                AxisMarker hor = new AxisMarker();
                hor.Label.Text = "";
                hor.Line.EndCap = LineCap.ArrowAnchor;
                hor.Line.StartCap = LineCap.ArrowAnchor;
                hor.Line.Width = 3;
                hor.Line.Color = ArrowColor;
                hor.Value = 3f;
                hor.Line.AnchorCapScale = 50;

                bc.XAxis.Markers.Add(hor);
                bc.YAxis.Markers.Add(hor);

                bc.Paint += new PaintEventHandler(bc_Paint);
            }

            bc.SeriesCollection.Add(sc);

            if (this.Style != SingleMatrix.STYLE_V07)
            {
                Bitmap bg = new Bitmap(width, height);

                switch (this.Style)
                {
                    case SingleMatrix.STYLE_CONE: 
                        bg = CreateCone(width, height);
                        break;

                    case SingleMatrix.STYLE_4GRADIENTS:
                        bg = Create4Grad(width, height);
                        break;

                    case SingleMatrix.STYLE_BAR:
                        bg = CreateBar(width, height);
                        break;

                    case SingleMatrix.STYLE_V05:
                        bg = CreateV05(width, height);
                        break;

                    case SingleMatrix.STYLE_4GRADSIMPLE:
                        bg = Create4Grad(width, height);
                        break;

                    case SingleMatrix.STYLE_V05SIMPLE:
                        bg = CreateV05(width, height);
                        break;

                    case SingleMatrix.STYLE_4GRAD5GRID:
                        bg = Create4Grad(width, height);
                        break;

                    case SingleMatrix.STYLE_GRAD5GRID:
                        bg = CreateGrad(width, height);
                        break;

                }

                string fn = Path.GetTempFileName();
                bg.Save(fn, ImageFormat.Png);
                bc.ChartArea.Background = new Background(fn, BackgroundMode.ImageStretch);

                bc.YAxis.Line.Color = bc.XAxis.Line.Color = Color.Transparent;
                bc.XAxis.ShowGrid = bc.YAxis.ShowGrid = false;
                bc.XAxis.AlternateGridBackground.Color = bc.YAxis.AlternateGridBackground.Color = Color.Transparent;
            }

            if (this.Precision == SingleMatrix.PRECISION_25)
            {
                bc.XAxis.Minimum = bc.YAxis.Minimum = 0.5;
                bc.XAxis.Maximum = bc.YAxis.Maximum = 5.5;
            }

            bc.Application = "itcIidhdhyk+bW1OOBTArpfNOr3GopKuOit20bU6/G4MlNN6vnk4wkfGB+NlXC+EWdY1Rm4vJ0qKOQOmw7d7gw==";

            bc.DrawToBitmap(OutputImage, new Rectangle(0, 0, OutputImage.Width, OutputImage.Height));

            bc.Dispose();
        }


        void bc_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Chart bc = (Chart)sender;

            Rectangle cr = bc.ChartArea.GetRectangle();

            //middle

            DrawArrow07(g, new Point(cr.X, cr.Y + cr.Height / 2), Direction.Left);
            DrawArrow07(g, new Point(cr.X + cr.Width, cr.Y + cr.Height / 2), Direction.Right);
            DrawArrow07(g, new Point(cr.X + cr.Width / 2, cr.Y), Direction.Up);
            DrawArrow07(g, new Point(cr.X + cr.Width / 2, cr.Y + cr.Height), Direction.Down);
        }

        public enum Direction { Left, Right, Up, Down}

        private void DrawArrow07(Graphics g, Point p, Direction d)
        {
            int wid = 10;
            int hei = 10;

            Point[] poly = new Point[0];

            switch (d)
            {
                case Direction.Left:
                    poly = new Point[] { p, new Point(p.X + wid, p.Y - hei/2), new Point(p.X + wid, p.Y + hei/2)};
                    break;

                case Direction.Right:
                    poly = new Point[] { p, new Point(p.X - wid, p.Y - hei / 2), new Point(p.X - wid, p.Y + hei / 2) };
                    break;

                case Direction.Up:
                    poly = new Point[] { p, new Point(p.X + wid / 2, p.Y + hei), new Point(p.X - wid / 2, p.Y + hei) };
                    break;

                case Direction.Down:
                    poly = new Point[] { p, new Point(p.X - wid / 2, p.Y - hei), new Point(p.X + wid / 2, p.Y - hei) };
                    break;
            }
            
            
            g.FillPolygon(new SolidBrush(ArrowColor), poly);
        }

		public override void Compute()
		{
            if (Design == SingleMatrix.Victor2006)
                Compute06();
            else
                Compute07();
		}

		public override void Save(string name, string path)
		{
			//
			Question BaseHorizontal = h;
			Question BaseVertical   = v;
			
			Question[] all = new Question[2];
			all[0] = h;
			all[1] = v;

			//cross?
			Evaluation seval;
			if (CrossTargets(all))
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

//				Console.WriteLine("td=" + td.Name + "; rcount=" + td.ResultCount);

				h = td.GetQuestion(BaseHorizontal, Eval);
				v = td.GetQuestion(BaseVertical, Eval);

				//Console.WriteLine("h=" + h + ";v=" + v);

				Compute();

				FileStream myFileOut = new FileStream(path + "\\" + SystemTools.Savable(name + " ("+td.Name+").png"), FileMode.Create );
				OutputImage.Save( myFileOut, ImageFormat.Png );
				myFileOut.Close();
			}

			seval = null;
			OutputImage = null;
		}

		public override void EditDialog()
		{
			OutputFormSingleMatrix ofsm = new OutputFormSingleMatrix(eval, false, this);
			ofsm.ShowDialog();
		}


        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_PercentMatrix(eval, this);
        }

	}
}
