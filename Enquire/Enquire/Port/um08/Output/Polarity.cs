using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{

	/// <summary>
	/// Summary description for Polarity.
	/// </summary>
	/// 
	[Serializable]
	public class Polarity : Output
	{
		public Question[] Questions;

		public bool imagesonly = false;

		public Font ValueFont;
		public Font QFont;
        
        public Color BackColorA;
        public Color BackColorB;

        public PersonSetting[] PersonOrder;
        public Hashtable PersonGroups;

        public float SizePercentText;
        public float SizePercentValues;

        public int Design;

        public Polarity(Evaluation eval)
        {
            this.eval = eval;
			ValueFont = new Font("Arial", 8, FontStyle.Bold);
			QFont = new Font("Arial", 8, FontStyle.Regular);

            BackColorA = Color.White;
            BackColorB = Color.LightGray;

            PersonOrder = new PersonSetting[0];

            PersonGroups = new Hashtable();

            this.Design = Output.Victor2006;

            SizePercentText = 0.3f;
            SizePercentValues = 0.3f;

            width = height = 500;
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

            Question.SetMultipartArray(Questions, Multipart);

			info.AddValue("Questions", this.Questions);
			info.AddValue("imagesonly", this.imagesonly);
			info.AddValue("ValueFont", this.ValueFont);
			info.AddValue("QFont", this.QFont);

            info.AddValue("BackColorA", this.BackColorA);
            info.AddValue("BackColorB", this.BackColorB);

            info.AddValue("PersonOrder", this.PersonOrder);
            info.AddValue("PersonGroups", this.PersonGroups);

            info.AddValue("Design", this.Design);

            info.AddValue("SizePercentText", this.SizePercentText);
            info.AddValue("SizePercentValues", this.SizePercentValues);
		}

		public Polarity(SerializationInfo info, StreamingContext ctxt)
		{
			base.ReadSerData(info, ctxt);

			this.Questions = (Question[])info.GetValue("Questions", typeof(Question[]));
			this.imagesonly = info.GetBoolean("imagesonly");

			try{this.ValueFont = (Font)info.GetValue("ValueFont", typeof(Font));}
			catch{ValueFont = null;}

			try{this.QFont = (Font)info.GetValue("QFont", typeof(Font));}
			catch{QFont = null;}

            try { this.BackColorA = (Color)info.GetValue("BackColorA", typeof(Color)); }
            catch { BackColorA = Color.White; }

            try { this.BackColorB = (Color)info.GetValue("BackColorB", typeof(Color)); }
            catch { BackColorB = Color.LightGray; }

            try
            {
                SizePercentText = (float)info.GetValue("SizePercentText", typeof(float));
                SizePercentValues = (float)info.GetValue("SizePercentValues", typeof(float));
            }
            catch
            {
                SizePercentValues = 0.3f;
                SizePercentText = 0.3f;
            }

            try { 
                this.PersonOrder = (PersonSetting[])info.GetValue("PersonOrder", typeof(PersonSetting[]));
                Console.WriteLine("personoder deser:");
                foreach (PersonSetting ps in PersonOrder)
                    Console.WriteLine(ps.ToString());
            }
            catch {
                PersonOrder = (PersonSetting[])this.CombinedPersons.Clone();
                Console.WriteLine("personorder deser failure");
            }

            try
            {
                Design = info.GetInt32("Design");
                //dnc = (DNCSettings)info.GetValue("dnc", typeof(DNCSettings));
            }
            catch
            {
                Design = Victor2006;
                //dnc = new DNCSettings();
            }

            try { this.PersonGroups = (Hashtable)info.GetValue("PersonGroups", typeof(Hashtable)); }
            catch { PersonGroups = new Hashtable();
            foreach (PersonSetting ps in PersonOrder)
                PersonGroups[ps] = 0;
        }
		}

		private Bitmap PolarityImage(float width, int[] orders, float[]values, int[]shapes, Color[]colors, Color[] colors2, Color Background)
		{
			if (values.Length == 0)
			{
				return new Bitmap((int)width, 1);
			}
			float valueheight = 26;
			float shapeheight = 20;
			

			Bitmap pol = new Bitmap((int)width, (int)(valueheight*values.Length));
			Graphics g = Graphics.FromImage(pol);
			g.SmoothingMode = SmoothingMode.AntiAlias;

			float XOff = 0; //shapeheight/2;
			
			g.Clear(Background);

			g.FillRectangle(new SolidBrush(Background), XOff, 0, width-1-(2*XOff), pol.Height-1);

			//grid, border

			float scale = (float)(int)(width-(2*XOff)) / 4; 

			//g.DrawRectangle(new Pen(Color.Gray), XOff, 0, width-1-(2*XOff), pol.Height-1);

			for (int l = 1; l < 4; l++)
				g.DrawLine(new Pen(Color.Gray, 3), XOff+l*scale, 0, XOff+l*scale, pol.Height);
			
			//shapes

			int i = 0;
			float y = 0;
			foreach (float val in values)
			{
				if (val == -1)
				{
					i++;
					y+=valueheight;
					continue;
				}
				float x = XOff+ (scale * val);

                PointF topLeft   = new PointF(x-shapeheight/2, y+(valueheight-shapeheight)/2);
				PointF topCenter = new PointF(x,y+(valueheight-shapeheight)/2);
				PointF topRight  = new PointF(x+shapeheight/2, y+(valueheight-shapeheight)/2);
				PointF botLeft   = new PointF(x-shapeheight/2, y+valueheight-(valueheight-shapeheight)/2);
				PointF botCenter = new PointF(x,y+valueheight-(valueheight-shapeheight)/2);
				PointF botRight  = new PointF(x+shapeheight/2, y+valueheight-(valueheight-shapeheight)/2);

				//Brush b = new SolidBrush(colors[i]);
				Brush b = new LinearGradientBrush(topLeft, botRight, colors[i], colors2[i]);

				switch (shapes[i])
				{
					case SHAPE_BOX:
						g.FillRectangle(b, topLeft.X, topLeft.Y, shapeheight,shapeheight); 
						break;

					case SHAPE_CIRCLE:
						//GraphicTools.Sphere(x, y+(valueheight/2), shapeheight/2, colors[i], colors[i], g);
						g.FillEllipse(b, topLeft.X, topLeft.Y, shapeheight,shapeheight);
						break;

					case SHAPE_TRIANGLE:
						g.FillPolygon(b, new PointF[]{topCenter, botRight, botLeft}, FillMode.Alternate);
						break;

					case SHAPE_TRIANGLED:
						g.FillPolygon(b, new PointF[]{botCenter, topRight, topLeft}, FillMode.Alternate);
						break;

					case SHAPE_ELLIPSE:
						g.FillEllipse(b, topLeft.X, topLeft.Y+shapeheight/4, shapeheight,shapeheight/2);
						break;

					case SHAPE_ELLIPSED:
						g.FillEllipse(b, topLeft.X+shapeheight/4, topLeft.Y, shapeheight/2,shapeheight);
						break;
				}
				i++;

                if (orders.Length > i && (orders[i-1] != orders[i]))
				    y+=valueheight;
			}

			return pol;
			
		}

		private void ComputeNotext()
		{
			int xoff = 3;
			int yoff = 3;
			int i;

			float linepos = yoff*2;

			Bitmap bmp = new Bitmap(width + 2*xoff,5000 + 2*xoff);
			Graphics g = Graphics.FromImage(bmp);

			Color bgcol = BackColorA;
			
			foreach (Question q in Questions)
			{
                float[] values = new float[PersonOrder.Length];
                int[] shapes = new int[PersonOrder.Length];
                Color[] colors = new Color[PersonOrder.Length];
                Color[] colors2 = new Color[PersonOrder.Length];
                int[] orders = new int[PersonOrder.Length];
				i = 0;
                foreach (PersonSetting ps in PersonOrder)
				{
					values[i] = q.GetAverageByPersonAsMark(Eval, ps) - 1;
					shapes[i] = ps.Shape;
					colors[i] = ps.Color1;
					colors2[i] = ps.Color2;

                    orders[i] = (int)PersonGroups[ps];
					i++;
				}

                if (bgcol == BackColorA) bgcol = BackColorB;
                else bgcol = BackColorA;

				Bitmap pol = PolarityImage(width-3*xoff, orders, values, shapes, colors, colors2, bgcol);
				g.DrawImage(pol, xoff, linepos);
				
				linepos += pol.Height + 2*yoff;
			}

			Bitmap result = new Bitmap(width + 2*xoff,(int)linepos+1);
			Graphics rg = Graphics.FromImage(result);

			rg.DrawImage(bmp, 0, 0);

			OutputImage = result;
		}

		public void Compute06()
		{
            /*
			if (imagesonly)
			{
				ComputeNotext();
				return;
			}
             * */

			int i;
            if (width == 0 || height == 0) return;
			OutputImage = new Bitmap(width,height);

			//header
            string[] header = new string[1 + PersonOrder.Length + 1];
			header[0] = "";
			i=1;
            foreach (PersonSetting ps in PersonOrder)
				header[i++] = ps.Short;




			header[i] = "";
	
			//dimensions
			int[] dimensions = new int[1 + CombinedPersons.Length + 1];

            for (i = 0; i < PersonOrder.Length; i++)
				dimensions[i+1] = 60;

            int pwid = width - (60 * PersonOrder.Length);

			dimensions[0] = pwid/4;
			dimensions[dimensions.Length-1] = 3*(pwid/4);


			string[] markheader = new string[5];
			i = 0;
			foreach (string a in Questions[0].AnswerList)
			{
				markheader[i++] = a;
				if (i == 5) break;
			}

			int markwid = dimensions[dimensions.Length-1] / 5;

			///Vars
			///

			int Width = 0;
			foreach (int d in dimensions)
				Width+=d;

			SizeF size;

			int xoff = 3;
			int yoff = 3;

			float linepos = yoff*2;

			///Tools
			///
			SolidBrush HeaderBack = new SolidBrush(Color.LightGray);
			SolidBrush LineBack2  = new SolidBrush(Color.White);
			SolidBrush LineBack1  = new SolidBrush(Color.White);

			Pen OuterLine = new Pen(Color.Gray, 2);
			Pen SeperatorLine = new Pen(Color.Black, 2);
			Pen GridLine = new Pen(Color.Black, 2);

			SolidBrush BlackBrush = new SolidBrush(Color.Black);

			Font HeadFont = new Font("Arial", 9, FontStyle.Bold);
			Font TextFont = new Font("Arial", 8, FontStyle.Regular);

			if (ValueFont == null) 
				ValueFont = TextFont;

			if (QFont == null) 
				QFont = TextFont;

			///
			Bitmap bmp = new Bitmap(Width + 2*xoff,5000 + 2*xoff);
			Graphics g = Graphics.FromImage(bmp);
			g.SmoothingMode = SmoothingMode.AntiAlias;

			g.Clear(Color.White);

			float hheight = 0;
			int widpos;

			///header
			///

			Color[] hcolors = new Color[PersonOrder.Length + 2];

			int c = 1;
            foreach (PersonSetting ps in PersonOrder)
			{
				hcolors[c++] = ps.Color2;
			}

			hcolors[0] = hcolors[c] = Color.Black;



			//mittelwerte


			int mwhei = 20;
			int mwlen = 0;

			for (i = 1; i < dimensions.Length-1; i++)
				mwlen += dimensions[i];

			//g.FillRectangle(HeaderBack, xoff, yoff, Width-xoff, mwhei+2*yoff);

			g.DrawLine(GridLine, xoff+dimensions[0], yoff, xoff+dimensions[0], yoff+mwhei);
			g.DrawLine(GridLine, xoff+dimensions[0]+mwlen, yoff, xoff+dimensions[0]+mwlen, yoff+mwhei);

			string mws = GraphicTools.SplitString("Mittelwerte", mwlen, g, HeadFont); 
			SizeF siz = g.MeasureString(mws, HeadFont);

			if (siz.Width > mwlen) mws = "MW";
			siz = g.MeasureString(mws, HeadFont);

			g.DrawString(mws, HeadFont, new SolidBrush(hcolors[i]), xoff+dimensions[0]+(mwlen-siz.Width)/2, linepos);
			
			widpos = 0;

			for (i=0; i< dimensions.Length-1; i++)
				widpos += dimensions[i];

			widpos+= 0;

			float wid = dimensions[dimensions.Length-1] - 3*xoff;

			//TODO
			float scale = (float)(int)(wid - 1*xoff) / 4;
			float scale2 = (float)(int)(wid - 6*xoff) / 4;

			for (int l = 1; l < 6; l++)
				g.DrawString(l.ToString(), TextFont, new SolidBrush(Color.Black), widpos+10+(l-1)*scale2, linepos);

					
			linepos += mwhei + yoff;

			//seperator line below "MW"
			g.DrawLine(SeperatorLine, xoff+dimensions[0], linepos, xoff+dimensions[0]+mwlen, linepos);

			linepos+=yoff;

			if (header != null)
			{
			
				///content
				///

				hheight = 0;
			
				for (i = 0; i < dimensions.Length; i++)
				{
					size = g.MeasureString(GraphicTools.SplitString(header[i], dimensions[i], g, HeadFont), HeadFont, new PointF(0, 0), StringFormat.GenericDefault);				
					if (size.Height > hheight)
						hheight = size.Height;
				}

				foreach (string h in markheader)
				{
					size = g.MeasureString(GraphicTools.SplitString(h, markwid, g, HeadFont), HeadFont, new PointF(0, 0), StringFormat.GenericDefault);				
					if (size.Height > hheight)
						hheight = size.Height;
				}

				//g.FillRectangle(HeaderBack, xoff, yoff+mwhei, Width-xoff, hheight+3*yoff);

				widpos = xoff*2;

				for (i = 0; i < dimensions.Length; i++)
				{
					string colh = GraphicTools.SplitString(header[i], dimensions[i]-2*xoff, g, HeadFont); 
					SizeF s = g.MeasureString(colh, HeadFont, dimensions[i]-2*xoff, StringFormat.GenericDefault);
				
					g.DrawString(colh, HeadFont, new SolidBrush(hcolors[i]), widpos+((dimensions[i]-s.Width)/2)-xoff, linepos);

					widpos += dimensions[i];
				}

				//mark header

				widpos = 0;

				for (i=0; i< dimensions.Length-1; i++)
					widpos += dimensions[i];

				widpos+=10;

				foreach (string h in markheader)
				{
					string ms = GraphicTools.SplitString(h, markwid, g, HeadFont);
					size = g.MeasureString(ms, HeadFont, new PointF(0, 0), StringFormat.GenericDefault);				
					
					g.DrawString(ms, TextFont, new SolidBrush(Color.Black), (widpos+(markwid-size.Width)/2)+2*xoff, linepos-2*yoff);

					widpos += markwid;
				}

				linepos += hheight;

				g.DrawLine(SeperatorLine, xoff, linepos, Width, linepos);

				linepos+=yoff;
			}

			//rows

			float headhei = linepos;

			Color bgcol = Color.White;

			foreach (Question q in Questions)
			{
				widpos = xoff*2 + dimensions[0];
				string text;
				

				text = GraphicTools.SplitString(eval.getTextOverload(q), dimensions[0]-xoff*2, g, QFont);
				size = g.MeasureString(text, QFont);

                float[] values = new float[PersonOrder.Length];
                int[] shapes = new int[PersonOrder.Length];
                Color[] colors = new Color[PersonOrder.Length];
                Color[] colors2 = new Color[PersonOrder.Length];
				i = 0;

                int[] orders = new int[PersonOrder.Length];

                foreach (PersonSetting ps in PersonOrder)
				{
					values[i] = q.GetAverageByPersonAsMark(Eval, ps) - 1;
					
					shapes[i] = ps.Shape;
					colors[i] = ps.Color1;
					colors2[i] = ps.Color2;

                    orders[i] = (int)PersonGroups[ps];

					widpos += dimensions[i+1];

					i++;
				}

                if (bgcol == BackColorA) bgcol = BackColorB;
                else bgcol = BackColorA;

				//float wid = dimensions[dimensions.Length-1] - 3*xoff;

				Bitmap pol = PolarityImage(wid-xoff, orders, values, shapes, colors, colors2, bgcol);

                float lineh = Math.Max(size.Height, pol.Height);

				g.FillRectangle(new SolidBrush(bgcol), xoff, linepos-yoff, Width-xoff, lineh+2*yoff);

				//TODO
				//float scale = (float)(int)(wid - 20) / 4;

				for (int l = 1; l < 4; l++)
					g.DrawLine(new Pen(Color.Gray, 3), widpos-xoff+l*scale, linepos-yoff, widpos-xoff+l*scale, linepos+lineh+1*yoff);
				

				g.DrawImage(pol, widpos-xoff, linepos);

				g.DrawString(text, QFont, BlackBrush, xoff*2, linepos + lineh/2 - size.Height/2);

				widpos = xoff*2 + dimensions[0];
				i = 0;
                int texthei = 0;
                foreach (PersonSetting ps in PersonOrder)
				{
					float val = (float)Math.Round(q.GetAverageByPersonAsMark(Eval, ps), 1);

					size = g.MeasureString(val.ToString(), HeadFont);

					if (val >= 1 && val <= 5)
						g.DrawString(val.ToString(), ValueFont, new SolidBrush(ps.Color2), widpos+((dimensions[i+1]-size.Width)/2)-2*yoff, (linepos + texthei) + lineh/2 - size.Height/2);

					widpos += dimensions[i+1];
                    
                    
					i++;

                    if ((orders.Length > i) && (orders[i - 1] != orders[i]))
                    {
                        texthei += 30;
                    }
				}
				
				linepos +=  lineh + yoff;

				g.DrawLine(GridLine, xoff, linepos-1, Width, linepos-1);

				linepos += yoff;
				
			}
			
			//draw border

			
			//g.DrawLine(OuterLine, xoff, yoff, Width, yoff);
			//g.DrawLine(OuterLine, xoff, linepos-yoff, Width, linepos-yoff);
			//g.DrawLine(OuterLine, xoff, yoff, xoff, linepos-yoff);
			//g.DrawLine(OuterLine, Width, yoff, Width, linepos-yoff);

			
			//g.DrawRectangle(OuterLine, xoff, yoff, Width-xoff, linepos-2*yoff);
			g.DrawRectangle(OuterLine, xoff, headhei-yoff, Width-xoff, linepos-headhei);
			g.DrawRectangle(OuterLine, xoff+dimensions[0], yoff, Width-xoff-dimensions[0], headhei-2*yoff);

			// draw grid


			widpos = xoff + dimensions[0];
			g.DrawLine(GridLine, widpos, yoff, widpos+mwlen, yoff);
			for (i = 1; i < dimensions.Length; i++)
			{
				//GridLine = new Pen(Color.Green, 2);
				float posy = yoff+mwhei+2*yoff;
				if (i == 1 || i == dimensions.Length-1)
					posy = yoff;

				g.DrawLine(GridLine, widpos, posy, widpos, linepos-yoff);
				widpos += dimensions[i];
			}

			

			Bitmap result = new Bitmap(Width + 2*xoff,(int)linepos+1);
			Graphics rg = Graphics.FromImage(result);

			rg.DrawImage(bmp, 0, 0);

			OutputImage = result;
		}

        public void Compute07()
        {

            //three sizes

            float stot = (float)width;

            float stxt = stot * SizePercentText;
            float sval = stot * SizePercentValues;
            float spic = stot - (stxt + sval);

            //compute

            int ShortWidth = (int)(sval / (float)PersonOrder.Length);

            int ValueWidth = PersonOrder.Length * ShortWidth;

            int RestWidth = width - ValueWidth;

            int TextWidth = (int)stxt; //(RestWidth / 3);

            int DrawWidth = RestWidth - TextWidth;

            int HeaderHeight = 60;

            int HeaderWidth = DrawWidth + ValueWidth;

            int LineHeight = 40;


            #region compute groups

            Hashtable Groups = new Hashtable();

            int extra = -1;
            foreach (PersonSetting ps in PersonOrder)
            {
                // get group id
                int id = (int)PersonGroups[ps];

                if (id == 0) // extra group
                {
                    ArrayList ng = new ArrayList();
                    ng.Add(ps);

                    Groups[extra] = ng;

                    extra--;
                }
                else //existing or new group
                {
                    if (Groups.ContainsKey(id))
                    {
                        ArrayList grp = (ArrayList)Groups[id];
                        grp.Add(ps);
                    }
                    else
                    {
                        ArrayList ng = new ArrayList();
                        ng.Add(ps);
                        Groups[id] = ng;
                    }
                }

            }
            #endregion

            //tools

            Graphics g;

            Pen BorderPen = new Pen(Color.Black, 1);

            Font AnswerFont = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point);

            Font mwHeaderFont = new Font("Arial", (0.6f * (float)(HeaderHeight / 2)), FontStyle.Regular, GraphicsUnit.Pixel);

            Font ShortFont = new Font("Arial", (0.6f * (float)(HeaderHeight / 2)), FontStyle.Regular, GraphicsUnit.Pixel);

            Brush AnswerBrush = new SolidBrush(Color.Black);
            Brush mwHeaderBrush = new SolidBrush(Color.DarkGray);
            Brush qTextBrush = new SolidBrush(Color.Black);


            //draw

            string[] markheader = new string[5];
            int i = 0;
            foreach (string a in Questions[0].AnswerList)
            {
                markheader[i++] = a;
                if (i == 5) break;
            }


            #region header
            /* header */

            if (HeaderWidth == 0 || HeaderHeight == 0) return;
            Bitmap Header = new Bitmap(HeaderWidth, HeaderHeight);
            g = Graphics.FromImage(Header);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(BackColorA);

            g.DrawLine(BorderPen, 0, 0, 0, HeaderHeight);
            g.DrawLine(BorderPen, 0, 0, HeaderWidth, 0);
            g.DrawLine(BorderPen, HeaderWidth-1, 0, HeaderWidth-1, HeaderHeight);

            g.DrawLine(BorderPen, ValueWidth, 0, ValueWidth, HeaderHeight);
            g.DrawLine(BorderPen, 0, HeaderHeight / 2, ValueWidth, HeaderHeight / 2);

            // mw header

            string mwHeader = "MITTELWERTE";
            SizeF mwSize = g.MeasureString(mwHeader, mwHeaderFont);

            if (mwSize.Width > ValueWidth)
            {
                mwHeader = "MW";
                mwSize = g.MeasureString(mwHeader, mwHeaderFont);
            }

            g.DrawString(mwHeader, mwHeaderFont, mwHeaderBrush, (ValueWidth - mwSize.Width) / 2, ( (HeaderHeight/2) - mwSize.Height) / 2);

            // mw headers

            i = 0;
            foreach (int grpId in Groups.Keys)
            {
                foreach (PersonSetting ps in (ArrayList)Groups[grpId])
                {

                    g.DrawLine(BorderPen, ShortWidth * i, HeaderHeight / 2, ShortWidth * i, HeaderHeight);

                    string sh = ps.Short;

                    ps.Sym.x = ShortWidth * i + ps.Sym.Size/2 + 3;
                    ps.Sym.y = HeaderHeight / 5 * 2;
                    ps.Sym.Draw(g, ps);

                    SizeF shs = g.MeasureString(sh, ShortFont);

                    g.DrawString(sh, ShortFont, new SolidBrush(ps.Color1), ShortWidth * i + ((ShortWidth - shs.Width) / 2), HeaderHeight / 2 + ((HeaderHeight / 2) - mwSize.Height) / 2);

                    i++;
                }
            }

            // draw headers

            int split = DrawWidth/4;
            int split2 = DrawWidth/5;

            for (i = 0; i < 5; i++)
            {
                //number

                string num = (i+1).ToString();
                SizeF numS = g.MeasureString(num, AnswerFont);

                int xpos = ValueWidth + (split * i) - (int)(numS.Width/2);

                if (i == 0) xpos += (int)numS.Width;
                if (i == 4) xpos -= (int)numS.Width;

                g.DrawString(num, AnswerFont, AnswerBrush, xpos, HeaderHeight - numS.Height);

                //text

                string mh = GraphicTools.SplitString(markheader[i], split2, g, AnswerFont);

                SizeF mhS = g.MeasureString(mh, AnswerFont);

                xpos = ValueWidth + (split*i) - (int)(mhS.Width/2);

                if (i == 0) xpos += (int)mhS.Width/2 + 5;
                if (i == 4) xpos -= (int)mhS.Width/2;

                g.DrawString(mh, AnswerFont, AnswerBrush, xpos, 0);
            }
            #endregion



            /* questions */

            ArrayList qImages = new ArrayList();

            Color BG = this.BackColorA;

            foreach (Question q in this.Questions)
            {
                //compute size
                //System.Windows.Forms.MessageBox.Show("text=" + q.Text + "\noverload=" + eval.getTextOverload(q));
                string qText = GraphicTools.SplitString(eval.getTextOverload(q), TextWidth - 20, g, this.QFont);
                SizeF qTextS = g.MeasureString(qText, QFont);

                int qHei = (int)Math.Max(qTextS.Height, Groups.Keys.Count * LineHeight);

                if (width == 0 || qHei == 0) continue;
                //draw

                Bitmap qbmp = new Bitmap(width, qHei);
                g = Graphics.FromImage(qbmp);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(BG);

                //border

                g.DrawRectangle(BorderPen, 0, 0, width - 1, qHei-1);

                for (i = 0; i < Groups.Keys.Count; i++)
                {
                    g.DrawLine(BorderPen, TextWidth, i * (qHei / Groups.Keys.Count), TextWidth + ValueWidth, i * (qHei / Groups.Keys.Count));
                }

                // id seperators

                for (i = 0; i < 4; i++)
                    g.DrawLine(BorderPen, TextWidth + ValueWidth + i * split, 0, TextWidth + ValueWidth + i * split, qHei);

                int xpos = TextWidth;

                int lpos = 0;

                foreach (int grpId in Groups.Keys)
                {
                    ArrayList grp = (ArrayList)Groups[grpId];

                    //values
                   
                    int gpos = xpos;

                    foreach (PersonSetting ps in grp)
                    {
                        float val = q.GetAverageByPersonAsMark(Eval, ps) - 1;

                        string txt = Math.Round(val+1, 1).ToString();
                        if (val == -2) txt = "-";
                        SizeF txtS = g.MeasureString(txt, ShortFont);

                        g.DrawString(txt, ShortFont, new SolidBrush(ps.Color1), gpos + ((ShortWidth - txtS.Width) / 2), lpos + ((LineHeight - txtS.Height) / 2));

                        g.DrawLine(BorderPen, gpos, lpos, gpos, lpos + LineHeight);
                        gpos += ShortWidth;

                        if (val == -2) continue;

                        //val = 1; 

                        // drawings

                        float x = TextWidth + ValueWidth + (((float)DrawWidth) / 4f) * val;
                        //float shapeheight = 20f;
                        float valueheight = (float)LineHeight;
                        float y = (float)lpos;

                        ps.Sym.x = x;
                        ps.Sym.y = y;
                        ps.Sym.valueheight = valueheight;

                        ps.Sym.Draw(g, ps.Color1, ps.Color2);

                        /*
                        PointF topLeft = new PointF(x - shapeheight / 2, y + (valueheight - shapeheight) / 2);
                        PointF topCenter = new PointF(x, y + (valueheight - shapeheight) / 2);
                        PointF topRight = new PointF(x + shapeheight / 2, y + (valueheight - shapeheight) / 2);
                        PointF botLeft = new PointF(x - shapeheight / 2, y + valueheight - (valueheight - shapeheight) / 2);
                        PointF botCenter = new PointF(x, y + valueheight - (valueheight - shapeheight) / 2);
                        PointF botRight = new PointF(x + shapeheight / 2, y + valueheight - (valueheight - shapeheight) / 2);

                        Brush b = new LinearGradientBrush(topLeft, botRight, ps.Color1, ps.Color2);

                        switch (ps.Shape)
                        {
                            case SHAPE_BOX:
                                g.FillRectangle(b, topLeft.X, topLeft.Y, shapeheight, shapeheight);
                                break;

                            case SHAPE_CIRCLE:
                                //GraphicTools.Sphere(x, y+(valueheight/2), shapeheight/2, colors[i], colors[i], g);
                                g.FillEllipse(b, topLeft.X, topLeft.Y, shapeheight, shapeheight);
                                break;

                            case SHAPE_TRIANGLE:
                                g.FillPolygon(b, new PointF[] { topCenter, botRight, botLeft }, FillMode.Alternate);
                                break;

                            case SHAPE_TRIANGLED:
                                g.FillPolygon(b, new PointF[] { botCenter, topRight, topLeft }, FillMode.Alternate);
                                break;

                            case SHAPE_ELLIPSE:
                                g.FillEllipse(b, topLeft.X, topLeft.Y + shapeheight / 4, shapeheight, shapeheight / 2);
                                break;

                            case SHAPE_ELLIPSED:
                                g.FillEllipse(b, topLeft.X + shapeheight / 4, topLeft.Y, shapeheight / 2, shapeheight);
                                break;
                        }
                         * */
                    }

                    //group seperators

                    g.DrawLine(BorderPen, xpos, 0, xpos, qHei);

                    xpos += grp.Count * ShortWidth;

                    g.DrawLine(BorderPen, xpos, 0, xpos, qHei);

                    
                    lpos += LineHeight;
                }
                

                g.DrawLine(BorderPen, xpos, 0, xpos, qHei);

                g.DrawString(qText, QFont, qTextBrush, 10, (qHei - qTextS.Height) / 2);

                qImages.Add(qbmp);


                if (BG == BackColorA) BG = BackColorB;
                else BG = BackColorA;
            }


            //combine

            int tHei = Header.Height;

            foreach (Bitmap bmp in qImages)
            {
                tHei += bmp.Height + 10;
            }
            
            if (width == 0 || tHei == 0) return;

            OutputImage = new Bitmap(width, tHei);
            g = Graphics.FromImage(OutputImage);

            g.DrawImage(Header, TextWidth, 0);

            int ypos = Header.Height;
            foreach (Bitmap bmp in qImages)
            {
                g.DrawImage(bmp, 0, ypos);

                ypos += bmp.Height + 10;
            }
            
        }

        public override void Compute()
        {
            if (Design == Output.Victor2006) Compute06();
            else Compute07();
        }

		public override void EditDialog()
		{
			OutputFormPolarity ofp = new OutputFormPolarity(eval, false, this);
			ofp.ShowDialog();
		}

        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_Polarity(eval, false, this);
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
