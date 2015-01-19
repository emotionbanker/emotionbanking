using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.PieChart;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using dotnetCHARTING.WinForms;
using umfrage2;
using umfrage2._2007;
using ImageFormat = System.Drawing.Imaging.ImageFormat;
using System.Collections;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{
	[Serializable]
	public class Pie : Output
	{
		public Bitmap PieImage;
        			
		public bool Ring = false;
        public bool ThreeD = false;
        public bool Explode = false;
        public bool AvgPie = false;

		public int StartAngle = 0;

        public int Design;
        public DNCSettings dnc;

		public int PieHeight
		{
			get
			{
				return (height/5) * 3;
			}
		}

		public int TableWidth
		{
			get {return 300;}
		}
		
		public Question q;

		public Pie(Evaluation eval)
		{
            this.Design = Output.Victor2007;
            dnc = new DNCSettings();
            
            this.eval = eval;

            this.height = this.width = 500; 
		}

        public override void LoadGlobalQ()
        {
            LoadQ(q);
        }

        public override void LoadTargetQ(TargetData td)
        {
            LoadTQ(td, q);
        }

		/// <summary>
		/// serialization functions
		/// </summary>
		/// <param name="info"></param>
		/// <param name="ctxt"></param>
		    public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		    {
			    LoadSerData(info, ctxt);

                Question.SetMultipart(q, Multipart);

			    info.AddValue("q", this.q);
			    info.AddValue("Ring", this.Ring);
			    info.AddValue("StartAngle", this.StartAngle);

                info.AddValue("Design", this.Design);
                info.AddValue("dnc", this.dnc);

                info.AddValue("ThreeD", this.ThreeD);
                info.AddValue("Explode", this.Explode);

                info.AddValue("AvgPie", this.AvgPie);
		    }

		    public Pie(SerializationInfo info, StreamingContext ctxt)
		    {
			    base.ReadSerData(info, ctxt);

			    this.q = (Question)info.GetValue("q", typeof(Question));

			    this.PieImage = new Bitmap(1,1);

			    try
			    {
				    this.Ring = info.GetBoolean("Ring");
			    }
			    catch
			    {
				    this.Ring = false;
			    }

                try
                {
                    this.Explode = info.GetBoolean("Explode");
                }
                catch
                {
                    this.Explode = false;
                }

                try
                {
                    this.ThreeD = info.GetBoolean("ThreeD");
                }
                catch
                {
                    this.ThreeD = false;
                }

			    try
			    {
				    this.StartAngle = info.GetInt32("StartAngle");
			    }
			    catch
			    {
				    this.StartAngle = 0;
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

                try { this.AvgPie = info.GetBoolean("AvgPie"); }
                catch { this.AvgPie = false; }
		    }

		private Bitmap ComputeTable(int width, decimal[] values, Color[] colors, string[] texts)
		{
			return GraphicTools.ColorTable(colors, colors, texts, values, width);
		}

		public float deg2rad(float grad)
		{
			return grad* (float)(Math.PI/180f);
		}

		public float rad2deg(float rad)
		{
			return rad * 57.2957795f;
		}

		private Bitmap DrawRings(float x, float y, float ringwid, float width, float height, float[] values, Color[] colors, float DOffset, bool last)
		{
			Console.WriteLine("called drawrings");
			Bitmap bmp = new Bitmap((int)width+(int)DOffset, (int)height+(int)DOffset);

			Graphics g = Graphics.FromImage(bmp);

			//g.SmoothingMode = SmoothingMode.HighQuality;;

			//g.Clear(Color.White);

			float angle = StartAngle;
		
			float gap = 2;
			float gaps = gap * values.Length;
			float scale = (360f - gaps) / 100f;
			Font font = new Font("Arial", ringwid/3, FontStyle.Bold, GraphicsUnit.Pixel);
			
			Pen bpen = new Pen(Color.Black);

			int i = 0;
			foreach (float f in values)
			{
				//if (!last) continue;

				float nangle = (f * scale);

				Color c = colors[i];
				if (c.Equals(Color.White)) c= Color.FromArgb(244,255,255);

				if (!last) c = GraphicTools.Contrast(c, 50);

				GraphicsPath path = new GraphicsPath();

				//path.AddArc(new RectangleF(x,y,width,height), angle, nangle);

				for (float a = angle; a <= (angle+nangle); a+=1)
				{
					float cx = x + width/2f + (float)(Math.Cos(deg2rad(a)) * (width)/2d);
					float cy = y + height/2f + (float)(Math.Sin(deg2rad(a)) * (height)/2d);

					path.AddLine(cx,cy,cx,cy);
					//path.CloseFigure();
				}

				path.AddLine(x + width/2, y + height/2, x + width/2, y + height/2);

				path.CloseFigure();

				//g.DrawPath(new Pen(c), path);
				g.FillPath(new SolidBrush(c), path);
					
				//g.FillPie(new SolidBrush(c), x, y, width, height, angle, nangle);

				//break;

				angle += nangle + gap;

				i++;
			}

			//return bmp;

			//if ( last)
			g.FillEllipse(new SolidBrush(Color.White), ringwid, ringwid, width-2*ringwid, height-2*ringwid);

			angle = StartAngle;


			i = 0;
			if (last)
			{

				//Console.WriteLine("texts");
				foreach (float f in values)
				{
					float nangle = (f * scale);
			
					float an = angle + nangle/2;

					//x = links oben
					//y = links oben

					//width = durchmesser x
					//height = durchmessery

					// (x+width/2, y+height/2) = mittelpunkt

					// an = winkel

					// width-ringwid/2  = radius, mitte vom ellipsensegment
					// height-ringwid/2 = radius, mitte vom ellipsensegment

					// x = mx + sin(a) * radx
					// y = my - cos(a) * rady
				
					float cx = x + width/2f + (float)(Math.Cos(deg2rad(an)) * (width-ringwid)/2d);
					float cy = y + height/2f + (float)(Math.Sin(deg2rad(an)) * (height-ringwid)/2d);

					string s = Math.Round(f, 1).ToString() + "%";
					SizeF si = g.MeasureString(s, font);
					
					//Console.WriteLine(s + " on " + cx + "/" + cy);
					if (f > 5) 
					{
						g.SmoothingMode = SmoothingMode.None;
						g.DrawString(s, font, new SolidBrush(Color.Black), cx-si.Width/2f, cy-si.Height/2f);

						//bmp.SetPixel((int)cx,(int)cy,Color.Blue);
					}

					angle = angle % 360;
				
					angle += nangle;

					angle = angle%360;

					angle+=gap;
					i++;
				}
			}

			bmp.MakeTransparent(Color.White);
			return bmp;
		}

		private Bitmap ComputeRing(int width, int height, decimal[] values, Color[] colors, string[] texts)
		{
			Console.WriteLine("ComputeRing()");
			if (values.Length == 0)
				return new Bitmap(width, height);

			Bitmap ring = new Bitmap(width, height);

			Graphics g = Graphics.FromImage(ring);
			g.Clear(Color.White);

			float ringwid = width/10;
			float DOffset = ringwid/3;

			float rwid = width - DOffset;
			float rhei = height - DOffset;



			float[] percents = new float[values.Length];

			int i = 0;
			float total = 0;

			foreach (decimal val in values)
			{
				percents[i++] = (float)val;
				total += (float)val;
			}

			for (i = 0; i < percents.Length; i++)
				percents[i] = 100f * (percents[i]/total);

			//g.SmoothingMode = SmoothingMode.AntiAlias;

			for (float off = 0; off < DOffset; off+=1f)
			{
				//DrawRings(g, DOffset - off, off, ringwid, rwid, rhei, percents, colors, DOffset, false);
				g.DrawImage(DrawRings(0, 0, ringwid, rwid, rhei, percents, colors, DOffset, false), DOffset - off, off);
			}	
			//DrawRings(g, 0, DOffset, ringwid, rwid, rhei, percents, colors, DOffset, true);
			g.DrawImage(DrawRings(0, 0, ringwid, rwid, rhei, percents, colors, DOffset, true), 0, DOffset);

			return ring;
		}

		private Bitmap ComputePie(int width, int height, decimal[] values, Color[] colors, string[] texts)
		{
			if (values.Length == 0)
				return new Bitmap(width, height);

			decimal total = 0;
			foreach (decimal val in values)
			{
				total += val;
			}

			for (int i = 0; i < values.Length; i++)
				values[i] = (values[i] / total) * 100;

			PieChart3D pie = new PieChart3D(0, 0, width, height, values);
			

			
			pie.Texts = texts;
			float[] displacements = new float[values.Length];
			
			for (int i = 0; i < values.Length; i++)
				displacements[i] = 0.05f;

			pie.SliceRelativeDisplacements = displacements;

			pie.SliceRelativeHeight = 0.2f;
			//pie.Font = new Font("Arial", 8);
			//pie.ForeColor = Color.White;
			pie.ShadowStyle = ShadowStyle.GradualShadow;
			pie.EdgeColorType = EdgeColorType.DarkerThanSurface;
			pie.EdgeLineWidth = 1;
			pie.InitialAngle = StartAngle;

			pie.FitToBoundingRectangle = true;

			pie.Colors = colors;
			
			Bitmap pbmp = new Bitmap((int)pie.Width+1, (int)pie.Height+1);
			Graphics g = Graphics.FromImage(pbmp);
			g.SmoothingMode = SmoothingMode.AntiAlias;

			g.Clear(Color.White);
			pie.Draw(g);
			pie.PlaceTexts(g);

			return pbmp;
		}

		public void Compute06()
		{
			//width  = 500;
			//height = 300;

			//Console.WriteLine("computing pie for " + q.SID);
			//Console.WriteLine(q.AnswerList.Length + " possible answers");
			//Console.WriteLine(q.Results.Count + " results for this question");
			if (q == null)
			{
				OutputImage = new Bitmap(width, height);
				//Console.WriteLine("q is null");
				return;
			}

			string[] texts = q.AnswerList;

			decimal[] values = new decimal[q.AnswerList.Length];

			int i = 0;
			int zeroes = 0;
			foreach (string answer in q.AnswerList)
			{
				int j; 
				for (j = 0; j < q.AnswerList.Length; j++)
					if (q.AnswerList[j].Equals(answer))
						break;

				if (j == q.AnswerList.Length)
				{
					values[i++] = (decimal)0;
					continue;
				}

				int count = 0;
				//Console.WriteLine(q.SID + "=" + q.Results.Count);

				//Console.Write("start counting for " + answer + "... ");

				foreach (Result r in q.Results)
				{
					bool add = false;
					int PID;

					PID =  Eval.GetPersonIdByUser(r.UserID);

					//Console.WriteLine("pid=" + PID);

					foreach (Person p in PersonList)
						if (p.ID == PID)
							add = true;

					foreach (PersonCombo c in ComboList)
						if (c.ContainsID(PID))
							add = true;

					if (add)
					{
						if (q.Display.ToLower().Equals("radio"))
						{
							if (r.SelectedAnswer == i)
								count++;
						}
						else
						{
							string[] tanswers = r.TextAnswer.Split(';');
							foreach (string tanswer in tanswers)
								if (tanswer.Equals(answer))
									count++;
						}
					}
				}

				//Console.WriteLine(count.ToString());
				values[i++] = (decimal)count;
			}


			//zeroes?
			
			decimal total = 0;
			foreach (decimal d in values)
			{
				//Console.WriteLine("d=" + d);
				total += d;
				if (d == 0)
					zeroes++;
			}
			
			Color[] colors = new Color[values.Length];
			int col = 0;
			foreach (string txt in texts)
				colors[col++] = (Color)eval.PieColors[txt];


			//remove zeroes
			decimal[] vals = new decimal[values.Length - zeroes];
			Color[] cols = new Color[values.Length - zeroes];
			string[] txts = new string[values.Length - zeroes];

			int c1 = 0;
			int c2 = 0;
			foreach (decimal d in values)
			{
				if (d != 0)
				{
					vals[c2] = values[c1];
					cols[c2] = colors[c1];
					txts[c2] = texts[c1];
					c2++;
				}
				c1++;
			}

			if (!this.Ring)
				PieImage = ComputePie(width-10, PieHeight, vals, cols, txts);
			else
				PieImage = ComputeRing(width-10, PieHeight, vals, cols, txts);

			Bitmap table = ComputeTable(TableWidth, values, colors, texts);

			OutputImage = new Bitmap(PieImage.Width + table.Width + 20, Math.Max(PieImage.Height, table.Height));

			Graphics g = Graphics.FromImage(OutputImage);
			g.Clear(Color.White);

			if (PieImage.Height < table.Height)
			{
				g.DrawImage(PieImage, 0, Math.Abs(table.Height-PieImage.Height)/2);
				g.DrawImage(table, PieImage.Width + 20, 0);
			}
			else
			{
				g.DrawImage(PieImage, 0, 0);
				g.DrawImage(table, PieImage.Width + 20, (PieImage.Height-table.Height)/2);
			}
		}

        public void Compute07()
        {
            if (q == null || (PersonList.Length == 0 && ComboList.Length == 0) ) return;

            OutputImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            Chart bc = new Chart();

            dnc.Apply(bc);

            bc.Title = this.Name;



            if (this.Ring) bc.Type = ChartType.Donut;
            else bc.Type = ChartType.Pie;

            bc.Use3D = this.ThreeD;

            bc.Width = width;
            bc.Height = height;

            SeriesCollection sc = new SeriesCollection();

            string[] texts = q.AnswerList;

			decimal[] values = new decimal[q.AnswerList.Length];

			int i = 0;
			int zeroes = 0;
			foreach (string answer in q.AnswerList)
			{
				int j; 
				for (j = 0; j < q.AnswerList.Length; j++)
					if (q.AnswerList[j].Equals(answer))
						break;

				if (j == q.AnswerList.Length)
				{
					values[i++] = (decimal)0;
					continue;
				}

				int count = 0;
				//Console.WriteLine(q.SID + "=" + q.Results.Count);

				//Console.Write("start counting for " + answer + "... ");

				foreach (Result r in q.Results)
				{
					bool add = false;
					int PID;

					PID =  Eval.GetPersonIdByUser(r.UserID);

					//Console.WriteLine("pid=" + PID);

					foreach (Person p in PersonList)
						if (p.ID == PID)
							add = true;

					foreach (PersonCombo c in ComboList)
						if (c.ContainsID(PID))
							add = true;

					if (add)
					{
						if (q.Display.ToLower().Equals("radio"))
						{
							if (r.SelectedAnswer == i)
								count++;
						}
						else
						{
							string[] tanswers = r.TextAnswer.Split(';');
							foreach (string tanswer in tanswers)
								if (tanswer.Equals(answer))
									count++;
						}
					}
				}

				//Console.WriteLine(count.ToString());
				values[i++] = (decimal)count;
			}


			//zeroes?
			
			decimal total = 0;
			foreach (decimal d in values)
			{
				//Console.WriteLine("d=" + d);
				total += d;
				if (d == 0)
					zeroes++;
			}
			
			Color[] colors = new Color[values.Length];
			int col = 0;

            foreach (string txt in texts)
            {
                try
                {
                    /*if (txt.StartsWith("< 31"))
                    {
                        tmp += txt+"\n";
                    }
                    else if (txt.StartsWith("31 - 40")){
                        tmp += txt + "\n";
                    }
                    else if (txt.StartsWith("41 – 50"))
                    {
                        tmp += txt + "\n";
                        colors[col] = (Color)eval.PieColors[txt];
                        eval.PieColors.Add("41 - 50", colors);
                    }else if (txt.StartsWith("51 - 60")){
                        tmp += txt + "\n";
                    }
                    else if (txt.StartsWith("< 31"))
                    {
                        tmp += txt + "\n";
                    }
                    else if (txt.StartsWith("41 - 50"))
                    {
                        tmp += txt + "\n";
                    }
                    else if (txt.StartsWith("> 60"))
                    {
                        tmp += txt + "\n";
                    }*/
                    
                    colors[col] = (Color)eval.PieColors[txt];
                    col++;            
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message+"\n"+e.StackTrace);
                }
            
            }//end foreach

			//remove zeroes
			decimal[] vals = new decimal[values.Length ];
			Color[] cols = new Color[values.Length ];
			string[] txts = new string[values.Length ];

			int c1 = 0;
			int c2 = 0;

			foreach (decimal d in values)
			{
				if (d >= 0)
				{
					vals[c2] = values[c1];
					cols[c2] = colors[c1];
					txts[c2] = texts[c1];
					c2++;
				}
				c1++;
			}

            bc.DefaultSeries.EmptyElement.Mode = EmptyElementMode.TreatAsZero;

            Console.WriteLine("total= " + total);

            if (AvgPie)
            {
                Series s = new Series();
                
                s.Name = q.Text;
                s.DefaultElement.Color = cols[0];
                s.DefaultElement.ShowValue = true;
                s.DefaultElement.ExplodeSlice = Explode;

                double pcnt = 0;
                for (int ji = 0; ji < vals.Length; ji++)
                {
                    pcnt += ((double)vals[ji]) * ((double)(ji+1));
                }


                Element e = new Element();

                //double pcnt = (double)q.GetAverageByPersons(eval, this.CombinedPersons);
                Console.WriteLine("[AVGPIE]\t" + pcnt);
                pcnt = pcnt / (double)total;
                Console.WriteLine("[AVGPIE]\t" + pcnt);
                pcnt = 5d - pcnt;
                Console.WriteLine("[AVGPIE]\t" + pcnt);
                pcnt = Math.Round((pcnt / 5d) * 100, 0);
                Console.WriteLine("[AVGPIE]\t" + pcnt);
                Console.WriteLine();

                e.YValue = pcnt;

                e.Color = cols[0];
                e.SecondaryColor = cols[0];

                e.ShowValue = true;

                //bc.LegendBox.ExtraEntries.Add(
                s.Elements.Add(e);

                Series s2 = new Series();

                s2.Name = "";
                s2.DefaultElement.Color = Color.Transparent;// cols[0];
                s2.DefaultElement.ShowValue = false;
                s2.DefaultElement.ExplodeSlice = Explode;
                s2.DefaultElement.Transparency = 255;

                s2.LegendEntry = new LegendEntry();
                s2.LegendEntry.Visible = false;

                Element e2 = new Element();
                e2.YValue = 100 - pcnt;

                e2.Color = Color.Transparent;
                e2.SecondaryColor = Color.Transparent;
                e2.Transparency = 255;

                e2.ShowValue = false;
                e2.LegendEntry = new LegendEntry();
                e2.LegendEntry.Visible = false;

                s2.Elements.Add(e2);

                sc.Add(s);
                sc.Add(s2);

            }
            else if (total != 0)
            {
                for (int ji = 0; ji < vals.Length; ji++)
                {
                    Series s = new Series();
                    s.Name = txts[ji];
                    s.DefaultElement.Color = cols[ji];
                    s.DefaultElement.ShowValue = true;
                    s.DefaultElement.ExplodeSlice = Explode;

                    Element e = new Element();

                    e.Name = txts[ji];

                    e.YValue = (double)((vals[ji] / total) * 100);

                    Console.WriteLine(txts[ji] + " ... " + vals[ji]);

                    e.Color = cols[ji];
                    e.SecondaryColor = cols[ji];

                    e.ShowValue = true;

                    //bc.LegendBox.ExtraEntries.Add(
                    s.Elements.Add(e);

                    sc.Add(s);

                }
            }

            bc.SeriesCollection.Add(sc);

            if (dnc.ShowN)
            {
                LegendBox lb = new LegendBox();
                LegendEntry le = new LegendEntry("Stichprobengröße", total.ToString());
                lb.ExtraEntries.Add(le);
                bc.ExtraLegendBoxes.Add(lb);

                dnc.ApplyLegendBox(bc, lb);
            }

            //bc.LegendBox.DefaultEntry.Value = "";

            bc.Title = "";

            bc.XAxis.Label.Text = dnc.XLabel;

            bc.ExplodedSliceAmount = 2;
            
            bc.YAxis.Label.Text = dnc.YLabel;

            bc.PieLabelMode = PieLabelMode.Inside;

            bc.Application = "itcIidhdhyk+bW1OOBTArpfNOr3GopKuOit20bU6/G4MlNN6vnk4wkfGB+NlXC+EWdY1Rm4vJ0qKOQOmw7d7gw==";

            
            bc.DrawToBitmap(OutputImage, new Rectangle(0, 0, OutputImage.Width, OutputImage.Height));
            
            if (dnc.OnlyLegend)
            {
                //Bitmap b2 = new Bitmap(bc.ChartArea.LegendBox.Position.
            }

            bc.Dispose();
        }//end Compute7

        public override void Compute()
        {
            if (Design == Victor2006) Compute06();
            else Compute07();
        }

		public override void EditDialog()
		{
			OutputFormPie ofp = new OutputFormPie(eval, false, this);
			ofp.ShowDialog();
		}

        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_Pie(eval, false, this);
        }


		public override void Save(string name, string path)
		{
			//
			Question baseq = q;
			

			//cross?
			Evaluation seval;
			if (CrossTargets(q))
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

				q = td.GetQuestion(baseq, Eval);

				Compute();

				FileStream myFileOut = new FileStream(path + "\\" + SystemTools.Savable(name + " ("+td.Name+").png"), FileMode.Create );
				OutputImage.Save( myFileOut, ImageFormat.Png );
				myFileOut.Close();			}

			seval = null;
			OutputImage = null;
		}
	}
}
