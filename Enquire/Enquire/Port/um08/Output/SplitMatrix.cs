using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using dotnetCHARTING.WinForms;
using umfrage2._2007;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{
    [Serializable]
    public class SplitMatrix : Output
    {
        public int Format;
        public bool Small;

        public Question[] xq;
        public Question[] yq;

        public Color ArrowColor = Color.Orange;

        [NonSerialized]
        private int workHeight;
        [NonSerialized]
        private int workWidth;
        [NonSerialized]
        private int offset;
        [NonSerialized]
        private float x;
        [NonSerialized]
        private float y;
        [NonSerialized]
        private Brush black;
        [NonSerialized]
        private Brush red;
        [NonSerialized]
        private Color arrow;
        [NonSerialized]
        private Pen white;
        [NonSerialized]
        private Font f1;
        [NonSerialized]
        private Font f2;
        [NonSerialized]
        private Font f3;
        [NonSerialized]
        private Pen arrowPen;
        [NonSerialized]
        private Brush arrowBrush;
        [NonSerialized]
        private float radius;

        [NonSerialized]
        Bitmap Table;

        public Color BackColorA;
        public Color BackColorB;
        public Color BackColorC;
        public Color BackColorD;

        public int Design;
        public DNCSettings dnc;

        public bool Invert;
        public bool InvertLog;
        public string Skala;
        public int SkalaX;
        public int SkalaY;

        public SplitMatrix(Evaluation eval)
        {
            this.eval = eval;
            xq = new Question[0];
            yq = new Question[0];
            Format = MultiMatrix.FORMAT_SCALED;

            BackColorA = Color.DarkGray;
            BackColorB = Color.Gray;
            BackColorC = Color.DarkGray;
            BackColorD = Color.LightGray;

            this.Design = Output.Victor2007;
            dnc = new DNCSettings();

            Invert = false;
            InvertLog = false;

            width = height = 500;
            SkalaX = 1;
            SkalaY = 5;
        }


        public override void LoadGlobalQ()
        {
            LoadQArray(xq);
            LoadQArray(yq);
        }

        public override void LoadTargetQ(TargetData td)
        {
            LoadTQArray(td, xq);
            LoadTQArray(td, yq);
        }

        /// <summary>
        /// serialization functions
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            LoadSerData(info, ctxt);

            Question.SetMultipartArray(xq, Multipart);
            Question.SetMultipartArray(yq, Multipart);

            info.AddValue("xq", this.xq);
            info.AddValue("yq", this.yq);
            info.AddValue("Format", this.Format);
            info.AddValue("Small", this.Small);

            info.AddValue("BackColorA", BackColorA);
            info.AddValue("BackColorB", BackColorB);
            info.AddValue("BackColorC", BackColorC);
            info.AddValue("BackColorD", BackColorD);

            info.AddValue("Design", this.Design);
            info.AddValue("dnc", this.dnc);

            info.AddValue("ArrowColor", ArrowColor);
            info.AddValue("Invert", Invert);
            info.AddValue("InvertLog", InvertLog);
            info.AddValue("Skala",this.Skala);
        }

        public SplitMatrix(SerializationInfo info, StreamingContext ctxt)
        {
            base.ReadSerData(info, ctxt);

            this.xq = (Question[])info.GetValue("xq", typeof(Question[]));
            this.yq = (Question[])info.GetValue("yq", typeof(Question[]));
            this.Format = info.GetInt32("Format");
            this.Small = info.GetBoolean("Small");

            try
            {
                BackColorA = (Color)info.GetValue("BackColorA", typeof(Color));
                BackColorB = (Color)info.GetValue("BackColorB", typeof(Color));
                BackColorC = (Color)info.GetValue("BackColorC", typeof(Color));
                BackColorD = (Color)info.GetValue("BackColorD", typeof(Color));
            }
            catch
            {
                BackColorA = Color.DarkGray;
                BackColorB = Color.Gray;
                BackColorC = Color.DarkGray;
                BackColorD = Color.LightGray;
            }

            try
            {
                Design = info.GetInt32("Design");
                dnc = (DNCSettings)info.GetValue("dnc", typeof(DNCSettings));
            }
            catch
            {
                Design = Victor2006;
                dnc = new DNCSettings();
            }

            try { this.ArrowColor = (Color)info.GetValue("ArrowColor", typeof(Color)); }
            catch { ArrowColor = Color.Orange; }

            try { this.Invert = info.GetBoolean("Invert"); }
            catch { Invert = false; }

            try { this.InvertLog = info.GetBoolean("InvertLog"); }
            catch { InvertLog = false; }
        }

        public void ComputeScaled(Graphics g)
        {
            BackgroundScaled(g);

            //draw orientation lines
            for (int i = 0; i < 10; i++) // i < 10
            {
                g.DrawLine(white, offset + x * i, offset + 0, offset + x * i, offset + y * 10);
                g.DrawLine(white, offset + 0, offset + y * i, offset + x * 10, offset + y * i);
            }

            //draw arrow lines
            g.DrawLine(arrowPen, offset + x * 4, offset + 0, offset + x * 4, offset + y * 10);
            g.DrawLine(arrowPen, offset + 0, offset + y * 6, offset + x * 10, offset + y * 6);

            //draw arrow heads
            int headsize = workWidth / 50;
            //top
            g.FillPolygon(arrowBrush, new PointF[] {new PointF(offset + x*4-headsize, offset + 0), 
													  new PointF(offset + x*4+headsize, offset + 0),
													  new PointF(offset + x*4, offset -headsize)});
            //bottom
            g.FillPolygon(arrowBrush, new PointF[] {new PointF(offset + x*4-headsize, offset + y*10), 
													  new PointF(offset + x*4+headsize, offset + y*10),
													  new PointF(offset + x*4, offset + y*10 + headsize)});
            // left
            g.FillPolygon(arrowBrush, new PointF[] {new PointF(offset + 0, offset + y*6-headsize), 
													  new PointF(offset + 0, offset + y*6+headsize),
													  new PointF(offset -headsize, offset + y*6)});
            //right
            g.FillPolygon(arrowBrush, new PointF[] {new PointF(offset + x*10, offset + y*6-headsize), 
													  new PointF(offset + x*10, offset + y*6+headsize),
													  new PointF(offset + x*10+headsize, offset + y*6)});

            //text

            int xto = width / 40;
            int yto = height / 80;
            //5
            g.DrawString("5", f1, black, offset - xto, offset + y * 10 + yto);
            //4
            g.DrawString("4", f1, black, offset - xto, offset + y * 9);
            g.DrawString("4", f1, black, offset + x, offset + y * 10 + yto);
            //3
            g.DrawString("3", f1, black, offset - xto, offset + y * 8);
            g.DrawString("3", f1, black, offset + 2 * x, offset + y * 10 + yto);
            //2
            g.DrawString("2", f1, black, offset - xto, offset + y * 6);
            g.DrawString("2", f1, black, offset + 4 * x, offset + y * 10 + yto);
            //1,66
            g.DrawString("1,66", f1, black, offset - xto * 3, offset + y * 4);
            g.DrawString("1,66", f1, black, offset + 6 * x, offset + y * 10 + yto);
            //1,33
            g.DrawString("1,33", f1, black, offset - xto * 3, offset + y * 2);
            g.DrawString("1,33", f1, black, offset + 8 * x, offset + y * 10 + yto);
            //1
            g.DrawString("1", f1, black, offset - xto, offset);
            g.DrawString("1", f1, black, offset + 10 * x, offset + y * 10 + yto);

            //finally, content

            radius = width / 30;

            DataScaled(g);
        }


        public void ComputeBasic(Graphics g)
        {
            BackgroundBasic(g);

            //draw orientation lines
            for (int i = 0; i < 8; i++) // i < 10
            {
                g.DrawLine(white, offset + x * i, offset + 0, offset + x * i, offset + y * 8);
                g.DrawLine(white, offset + 0, offset + y * i, offset + x * 8, offset + y * i);
            }

            g.DrawLine(arrowPen, offset + x * 4, offset + 0, offset + x * 4, offset + y * 8);
            g.DrawLine(arrowPen, offset + 0, offset + y * 4, offset + x * 8, offset + y * 4);

            //draw arrow heads
            int headsize = workWidth / 50;
            //top
            g.FillPolygon(arrowBrush, new PointF[] {new PointF(offset + x*4-headsize, offset + 0), 
													   new PointF(offset + x*4+headsize, offset + 0),
													   new PointF(offset + x*4, offset -headsize)});
            //bottom
            g.FillPolygon(arrowBrush, new PointF[] {new PointF(offset + x*4-headsize, offset + y*8), 
													   new PointF(offset + x*4+headsize, offset + y*8),
													   new PointF(offset + x*4, offset + y*8 + headsize)});
            // left
            g.FillPolygon(arrowBrush, new PointF[] {new PointF(offset + 0, offset + y*4-headsize), 
													   new PointF(offset + 0, offset + y*4+headsize),
													   new PointF(offset -headsize, offset + y*4)});
            //right
            g.FillPolygon(arrowBrush, new PointF[] {new PointF(offset + x*8, offset + y*4-headsize), 
													   new PointF(offset + x*8, offset + y*4+headsize),
													   new PointF(offset + x*8+headsize, offset + y*4)});

            //text

            radius = width / 30;

            int xto = width / 40;
            int yto = height / 80;
            //5
            g.DrawString("5", f1, black, offset - xto, offset + y * 8 + yto);
            //4
            g.DrawString("4", f1, black, offset - xto, offset + y * 6);
            g.DrawString("4", f1, black, offset + 2 * x, offset + y * 8 + yto);
            //3
            g.DrawString("3", f1, black, offset - xto, offset + y * 4f);
            g.DrawString("3", f1, black, offset + 4f * x, offset + y * 8 + yto);
            //2
            g.DrawString("2", f1, black, offset - xto, offset + y * 2);
            g.DrawString("2", f1, black, offset + 6f * x, offset + y * 8 + yto);
            //1
            g.DrawString("1", f1, black, offset - xto, offset + y * 0);
            g.DrawString("1", f1, black, offset + 8 * x, offset + y * 8 + yto);

            //finally, content

            DataBasic(g);
        }

        public void ComputeScaledSmall(Graphics g)
        {
            offset = 0;
            workHeight = OutputImage.Height - 2 * offset;
            workWidth = OutputImage.Width - 2 * offset;
            SetXY();

            radius = width / 20;
            f2 = new Font("Arial", width / 18, FontStyle.Bold, GraphicsUnit.Pixel);

            BackgroundScaled(g);
            DataScaled(g);
        }

        public void ComputeBasicSmall(Graphics g)
        {
            offset = 0;
            workHeight = OutputImage.Height - 2 * offset;
            workWidth = OutputImage.Width - 2 * offset;
            SetXY();

            radius = width / 20;
            f2 = new Font("Arial", width / 18, FontStyle.Bold, GraphicsUnit.Pixel);

            BackgroundBasic(g);
            DataBasic(g);

        }

        private void SetXY()
        {
            float fact;

            if (Format == Output.FORMAT_BASIC)
                fact = 8;
            else fact = 10;

            // fill space rectangles
            if (workHeight > workWidth)
            {
                //x = (workWidth/10);
                //y = (workWidth/10);
                x = (workWidth / fact);
                y = (workWidth / fact);
            }
            else
            {
                //x = (workHeight/10);
                //y = (workHeight/10);
                x = (workHeight / fact);
                y = (workHeight / fact);
            }
        }

        private void DataBasic(Graphics g)
        {
            float scale = (8 / 4f) * x;

            int[] dimensions = new int[2 + CombinedPersons.Length];
            dimensions[0] = 100;
            dimensions[1] = 300;
            for (int i = 2; i < dimensions.Length; i++) dimensions[i] = 50;

            string[] headers = new string[2 + CombinedPersons.Length];
            headers[0] = "Nummer";
            headers[1] = "Frage";
            for (int i = 2; i < headers.Length; i++) headers[i] = CombinedPersons[i - 2].Short;

            Color[] RowColors = new Color[2 + CombinedPersons.Length];
            RowColors[0] = RowColors[1] = Color.Black;
            for (int i = 2; i < RowColors.Length; i++) RowColors[i] = CombinedPersons[i - 2].Color2;

            ArrayList tab = new ArrayList();

            for (int n = 0; n < xq.Length; n++)
            {
                string[] rowx = new string[2 + CombinedPersons.Length];
                rowx[0] = (n + 1).ToString();
                rowx[1] = eval.getTextOverload((Question)xq[n]);

                string[] rowy = new string[2 + CombinedPersons.Length];
                rowy[0] = (n + 1).ToString();
                rowy[1] = eval.getTextOverload((Question)yq[n]);

                int j = 2;

                foreach (PersonSetting person in CombinedPersons)
                {
                    //					Console.WriteLine(n + "; " + person);

                    float avgx = ((Question)xq[n]).GetAverageByPerson(Eval, person);
                    float avgy = ((Question)yq[n]).GetAverageByPerson(Eval, person);

                    if (float.IsNaN(avgx) || float.IsNaN(avgy))
                    {
                        rowx[j] = "";
                        rowy[j++] = "";
                        continue;
                    }

                    rowx[j] = "" + Math.Round(avgx + 1, 1);
                    rowy[j++] = "" + Math.Round(avgy + 1, 1);

                    avgx *= scale;
                    avgy *= scale;

                    //x: best = highest!
                    avgx = workWidth - avgx;

                    // draw point
                    GraphicTools.Sphere(offset + avgx, offset + avgy, radius, person.Color1, person.Color2, g);

                    //draw string (question n)
                    g.DrawString((n + 1).ToString(), f2, black, offset + avgx - radius / 2 - 2, offset + avgy - radius / 2 - 2);
                }
                tab.Add(rowx);
                tab.Add(rowy);
            }
            Table = GraphicTools.ImageTable(tab, dimensions, headers, RowColors);
        }

        private void DataScaled(Graphics g)
        {
            float scale1 = x * 6;
            float scale2 = x * 2;
            float scale3 = x;

            int[] dimensions = new int[2 + CombinedPersons.Length];
            dimensions[0] = 100;
            dimensions[1] = 300;
            for (int i = 2; i < dimensions.Length; i++) dimensions[i] = 50;

            string[] headers = new string[2 + CombinedPersons.Length];
            headers[0] = "Nummer";
            headers[1] = "Frage";
            for (int i = 2; i < headers.Length; i++) headers[i] = CombinedPersons[i - 2].Short;

            Color[] RowColors = new Color[2 + CombinedPersons.Length];
            RowColors[0] = RowColors[1] = Color.Black;
            for (int i = 2; i < RowColors.Length; i++) RowColors[i] = CombinedPersons[i - 2].Color2;

            ArrayList tab = new ArrayList();

            for (int n = 0; n < xq.Length; n++)
            {
                if (xq[n] == null || yq[n] == null) continue;

                string[] rowx = new string[2 + CombinedPersons.Length];
                rowx[0] = (n + 1).ToString();
                rowx[1] = eval.getTextOverload((Question)xq[n]);

                string[] rowy = new string[2 + CombinedPersons.Length];
                rowy[0] = (n + 1).ToString();
                rowy[1] = eval.getTextOverload((Question)yq[n]);

                int j = 2;

                foreach (PersonSetting person in CombinedPersons)
                {
                    float avgx = ((Question)xq[n]).GetAverageByPerson(Eval, person);
                    float avgy = ((Question)yq[n]).GetAverageByPerson(Eval, person);

                    if (float.IsNaN(avgx) || float.IsNaN(avgy))
                    {
                        rowx[j] = "";
                        rowy[j++] = "";
                        continue;
                    }

                    rowx[j] = "" + Math.Round(avgx + 1, 1);
                    rowy[j++] = "" + Math.Round(avgy + 1, 1);

                    if (avgx <= 1) avgx = avgx * scale1;
                    else if (avgx <= 2) avgx = scale1 + scale2 * (avgx - 1);
                    else avgx = scale1 + scale2 + scale3 * (avgx - 2);

                    if (avgy <= 1) avgy = avgy * scale1;
                    else if (avgy <= 2) avgy = scale1 + scale2 * (avgy - 1);
                    else avgy = scale1 + scale2 + scale3 * (avgy - 2);

                    //x: best = highest!
                    avgx = workWidth - avgx;

                    // draw point

                    GraphicTools.Sphere(offset + avgx, offset + avgy, radius, person.Color1, person.Color2, g);

                    //draw string (question n)
                    g.DrawString((n + 1).ToString(), f2, black, offset + avgx - radius / 2 - 2, offset + avgy - radius / 2 - 2);
                }
                tab.Add(rowx);
                tab.Add(rowy);
            }

            Table = GraphicTools.ImageTable(tab, dimensions, headers, RowColors);
        }

        private void BackgroundBasic(Graphics g)
        {
            Brush filler;
            RectangleF fillrect;
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

            g.DrawLine(arrowPen, offset + x * 4, offset + 0, offset + x * 4, offset + y * 8);
            g.DrawLine(arrowPen, offset + 0, offset + y * 4, offset + x * 8, offset + y * 4);
        }

        private void BackgroundScaled(Graphics g)
        {
            Brush filler;
            RectangleF fillrect;
            //top left
            fillrect = new RectangleF(offset, offset, x * 4, y * 6);
            filler = new LinearGradientBrush(fillrect, BackColorA, Color.White, 45, false);
            g.FillRectangle(filler, fillrect);
            //bottom left
            fillrect = new RectangleF(offset, offset + y * 6, x * 4, y * 4);
            filler = new LinearGradientBrush(fillrect, BackColorB, Color.White, 315, false);
            g.FillRectangle(filler, fillrect);
            //bottom right
            fillrect = new RectangleF(offset + x * 4, offset + y * 6, x * 6, y * 4);
            filler = new LinearGradientBrush(fillrect, BackColorC, Color.White, 225, false);
            g.FillRectangle(filler, fillrect);
            //top right
            fillrect = new RectangleF(offset + x * 4, offset, x * 6, y * 6);
            filler = new LinearGradientBrush(fillrect, BackColorD, Color.White, 135, false);
            g.FillRectangle(filler, fillrect);

            //draw arrow lines
            g.DrawLine(arrowPen, offset + x * 4, offset + 0, offset + x * 4, offset + y * 10);
            g.DrawLine(arrowPen, offset + 0, offset + y * 6, offset + x * 10, offset + y * 6);
        }

        public void Compute06()
        {
            if (width == 0 || height == 0) return;
            OutputImage = new Bitmap(width, height);
            offset = width / 15;

            workHeight = OutputImage.Height - 2 * offset;
            workWidth = OutputImage.Width - 2 * offset;

            Graphics g = Graphics.FromImage(OutputImage);

            black = new SolidBrush(Color.Black);
            red = new SolidBrush(Color.Red);

            f1 = new Font("Arial", width / 30, FontStyle.Regular, GraphicsUnit.Pixel);
            f2 = new Font("Arial", width / 25, FontStyle.Bold, GraphicsUnit.Pixel);
            f3 = new Font("Arial", width / 30, FontStyle.Bold, GraphicsUnit.Pixel);

            white = new Pen(Color.White, width / 100);

            arrow = Color.Orange;

            arrowPen = new Pen(arrow, width / 100);
            arrowBrush = new SolidBrush(arrow);

            g.Clear(Color.White);

            SetXY();

            switch (Format)
            {
                case Output.FORMAT_SCALED:
                    if (Small) ComputeScaledSmall(g);
                    else ComputeScaled(g);
                    break;

                case Output.FORMAT_BASIC:
                    if (Small) ComputeBasicSmall(g);
                    else ComputeBasic(g);
                    break;
            }
        }

        public override void Compute()
        {
            if (this.Design == Output.Victor2006) Compute06();
            else Compute07();
        }

        public void Compute07()
        {
            Compute06();

            OutputImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            Chart bc = new Chart();

            dnc.Apply(bc);

            bc.Title = this.Name;

            bc.Type = ChartType.Bubble;

            bc.DefaultSeries.Type = SeriesType.Spline;

            bc.DefaultSeries.DefaultElement.Transparency = dnc.Transparency;


            bc.Width = this.width;
            bc.Height = this.height;
            bc.Title = "";

            bc.MaximumBubbleSize = 40;
            if (Small)
            {
                bc.XAxis.ClearValues = bc.YAxis.ClearValues = true;
                bc.MaximumBubbleSize = 80;
            }

            if (Format == Output.FORMAT_SCALED)
            {
                bc.XAxis.Scale = bc.YAxis.Scale = Scale.Logarithmic;
                //bc.XAxis.LogarithmicBase = bc.YAxis.LogarithmicBase = 1.71;
                bc.XAxis.LogarithmicBase = bc.YAxis.LogarithmicBase = 4.5;
            }



            bc.MaximumBubbleSizeValue = 1;


            if (Cross == null) return;

            Question[] all = new Question[xq.Length + yq.Length];
            int li = 0;
            foreach (Question l in xq)
                all[li++] = l;
            foreach (Question l in yq)
                all[li++] = l;


            CrossTargets(all, false, false);
            
            Evaluation seval = this.CrEval;
            

            SeriesCollection sc = new SeriesCollection();

            int numr = 1;

            foreach (TargetData td in seval.CombinedTargets)
            {
                if (td == null) continue;

                if (!td.Included)
                    continue;

                if (td.Name.Equals("Global"))
                    continue;

                foreach (PersonSetting ps in CombinedPersons)
                {
                    Series s = new Series();
                    s.Name = td.ToString().Substring(td.ToString().IndexOf(",") + 1).Trim();
                    s.Name = numr + " " + s.Name;

                    for (int i = 0; i < Math.Min(xq.Length, yq.Length); i++)
                    {
                        Element e = new Element();

                        Question xxq = td.GetQuestion(xq[i], seval);
                        Question yyq = td.GetQuestion(yq[i], seval);

                        e.XValue = xxq.GetAverageByPersonAsMark(seval, ps);
                        e.YValue = yyq.GetAverageByPersonAsMark(seval, ps);

                        if (e.XValue == -1 || e.YValue == -1) continue;

                        Console.WriteLine("[splitmatrix]\thund: '"+td.ToString()+"' x=" + e.XValue + ", y=" + e.YValue);

                        if (InvertLog)
                        {
                            e.XValue = 6 - e.XValue;
                            e.YValue = 6 - e.YValue;
                        }

                        e.BubbleSize = 1;

                        string tds = td.ToString().Substring(td.ToString().IndexOf(",")+1).Trim();
                        Console.WriteLine("[splitmatrix]\tcoloring " + td.ToString() + " (=" + tds +")");
                        try
                        {
                            e.Color = (Color)eval.PieColors[tds];
                        }
                        catch 
                        {
                            Console.WriteLine("[splitmatrix]\t get pie colors failed");
                        }
                        //e.SecondaryColor = ps.Color2;
                        

                        //MessageBox.Show(td.ToString());
                        //eval.PieColors[td.];
                        
                        e.SmartLabel.Text = numr.ToString();
                        e.SmartLabel.Alignment = LabelAlignment.Center;
                        //if (!Small) e.ShowValue = true;
                        e.ShowValue = true;

                        //e.LegendEntry.Value = 

                        s.Elements.Add(e);
                    }

                    s.LegendEntry.Value = "";

                    sc.Add(s);
                }

                numr++;
            }

            //bc.XAxis.InvertScale = true;
            //bc.YAxis.InvertScale = true;

            if (InvertLog) bc.XAxis.InvertScale = bc.YAxis.InvertScale = Invert;
            else bc.XAxis.InvertScale = bc.YAxis.InvertScale = !Invert;

            bc.XAxis.Maximum = bc.YAxis.Maximum = 3;
            bc.XAxis.Minimum = bc.YAxis.Minimum = 1;

            bc.LegendBox.Visible = dnc.ShowLegend; // false;

            bc.LegendBox.Orientation = dotnetCHARTING.WinForms.Orientation.Bottom;

            //arrows

            AxisMarker hor = new AxisMarker();
            hor.Label.Text = "";
            hor.Line.EndCap = LineCap.ArrowAnchor;
            hor.Line.StartCap = LineCap.ArrowAnchor;
            hor.Line.Width = 3;
            hor.Line.Color = ArrowColor;

            if (Format != Output.FORMAT_SCALED) hor.Value = 3f;
            else hor.Value = 2f;

            hor.Line.AnchorCapScale = 50;

            hor.LegendEntry.Visible = false;

            bc.XAxis.Markers.Add(hor);
            bc.YAxis.Markers.Add(hor);

            bc.Paint += new PaintEventHandler(bc_Paint);

            //end arrows

            //precision
            bc.XAxis.NumberPrecision = bc.YAxis.NumberPrecision = 1;

            bc.SeriesCollection.Add(sc);

            if (Format == Output.FORMAT_SCALED)
            {
                bc.YAxis.ClearValues = bc.XAxis.ClearValues = true;

                for (int i = 1; i <= 5; i++)
                {
                    AxisTick at = new AxisTick(i);
                    if (InvertLog) at.Label = new dotnetCHARTING.WinForms.Label("" + (6 - i) + ",0");
                    bc.YAxis.ExtraTicks.Add(at);
                    bc.XAxis.ExtraTicks.Add(at);
                }

                AxisTick at5 = new AxisTick(4.5f);
                if (InvertLog) at5.Label = new dotnetCHARTING.WinForms.Label("1,5");
                bc.XAxis.ExtraTicks.Add(at5);
                bc.YAxis.ExtraTicks.Add(at5);
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
            if (Format != Output.FORMAT_SCALED)
            {
                DrawArrow07(g, new Point(cr.X, cr.Y + cr.Height / 2), Direction.Left);
                DrawArrow07(g, new Point(cr.X + cr.Width, cr.Y + cr.Height / 2), Direction.Right);
                DrawArrow07(g, new Point(cr.X + cr.Width / 2, cr.Y), Direction.Up);
                DrawArrow07(g, new Point(cr.X + cr.Width / 2, cr.Y + cr.Height), Direction.Down);
            }
            else
            {
                int hpos, wpos;

                bool i = Invert;
                if (InvertLog) i = !i;

                if (!i)
                {
                    hpos = (int)(((float)cr.Height) / 4.62f) * 2;
                    wpos = (int)(((float)cr.Width) / 1.75f);
                }
                else
                {
                    hpos = (int)(((float)cr.Height) / 1.75f);
                    wpos = (int)(((float)cr.Width) / 2.31f);
                }

                DrawArrow07(g, new Point(cr.X, cr.Y + hpos), Direction.Left);
                DrawArrow07(g, new Point(cr.X + cr.Width, cr.Y + hpos), Direction.Right);
                DrawArrow07(g, new Point(cr.X + wpos, cr.Y), Direction.Up);
                DrawArrow07(g, new Point(cr.X + wpos, cr.Y + cr.Height), Direction.Down);
            }
        }

        public enum Direction { Left, Right, Up, Down }

        private void DrawArrow07(Graphics g, Point p, Direction d)
        {
            int wid = 10;
            int hei = 10;

            Point[] poly = new Point[0];

            switch (d)
            {
                case Direction.Left:
                    poly = new Point[] { p, new Point(p.X + wid, p.Y - hei / 2), new Point(p.X + wid, p.Y + hei / 2) };
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


        public Bitmap FullImage
        {
            get
            {
                return OutputImage;
                /*
                Bitmap ob;

                if (Table != null && !Small && this.dnc.ShowLegend)
                {
                    int wid;

                    if (OutputImage.Width > Table.Width)
                        wid = OutputImage.Width;
                    else
                        wid = Table.Width;

                    ob = new Bitmap(wid, OutputImage.Height + 30 + Table.Height);
                    Graphics g = Graphics.FromImage(ob);

                    g.Clear(Color.White);

                    g.DrawImage(OutputImage, (wid - OutputImage.Width) / 2, 0);
                    g.DrawImage(Table, (wid - Table.Width) / 2, OutputImage.Height + 29);

                    //ob.Save(path + "\\" + name + " ("+td.Name+").png", ImageFormat.Png);
                }
                else
                    ob = OutputImage;

                return ob;
                 * */
            }
        }

        public override void Save(string name, string path)
        {
            //
            Question[] BaseX = xq;
            Question[] BaseY = yq;

            Question[] all = new Question[xq.Length + yq.Length];
            int li = 0;
            foreach (Question l in xq)
                all[li++] = l;
            foreach (Question l in yq)
                all[li++] = l;

            //cross?
            
            Evaluation seval;
            
            /*
             * if (CrossTargets(all))
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
             * */
            seval = this.eval;

            foreach (TargetData td in seval.CombinedTargets)
            {
                if (!td.Included)
                    continue;

                xq = new Question[xq.Length];
                yq = new Question[yq.Length];

                int i = 0;
                foreach (Question q in BaseX)
                    xq[i++] = td.GetQuestion(q, Eval);
                i = 0;
                foreach (Question q in BaseY)
                    yq[i++] = td.GetQuestion(q, Eval);

                Compute();

                FileStream myFileOut = new FileStream(path + "\\" + SystemTools.Savable(name + " (" + td.Name + ").png"), FileMode.Create);
                FullImage.Save(myFileOut, ImageFormat.Png);
                myFileOut.Close();
            }

            seval = null;
            this.OutputImage = null;
        }

        public override void EditDialog()
        {
            //OutputFormMultiMatrix ofmm = new OutputFormMultiMatrix(eval, false, this);
            //ofmm.ShowDialog();
        }

        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_SplitMatrix(eval, false, this);
        }
    }
}
