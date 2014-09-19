using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.Serialization;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output.Polarity2008
{
    [Serializable]
    public class Polarity2008 : Output
    {
        public bool imagesonly = false;

        public Font ValueFont;
        public Font QFont;
        public Font ShortFont;

        public Color BackColorA;
        public Color BackColorB;

        public PersonSetting[] PersonOrder;
        public Hashtable PersonGroups;

        public float SizePercentText;
        public float SizePercentValues;

        public int Design;

        public Question[] Questions;

        public ArrayList Cols;

        public bool ConnectTheDots = false;

        public int LineWidth = 5;
        public DashStyle LineStyle = DashStyle.Solid;

        private int _lastHeight;

        public override Output Clone
        {
            get
            {
                Polarity2008 clone = (Polarity2008)this.MemberwiseClone();

                clone.Cols = new ArrayList();
                
                foreach (PolarityUGSplit split in Cols)
                {
                    clone.Cols.Add(split.Clone());
                }

                return clone;
            }
        }


        public Polarity2008(Evaluation eval)
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

            Cols = new ArrayList();

            ShortFont = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Pixel);
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

            info.AddValue("Cols", this.Cols);

            info.AddValue("ConnectTheDots", this.ConnectTheDots);

            info.AddValue("ShortFont", this.ShortFont);

            info.AddValue("LineWidth", this.LineWidth);
            info.AddValue("LineStyle", this.LineStyle);
		}

		public Polarity2008(SerializationInfo info, StreamingContext ctxt)
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
            catch
            {
                PersonGroups = new Hashtable();
                foreach (PersonSetting ps in PersonOrder)
                    PersonGroups[ps] = 0;
            }

            try { this.Cols = (ArrayList)info.GetValue("Cols", typeof(ArrayList)); }
            catch { Cols = new ArrayList(); }

            try { this.ConnectTheDots = info.GetBoolean("ConnectTheDots"); }
            catch { ConnectTheDots = false; }

            try { this.ShortFont = (Font)info.GetValue("ShortFont", typeof(Font)); }
            catch { ShortFont = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Pixel); }

            try
            {
                this.LineWidth = info.GetInt32("LineWidth");
                this.LineStyle = (DashStyle) info.GetValue("LineStyle", typeof (DashStyle));
            } catch
            {
                this.LineWidth = 5;
                this.LineStyle = DashStyle.Solid;
            }
		}

        public override void LoadGlobalQ()
        {
            LoadQArray(Questions);
        }

        public override void LoadTargetQ(TargetData td)
        {
            LoadTQArray(td, Questions);
        }


        private Hashtable GetGroups()
        {
            Hashtable g = new Hashtable();

            foreach (PolarityUGSplit s in Cols)
            {
                if (s.GroupID == 0)
                {
                    ArrayList al = new ArrayList();
                    al.Add(s);
                    g[s] = al;
                }
                else if (!g.ContainsKey(s.GroupID))
                {
                    ArrayList al = new ArrayList();
                    al.Add(s);
                    g[s.GroupID] = al;
                }
                else
                {
                    ArrayList al = (ArrayList)g[s.GroupID];
                    al.Add(s);
                }
            }
            
            return g;
        }

        private Bitmap PolarityImage(float width, int[] orders, float[] values, int[] shapes, Color[] colors, Color[] colors2, Color Background)
        {
            if (values.Length == 0)
            {
                return new Bitmap((int)width, 1);
            }
            float valueheight = 26;
            float shapeheight = 20;


            Bitmap pol = new Bitmap((int)width, (int)(valueheight * values.Length));
            Graphics g = Graphics.FromImage(pol);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float XOff = 0; //shapeheight/2;

            g.Clear(Background);

            g.FillRectangle(new SolidBrush(Background), XOff, 0, width - 1 - (2 * XOff), pol.Height - 1);

            //grid, border

            float scale = (float)(int)(width - (2 * XOff)) / 4;

            //g.DrawRectangle(new Pen(Color.Gray), XOff, 0, width-1-(2*XOff), pol.Height-1);

            for (int l = 1; l < 4; l++)
                g.DrawLine(new Pen(Color.Gray, 3), XOff + l * scale, 0, XOff + l * scale, pol.Height);

            //shapes

            int i = 0;
            float y = 0;
            foreach (float val in values)
            {
                if (val == -1)
                {
                    i++;
                    y += valueheight;
                    continue;
                }
                float x = XOff + (scale * val);

                PointF topLeft = new PointF(x - shapeheight / 2, y + (valueheight - shapeheight) / 2);
                PointF topCenter = new PointF(x, y + (valueheight - shapeheight) / 2);
                PointF topRight = new PointF(x + shapeheight / 2, y + (valueheight - shapeheight) / 2);
                PointF botLeft = new PointF(x - shapeheight / 2, y + valueheight - (valueheight - shapeheight) / 2);
                PointF botCenter = new PointF(x, y + valueheight - (valueheight - shapeheight) / 2);
                PointF botRight = new PointF(x + shapeheight / 2, y + valueheight - (valueheight - shapeheight) / 2);

                //Brush b = new SolidBrush(colors[i]);
                Brush b = new LinearGradientBrush(topLeft, botRight, colors[i], colors2[i]);

                switch (shapes[i])
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
                i++;

                if (orders.Length > i && (orders[i - 1] != orders[i]))
                    y += valueheight;
            }

            this.height = pol.Height;

            return pol;

        }


        //FIXME
        public override void Compute()
        {

            //three sizes

            float stot = (float)width;

            float stxt = stot * SizePercentText;
            float sval = stot * SizePercentValues;
            float spic = stot - (stxt + sval);

            //compute

            int ShortWidth = (int)(sval / (float)Cols.Count);

            int ValueWidth = Cols.Count * ShortWidth;

            int RestWidth = width - ValueWidth;

            int TextWidth = (int)stxt; //(RestWidth / 3);

            int DrawWidth = RestWidth - TextWidth;

            int HeaderHeight = 60;

            int HeaderWidth = DrawWidth + ValueWidth;

            int LineHeight = 40;

            Hashtable Conns = new Hashtable();


            #region compute groups

            Hashtable Groups = new Hashtable();

            int extra = -1;
            foreach (PolarityUGSplit pus in Cols) //PersonSetting ps in PersonOrder)
            {
                // get group id
                int id = pus.GroupID;// (int)PersonGroups[ps];

                if (id == 0) // extra group
                {
                    ArrayList ng = new ArrayList();
                    ng.Add(pus);

                    Groups[extra] = ng;

                    extra--;
                }
                else //existing or new group
                {
                    if (Groups.ContainsKey(id))
                    {
                        ArrayList grp = (ArrayList)Groups[id];
                        grp.Add(pus);
                    }
                    else
                    {
                        ArrayList ng = new ArrayList();
                        ng.Add(pus);
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

            //Font ShortFont = new Font("Arial", (0.6f * (float)(HeaderHeight / 2)), FontStyle.Regular, GraphicsUnit.Pixel);

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
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(BackColorA);

            g.DrawLine(BorderPen, 0, 0, 0, HeaderHeight);
            g.DrawLine(BorderPen, 0, 0, HeaderWidth, 0);
            g.DrawLine(BorderPen, HeaderWidth - 1, 0, HeaderWidth - 1, HeaderHeight);

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

            g.DrawString(mwHeader, mwHeaderFont, mwHeaderBrush, (ValueWidth - mwSize.Width) / 2, ((HeaderHeight / 2) - mwSize.Height) / 2);

            // mw headers

            i = 0;
            foreach (int grpId in Groups.Keys)
            {
                foreach ( PolarityUGSplit pus in (ArrayList)Groups[grpId])//PersonSetting ps in (ArrayList)Groups[grpId])
                {
                    if (pus.person == null) continue;

                    g.DrawLine(BorderPen, ShortWidth * i, HeaderHeight / 2, ShortWidth * i, HeaderHeight);

                    string sh = pus.Name;// ps.Short;

                    pus.person.Sym.x = ShortWidth * i + pus.person.Sym.Size / 2 + 3;
                    pus.person.Sym.y = HeaderHeight / 5 * 2;
                    pus.person.Sym.Draw(g, pus.Col1, pus.Col2);

                    SizeF shs = g.MeasureString(sh, ShortFont);

                    g.DrawString(sh, ValueFont, new SolidBrush(pus.Col1), ShortWidth * i + ((ShortWidth - shs.Width) / 2), HeaderHeight / 2 + ((HeaderHeight / 2) - mwSize.Height) / 2);

                    i++;
                }
            }

            // draw headers

            int split = DrawWidth / 4;
            int split2 = DrawWidth / 5;

            for (i = 0; i < 5; i++)
            {
                //number

                string num = (i + 1).ToString();
                SizeF numS = g.MeasureString(num, AnswerFont);

                int xpos = ValueWidth + (split * i) - (int)(numS.Width / 2);

                if (i == 0) xpos += (int)numS.Width;
                if (i == 4) xpos -= (int)numS.Width;

                g.DrawString(num, AnswerFont, AnswerBrush, xpos, HeaderHeight - numS.Height);

                //text

                string mh = GraphicTools.SplitString(markheader[i], split2, g, AnswerFont);

                SizeF mhS = g.MeasureString(mh, AnswerFont);

                xpos = ValueWidth + (split * i) - (int)(mhS.Width / 2);

                if (i == 0) xpos += (int)mhS.Width / 2 + 5;
                if (i == 4) xpos -= (int)mhS.Width / 2;

                g.DrawString(mh, ShortFont, AnswerBrush, xpos, 0);
            }
            #endregion



            /* questions */

            ArrayList qImages = new ArrayList();

            Color BG = this.BackColorA;

            foreach (Question q in this.Questions)
            {
                //compute size

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

                g.DrawRectangle(BorderPen, 0, 0, width - 1, qHei - 1);

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

                    foreach (PolarityUGSplit pus in grp) //PersonSetting ps in grp)
                    {
                        if (pus.person == null) continue;

                        float val;
                        if (pus.split == null)
                            val = q.GetAverageByPersonAsMark(Eval, pus.person) - 1;
                        else
                        {
                            QuestionSplit qsp = new QuestionSplit(q, pus.split);
                            Question[] splits = qsp.ComputeQuestionSplits(Eval);
                            val = splits[pus.splitID].GetAverageByPersonAsMark(Eval, pus.person) - 1;
                        }

                        string txt = Math.Round(val + 1, 1).ToString();
                        if (val == -2) txt = "-";
                        SizeF txtS = g.MeasureString(txt, ShortFont);

                        g.DrawString(txt, ValueFont, new SolidBrush(pus.Col1), gpos + ((ShortWidth - txtS.Width) / 2), lpos + ((LineHeight - txtS.Height) / 2));

                        g.DrawLine(BorderPen, gpos, lpos, gpos, lpos + LineHeight);
                        gpos += ShortWidth;

                        if (val == -2) continue;

                        //val = 1; 

                        // drawings

                        float x = TextWidth + ValueWidth + (((float)DrawWidth) / 4f) * val;
                        //float shapeheight = 20f;
                        float valueheight = (float)LineHeight;
                        float y = (float)lpos;

                        pus.person.Sym.x = x;
                        pus.person.Sym.y = y;
                        pus.person.Sym.valueheight = valueheight;

                        pus.person.Sym.Draw(g, pus.Col1, pus.Col2);

                        Hashtable dots;
                        if (Conns.ContainsKey(qbmp)) dots = (Hashtable)Conns[qbmp];
                        else { dots = new Hashtable(); }

                        dots[pus] = new PointF(x, y + pus.person.Sym.Size / 2);

                        Conns[qbmp] = dots;

                        Console.WriteLine("added " + pus.Name + "/" + dots[pus] + " to dots");

                    }

                    //group seperators

                    g.DrawLine(BorderPen, xpos, 0, xpos, qHei);

                    xpos += grp.Count * ShortWidth;


                    Console.WriteLine("[Output][Polarity2008] - drawing " + xpos + "/" + qHei);

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

            _lastHeight = tHei;

            OutputImage = new Bitmap(width, tHei);
            g = Graphics.FromImage(OutputImage);

            g.DrawImage(Header, TextWidth, 0);

            int ypos = Header.Height;
            foreach (Bitmap bmp in qImages)
            {
                g.DrawImage(bmp, 0, ypos);

                ypos += bmp.Height + 10;
            }

            //draw connectors
            if (ConnectTheDots)
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                Console.WriteLine("CONNECT THE DOTS!");
                foreach (PolarityUGSplit sp in Cols)
                {
                    ypos = Header.Height;
                    ArrayList points = new ArrayList();

                    int bc = 1;
                    foreach (Bitmap bmp in qImages)
                    {
//                        Console.WriteLine("[" + sp.Name + "][" + bc + "]\tcontains bmp?" + Conns.ContainsKey(bmp));

                        if (Conns.ContainsKey(bmp))
                        {
                            Hashtable dots = (Hashtable)Conns[bmp];

                            if (dots.ContainsKey(sp))
                            {
                                PointF p = (PointF)dots[sp];
                                p.Y += ypos + 10;
                                points.Add(p);

                                ypos += bmp.Height + 10;
                            }
                        }
                        bc++;
                    }

                    Pen connPen = new Pen(sp.Col1, LineWidth);
                    connPen.DashStyle = LineStyle;

                    for (int ii = 1; ii < points.Count; ii++)
                    {
                        Console.WriteLine("[ConnectTheDots]\t" + sp.Name + "\t" + (PointF)points[ii - 1] + "\t" + (PointF)points[ii]);
                        g.DrawLine(connPen, (PointF)points[ii - 1], (PointF)points[ii]);
                    }

                }
            }

        }


        public void StoreHeight()
        {
            this.height = _lastHeight;
        }

        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_Polarity2008(eval, false, this);
        }

        public override void EditDialog()
        {
            //OutputControl_Polarity2008 ofp = new OutputControl_Polarity2008(eval, false, this);
            //ofp.ShowDialog();
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
