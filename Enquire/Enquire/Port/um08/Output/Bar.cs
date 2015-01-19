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

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{
	/// <summary>
	/// Summary description for Bar.
	/// </summary>
	/// 
	[Serializable]
	public class Bar : Output
	{
        public enum BarType { Standard, Kombiniert, Durchschnitt }

        public BarType Type = BarType.Standard;

		public bool Text = false;   

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

        private float gridOffXRight;
        private float GridOffYTop;
        private float GridOffYBottom;

        public float BarOffset;

        public float BarHeight;

		public bool invert = false;

		public bool Percent = false;

		public bool Horizontal = false;

        public bool Opposites = false;

        public bool Absolutes = false;

		public Question[] Questions;

		public Font Txt;

        public Color BackColor;

        public StringCollection HideAnswers;
	    public List<String> AnswerOrder;

        public Hashtable PersonGroups;

        public int Design;
        public DNCSettings dnc;
        public SortOrder sort;

	    public Boolean UseManualWidth = false;
	    public Int32 ManualWidth = 100;

		private float DrawAreaWidth
		{
			get {if (!Horizontal) return(width-GridOffXLeft-GridOffXRight);
			else return(height-GridOffYTop-GridOffYBottom);}
		}

		private float DrawAreaHeight
		{
			get {if (!Horizontal) return(height-GridOffYTop-GridOffYBottom);
			else return (width-GridOffXLeft-GridOffXRight);}
		}

		private float Step
		{
			get {return(DrawAreaWidth/Steps);}
		}

		private float StepNum
		{
			get {return((MaxVal-MinVal)/Steps);}
		}

		private float Val
		{
			get 
			{
				if (!Horizontal)
				{
					if (!Percent)
						return ( DrawAreaWidth/(MaxVal-MinVal) );
					else
						return ( (DrawAreaWidth+2*BarOffset)/ 100);
				}
				else
				{
					if (!Percent)
						return ( DrawAreaHeight/(MaxVal-MinVal) );
					else
						return ( (DrawAreaHeight+2*BarOffset)/ 100);
				}
			}
		}

		private float GridX
		{
			get {if (!Horizontal) return (GridOffXLeft); else return 30;}
		}

		private float GridY
		{
			get {if (!Horizontal) return (GridOffYTop); else return GridX;}
		}

		private float GridOffXLeft
		{
			get {if (!Horizontal && text)return width/3;
			     else return 10;}
		}

		private float GridOffXRight
		{
			get 
			{
				if (Horizontal && text)return width/3;
				else return gridOffXRight;
			}
			set
			{
				gridOffXRight = value;
			}
		}

        #region SET & GET

        public BarType GetType()
        {
            return this.Type;
        }

        public void SetType(BarType type)
        {
            this.Type = type;
        }

        public bool GetText()
        {
            return this.Text;
        }

        public void SetText(bool Text2)
        {
            this.Text = Text2;
        }

        public bool GetShowText()
        {
            return this.ShowText;
        }

        public void SetShowText(bool ShowText2)
        {
            this.ShowText = ShowText2;
        }

        public bool GetInvert()
        {
            return this.invert;
        }

        public void SetInvert(bool invert2)
        {
            this.invert = invert2;
        }

        public bool GetPercent()
        {
            return this.Percent;
        }

        public void SetPercent(bool percent)
        {
            this.Percent = percent;
        }

        public bool GetHorizontal()
        {
            return this.Horizontal;
        }

        public void SetHorizontal(bool horizontal)
        {
            this.Horizontal = horizontal;
        }

        public bool GetOpposites()
        {
            return this.Opposites;
        }

        public void SetOpposites(bool opposites)
        {
            this.Opposites = opposites;
        }

        public bool GetAbsolutes()
        {
            return this.Absolutes;
        }

        public void SetAbsolutes(bool absolutes)
        {
            this.Absolutes = absolutes;
        }

        public bool GetBase()
        {
            return this.Base;
        }

        public void SetBase(bool base2)
        {
            this.Base = base2;
        }

        public Question GetBaseQ()
        {
            return this.BaseQ;
        }

        public void SetBaseQ(Question baseq2)
        {
            this.BaseQ = baseq2;
        }

        public bool GetUseManualWidth()
        {
            return this.UseManualWidth;
        }

        public void SetUseManualWidth(bool useManualWidth)
        {
            this.UseManualWidth = useManualWidth;
        }

        public int GetManualWidth()
        {
            return this.ManualWidth;
        }

        public void SetManualWidth(int manualWidth)
        {
            this.ManualWidth = manualWidth;
        }

        public float GetMaxVal()
        {
            return this.MinVal;
        }

        public void SetMaxVal(float maxval)
        {
            this.MaxVal = maxval;
        }

        public float GetMinVal()
        {
            return this.MaxVal;
        }

        public void SetMinVal(float minval)
        {
            this.MinVal = minval;
        }

        public float GetSteps()
        {
            return this.Steps;
        }

        public void SetSteps(float steps)
        {
            this.Steps = steps;
        }

        public float GetBarOffSet()
        {
            return this.BarOffset;
        }

        public void SetBarOffSet(float barOffSet)
        {
            this.BarOffset = barOffSet;
        }

        public float GetBarHeight()
        {
            return this.BarHeight;
        }

        public void SetBarHeight(float barHeight)
        {
            this.BarHeight = barHeight;
        }

        public float GetGridOffXRight()
        {
            return this.gridOffXRight;
        }

        public void SetGridOffXRight(float gridOffXRight2)
        {
            this.gridOffXRight = gridOffXRight2;
        }

        public float GetGridOffYTop()
        {
            return this.GridOffYTop;
        }

        public void SetGridOffYTop(float gridOffYTop)
        {
            this.GridOffYTop = gridOffYTop;
        }

        public float GetGridOffYBottom()
        {
            return this.GridOffYBottom;
        }

        public void SetGridOffYBottom(float gridOffYBottom)
        {
            this.GridOffYBottom = gridOffYBottom;
        }

        public Font GetTxt()
        {
            return this.Txt;
        }

        public void SetTxt(Font txt)
        {
            this.Txt = txt;
        }

        public Color GetBackColor()
        {
            return this.BackColor;
        }

        public void SetBackColor(Color backColor)
        {
            this.BackColor = backColor;
        }

        public int GetDesign()
        {
            return this.Design;
        }

        public void SetDesign(int design)
        {
            this.Design = design;
        }

        public DNCSettings GetDNC()
        {
            return this.dnc;
        }

        public void SetDNC(DNCSettings dnc2)
        {
            this.dnc = dnc2;
        }

        public Question[] GetQuestionList()
        {
            return Questions;
        }

        public void SetQuestionList(Question[] question)
        {
            this.Questions = question;
        }

        public SortOrder GetSort()
        {
            return this.sort;
        }

        public void SetSort(SortOrder sort2)
        {
            this.sort = sort2;
        }

        public StringCollection GetHideAnswers()
        {
            return this.HideAnswers;
        }

        public void SetHideAnswers(StringCollection HideAnswers2){
            this.HideAnswers = HideAnswers2;
        }

        public List<String> GetAnswerOrder()
        {
            return this.AnswerOrder;
        }

        public void SetAnswerOrder(List<String>AnswerOrder2){
            this.AnswerOrder = AnswerOrder2;
        }

        public Hashtable GetPersonGroups()
        {
            return this.PersonGroups;
        }

        public void SetPersonGroups(Hashtable PersonGroups2)
        {
            this.PersonGroups = PersonGroups2;
        }

        #endregion

        public Bar(Evaluation eval)
		{
            this.eval = eval;
			MinVal = 1;
			MaxVal = 5;
			Steps = 8;

			BarOffset = 8;
			BarHeight = 30;

			GridOffXRight  = 40 + BarOffset;
			GridOffYTop    = 20;
			GridOffYBottom = 30;

			Txt = new Font("Arial", 8);

            BackColor = Color.LightGray;

            this.Design = Output.Victor2007;
            dnc = new DNCSettings();

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
				info.AddValue("MaxVal",this.MaxVal);
				info.AddValue("Steps", this.Steps);

				info.AddValue("gridOffYBottom", this.GridOffYBottom);
				info.AddValue("GridOffYTop", this.GridOffYTop);
				info.AddValue("GridOffXRight", this.GridOffXRight);
				info.AddValue("BarOffset", this.BarOffset);
				info.AddValue("BarHeight", this.BarHeight);

				info.AddValue("invert", this.invert);
				info.AddValue("Questions", this.Questions);

				info.AddValue("Percent", this.Percent);
				info.AddValue("Horizontal", this.Horizontal);

                info.AddValue("Opposites", this.Opposites);

				info.AddValue("Txt", this.Txt);
                
                info.AddValue("BackColor", this.BackColor);

                info.AddValue("Design", this.Design);
                info.AddValue("dnc", this.dnc);

                info.AddValue("HideAnswers", this.HideAnswers);
                info.AddValue("AnswerOrder", this.AnswerOrder);

                info.AddValue("sort", this.sort);

                info.AddValue("Type", this.Type);

                info.AddValue("PersonGroups", this.PersonGroups);

                info.AddValue("Base", this.Base);

                info.AddValue("BaseQ", this.BaseQ);

                info.AddValue("Absolutes", this.Absolutes);

                info.AddValue("UseManualWidth", this.UseManualWidth);
                info.AddValue("ManualWidth", this.ManualWidth);
			}
			catch
			{
				Console.WriteLine("Bar!");
			}

		}

		public Bar(SerializationInfo info, StreamingContext ctxt)
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

				this.BarOffset = (float)info.GetValue("BarOffset", typeof(float));
				this.BarHeight = (float)info.GetValue("BarHeight", typeof(float));

				try {this.invert = info.GetBoolean("invert");}
				catch {invert = false;}

				try {this.Percent = info.GetBoolean("Percent");}
				catch{Percent=false;}

				try {this.Horizontal = info.GetBoolean("Horizontal");}
				catch{Horizontal=false;}

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

				if (BarOffset != 8) BarOffset = 8;
				if (BarHeight != 30) BarHeight = 30;
				if (GridOffXRight != (40 + BarOffset)) GridOffXRight = 40 + BarOffset;
				if (GridOffYTop != 20) GridOffYTop = 20;
				if (GridOffYBottom != 30) GridOffYBottom = 30;

                try { this.sort = (SortOrder)info.GetValue("sort", typeof(SortOrder)); }
                catch { sort = SortOrder.None; }

                try { this.HideAnswers = (StringCollection)info.GetValue("HideAnswers", typeof(StringCollection)); }
                catch { HideAnswers = new StringCollection(); }

                try { this.AnswerOrder = (List<String>)info.GetValue("AnswerOrder", typeof(List<String>)); }
                catch { AnswerOrder = new List<String>(); }

                try { this.Type = (BarType)info.GetValue("Type", typeof(BarType)); }
                catch { Type = BarType.Standard; }

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
                }
                catch
                {
                    this.UseManualWidth = false;
                }

                try
                {
                    
                    this.ManualWidth = info.GetInt32("ManualWidth");
                }
                catch
                {
                    
                    this.ManualWidth = 100;
                    
                }


			}
			catch (Exception ex)
			{
				Console.WriteLine("Bar@Const");
				Console.WriteLine(ex.Message);
			}
		}

		private void DrawOuterGrid(Graphics g)
		{
			Pen Border = new Pen(Color.DarkGray);
		 	//grid
			//g.DrawRectangle(Border, GridX, GridY, DrawAreaWidth, DrawAreaHeight);

			g.DrawLine(Border, GridX, GridY, GridX, GridY+DrawAreaHeight);
			g.DrawLine(Border, GridX, GridY+DrawAreaHeight, GridX+DrawAreaWidth, GridY+DrawAreaHeight);
			
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
			g.FillRectangle(BackBrush, GridX+BarOffset, GridY-BarOffset, DrawAreaWidth, DrawAreaHeight);

			
			g.FillPolygon(BackBrush,
				new PointF[]{new PointF(GridX, GridY), 
								new PointF(GridX+BarOffset, GridY-BarOffset), 
								new PointF(GridX+BarOffset, GridY)}, 
				FillMode.Alternate);

			
			g.FillPolygon(BackBrush,
				new PointF[]{new PointF(GridX+DrawAreaWidth, GridY+DrawAreaHeight), 
								new PointF(GridX+DrawAreaWidth+BarOffset, GridY+DrawAreaHeight-BarOffset), 
								new PointF(GridX+DrawAreaWidth, GridY+DrawAreaHeight-BarOffset)}, 
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
						numstring = (i*StepNum + MinVal).ToString();
					else
						numstring = (MaxVal - (i*StepNum)).ToString();
				}
				else
				{
					numstring = Math.Round(((i*StepNum) / (Steps*StepNum))*100,0).ToString();
				}

				SizeF size = g.MeasureString(numstring, Num);
				float offset = (size.Width/2);

				if (!Horizontal)
				{
					Console.WriteLine(numstring + ": " + (GridX + BarOffset+ i*Step - offset) + "/" + (GridY+DrawAreaHeight));
					g.DrawString(numstring, Num, Black, GridX + BarOffset+ i*Step - offset, GridY+DrawAreaHeight);
					g.DrawLine(Grid, GridX +  BarOffset + i*Step, GridY-BarOffset, GridX + BarOffset + i*Step, GridY+DrawAreaHeight-BarOffset);			
				}
				else
				{
					if (!Percent)
					{
						if (invert)
							numstring = (i*StepNum + MinVal).ToString();
						else
							numstring = (MaxVal - (i*StepNum)).ToString();
					}
					else
					{
						numstring = Math.Abs(100-Math.Round(((i*StepNum) / (Steps*StepNum))*100,0)).ToString();
					}

					Console.WriteLine("step=" + Step);
					float s = DrawAreaHeight/Steps;
					Console.WriteLine("s=" + s);

					g.DrawString(numstring, Num, Black, 0, GridX -BarOffset+ i*s);
					g.DrawLine(Grid, GridY+BarOffset, GridX -BarOffset+ i*s, GridY+DrawAreaWidth+BarOffset,  GridX  -BarOffset + i*s);			
				}
			}

			//grid
			//g.DrawRectangle(Border, GridX, GridY, DrawAreaWidth, DrawAreaHeight);
			//3d
			g.DrawRectangle(Border, GridX+BarOffset, GridY-BarOffset, DrawAreaWidth, DrawAreaHeight);

			//corner lines

			g.DrawLine(Border, GridX, GridY, GridX + BarOffset, GridY - BarOffset);
			//g.DrawLine(Border, GridX + DrawAreaWidth, GridY, GridX + DrawAreaWidth + BarOffset, GridY - BarOffset);
			g.DrawLine(Border, GridX, GridY+DrawAreaHeight, GridX + BarOffset, GridY+DrawAreaHeight- BarOffset);
			g.DrawLine(Border, GridX + DrawAreaWidth, GridY+DrawAreaHeight, GridX + BarOffset+ DrawAreaWidth, GridY+DrawAreaHeight- BarOffset);
		}

		private void DrawBar(float val, float y, Color c1, Color c2, Graphics g)
		{
			DrawBar(val, y, BarHeight, c1, c2, g, "");
		}

		private void DrawBar(float val, float y, Color c1, Color c2, Graphics g, string text)
		{
			DrawBar(val, y, BarHeight, c1, c2, g, text);
		}

		private void DrawBar(float val, float y, float hei, Color c1, Color c2, Graphics g, string text)
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
			
			//bar

			if (val2 != 0 && val != 0)
			{
				if (!Horizontal)
					GraphicTools.Bar3d(GridX, GridY+y, (val2-MinVal)*Val, hei, 0, BarOffset, c1, c2, g, true);
				else
					GraphicTools.Bar3d(GridX+y, GridY+DrawAreaHeight-((val2-MinVal)*Val), hei, (val2-MinVal)*Val, 0, BarOffset, c1, c2, g, true);
			}

			string numstring;
			
			if (!Percent)
				numstring = (Math.Round(val,1)).ToString();
			else
				numstring = (Math.Round(val,0)).ToString();

			SizeF size = g.MeasureString(numstring, Num);
			float offset = size.Width;
			if (offset > (val2-MinVal)*Val) offset = - ( ((val2-MinVal)*Val) + BarOffset);

			SizeF nsize = g.MeasureString(text, Num);

			//if (val == 0) offset = -10;

			if (!spec)
			{
				float p = (val2-MinVal)*Val - offset;
				if (p < (nsize.Width+5)) p = nsize.Width + 5;

				if (!Horizontal)
				{
					if (!Percent)
						g.DrawString(numstring, Num, Black,GridX + (val2-MinVal)*Val - offset, y+GridY + 5);
					else
					{
						g.DrawString(text, Num, Black, GridX, y+GridY);
						g.DrawString(numstring, Num, Black,GridX + p, y+GridY);
					}
				}
				else
				{
					if (!Percent)
						g.DrawString(numstring, Num, Black,y+GridY+2,GridX + (DrawAreaHeight-(val2-MinVal)*Val));
					else
					{
						StringFormat drawFormat = new StringFormat(StringFormatFlags.DirectionRightToLeft | StringFormatFlags.DirectionVertical);
						Matrix m = new Matrix();
						m.Rotate(180f, MatrixOrder.Append);
						m.Translate(y+ GridY, DrawAreaHeight + GridX, MatrixOrder.Append);
						g.Transform = m;
						g.DrawString(text, Num, Black, 0,0, drawFormat);		    
						g.ResetTransform();

						g.DrawString(numstring, Num, Black,y+GridY,GridX + (DrawAreaHeight-/*(val2-MinVal)*Val*/p - size.Height - BarOffset));
					}

				}
			}

			
			//return size.Height;
		}

		private void DrawText(string text, float y, Graphics g)
		{
			if (!Horizontal)
			{
				SolidBrush Black = new SolidBrush(Color.Black);
				//text

				text = GraphicTools.SplitString(text, GridX-5, g, Txt);
				SizeF size = g.MeasureString(text, Txt);

				g.DrawString(text, Txt, Black, 0 /*GridX-size.Width-5*/, y+ GridY);
			}
			else
			{
				SolidBrush Black = new SolidBrush(Color.Black);
				StringFormat drawFormat = new StringFormat(StringFormatFlags.DirectionRightToLeft | StringFormatFlags.DirectionVertical);
				//text

				text = GraphicTools.SplitString(text, GridOffXRight-5, g, Txt);
				SizeF size = g.MeasureString(text, Txt, (int)(GridOffXRight-5));

				//g.TranslateTransform(y+ GridY, GridOffXLeft + DrawAreaHeight);
				Matrix m = new Matrix();
			   
				m.Rotate(180f, MatrixOrder.Append); // or m.RotateAt
				m.Translate(y+ GridY, width, MatrixOrder.Append);
				g.Transform = m;
				g.DrawString(text, Txt, Black, 0,0, drawFormat/*GridX-size.Width-5*/ );		    
				g.ResetTransform();
			}
		}

		public void Compute06()
		{
			if (!Percent) 
			{
				BarHeight = 30;
				BarOffset = 8;
				this.Steps = 8;
			}
			else 
			{
				this.Steps = 10;
				BarHeight = 75;
				BarOffset = 4;
			}

			//invert = false;

			Font Txt = new Font("Arial", 8);

			/*
			if (Horizontal)
				OutputImage = new Bitmap(height,width);
			else
				OutputImage = new Bitmap(width,height);
			*/
			OutputImage = new Bitmap(1,1);

			Graphics g = Graphics.FromImage(OutputImage);
			g.Clear(Color.White);

			SizeF size = new SizeF(0,0);
			float h = 5;

			int qc = 0;
			foreach (Question q in Questions)
			{
				if (q == null) continue;

				float innerheight = 0;
				bool inc = false;
				foreach (PersonSetting ps in CombinedPersons)
				{
					string text;

					if (!Horizontal)
						text = GraphicTools.SplitString(eval.getTextOverload(q), GridX-5, g, Txt);
					else
						text = "";

					size = g.MeasureString(text, Txt);
					if (!Percent)
					{ 
						float avg = q.GetAverageByPersonAsMark(Eval, ps);
						innerheight += BarOffset + BarHeight + 5;
						inc = true;
					}
					else
					{
						for (int i = 0; i < q.AnswerList.Length; i++)
						{
							float bhei = (BarHeight/5);// * q.AnswerList.Length);// - (BarOffset/q.AnswerList.Length);
							float pct = (float)q.GetAnswerPercentByPerson(i, Eval, ps);
							innerheight += bhei + BarOffset + 2;//2*(BarOffset/q.AnswerList.Length);
						}
						innerheight += 5;
						inc = true;
					}
					
				}
				qc++;

				if (inc)
				{
					if (this.text && !Horizontal)
						h += Math.Max(size.Height + BarOffset + 5, innerheight);
					else
						h += innerheight;

					if (Questions.Length > qc && CombinedPersons.Length > 1) h += 10;
				}
			}

			Console.WriteLine("wid=" + this.width);
			this.height = (int)h+1+(int)GridY+1+(int)GridOffYBottom+1+(int)GridOffYTop;

			if (!Horizontal)
				OutputImage = new Bitmap(width,height);
			else
				OutputImage = new Bitmap(height,width);

			g = Graphics.FromImage(OutputImage);

			g.Clear(Color.White);

			DrawGrid(g);

			float y = 5;
			qc = 0;
			foreach (Question q in Questions)
			{
				if (q == null) continue;
				float innerheight = 0;
				bool inc = false;
				foreach (PersonSetting ps in CombinedPersons)
				{
					string text = GraphicTools.SplitString(eval.getTextOverload(q), GridX-5, g, Txt);
					size = g.MeasureString(text, Txt);
					
					inc = true;

					if (!Percent)
					{ 
						float avg = q.GetAverageByPersonAsMark(Eval, ps);
						DrawBar(avg, y + innerheight, ps.Color1, ps.Color2, g);
						innerheight += BarOffset + BarHeight + 5;
					}
					else
					{
						for (int i = 0; i < q.AnswerList.Length; i++)
						{
							float bhei = (BarHeight/5);//q.AnswerList.Length);// - (BarOffset/q.AnswerList.Length);
							float pct = (float)q.GetAnswerPercentByPerson(i, Eval, ps);
							Console.WriteLine(pct + "&");

							DrawBar(pct, y+innerheight, bhei, ps.Color1, ps.Color2, g, q.AnswerList[i]);
							innerheight += bhei + BarOffset + 2;//2*(BarOffset/q.AnswerList.Length);
						}
						innerheight += 5;
					}
				}
				qc++;
				if (inc)
				{
					if (this.text /*&& !Horizontal*/) DrawText(eval.getTextOverload(q), y, g);
					
					if (this.text && !Horizontal)
						y += Math.Max(size.Height + BarOffset + 5, innerheight);
					else
						y += innerheight;
					
					//y += Math.Max(size.Height + BarOffset + 5, innerheight);

					if (Questions.Length > qc && CombinedPersons.Length > 1)
					{
						y+=10;
						if (!Horizontal)
							g.DrawLine(new Pen(new SolidBrush(Color.White)), GridX+BarOffset, y+5, BarOffset+GridX + DrawAreaWidth, y+5);
							
						else
							g.DrawLine(new Pen(new SolidBrush(Color.White)), y+15+BarOffset, GridX-BarOffset, y+15+BarOffset, GridX + DrawAreaHeight-BarOffset);
							
					}
				}
			}

			DrawOuterGrid(g);
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
            if (width < 1) width = 500;
            if (height < 1) height = 500;

            OutputImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            

            Chart bc = new Chart();

            dnc.Apply(bc);

            bc.Title = this.Name;

            if (!Horizontal) bc.Type = ChartType.ComboHorizontal;
            else bc.Type = ChartType.Combo;

            bc.Width = width;
            bc.Height = height;

            bc.DefaultSeries.EmptyElement.Mode = EmptyElementMode.TreatAsZero;

            SeriesCollection sc = new SeriesCollection();

            int total = 0;

            #region BarType-Averages
            if (Type == BarType.Durchschnitt)
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
                            pc.Color1 = ps.Color2;
                            pc.Color2 = ps.Color1;
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
                            e.Color = pc.Color2;
                            e.SecondaryColor = pc.Color1;
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

            #region BarType-Combined
            if (Type == BarType.Kombiniert)
            {
                Hashtable series = new Hashtable();
                if (!Horizontal) bc.XAxis.Scale = Scale.Stacked;
                else bc.YAxis.Scale = Scale.Stacked;

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

                            e.Color = ps.Color2;
                            e.SecondaryColor = ps.Color1;
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
                    singleLegendEntry.Background.Color = ps.Color2;
                    singleLegendEntry.Background.SecondaryColor = ps.Color1;
                    bc.ExtraLegendEntries.Add(singleLegendEntry);
                }

            }    
            #endregion


            float maxAbs = 0;
            float maxPcnt = 0;

            int elemcount = 0;
            #region BarType-Standard
            if (Type == BarType.Standard)
            {
                foreach (PersonSetting ps in this.CombinedPersons)
                {
                    Series s = new Series();
                    s.Name = ps.ToString();

                    foreach (Question q in this.Questions)
                    {
                        if (q.NAnswersByPerson(Eval, ps) > total) total = q.NAnswersByPerson(Eval, ps);

                        if (!Percent)
                        {
                            Element e = new Element();
                            e.Name = eval.getTextOverload(q);
                            e.YValue = q.GetAverageByPersonAsMark(Eval, ps);
                            
                            if (e.YValue == -1) continue;
                            e.Color = ps.Color2;
                            e.SecondaryColor = ps.Color1;
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
                            if (Horizontal)
                            {
                                order.AddRange(AnswerOrder);
                            }
                            else
                            {
                                for (int j = AnswerOrder.Count-1; j >= 0; j--)
                                {
                                    order.Add(AnswerOrder[j]);
                                }
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
                                e.Color = ps.Color2;
                                e.SecondaryColor = ps.Color1;
                                e.Name = q.AnswerList[i];

                                //e.Name = adaptName(q.AnswerList[i]);
 

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
            if (!ShowText && !Horizontal) bc.YAxis.ClearValues = true;
            if (!ShowText && Horizontal) bc.XAxis.ClearValues = true;

            //if (invert && !Horizontal) bc.XAxis.InvertScale = true;
            //if (invert && Horizontal) bc.YAxis.InvertScale = true;

            bc.LegendBox.DefaultEntry.Value = "";

            if (invert)
            {
                //change ticks
                if (Percent)
                {
                    for (int i = 0; i <= 100; i+=10)
                    {
                        AxisTick at = new AxisTick(i, (100 - i).ToString());
                        bc.XAxis.ExtraTicks.Add(at);
                        bc.YAxis.ExtraTicks.Add(at);
                    }
                }
                else if (Percent && Absolutes)
                {
                    for (int i = 0; i <= maxAbs+10; i += 10)
                    {
                        AxisTick at = new AxisTick(i, ((maxAbs+10) - i).ToString());
                        bc.XAxis.ExtraTicks.Add(at);
                        bc.YAxis.ExtraTicks.Add(at);
                    }
                }
                else
                {
                    for (float i = 1; i <= 5; i+=0.5f)
                    {
                        AxisTick at = new AxisTick(i, (6 - i).ToString());
                        bc.XAxis.ExtraTicks.Add(at);
                        bc.YAxis.ExtraTicks.Add(at);
                    }
                }
            }

            if (!Percent && Horizontal) { bc.YAxis.Maximum = 5; bc.YAxis.Minimum = 1; }
            if (!Percent && !Horizontal) { bc.XAxis.Maximum = 5; bc.XAxis.Minimum = 1; }

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

        /*string adaptName(string AnswerlistName)
        {
            int findeIndex = 0;
            if (AnswerlistName.Length>50 && AnswerlistName.Contains(" "))
             findeIndex = AnswerlistName.LastIndexOf(' ', 0, 50);

            findeIndex = AnswerlistName.IndexOf(
            string neuerText = "";
            if (findeIndex > 0)
                neuerText = AnswerlistName.Insert(findeIndex, Environment.NewLine);
            else
                neuerText = AnswerlistName;

            /*if (AnswerlistName.Equals("Raiffeisenlandesbank / Raiffeisen Bank International"))
                MessageBox.Show(neuerText);*/
           /* return neuerText;
        }*/
        
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

        public override void Compute()
        {
            if (Design == Victor2006) Compute06();
            else Compute07();
        }

		public override void EditDialog()
		{
			OutputFormBar ofb = new OutputFormBar(eval, false, this);
			ofb.ShowDialog();
		}

        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_Bar(eval, false, this);
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

				FileStream myFileOut = new FileStream(path + "\\" + SystemTools.Savable(name + " ("+td.Name+").png"), FileMode.Create );
				OutputImage.Save( myFileOut, ImageFormat.Png );
				myFileOut.Close();
			}

			seval = null;
			OutputImage = null;
		}

	}
}
