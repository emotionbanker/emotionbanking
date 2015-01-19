using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Collections;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using Compucare.Enquire.Legacy.Umfrage2Lib.Output.Scoring;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{
	/// <summary>
	/// Summary description for Scoring.
	/// </summary>
	/// 
	[Serializable]
	public class Scoring : Output
	{
		[NonSerialized]
		private string name;

		[NonSerialized]
		private string path;

		[NonSerialized]
		private readonly bool Cockpit;

		[NonSerialized]
		private readonly bool Cockpit06;

        [NonSerialized]
        private readonly bool Cockpit07;

        public override void LoadGlobalQ()
        {
        }

        public override void LoadTargetQ(TargetData td)
        {
        }

		public Scoring(Evaluation eval, bool Cockpit, bool Cockpit06, bool Cockpit07)
		{
			this.Cockpit = Cockpit;
			this.Cockpit06 = Cockpit06;
            this.Cockpit07 = Cockpit07;
			this.eval = eval;
			this.Name = "Scoring";
		}


		public override void Compute()
		{
			Hashtable cockpits = new Hashtable();
			Hashtable tops     = new Hashtable();
			Hashtable flops    = new Hashtable();
			Hashtable averages = new Hashtable();

			foreach (TargetData td in eval.CombinedTargets)
			{
				if (!td.Included)
					continue;

				Hashtable columns = new Hashtable();

				StringBuilder r = new StringBuilder();
				foreach (Column col in eval.Columns)
				{		
					float[] catpoints = new float[col.Categories.Length];
					float[] cattotals = new float[col.Categories.Length];
                    float[] catplus  = new float[col.Categories.Length];
                    float[] catminus = new float[col.Categories.Length];

					for (int c = 0; c < col.Categories.Length; c++)
						catpoints[c] = cattotals[c] = catplus[c] = catminus[c] = 0;

					r.Append("SCORING BERICHT für SÄULE " + col.Name);
					r.Append("\r\n\r\n");

					r.Append("Punktberechnungen für Fragen\r\n");

					///score!
					///
					ArrayList DoneGaps = new ArrayList(); //dont do gaps twice!

                    r.Append("\r\n\r\n");
                    r.Append("[Frage]\tPunkte\tMax.Punkte\tGew.Punkte\tGew.Max.Punkte\tKategorie\tGewichtung\tMittelwert Frage\r\n");
					foreach (ColumnQuestion q in col.Questions)
					{
						int CatIndex = col.CategoryIndex(q.Cat);

						if (CatIndex != -1)
						{
							Question qu = td.GetQuestion(q.QuestionID, eval);
							if (qu == null) continue;

							float avg = 0;
							float tot = 0;
							
							foreach (int person in q.PersonIDs)
							{
								float pav = qu.GetAverageByPersonAsMark(eval, person); 
								if (q.QuestionID == -125)
								{
									Console.WriteLine(person + "=" + pav);
								}
								if (pav != -1)
								{
									avg+=pav;
									tot+=1;
								}
							}

							if (q.QuestionID == -125)
							{
								Console.WriteLine("avg=" + Math.Round((avg/tot),1));
							}

							if (tot > 0)
							{
								float qpts = 0;
								qpts += col.AnswerPoints[(int)Math.Ceiling(avg/tot)-1];
								qpts += (float)(Math.Ceiling(avg/tot) - (avg/tot)) * (Math.Abs(col.AnswerPoints[(int)Math.Floor(avg/tot)-1]-col.AnswerPoints[(int)Math.Ceiling(avg/tot)-1]));

                                r.Append("[" + q.SID + "]\t" + qpts + "\t" + col.AnswerPoints[0] + "\t" + (qpts * q.Weight) + "\t" + (col.AnswerPoints[0] * q.Weight) + "\t" + q.Cat.Name + "\t" + q.Weight + "\t" + Math.Round((avg / tot), 2) + "\r\n");

                                catpoints[CatIndex] += qpts * q.Weight;
								cattotals[CatIndex] += col.AnswerPoints[0] * q.Weight;

                                catplus[CatIndex] += qpts * q.Weight;
								//gaps

								//gap for this question
								foreach (PersonV v in q.gap.Persons)
								{
                                    if (!qu.ContainsPerson(eval, v.A))
                                    {
                                        //no results for one gap person, ignore and continue

                                        r.Append("\t[gap]\tKeine Ergebnisse für Personengruppe [" + v.A.Name + "], wird für Gapabzüge ignoriert\r\n");

                                        continue;
                                    }
                                    else if (!qu.ContainsPerson(eval, v.B))
                                    {
                                        //same, different output

                                        r.Append("\t[gap]\tKeine Ergebnisse für Personengruppe [" + v.A.Name + "], wird für Gapabzüge ignoriert\r\n");

                                        continue;
                                    }


									//float pen = g.GetPenalty(v, qu, eval);
									float gap = q.gap.GetGap(v, qu, eval);

                                    if (gap > (col.MaxGapVal*-1)) gap = (float) (col.MaxGapVal*-1);

									float pen = q.gap.GetPenalty(gap);

									if (gap != 0)
									{
										//"pen" is already weighted by GetPenalty
										catpoints[CatIndex] -= pen;
                                        catminus[CatIndex] += pen;

                                        r.Append("\t[gap]\tgap=" + q.gap.GetGapAbs(v, qu, eval) + ", x" + q.gap.Limit + "=" + gap + " (=" + pen + " gewichtet mit " + q.Weight + ")\r\n");	
									}
									else
									{
                                        r.Append("\t[gap]\tgap=" + q.gap.GetGapAbs(v, qu, eval) + " - Limit=" + q.gap.Limit + ", keine Abzüge!\r\n");
									}
								}

								// >> FOOTNOTE 1
							}
							else
							{
								r.Append("["+q.QuestionID + "]\t keine Werte!\r\n");
							}
						}
						else
						{
							r.Append("["+q.QuestionID + "]\t keine Kategorie!\r\n");
						}
					}

					///done with questions, score categories
					///

					r.Append("\r\n\r\n");

					float points = 0;
					float counter = 0;


					for (int i = 0; i < catpoints.Length; i++)
					{
                        r.Append("\r\nKategorie " + col.Categories[i].Name + "\r\n");
                        r.Append("\tPluspunkte:\t" + catplus[i] + "(=" + (catplus[i] * col.Categories[i].Weight) + " gewichtet mit " + col.Categories[i].Weight + ")\r\n");
                        r.Append("\tMinuspunkte:\t" + catminus[i] + "(=" + (catminus[i] * col.Categories[i].Weight) + " gewichtet mit " + col.Categories[i].Weight + ")\r\n");


						//catpoints[i] = catpoints[i] / cattotals[i];
						r.Append("\tGesamtpunkte:\t" + catpoints[i] + " (="+(catpoints[i] * col.Categories[i].Weight)+" gewichtet mit "+col.Categories[i].Weight+")\r\n");
						points  += catpoints[i] * col.Categories[i].Weight;
						//counter += col.Categories[i].Weight;
						counter += cattotals[i] * col.Categories[i].Weight;
					}
					
					//points = points/counter;

					float pct = points/counter;
					float val = pct * (float)col.MaxPoints;

					if (counter == 0)
						val = 0;

					r.Append("\r\n\r\n");

					float hgp;

                    if (col.GapOnly)
                    {
                        double fact = 1 - (points / col.MinPointsForTarget(td, eval));

                        val = ((float)col.MaxPoints) * (float)fact;
                    }
						
					hgp = (float)Math.Round(val,0);


					r.Append("Gesamtpunkte für Säule " + col.Name + ":\t" + points + "/" + counter + "\r\n");
                    if (col.GapOnly)
                    {
                        r.Append("Maximaler Punkteabzug durch Gaps: " + col.MinPointsForTarget(td, eval) + "\r\n");
                        r.Append("entspricht \t" + points + "/" + col.MinPointsForTarget(td, eval) + "\t Punkten");
                        r.Append("\r\n\r\n");
                    }
                    else
                    {
                        r.Append("entspricht \t" + points + "/" + counter + "\t Punkten");
                        r.Append("\r\n\r\n");
                    }
                    r.Append("\t entspricht hochgerechnet: " + hgp + "/" + col.MaxPoints + " Punkte");
					r.Append("\r\n\r\n");
					r.Append("\r\n\r\n");

					columns[col.Name] = val;

					if (col.GapOnly) val = Math.Abs(points);
					
					if (!tops.ContainsKey(col.Name)  || val > (float)tops[col.Name])
					{
						if (val > 0) tops[col.Name] = val;
					}

					if (!flops.ContainsKey(col.Name) || val < (float)flops[col.Name])
					{
						if (val > 0) flops[col.Name] = val;
					}

					if (td.Name.Equals("Global"))
					{
						if (!averages.ContainsKey(col.Name)) averages[col.Name] = 0f;
						if (val > 0) averages[col.Name] = val;
					}

					//done with this column
			    }

				//save report,cockpit

				FileStream index = new FileStream(path + "\\" + name + " (" +td.Name+") - Bericht.txt", FileMode.Create);
				StreamWriter sw = new StreamWriter(index,Encoding.UTF8);
				sw.WriteLine(r.ToString());
				sw.Close();
				index.Close();

				cockpits[td.Name] = columns;
			}

            #region Create Cockpits

            ChangeScoringForm csf = new ChangeScoringForm(eval, cockpits);

			if (Cockpit06 || Cockpit || Cockpit07)
			{
				
				csf.ShowDialog();

				cockpits = csf.Cockpits;
				tops = csf.Tops;
				flops = csf.Flops;
				averages = csf.Averages;
			}

			if (Cockpit)
			{
				foreach (TargetData td in eval.CombinedTargets)
				{
					if (!td.Included)
						continue;

                    ScoringCockpitOld cockpit = new ScoringCockpitOld();
					Bitmap bmp = cockpit.CreateCockpit((Hashtable)cockpits[td.Name], tops, flops);

					bmp.Save(path + "\\" + name + " (" +td.Name+") - Cockpit05.png", ImageFormat.Png);
				}
			}

			if (Cockpit06)
			{
				foreach (TargetData td in eval.CombinedTargets)
				{
					if (!td.Included)
						continue;

                    ScoringCockpit06 cockpit = new ScoringCockpit06();
					Bitmap bmp = cockpit.CreateCockpit((Hashtable)cockpits[td.Name], averages);

					bmp.Save(path + "\\" + name + " (" +td.Name+") - Cockpit06.png", ImageFormat.Png);
				}
			}

            if (Cockpit07)
            {
                foreach (TargetData td in eval.CombinedTargets)
                {
                    if (!td.Included)
                        continue;

                    ScoringCockpit07 cockpit = new ScoringCockpit07();
                    Bitmap bmp = cockpit.CreateCockpit(csf.IncList(td, eval));//, csf.IncTotal(eval.CombinedTargets, eval));

                    bmp.Save(path + "\\" + name + " (" + td.Name + ") - Cockpit07.png", ImageFormat.Png);
                }
            }

            #endregion Create Cockpits
        }


		public override void EditDialog()
		{

		}

		public override void Save(string name, string path)
		{
			this.name = name;
			this.path = path;
			Compute();
		}
	}
}