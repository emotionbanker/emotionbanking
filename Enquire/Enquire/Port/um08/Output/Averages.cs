using System;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{
	/// <summary>
	/// Summary description for Averages.
	/// </summary>
	/// 

	[Serializable]
	public class Averages : Output
	{
		public Question[] Questions;

		public string ResultTable;

		public int Precision;

		public bool average;
		public bool median;
		public bool percent;
        public bool n;

        public Averages(Evaluation eval)
        {
            this.eval = eval;
			ResultTable = string.Empty;
			Questions = new Question[0];
			Precision = 1;
			average = true;
			median = false;
			percent = false;
            n = false;
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
			info.AddValue("ResultTable", this.ResultTable);
			info.AddValue("Precision", this.Precision);
			info.AddValue("average", this.average);
			info.AddValue("median", this.median);
			info.AddValue("percent", this.percent);
            info.AddValue("n", this.n);
		}

		public Averages(SerializationInfo info, StreamingContext ctxt)
		{
			try
			{
				ReadSerData(info, ctxt);
			}
			catch (Exception ex)
			{
				Console.WriteLine("in constructor!" + ex.Message);
			}

			this.Questions = (Question[])info.GetValue("Questions", typeof(Question[]));
			this.ResultTable = info.GetString("ResultTable");
			this.Precision = info.GetInt32("Precision");
			this.average = info.GetBoolean("average");
			this.median = info.GetBoolean("median");
			this.percent = info.GetBoolean("percent");

            try { this.n = info.GetBoolean("n"); }
            catch { n = false; }
		}

		public override void Compute()
		{
			ResultTable = string.Empty;

			if (average)
			{
				float count = 0;
				float total = 0;

				float[] countperss = new float[CombinedPersons.Length];
				float[] totalperss = new float[CombinedPersons.Length];

				ResultTable += "MITTELWERTE\r\n\r\n";

				ResultTable += "Frage\t";

				foreach (PersonSetting ps in CombinedPersons)
				{
					ResultTable += ps.Short + "\t";
				}

				ResultTable += "Gesamt\r\n";
				float a = 0;
				foreach (Question q in Questions)
				{
					if (q == null) continue;

					ResultTable += q.SID + "\t";
					float totpers = 0;
					float countpers = 0;
					for (int i = 0; i < (CombinedPersons.Length); i++)
					{
						a = q.GetAverageByPersonAsMark(Eval, CombinedPersons[i], Precision);
                        //MessageBox.Show(a + " " + CombinedPersons[i]+" "+Precision);
						if (a != -1)
						{
							countpers ++;
							totpers += a;
							countperss[i] ++;
							totalperss[i] += a;

							ResultTable += a;
						}
						else
							ResultTable += "-";
						
						ResultTable += "\t";
					}
					ResultTable += Math.Round((totpers/countpers),Precision).ToString();
					total += totpers;
					count += countpers;
					ResultTable += "\r\n";
				}

				ResultTable += "\r\n\r\n";

				ResultTable += "Gesamtmittelwerte nach Personen\r\n\r\n";
				for (int g = 0; g < CombinedPersons.Length; g++)
					ResultTable += CombinedPersons[g].Short + ":\t" + Math.Round((totalperss[g]/countperss[g]),Precision) + "\r\n";
				ResultTable += "Alle:\t" + Math.Round((total/count),Precision);

				ResultTable += "\r\n\r\n";
			}

			if (median)
			{
				ResultTable += "MEDIANE\r\n\r\n";

				ResultTable += "Frage\t";

				foreach (PersonSetting ps in CombinedPersons)
				{
					ResultTable += ps.Short + "\t";
				}

				ResultTable += "\r\n";
				float a = 0;
				foreach (Question q in Questions)
				{
					ResultTable += q.SID + "\t";
					for (int i = 0; i < (CombinedPersons.Length); i++)
					{
						a = q.GetMedianByPersonAsMark(Eval, CombinedPersons[i], Precision);

						if (a != -1)
							ResultTable += a;
						else
							ResultTable += "-";

						ResultTable += "\t";
					}
					ResultTable += "\r\n";
				}

				ResultTable += "\r\n\r\n";
			}

			if (percent)
			{
				ResultTable += "PROZENTWERTE\r\n\r\n";

				
				for (int i = 0; i < (CombinedPersons.Length); i++)
				{	
					ResultTable += CombinedPersons[i].ToString() + "\r\n";
					ResultTable += "Frage/#Antworten\tAntwortmöglichkeiten/Prozent";
					ResultTable += "\r\n\r\n";
					foreach (Question q in Questions)
					{
						ResultTable += q.SID + "\t";

						for (int x = 0; x < q.AnswerList.Length; x++)
							ResultTable += (x+1) + "\t";

						ResultTable += "\r\n";

						ResultTable += Math.Round(q.GetAverageAnswersByUser(Eval, CombinedPersons[i]), Precision) + "\t";
									
						int v = 0;
						foreach (string answer in q.AnswerList)
						{
							ResultTable += Math.Round(q.GetAnswerPercentByPerson(answer, Eval, CombinedPersons[i]), Precision);
							if (v < q.AnswerList.Length-1)
								ResultTable += "\t";
							v++;
						}

                        ResultTable += "\r\nProzent/Abweichung:\t";

                        float pcnt = q.GetAverageByPersonAsMark(Eval, CombinedPersons[i], Precision);
                        pcnt = (1 - ((pcnt -1 ) / 4)) * 100;

                        ResultTable += Math.Round(pcnt, Precision) + "%";


						ResultTable += "\r\n\r\n";
					}
					ResultTable += "\r\n";
				}

				ResultTable += "\r\n\r\n";
			}

            if (n)
            {
                ResultTable += "STICHPROBENGRÖSSE (MITTELWERTE)\r\n\r\n";

                ResultTable += "Frage\t";

                foreach (PersonSetting ps in CombinedPersons)
                {
                    ResultTable += ps.Short + "\t";
                }

                ResultTable += "Gesamt\r\n";
                float a = 0;
                foreach (Question q in Questions)
                {
                    if (q == null) continue;

                    ResultTable += q.SID + "\t";

                    for (int i = 0; i < (CombinedPersons.Length); i++)
                    {
                        ResultTable += q.NAnswersByPerson(Eval, CombinedPersons[i]).ToString();

                        ResultTable += "\t";
                    }
                    
                    ResultTable += "\r\n";
                }

                ResultTable += "\r\n\r\n";
            }

			ResultTable += "LEGENDE\r\n\r\n";

			foreach (Question q in Questions)
			{
				if (q != null)
				ResultTable += q.SID + "...\t" + q.Text + "\r\n";
			}
			foreach (PersonSetting ps in CombinedPersons)
			{
				ResultTable += ps.Short + "...\t" + ps + "\r\n";
			}
		}

		public override void EditDialog()
		{
			OutputFormAverages ofa = new OutputFormAverages(eval, false, this);
			ofa.ShowDialog();
		}

        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_Averages(eval, false, this);
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
                //MessageBox.Show(""+td.Name);
                if (!td.Included)
					continue;

				int i = 0;
				foreach (Question q in baseq)
					Questions[i++] = td.GetQuestion(q, Eval);

				Compute();

                FileStream fs = new FileStream(path + "\\" + SystemTools.Savable(name + " (" + td.Name + ").txt"), FileMode.Create);
                StreamWriter sr = new StreamWriter(fs);
                sr.Write(ResultTable);
                sr.Close();
			}

			seval = null;
			ResultTable = null;
		}
	}
}
