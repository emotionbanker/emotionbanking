using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using dotnetCHARTING.WinForms;
using umfrage2;
using umfrage2._2007;
using ImageFormat = System.Drawing.Imaging.ImageFormat;
using Compucare.Enquire.Legacy.Umfrage2Lib._2007.Dialogs;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{
    /// <summary>
    /// Summary description for Gauge_h056.
    /// </summary>
    /// 
    [Serializable]
    public class Gauge_h056 : Output
    {
        public enum GaugeTypeh056 { Standard, Kombiniert, Durchschnitt }
        public GaugeTypeh056 Type = GaugeTypeh056.Standard;
        public bool Text = false;
        public Hashtable answerList = new Hashtable();
        public enum GaugeEffekt { Style1, Style2 };
        public GaugeEffekt GEffekt = GaugeEffekt.Style1;
        public bool ShowText = true;

        public bool Base = false;

        public Question BaseQ = null;

        public bool text
        {
            get
            {
                if (!Text || !ShowText) return false;
                else return true;
                //return Text;
            }
            set
            {
                Text = value;
            }
        }

        private float MinVal;
        private float MaxVal;
        private float Steps;

        public bool manuelHeight;
        public int manuelHeightValue;
        private float gridOffXRight;
        private float GridOffYTop;
        private float GridOffYBottom;

        public float GaugeOffset;

        public float GaugeHeight;

        public bool invert = false;

        public bool Percent = false;
        public int PercentValue;
        public float MaxYValue;
        public bool Opposites = false;
        public bool Antwortexte = true;
        public bool Absolutes = false;

        public bool Marker = false;

        public Question[] Questions;

        public Font Txt;

        public Color BackColor;

        public StringCollection HideAnswers;
        public List<String> AnswerOrder;

        public Hashtable PersonGroups;

        public int Design;
        public DNCSettings dnc;
        public Marker marker;
        public SortOrder sort;

        public Boolean UseManualWidth = false;
        public Int32 ManualWidth = 100;

        private float DrawAreaWidth
        {
            get
            {
                return (width - GridOffXLeft - GridOffXRight);
                /*if (!Horizontal) return (width - GridOffXLeft - GridOffXRight);
                else return (height - GridOffYTop - GridOffYBottom);*/
            }
        }

        private float DrawAreaHeight
        {
            get
            {
                return (height - GridOffYTop - GridOffYBottom);
                /*if (!Horizontal) return (height - GridOffYTop - GridOffYBottom);
                else return (width - GridOffXLeft - GridOffXRight);*/
            }
        }

        private float Step
        {
            get { return (DrawAreaWidth / Steps); }
        }

        private float StepNum
        {
            get { return ((MaxVal - MinVal) / Steps); }
        }

        private float Val
        {
            get
            {
                if (!Percent)
                    return (DrawAreaWidth / (MaxVal - MinVal));
                else
                    return ((DrawAreaWidth + 2 * GaugeOffset) / 100);
                /*if (!Horizontal)
                {
                    if (!Percent)
                        return (DrawAreaWidth / (MaxVal - MinVal));
                    else
                        return ((DrawAreaWidth + 2 * GaugeOffset) / 100);
                }
                else
                {
                    if (!Percent)
                        return (DrawAreaHeight / (MaxVal - MinVal));
                    else
                        return ((DrawAreaHeight + 2 * GaugeOffset) / 100);
                }*/
            }
        }

        private float GridX
        {
            get { return (GridOffXLeft); // if (!Horizontal) return (GridOffXLeft); else return 30;
            }
        }

        private float GridY
        {
            get
            {
                return (GridOffYTop); //if (!Horizontal) return (GridOffYTop); else return GridX; 
            }
        }

        private float GridOffXLeft
        {
            get
            {
                if (text)
                {
                    return width / 3;

                }
                else return 10;

                /*if (!Horizontal && text) return width / 3;
                else return 10;*/
            }
        }

        private float GridOffXRight
        {
            get
            {
                if (text) return width / 3;
                else return gridOffXRight;

                /*if (Horizontal && text) return width / 3;
                else return gridOffXRight;*/
            }
            set
            {
                gridOffXRight = value;
            }
        }

        public int getPercentValue()
        {
           return this.PercentValue;
        }

        public float getMaxYValue()
        {
            return this.MaxYValue;
        }

        public Gauge_h056(Evaluation eval)
		{
            this.eval = eval;
			MinVal = 1;
			MaxVal = 5;
            MaxYValue = 1;
			Steps = 8;
            manuelHeight = false;
            manuelHeightValue = 0;
			GaugeOffset = 8;
			GaugeHeight = 30;
            PercentValue = 1;
            answerList = new Hashtable();
            Antwortexte = true;
			GridOffXRight  = 40 + GaugeOffset;
			GridOffYTop    = 20;
			GridOffYBottom = 30;

			Txt = new Font("Arial", 8);

            BackColor = Color.LightGray;

            this.Design = Output.Victor2007;
            dnc = new DNCSettings();
            marker = new Marker();

            Questions = new Question[0];

            sort = SortOrder.None;

            HideAnswers = new StringCollection();
		    AnswerOrder = new List<String>();

            PersonGroups = new Hashtable();

            width = 500;
            height = 500;
		}

        public override void LoadGlobalQ()
        {
            LoadQArray(Questions);
        }

        public override void LoadTargetQ(TargetData td)
        {
            LoadTQArray(td, Questions);
        }

        /// <summary>
        /// serialization functions
        /// </summary>
        /// <param name="info"></param>
        /// <param name="ctxt"></param>
        public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            LoadSerData(info, ctxt);
            try
            {
                Question.SetMultipartArray(Questions, Multipart);

                info.AddValue("Text", this.Text);

                info.AddValue("ShowText", this.ShowText);

                info.AddValue("MinVal", this.MinVal);
                info.AddValue("MaxVal", this.MaxVal);
                info.AddValue("Steps", this.Steps);
                info.AddValue("manuelHeight", this.manuelHeight);
                info.AddValue("manuelHeightValue", this.manuelHeightValue);
                info.AddValue("MaxYValue", this.MaxYValue);
                info.AddValue("Antwortexte", this.Antwortexte);
                
                info.AddValue("gridOffYBottom", this.GridOffYBottom);
                info.AddValue("GridOffYTop", this.GridOffYTop);
                info.AddValue("GridOffXRight", this.GridOffXRight);
                info.AddValue("GaugeOffset", this.GaugeOffset);
                info.AddValue("GaugeHeight", this.GaugeHeight);
                info.AddValue("answerList", this.answerList);
                    
                info.AddValue("invert", this.invert);
                info.AddValue("Questions", this.Questions);

                info.AddValue("Percent", this.Percent);
                info.AddValue("PercentValue", this.PercentValue);

                info.AddValue("Marker", this.Marker);
                
                info.AddValue("Opposites", this.Opposites);

                info.AddValue("Txt", this.Txt);

                info.AddValue("BackColor", this.BackColor);

                info.AddValue("Design", this.Design);
                info.AddValue("dnc", this.dnc);
                info.AddValue("marker", this.marker);
                info.AddValue("HideAnswers", this.HideAnswers);
                info.AddValue("AnswerOrder", this.AnswerOrder);

                info.AddValue("sort", this.sort);

                info.AddValue("Type", this.Type);
                info.AddValue("GEffekt", this.GEffekt);

                info.AddValue("PersonGroups", this.PersonGroups);

                info.AddValue("Base", this.Base);

                info.AddValue("BaseQ", this.BaseQ);

                info.AddValue("Absolutes", this.Absolutes);

                info.AddValue("UseManualWidth", this.UseManualWidth);
                info.AddValue("ManualWidth", this.ManualWidth);
            }
            catch
            {
                Console.WriteLine("Gauge!");
            }

        }

        public Gauge_h056(SerializationInfo info, StreamingContext ctxt)
		{
			ReadSerData(info, ctxt);

			try
			{
				this.Questions = (Question[])info.GetValue("Questions", typeof(Question[]));

				try
				{
					this.text = info.GetBoolean("text");
				}
				catch
				{
					this.text = info.GetBoolean("Text");
				}
				try
				{
					this.ShowText = info.GetBoolean("ShowText");
				}
				catch
				{
					this.ShowText = true;
				}
				this.MinVal = (float)info.GetValue("MinVal", typeof(float));
				this.MaxVal = (float)info.GetValue("MaxVal", typeof(float));
				this.Steps = (float)info.GetValue("Steps", typeof(float));

                this.answerList = (Hashtable)info.GetValue("answerList", typeof(Hashtable));
                
				this.GridOffYBottom = (float)info.GetValue("gridOffYBottom", typeof(float));

				this.GridOffYTop = (float)info.GetValue("GridOffYTop", typeof(float));
				try
				{
					this.GridOffXRight = (float)info.GetValue("GridOffXRight", typeof(float));
				}
				catch
				{
					this.GridOffXRight = (float)info.GetValue("gridOffXRight", typeof(float));
				}
				//this.GridOffXRight = (float)info.GetValue("GridOffXRight", typeof(float));

				this.GaugeOffset = (float)info.GetValue("GaugeOffset", typeof(float));
				this.GaugeHeight = (float)info.GetValue("GaugeHeight", typeof(float));

				try {this.invert = info.GetBoolean("invert");}
				catch {invert = false;}

                this.MaxYValue = (float)info.GetValue("MaxYValue", typeof(float));
           

                try { this.manuelHeight = info.GetBoolean("manuelHeight"); }
                catch { manuelHeight = false; }

                try { this.manuelHeightValue = info.GetInt32("manuelHeightValue"); }
                catch { manuelHeightValue = 100; }

				try {this.Percent = info.GetBoolean("Percent");}
				catch{Percent=false;}

                try { this.PercentValue = info.GetInt32("PercentValue"); }
                catch { PercentValue = 0; }

                try { this.Marker = info.GetBoolean("Marker"); }
                catch { Marker = false; }

                try { this.Antwortexte = info.GetBoolean("Antwortexte"); }
                catch { Antwortexte = true; }
                

				try {this.Txt = (Font)info.GetValue("Txt", typeof(Font));}
				catch{Txt=new Font("Arial", 8);}

                try { this.BackColor = (Color)info.GetValue("BackColor", typeof(Color)); }
                catch { BackColor = Color.LightGray; }

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

                try
                {
                    marker = (Marker)info.GetValue("marker", typeof(Marker));
                }
                catch
                {
                    marker = new Marker();
                }

				if (GaugeOffset != 8) GaugeOffset = 8;
				if (GaugeHeight != 30) GaugeHeight = 30;
				if (GridOffXRight != (40 + GaugeOffset)) GridOffXRight = 40 + GaugeOffset;
				if (GridOffYTop != 20) GridOffYTop = 20;
				if (GridOffYBottom != 30) GridOffYBottom = 30;

                try { this.sort = (SortOrder)info.GetValue("sort", typeof(SortOrder)); }
                catch { sort = SortOrder.None; }

                try { this.HideAnswers = (StringCollection)info.GetValue("HideAnswers", typeof(StringCollection)); }
                catch { HideAnswers = new StringCollection(); }

                try { this.AnswerOrder = (List<String>)info.GetValue("AnswerOrder", typeof(List<String>)); }
                catch { AnswerOrder = new List<String>(); }

                try { this.Type = (GaugeTypeh056)info.GetValue("Type", typeof(GaugeTypeh056)); }
                catch { Type = GaugeTypeh056.Standard; }

                try { this.GEffekt = (GaugeEffekt)info.GetValue("GEffekt", typeof(GaugeEffekt)); }
                catch { GEffekt = GaugeEffekt.Style1; }


                try { this.Opposites = info.GetBoolean("Opposites"); }
                catch { Opposites = false; }

                try { this.PersonGroups = (Hashtable)info.GetValue("PersonGroups", typeof(Hashtable)); }
                catch
                {
                    PersonGroups = new Hashtable();
                    foreach (PersonSetting ps in CombinedPersons)
                        PersonGroups[ps] = 0;
                }

                try
                {
                    this.Base = info.GetBoolean("Base");
                    this.BaseQ = (Question)info.GetValue("BaseQ", typeof(Question));
                }
                catch
                {
                    Base = false;
                    BaseQ = null;
                }

                try { this.Absolutes = info.GetBoolean("Absolutes"); }
                catch { Absolutes = false; }

                try
                {
                    this.UseManualWidth = info.GetBoolean("UseManualWidth");
                    this.ManualWidth = info.GetInt32("ManualWidth");
                }
                catch
                {
                    this.UseManualWidth = false;
                    this.ManualWidth = 100;
                }


			}
			catch (Exception ex)
			{
				Console.WriteLine("Gauge@Const");
				Console.WriteLine(ex.Message);
			}
		}

        private void DrawGrid(Graphics g)
        {
            SolidBrush BackBrush = new SolidBrush(BackColor);
            Pen Border = new Pen(Color.DarkGray);
            Pen Grid = new Pen(Color.White);
            Font Num = new Font("Arial", 8);
            SolidBrush Black = new SolidBrush(Color.Black);

            //background


            //grid
            g.FillRectangle(BackBrush, GridX, GridY, DrawAreaWidth, DrawAreaHeight);
            //3d
            g.FillRectangle(BackBrush, GridX + GaugeOffset, GridY - GaugeOffset, DrawAreaWidth, DrawAreaHeight);


            g.FillPolygon(BackBrush,
                new PointF[]{new PointF(GridX, GridY), 
								new PointF(GridX+GaugeOffset, GridY-GaugeOffset), 
								new PointF(GridX+GaugeOffset, GridY)},
                FillMode.Alternate);


            g.FillPolygon(BackBrush,
                new PointF[]{new PointF(GridX+DrawAreaWidth, GridY+DrawAreaHeight), 
								new PointF(GridX+DrawAreaWidth+GaugeOffset, GridY+DrawAreaHeight-GaugeOffset), 
								new PointF(GridX+DrawAreaWidth, GridY+DrawAreaHeight-GaugeOffset)},
                FillMode.Alternate);


            //nummerierung
            Console.WriteLine("StepNum = " + StepNum);
            Console.WriteLine("Steps = " + Steps);

            for (int i = 0; i <= Steps; i++)
            {
                string numstring;
                if (!Percent)
                {
                    if (!invert)
                        numstring = (i * StepNum + MinVal).ToString();
                    else
                        numstring = (MaxVal - (i * StepNum)).ToString();
                }
                else
                {
                    numstring = Math.Round(((i * StepNum) / (Steps * StepNum)) * 100, 0).ToString();
                }

                SizeF size = g.MeasureString(numstring, Num);
                float offset = (size.Width / 2);

                //if (!Horizontal)
                //{
                    Console.WriteLine(numstring + ": " + (GridX + GaugeOffset + i * Step - offset) + "/" + (GridY + DrawAreaHeight));
                    g.DrawString(numstring, Num, Black, GridX + GaugeOffset + i * Step - offset, GridY + DrawAreaHeight);
                    g.DrawLine(Grid, GridX + GaugeOffset + i * Step, GridY - GaugeOffset, GridX + GaugeOffset + i * Step, GridY + DrawAreaHeight - GaugeOffset);
                /*}
                else
                {
                    if (!Percent)
                    {
                        if (invert)
                            numstring = (i * StepNum + MinVal).ToString();
                        else
                            numstring = (MaxVal - (i * StepNum)).ToString();
                    }
                    else
                    {
                        numstring = Math.Abs(100 - Math.Round(((i * StepNum) / (Steps * StepNum)) * 100, 0)).ToString();
                    }

                    Console.WriteLine("step=" + Step);
                    float s = DrawAreaHeight / Steps;
                    Console.WriteLine("s=" + s);

                    g.DrawString(numstring, Num, Black, 0, GridX - GaugeOffset + i * s);
                    g.DrawLine(Grid, GridY + GaugeOffset, GridX - GaugeOffset + i * s, GridY + DrawAreaWidth + GaugeOffset, GridX - GaugeOffset + i * s);
                }*/
            }

            //grid
            //g.DrawRectangle(Border, GridX, GridY, DrawAreaWidth, DrawAreaHeight);
            //3d
            g.DrawRectangle(Border, GridX + GaugeOffset, GridY - GaugeOffset, DrawAreaWidth, DrawAreaHeight);

            //corner lines

            g.DrawLine(Border, GridX, GridY, GridX + GaugeOffset, GridY - GaugeOffset);
            //g.DrawLine(Border, GridX + DrawAreaWidth, GridY, GridX + DrawAreaWidth + GaugeOffset, GridY - GaugeOffset);
            g.DrawLine(Border, GridX, GridY + DrawAreaHeight, GridX + GaugeOffset, GridY + DrawAreaHeight - GaugeOffset);
            g.DrawLine(Border, GridX + DrawAreaWidth, GridY + DrawAreaHeight, GridX + GaugeOffset + DrawAreaWidth, GridY + DrawAreaHeight - GaugeOffset);
        }

        private void DrawOuterGrid(Graphics g)
        {
            Pen Border = new Pen(Color.DarkGray);
            //grid
            //g.DrawRectangle(Border, GridX, GridY, DrawAreaWidth, DrawAreaHeight);

            g.DrawLine(Border, GridX, GridY, GridX, GridY + DrawAreaHeight);
            g.DrawLine(Border, GridX, GridY + DrawAreaHeight, GridX + DrawAreaWidth, GridY + DrawAreaHeight);

        }

        private void DrawGauge(float val, float y, Color c1, Color c2, Graphics g)
        {
            DrawGauge(val, y, GaugeHeight, c1, c2, g, "");
        }

        private void DrawGauge(float val, float y, Color c1, Color c2, Graphics g, string text)
        {
            DrawGauge(val, y, GaugeHeight, c1, c2, g, text);
        }

        private void DrawGauge(float val, float y, float hei, Color c1, Color c2, Graphics g, string text)
        {
            bool spec = false;

            if (val == -1)
            {
                val = 0;
                spec = true;
            }

            float val2;

            if (!Percent && invert)
            {
                val2 = (MaxVal - val) + MinVal;
            }
            else
                val2 = val;

            Font Num;

            if (!Percent)
                Num = new Font("Arial", 10, FontStyle.Bold);
            else
                Num = new Font("Arial", 7, FontStyle.Bold);


            SolidBrush Black = new SolidBrush(Color.Black);

            //Gauge

            if (val2 != 0 && val != 0)
            {
                //if (!Horizontal)
                    GraphicTools.Gauge3d(GridX, GridY + y, (val2 - MinVal) * Val, hei, 0, GaugeOffset, c1, c2, g, true);
                //else
                    //GraphicTools.Gauge3d(GridX + y, GridY + DrawAreaHeight - ((val2 - MinVal) * Val), hei, (val2 - MinVal) * Val, 0, GaugeOffset, c1, c2, g, true);
            }

            string numstring;

            if (!Percent)
                numstring = (Math.Round(val, 1)).ToString();
            else
                numstring = (Math.Round(val, 0)).ToString();

            SizeF size = g.MeasureString(numstring, Num);
            float offset = size.Width;
            if (offset > (val2 - MinVal) * Val) offset = -(((val2 - MinVal) * Val) + GaugeOffset);

            SizeF nsize = g.MeasureString(text, Num);

            //if (val == 0) offset = -10;

            if (!spec)
            {
                float p = (val2 - MinVal) * Val - offset;
                if (p < (nsize.Width + 5)) p = nsize.Width + 5;

                /*if (!Horizontal)
                {*/
                    if (!Percent)
                        g.DrawString(numstring, Num, Black, GridX + (val2 - MinVal) * Val - offset, y + GridY + 5);
                    else
                    {
                        g.DrawString(text, Num, Black, GridX, y + GridY);
                        g.DrawString(numstring, Num, Black, GridX + p, y + GridY);
                    }
                /*}
                else
                {
                    if (!Percent)
                        g.DrawString(numstring, Num, Black, y + GridY + 2, GridX + (DrawAreaHeight - (val2 - MinVal) * Val));
                    else
                    {
                        StringFormat drawFormat = new StringFormat(StringFormatFlags.DirectionRightToLeft | StringFormatFlags.DirectionVertical);
                        Matrix m = new Matrix();
                        m.Rotate(180f, MatrixOrder.Append);
                        m.Translate(y + GridY, DrawAreaHeight + GridX, MatrixOrder.Append);
                        g.Transform = m;
                        g.DrawString(text, Num, Black, 0, 0, drawFormat);
                        g.ResetTransform();

                        g.DrawString(numstring, Num, Black, y + GridY, GridX + (DrawAreaHeight -/*(val2-MinVal)*Val
                    p - size.Height - GaugeOffset));
                    }

                }//end else*/
            }


            //return size.Height;
        }

        private void DrawText(string text, float y, Graphics g)
        {
            //if (!Horizontal)
            //{
                SolidBrush Black = new SolidBrush(Color.Black);
                //text

                text = GraphicTools.SplitString(text, GridX - 5, g, Txt);
                SizeF size = g.MeasureString(text, Txt);

                g.DrawString(text, Txt, Black, 0 /*GridX-size.Width-5*/, y + GridY);
            //}
            /*else
            {
                SolidBrush Black = new SolidBrush(Color.Black);
                StringFormat drawFormat = new StringFormat(StringFormatFlags.DirectionRightToLeft | StringFormatFlags.DirectionVertical);
                //text

                text = GraphicTools.SplitString(text, GridOffXRight - 5, g, Txt);
                SizeF size = g.MeasureString(text, Txt, (int)(GridOffXRight - 5));

                //g.TranslateTransform(y+ GridY, GridOffXLeft + DrawAreaHeight);
                Matrix m = new Matrix();

                m.Rotate(180f, MatrixOrder.Append); // or m.RotateAt
                m.Translate(y + GridY, width, MatrixOrder.Append);
                g.Transform = m;
                g.DrawString(text, Txt, Black, 0, 0, drawFormat/*GridX-size.Width-5);
                g.ResetTransform();
            }*/
        }
      


        public StringCollection getAnswerList()
        {
            StringCollection al = new StringCollection();

            foreach (Question q in Questions)
            {
                foreach (string a in q.AnswerList)
                {
                    if (!al.Contains(a)) al.Add(a);
                }
            }

            return al;
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

        Hashtable elTOQ;
        Hashtable drawList;

        public void Compute07()
        {
            MaxYValue = 0;
            
            if (width < 1) width = 500;
            if (height < 1) height = 500;

            OutputImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);


            Chart bc = new Chart();
            

            dnc.Apply(bc);

            bc.Title = this.Name;

            if (GEffekt == GaugeEffekt.Style1) bc.ShadingEffectMode = ShadingEffectMode.Three;
            else if (GEffekt == GaugeEffekt.Style2) bc.ShadingEffectMode = ShadingEffectMode.Four;
            else bc.ShadingEffectMode = ShadingEffectMode.Three;

            if (Marker == true)
            {
                if (Percent == true)
                {
                    AxisMarker am2 = new AxisMarker(marker.Text, new Line((Color)marker.MarkerColor, marker.Linestrength, marker.DashstyleMarker), marker.MarkerValue);
                    if (!marker.Legende)
                        am2.LegendEntry.Visible = false;

                    bc.YAxis.Markers.Add(am2);
                }
                else
                {
                    double value = (double) marker.MarkerValue/100;
                    AxisMarker am2 = new AxisMarker(marker.Text, new Line((Color)marker.MarkerColor, marker.Linestrength, marker.DashstyleMarker), value);
                    if (!marker.Legende)
                        am2.LegendEntry.Visible = false;

                    bc.YAxis.Markers.Add(am2);
                }


            }
           


            /*if (!Horizontal)
                 bc.Series.Type = GaugeType.Vertical;
            else bc.DefaultSeries = GaugeType.Horizontal;*/
            //bc.Type = ChartType.Gauges;
            //bc.DefaultSeries.GaugeType = GaugeType.Vertical;
            //bc.DefaultSeries.GaugeLinearStyle = GaugeLinearStyle.Thermometer;
            bc.DefaultSeries.Background.Color = Color.White;
           
            
            bc.Width = width;
            bc.Height = height;

            bc.DefaultSeries.EmptyElement.Mode = EmptyElementMode.TreatAsZero;

            SeriesCollection sc = new SeriesCollection();
            
            int total = 0;

            #region GaugeType-Averages
            if (Type == GaugeTypeh056.Durchschnitt)
            {
                elTOQ = new Hashtable();
                drawList = new Hashtable();

                //groups
                Hashtable grps = new Hashtable();
                foreach (PersonSetting ps in this.CombinedPersons)
                {
                    object key = PersonGroups[ps];

                    if (!grps.ContainsKey(key)) grps[key] = new ArrayList();
                    ((ArrayList)grps[key]).Add(ps);
                }

                foreach (object key in grps.Keys)
                {
                    Hashtable myTOC = new Hashtable();

                    ArrayList plist = (ArrayList)grps[key];

                    PersonCombo pc = new PersonCombo();

                    int i = 0;
                    foreach (PersonSetting ps in plist)
                    {
                        if (i == 0)
                        {
                            pc.Color1 = ps.Color1;
                            pc.Color2 = ps.Color2;
                        }
                        i++;

                        if (ps.GetType().Equals(typeof(Person)))
                            pc.AddPerson((Person)ps);
                        else
                        {
                            PersonCombo co = (PersonCombo)ps;
                            foreach (Person x in co.Persons)
                                pc.AddPerson(x);
                        }
                    }

                    Console.WriteLine("combo size = " + pc.Persons.Length);

                    Series s = new Series();
                    s.Name = pc.ToString();
                    
                    foreach (Question q in this.Questions)
                    {

                        if (!Percent)
                        {
                            Element e = new Element();
                            e.Name = eval.getTextOverload(q);
                            e.YValue = q.GetAverageByPersonAsMark(Eval, pc);

                            if (q.NAnswersByPerson(Eval, pc) > total) total = q.NAnswersByPerson(Eval, pc);

                            if (e.YValue == -1) continue;
                            e.Color = pc.Color1;
                            e.SecondaryColor = pc.Color2;
                            e.SmartLabel.Text = Math.Round(e.YValue, 1).ToString();
                            e.SmartLabel.Alignment = LabelAlignment.Top;
                            e.ShowValue = true;

                            if (invert || Opposites) e.YValue = 6 - e.YValue;
                            if (Opposites) e.SmartLabel.Text = Math.Round(e.YValue, 1).ToString();

                            s.Elements.Add(e);
                            drawList[e] = plist;

                            elTOQ[e] = q;
                        }
                    }
                    
                    sc.Add(s);
                    if (sort == SortOrder.Ascending) s.Sort(ElementValue.YValue, "Asc");
                    else if (sort == SortOrder.Descending) s.Sort(ElementValue.YValue, "Desc");

                }

                bc.Paint += new PaintEventHandler(bc_Paint);
            }
            #endregion

            #region GaugeType-Combined
            if (Type == GaugeTypeh056.Kombiniert)
            {
                Hashtable series = new Hashtable();
                bc.XAxis.Scale = Scale.Stacked;
                /*if (!Horizontal) bc.XAxis.Scale = Scale.Stacked;
                else bc.YAxis.Scale = Scale.Stacked;*/

                if (!Percent)
                {
                    foreach (Question q in Questions)
                    {
                        ArrayList done = new ArrayList();

                        while (done.Count < CombinedPersons.Length)
                        {
                            float small = float.MaxValue;
                            PersonSetting sq = null;

                            foreach (PersonSetting ps in CombinedPersons)
                            {
                                if (done.Contains(ps)) continue;
                                float val = q.GetAverageByPersonAsMark(Eval, ps);
                                if (val <= small)
                                {
                                    small = val;
                                    sq = ps;
                                }
                            }

                            if (sq != null) done.Add(sq);
                        }

                        double totval = 0;
                        foreach (PersonSetting ps in done)
                        {
                            Series s;

                            if (series.ContainsKey(ps)) s = (Series)series[ps];
                            else
                            {
                                s = new Series();
                                s.Name = ps.ToString();
                                series[ps] = s;
                            }

                            Element e = new Element();
                            e.Name = eval.getTextOverload(q);
                            float mval = q.GetAverageByPersonAsMark(Eval, ps);

                            if (q.NAnswersByPerson(Eval, ps) > total) total = q.NAnswersByPerson(Eval, ps);

                            if (mval == -1) continue;

                            e.YValue = mval - totval;

                            totval += e.YValue;

                            e.Color = ps.Color1;
                            e.SecondaryColor = ps.Color2;
                            e.SmartLabel.Text = Math.Round(mval, 1).ToString();
                            e.SmartLabel.Alignment = LabelAlignment.Top;
                            e.ShowValue = true;

                            s.Elements.Add(e);

                            sc.Add(s);
                        }
                    }
                }

                bc.DefaultSeries.LegendEntry.Visible = false;
                foreach (PersonSetting ps in CombinedPersons)
                {
                    LegendEntry singleLegendEntry = new LegendEntry();
                    singleLegendEntry.Name = ps.ToString();
                    singleLegendEntry.Background.Color = ps.Color1;
                    singleLegendEntry.Background.SecondaryColor = ps.Color2;
                    bc.ExtraLegendEntries.Add(singleLegendEntry);
                }

            }
            #endregion


            float maxAbs = 0;
            float maxPcnt = 0;
            float maxY = 0;
            int elemcount = 0;
            #region GaugeType-Standard
            if (Type == GaugeTypeh056.Standard)
            {
                foreach (PersonSetting ps in this.CombinedPersons)
                {
                    Series s = new Series();
                    s.Name = ps.ToString();

                    foreach (Question q in this.Questions)
                    {
                        if (q.NAnswersByPerson(Eval, ps) > total)
                        {
                            total = q.NAnswersByPerson(Eval, ps);
                        }

                        if (!Percent)
                        {
                            Element e = new Element();
                            if (Antwortexte)
                                e.Name = eval.getTextOverload(q);

                            e.YValue = q.GetAverageByPersonAsMark(Eval, ps);
                            if (e.YValue > MaxYValue)
                                MaxYValue = (float)e.YValue;
                            
                            if (e.YValue == -1) continue;
                            e.Color = ps.Color1;
                            e.SecondaryColor = ps.Color2;
                            e.SmartLabel.Text = Math.Round(e.YValue, 1).ToString();
                            e.SmartLabel.Alignment = LabelAlignment.Top;
                            
                            e.ShowValue = true;
                            

                            if (invert || Opposites) e.YValue = 6 - e.YValue;
                            if (Opposites) e.SmartLabel.Text = Math.Round(e.YValue, 1).ToString();

                            s.Elements.Add(e);
                        }
                        else
                        {
                            if (AnswerOrder.Count == 0)
                            {
                                foreach (String a in q.AnswerList)
                                {
                                    if (!AnswerOrder.Contains(a))
                                    {
                                        AnswerOrder.Add(a);
                                    }
                                }
                            }

                            List<String> order = new List<string>();
                          
                            for (int j = 0; j < AnswerOrder.Count; j++)
                            {
                                order.Add(AnswerOrder[j]);
                            }


                            foreach (String answer in order)
                            {
                                int i;
                                for (i = q.AnswerList.Length - 1; i >= 0; i--)
                                {
                                    if (q.AnswerList[i] == answer)
                                    {
                                        break;
                                    }
                                }

                                if (i < 0)
                                {
                                    continue;
                                }

                                if (q.AnswerList.Length > i && HideAnswers.Contains(q.AnswerList[i])) continue;

                                Element e = new Element();

                                if (Base && BaseQ != null)
                                {
                                    if (!Opposites) e.YValue = q.GetAnswerPercentByPersonWithBase(i, Eval, ps, BaseQ);
                                    else e.YValue = q.GetAnswerOppositePercentByPerson(i, Eval, ps);
                                }
                                else
                                {
                                    if (Absolutes)
                                    {
                                        e.YValue = q.GetAnswerCountByPerson(i, Eval, ps);
                                        if (e.YValue > maxAbs) maxAbs = (float)e.YValue;
                                    }
                                    else
                                    {
                                        if (!Opposites) e.YValue = q.GetAnswerPercentByPerson(i, Eval, ps);
                                        else e.YValue = q.GetAnswerOppositePercentByPerson(i, Eval, ps);
                                    }
                                }

                                //if (e.YValue == 0) continue;
                                e.Color = ps.Color1;
                                e.SecondaryColor = ps.Color2;
                                if(Antwortexte){
                                foreach(string a in answerList.Keys)
                                    if(a.Equals(q.AnswerList[i]))
                                        e.Name = (string) answerList[q.AnswerList[i]];
                                }

                                e.SmartLabel.Text = Math.Round(e.YValue, 0).ToString();
                                e.SmartLabel.Alignment = LabelAlignment.Top;
                                e.ShowValue = true;

                                e.Volume = elemcount;
                                elemcount++;

                                if (invert) e.YValue = 100 - e.YValue;
                                s.Elements.Add(e);

                                if (e.YValue > maxPcnt) maxPcnt = (float)e.YValue;
                            }
                        }
                    }

                    if (sort == SortOrder.Ascending) s.Sort(ElementValue.YValue, "ASC");
                    else if (sort == SortOrder.Descending) s.Sort(ElementValue.YValue, "DESC");

                    if (sort == SortOrder.Ascending && Percent) s.Sort(ElementValue.YValue, "ASC");
                    if (sort == SortOrder.Descending && Percent) s.Sort(ElementValue.YValue, "DESC");

                    sc.Add(s);
                }
            }
            #endregion
           
            bc.SeriesCollection.Add(sc);

            bc.YAxis.TickLabelMode = TickLabelMode.Wrapped;
            if (!ShowText) bc.YAxis.ClearValues = true;
            //if (!ShowText && Horizontal) bc.XAxis.ClearValues = true;
            //if (!ShowText && !Horizontal) bc.YAxis.ClearValues = true;
            //if (!ShowText && Horizontal) bc.XAxis.ClearValues = true;
            
            bc.LegendBox.DefaultEntry.Value = "";

            if (invert)
            {
                //change ticks
                if (Percent)
                {
                    for (int i = 0; i <= 100; i += 10)
                    {
                        AxisTick at = new AxisTick(i, (100 - i).ToString());
                        bc.XAxis.ExtraTicks.Add(at);
                        bc.YAxis.ExtraTicks.Add(at);
                    }
                }
                else if (Percent && Absolutes)
                {
                    for (int i = 0; i <= maxAbs + 10; i += 10)
                    {
                        AxisTick at = new AxisTick(i, ((maxAbs + 10) - i).ToString());
                        bc.XAxis.ExtraTicks.Add(at);
                        bc.YAxis.ExtraTicks.Add(at);
                    }
                }
                else
                {
                    for (float i = 1; i <= 5; i += 0.5f)
                    {
                        AxisTick at = new AxisTick(i, (6 - i).ToString());
                        bc.XAxis.ExtraTicks.Add(at);
                        bc.YAxis.ExtraTicks.Add(at);
                    }
                }
            }

            
            if (!Percent) { bc.XAxis.Maximum = 5; bc.XAxis.Minimum = 1; }

            int adder = (int)maxPcnt;
            adder += 6;

            while (adder % 10 != 0)
                adder++;

            if (Percent) bc.XAxis.Maximum = bc.YAxis.Maximum = adder;

            if (Percent && Absolutes) bc.XAxis.Maximum = bc.YAxis.Maximum = maxAbs + 10;

            if (UseManualWidth)
            {
                bc.XAxis.Maximum = ManualWidth;
            }
            
            if (manuelHeight == true)
            {
                PercentValue = (int)maxPcnt;
                bc.YAxis.Maximum = manuelHeightValue;
            }

            bc.Title = "";

            if (dnc.ShowN)
            {
                LegendBox lb = new LegendBox();
                LegendEntry le = new LegendEntry("Stichprobengröße", total.ToString());
                lb.ExtraEntries.Add(le);
                bc.ExtraLegendBoxes.Add(lb);

                dnc.ApplyLegendBox(bc, lb);
            }
            

            bc.Application = "itcIidhdhyk+bW1OOBTArpfNOr3GopKuOit20bU6/G4MlNN6vnk4wkfGB+NlXC+EWdY1Rm4vJ0qKOQOmw7d7gw==";


            bc.DrawToBitmap(OutputImage, new Rectangle(0, 0, OutputImage.Width, OutputImage.Height));

            

           
        }

        void bc_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine("PAINT");
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Chart bc = (Chart)sender;

            Rectangle cr = bc.ChartArea.GetRectangle();

            float scal = ((float)cr.Width) / 4f;

            for (int i = 0; i < bc.SeriesCollection.Count; i++)
            {
                for (int ib = 0; ib < bc.SeriesCollection[i].Elements.Count; ib++)
                {
                    Element el = bc.SeriesCollection[i].Elements[ib];

                    Console.WriteLine("ELEMENT");
                    if (elTOQ.ContainsKey(el))
                    {
                        Console.WriteLine(" found!");
                        Question q = (Question)elTOQ[el];

                        foreach (PersonSetting ps in (ArrayList)drawList[el])
                        {
                            float val = q.GetAverageByPersonAsMark(Eval, ps) - 1;
                            if (val == -1) continue;

                            if (invert || Opposites) val = 4 - val;
                            ps.Sym.x = cr.X + (val * scal);
                            ps.Sym.y = el.Point.Y;
                            ps.Sym.Draw(g, Color.FromArgb(150, ps.Color1),
                                           Color.FromArgb(150, ps.Color2),
                    new Pen(new SolidBrush(Color.FromArgb(150, Color.Black)), 1));
                        }
                    }
                }
            }
        }

        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_Gauge_h056(eval, false, this);
        }

        public override void Compute()
        {
           Compute07();
        }

        public override void EditDialog()
        {
            /*OutputFormBar ofb = new OutputFormBar(eval, false, this);
            ofb.ShowDialog();*/
            MessageBox.Show("EditDialog Gauge_h056.cs");
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
