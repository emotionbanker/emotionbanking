using System;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Microsoft.Office.Interop.Word;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{
	/// <summary>
	/// Summary description for Benchmarking.
	/// </summary>
	/// 

	[Serializable]
	public class Benchmarking : Output
	{
        [NonSerialized]
		public Question[] Questions;

		[NonSerialized]
		DialogBenchmark db;

		private string path = string.Empty;
		private string name = string.Empty;

		public bool Word = false;
        public bool ShowNulls = false;

		public Benchmarking(Evaluation eval)
		{
			this.eval = eval;
		}

        public override void LoadGlobalQ()
        {
        }

        public override void LoadTargetQ(TargetData td)
        {
        }

		public void ComputeThread()
		{
			Thread t = new Thread(new ThreadStart(this.Compute));
			t.Start();
		}

		private void ConvertToWord(object filename, string name, DateTime Start)
		{
			db.LocalPercent.Text = "0%";
			db.Status("Konvertiere " + name + " in MS Word");
			object saveAs = ((string)filename).Replace(".html", ".doc");

			File.Delete((string)saveAs);
            
			Application WordApp = new Application();

			object missing = Missing.Value;
			object otrue = true;
			object normalDot = SystemTools.GetAppPath() + "template.dot";
			object newTemplate = false;
			object docType = 0;
			object isVisible = true;
			object ofalse = false;

			Document doc1 = WordApp.Documents.Open(ref filename, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

			doc1.Select();
			WordApp.Selection.Copy();

			Document doc2 = WordApp.Documents.Add(ref normalDot, ref newTemplate, ref docType, ref isVisible);

			doc2.Select();
			WordApp.Selection.Paste();

			doc1.Close(ref ofalse, ref missing, ref missing);
			doc1 = null;
	
			
			db.Refresh();

			for (int i = 0; i < doc2.InlineShapes.Count; i++)
			{
				InlineShape ins = doc2.InlineShapes[i];
				LinkFormat lf = ins.LinkFormat;
				if (!lf.SavePictureWithDocument)
					lf.SavePictureWithDocument = true;

			
				db.Refresh();

				if (i%100 == 0)
				{
					//zwischenspeichern
					doc2.SaveAs(ref saveAs, ref missing, ref missing, ref missing, ref missing, 
						ref missing, ref missing, ref otrue, ref otrue, ref missing, ref missing);

					doc2.Close(ref ofalse, ref missing, ref missing);
					doc2 = null;

					doc2 = WordApp.Documents.Open(ref saveAs, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
				}
			}

			doc2.SaveAs(ref saveAs, ref missing, ref missing, ref missing, ref missing, 
				ref missing, ref missing, ref otrue, ref otrue, ref missing, ref missing);

			doc2.Close(ref ofalse, ref missing, ref missing);
			doc2 = null;
			WordApp.Quit(ref ofalse, ref missing, ref missing);
			WordApp = null;

		}

		public override void Compute()
		{
			DateTime Start = DateTime.Now;

			//this.PersonList = eval.Persons;
			//this.ComboList = eval.PersonCombos;

			string style= @"

				body {size: landscape; font-family: Arial;}

				table.main {border: 1px solid black;
							width: 800px;}

				td {font-size: 8pt;}

				tr.newheader td {border-top: 1px solid black;}

				td.headerline {background-color: #FBB75F;}

				td.lightH {background-color: #D0D0D0;}
				td.darkH  {background-color: #B0B0B0;}
				
				td.lightN {width: 25px;text-align: right; background-color: #FFFFFF;}
				td.darkN  {width: 25px;text-align: right; background-color: #D0D0D0;}

				td.lightNP {width: 25px;text-align: right; background-color: #FFFFFF;}
				td.darkNP  {width: 25px;text-align: right; background-color: #E9E9E9;}

				td.lightTB {width: 800px; background-color: #FFFFFF; border-right:1px solid black;}
				td.darkTB  {width: 800px; background-color: #D0D0D0; border-right:1px solid black;}

				td.lightB {width: 100px; background-color: #FFFFFF;}
				td.darkB  {width: 100px; background-color: #D0D0D0;}

				td.lightNB {width: 25px; text-align: right; background-color: #FFFFFF; font-weight:bold; border-right:1px solid black;}
				td.darkNB {width: 25px; text-align: right; background-color: #D0D0D0; font-weight:bold;  border-right:1px solid black;}

				td.htext {background-color: #B0B0B0; vertical-align: bottom; font-size: 10pt; font-weight: bold }
				";

			Directory.CreateDirectory(path + "\\" + name);


			db.Status("Berechne Werte...");

			//init bars
			

			int globalmax = 0;
			foreach (TargetData td in eval.CombinedTargets)
			{
				if (!td.Included)
					continue;

				globalmax += CombinedPersons.Length * Questions.Length;
			}

			

			if (Word)
			{
				int count = 0;
				foreach (TargetData td in eval.CombinedTargets)
				{
					if (!td.Included)
						continue;

					foreach (Question q in Questions)
					{
						foreach (PersonSetting ps in CombinedPersons)
							if (q.ContainsPerson(eval, ps))
								count++;
					}
				}
				
				Console.WriteLine("image count = " + count);
			}

			//compute values
			float[,,] Averages      = new float[eval.CombinedTargets.Length,CombinedPersons.Length,Questions.Length];
			float[,,] Medians		= new float[eval.CombinedTargets.Length,CombinedPersons.Length,Questions.Length];
			float[,] GlobalAverages = new float[CombinedPersons.Length,Questions.Length];
			float[,] BestValues     = new float[CombinedPersons.Length,Questions.Length];
			float[,] WorstValues    = new float[CombinedPersons.Length,Questions.Length];
			float[,] HistoricBest   = new float[CombinedPersons.Length,Questions.Length];
			float[,] HistoricWorst  = new float[CombinedPersons.Length,Questions.Length];

			for (int x = 0; x < CombinedPersons.Length; x++)
				for (int y = 0; y < Questions.Length; y++)
				{
					BestValues[x,y]    = 5;
					WorstValues[x,y]   = 0;
					HistoricBest[x,y]  = 5;
					HistoricWorst[x,y] = 0;
				}
			
			int t = 0, i = 0, j = 0;
			

			db.Status("Lade historische Daten...");
			float HistoricPercent = 0;
			
			if (eval.History == null)
				eval.History = new HistoricData[0];

			foreach (HistoricData hd in eval.History)
			{
				HistoricPercent += hd.Percent;
				hd.LoadInfo();
			}

			float thisPercent = 100 - HistoricPercent;
			float totalPercent = 100;

			foreach (PersonSetting person in CombinedPersons)
			{
				db.Status("Berechne Werte... " + person);
				j=0;
				foreach (Question q in Questions)
				{
                    db.Status("[H] Frage " + q.SID);
					foreach (HistoricData hd in eval.History)
					{
						foreach (TargetData htd in hd.Eval.CombinedTargets)
						{
							if (htd.Test) continue;

							Question hq = htd.GetQuestion(q, hd.Eval);
							if (hq == null)
								continue;

							float ha = hq.GetAverageByPersonAsMark(hd.Eval, person);

							if (ha != -1 && ha < HistoricBest[i,j])
								HistoricBest[i,j] = ha;
							if (ha != -1 && ha > HistoricWorst[i,j])
								HistoricWorst[i,j] = ha;
						}
					}

                    db.Status("[G] Frage " + q.SID);

					GlobalAverages[i,j] = eval.Global.GetQuestion(q, eval).GetAverageByPersonAsMark(eval, person);

					totalPercent = thisPercent;

					if (GlobalAverages[i,j] != -1)
					{
						GlobalAverages[i,j] *= thisPercent;

						foreach (HistoricData hd in eval.History)
						{
							if (hd.Percent == 0)
								continue;

							Question x = hd.Eval.Global.GetQuestion(q, hd.Eval);
							
							if (x == null)
								continue;

							float hv = x.GetAverageByPersonAsMark(hd.Eval, person);
						
							if (hv != -1)
							{
								GlobalAverages[i,j] += hv*hd.Percent;
								totalPercent += hd.Percent;
							}
							else
							{
								//Console.WriteLine(q.SID + " is -1 at " + hd.Eval.DatabaseName);
								//totalPercent -= hd.Percent;
								//Console.WriteLine("set totalpercent to " + totalPercent);
							}

						}
					}

					if (totalPercent != 0 && GlobalAverages[i,j] != -1)
						GlobalAverages[i,j] = GlobalAverages[i,j]/totalPercent;

                    db.Status("[C] Frage " + q.SID);

					//GlobalAverages[i,j] = (float)Math.Round(GlobalAverages[i,j], 1);

					t = 0;
					foreach (TargetData td in eval.CombinedTargets)
					{
						if (td.Test)
						{
							t++;
							continue;
						}

						totalPercent = 100;
						Question qq = td.GetQuestion(q, eval);

                        if (qq != null)
                        {
                            Averages[t, i, j] = qq.GetAverageByPersonAsMark(eval, person);
                            Medians[t, i, j] = qq.GetMedianByPersonAsMark(eval, person, 1);

                            if (Averages[t, i, j] != -1 && Averages[t, i, j] < BestValues[i, j])
                                BestValues[i, j] = Averages[t, i, j];

                            if (Averages[t, i, j] != -1 && Averages[t, i, j] > WorstValues[i, j])
                                WorstValues[i, j] = Averages[t, i, j];
                        }
	
						

						t++;
					}
					j++;
				}
				i++;
			}
			
			db.Status("Vergleiche Beste/Schlechteste Werte...");

			for (int hi = 0; hi < CombinedPersons.Length; hi++)
				for (int hj = 0; hj < Questions.Length; hj++)
				{
					if (BestValues[hi,hj] < HistoricBest[hi,hj])
						HistoricBest[hi,hj] = BestValues[hi,hj];

					if (WorstValues[hi,hj] > HistoricWorst[hi,hj])
						HistoricWorst[hi,hj] = WorstValues[hi,hj];

					//WorstValues[hi,hj] = (float)Math.Round(WorstValues[hi,hj],1);
					//BestValues[hi,hj] = (float)Math.Round(BestValues[hi,hj],1);
				}

		

			//db.Status("Erstelle Dokumente...");

			t = 0;
			foreach (TargetData td in eval.CombinedTargets)
			{
				if (!td.Included)
				{
					t++;
					continue;
				}

				
				Directory.CreateDirectory(path + "\\" + name + "\\" + td.CleanName);
				Directory.CreateDirectory(path + "\\" + name + "\\" + td.CleanName + "\\images");
				

				string alternate = "light";
				int imageName = 10000;
				int maxColumns = 30;
				int headColumns = 9;
				int pageCounter = 0;
				string lq = string.Empty;
				string lasthead = string.Empty;


				i = j = 0;
				foreach (PersonSetting person in CombinedPersons)
				{
					HtmlTools doc = new HtmlTools();
					db.Status("Erstelle Dokumente für " + td.Name + "... " + person);
					doc.SetTitle("Benchmarking für " + td.Name + "(" + person.ToString() + ")");
					doc.SetStyle(style);

					alternate = "light";

					doc.Header2(person.ToString());

					doc.StartTable("main", 2, 0);

					lq = string.Empty;
					lasthead = string.Empty;


					j=0;
					foreach (Question qq in Questions)
					{
						

						Question q = td.GetQuestion(qq, eval);

						if (q != null && q.Display.Equals("radio"))
						{                           
							if ( (Averages[t,i,j] == -1) || (Medians[t,i,j] == -1) || (GlobalAverages[i,j] == -1))
							{
								j++;
								continue;
							}

							if (!lq.Equals(q.Answers) || !td.GetLastHeader(q, person).Equals(lasthead))
							{
								if (pageCounter >= (maxColumns-headColumns))
								{
									htmlNewPage(ref doc);
									lq = string.Empty;
									pageCounter = 0;
								}
								doc.Line(buildHeader(q,td,person));
								pageCounter += headColumns;
								lq = q.Answers;
								lasthead = td.GetLastHeader(q, person);
							}

							doc.Line("<tr>");

							doc.Line("<td class='" + alternate + "TB'>" + q.Text + "</td>");
							doc.Line("<td class='" + alternate + "NB'><b>" + Math.Round(Averages[t,i,j], 1) + "</b></td>");
							doc.Line("<td class='" + alternate + "NB'>" + Medians[t,i,j] + "</td>");
							doc.Line("<td class='" + alternate + "NB'><b>" + Math.Round(GlobalAverages[i,j], 1) + "</b></td>");

							//doc.Line("<td class='" + (alternate = a(alternate)) + "NP'>" + BestValues[i,j] + "</td>");
							//doc.Line("<td class='" + (alternate = a(alternate)) + "NP'>" + WorstValues[i,j] + "</td>");
							
							doc.Line("<td class='" + alternate + "N'>" + Math.Round(q.GetAnswerPercentByPerson(0, eval, person),0) + "</td>");
							doc.Line("<td class='" + alternate + "N'>" + Math.Round(q.GetAnswerPercentByPerson(1, eval, person),0) + "</td>");
							doc.Line("<td class='" + alternate + "N'>" + Math.Round(q.GetAnswerPercentByPerson(2, eval, person),0) + "</td>");
							doc.Line("<td class='" + alternate + "N'>" + Math.Round(q.GetAnswerPercentByPerson(3, eval, person),0) + "</td>");
							doc.Line("<td class='" + alternate + "N'>" + Math.Round(q.GetAnswerPercentByPerson(4, eval, person),0) + "</td>");

							//traffic bar				
							Image tlb = TrafficLightBar(180,17,eval,4-(Averages[t,i,j]-1),4-(BestValues[i,j]-1),4-(WorstValues[i,j]-1),4-(HistoricBest[i,j]-1),4-(HistoricWorst[i,j]-1), true);

							tlb.Save(path + "\\" + name + "\\" + td.CleanName + "\\images\\" + imageName + ".png", ImageFormat.Png);

							doc.Line("<td class='" + alternate + "B'><img src='images/"+imageName+".png' /></td>");

                            if (ShowNulls) doc.Line("<td class='" + alternate + "N'>" + q.NullAnswers + "</td>");

							imageName++;

							doc.Line("</tr>");
							alternate = a(alternate);

							pageCounter++;


							if (pageCounter > maxColumns)
							{
								htmlNewPage(ref doc);
								lq = string.Empty;
								pageCounter = 0;
							}
						}
						j++;
					}
					doc.EndTable();
					i++;

					db.Status("Finalisiere " + td.Name);
					FileStream index = new FileStream(path + "\\" + name + "\\" + td.CleanName + "\\"+td.CleanName+" (" + person.ToString() + ").html", FileMode.Create);
					StreamWriter sw = new StreamWriter(index,Encoding.UTF8);

					sw.WriteLine(doc.GetDocument());

					sw.Close();
					index.Close();
				}
				t++;
			}

			if (Word)
			{
				foreach (TargetData td in eval.CombinedTargets)
				{
					if (!td.Included)
					{
						t++;
						continue;
					}
					foreach (PersonSetting person in CombinedPersons)
					{
						db.LocalPercent.Text = "0%";
						Thread.Sleep(2000);
						this.ConvertToWord(path + "\\" + name + "\\" + td.CleanName + "\\"+td.CleanName+" (" + person.ToString() + ").html", td.CleanName+" (" + person.ToString() + ")", Start);
					}
				}
			}

			db.Status("Vorgang abgeschlossen...");
			db.TimeRemainingLabel.Text = "";
			db.LocalPercent.Text = db.GlobalPercent.Text = "100%";

			db.DoneButton.Enabled = true;
		}

		public override void EditDialog()
		{

		}

		public string a(string s)
		{
			if (s.Equals("light")) s = "dark";
			else s = "light";

			return s;
		}

		public string buildHeader(Question q, TargetData td, PersonSetting ps)
		{
			//eval.Settings.getQuestByLongString
			string h = String.Empty;
			string alternate = "light";
			string header = String.Empty;
			string[] answerList = q.AnswerList;

            int max = 9;
            if (ShowNulls) max = 10;

			for (int i = 0; i < max; i++)
			{
				alternate = "light";
			
				if (i==0)
				{
					h+= "<tr class='newheader'>";
					h+= "<td class='htext' rowspan='"+max+"'>"+td.GetLastHeader(q, ps)+"</td>";
				}
				else
					h+= "<tr>";

				for (int j = 0; j < max; j++)
				{
					h+="<td class='"+alternate+"H' ";
					if (i==j)
					{
						h+= " colspan='"+(max-j)+"'>";
						if (i==0) h += "Eigener Durchschnitt";
						if (i==1) h += "Median";
						if (i==2) h += "Gesamtdurchschnitt";
						if (i==3) if (answerList.Length > 0) h += answerList[0];
						if (i==4) if (answerList.Length > 1) h += answerList[1];
						if (i==5) if (answerList.Length > 2) h += answerList[2];
						if (i==6) if (answerList.Length > 3) h += answerList[3];
						if (i==7) if (answerList.Length > 4) h += answerList[4];
						if (i==8) h += "Vergleich";
                        if (i == 9) if (ShowNulls) h += "Nicht ausgefüllt";
						break;
					}
					else
					{
						h+= ">&nbsp;";
					}
					h+="</td>";

					if (j < i)
						alternate = a(alternate);					
				}

				h+= "</tr>";
				alternate = a(alternate);
			}

			return h;
		}


		public void htmlNewPage(ref HtmlTools doc)
		{
			doc.EndTable();
			doc.Pagebreak();
			doc.StartTable("main", 2, 0);
		}


		public override void Save(string name, string path)
		{
			this.path = path;
			this.name = name;
			db = new DialogBenchmark(eval, this);
			db.ShowDialog();
		}

        public static Bitmap TrafficLightBar(int width, int height,
            Evaluation eval, float val, float bestval, float worstval, float histbest, float histworst, bool borderoffset)
        {
            return TrafficLightBar(width, height, eval, val, bestval, worstval, histbest, histworst, borderoffset, 0);
        }

	    public static Bitmap TrafficLightBar(int width, int height, 
            Evaluation eval, float val, float bestval, float worstval, float histbest, float histworst, bool borderoffset,
            float ownVal)
		{
			Bitmap bar = new Bitmap(width, height);
			Graphics g = Graphics.FromImage(bar);

			float offset;

			if (borderoffset)
				offset = ((float)width)/25f;
			else
				offset = 0;

			width -= (int)(2*(offset+1));

			float wid = (float)width;
			float hei = (float)height;

			g.Clear(Color.Transparent);
			g.SmoothingMode = SmoothingMode.AntiAlias;
		
			float c1wid = wid * eval.TlbVal1;
			float c2wid = wid * eval.TlbVal2;
			float c3wid = wid - (c1wid+c2wid);

			if (c1wid < 1) c1wid = 1;
			if (c2wid < 1) c2wid = 1;
			if (c3wid < 1) c3wid = 1;

			LinearGradientBrush a = new LinearGradientBrush(new PointF(offset,height/2), new PointF(offset+c1wid, height/2), eval.TlbColor1, eval.TlbColor2);

			SolidBrush b = new SolidBrush(eval.TlbColor2);

			if (c1wid+c2wid < wid)
			{
				LinearGradientBrush c = new LinearGradientBrush(new PointF(offset+c1wid+c2wid,height/2), new PointF(offset+wid+1, height/2), eval.TlbColor2, eval.TlbColor3);
				g.FillRectangle(c, offset+c1wid+c2wid+1, 0, c3wid, height);
			}


			g.FillRectangle(a, offset, 0, a.Rectangle.Width, hei);
			g.FillRectangle(b, offset+c1wid-1, 0, c2wid+2, height);
			

			///grid
			///

			Pen gridPen = new Pen(Color.Black);

			for (float i=1; i < 10; i++)
			{
				if (i%2 == 0)
					g.DrawLine(gridPen, offset+wid * i/8, hei-hei/4, offset+wid * i/8, hei);
				else
					g.DrawLine(gridPen, offset+wid * i/8, hei-hei/5, offset+wid * i/8, hei);
			}


			///values
			///

			g.SmoothingMode = SmoothingMode.None;

			float tbestval = histbest/4f;
			float tworsval = histworst/4f;

			float bestx = wid * tbestval;
			float worsx = wid * tworsval;

			Pen bw = new Pen(eval.TlbAllCol);
			bw.DashStyle = DashStyle.Solid;

			if (bestx >= wid)
				bestx = wid-1;

			g.DrawLine(bw, offset+bestx, 0, offset+bestx, hei);
			g.DrawLine(bw, offset+worsx, 0, offset+worsx, hei);

			
			bestval = bestval/4f;
			worstval = worstval/4f;

			bestx = wid * bestval;
			worsx = wid * worstval;

			Pen bw2 = new Pen(eval.TlbThisCol);
			bw2.DashStyle = DashStyle.Dash;

			if (bestx >= wid)
				bestx = wid-1;

			g.DrawLine(bw2, offset+bestx, 0, offset+bestx, hei);
			g.DrawLine(bw2, offset+worsx, 0, offset+worsx, hei);

			//triangle

			g.SmoothingMode = SmoothingMode.AntiAlias;

			val = val/4f;
			float valx = wid * val;

			SolidBrush vb = new SolidBrush(eval.TlbValCol);

			PointF[] triangle = new PointF[]{new PointF(offset+valx-wid/25f, 0),
											new PointF(offset+valx+wid/25f, 0),
											new PointF(offset+valx, hei/2.5f)};

			g.FillPolygon(vb, triangle, FillMode.Alternate);
			g.DrawPolygon(gridPen, triangle);

            if (ownVal != 0)
            {
                val = ownVal / 4f;
                valx = wid * val;

                triangle = new[]{new PointF(offset+valx-wid/25f, hei),
											new PointF(offset+valx+wid/25f, hei),
											new PointF(offset+valx, hei - (hei/2.5f))};

                g.FillPolygon(vb, triangle, FillMode.Alternate);
                g.DrawPolygon(gridPen, triangle);
            }

			return bar;
		}
	}
}
