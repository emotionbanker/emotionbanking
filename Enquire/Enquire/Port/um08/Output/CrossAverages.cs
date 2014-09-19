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
	public class CrossAverages : Output
	{
		public Question[] Questions;

		public string ResultTable;

		public int Precision;


        public CrossAverages(Evaluation eval)
        {
            this.eval = eval;
			ResultTable = string.Empty;
			Questions = new Question[0];
			Precision = 1;
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
		}

		public CrossAverages(SerializationInfo info, StreamingContext ctxt)
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
		}

		public override void Compute()
		{
			//Console.WriteLine("Cross=" + Cross);
			if (this.Cross == null)
				return;

			ResultTable = string.Empty;

			float[] sums = new float[Questions.Length];
			float[] counts = new float[Questions.Length];

			ResultTable += "MITTELWERTE nach Frage "+Cross.SID+"\r\n\r\n";

			ResultTable += "Frage:\t";


			foreach (Question q in this.Questions)
			{
				ResultTable += q.SID + "\t";
			}

			ResultTable += "\r\n\r\n";

			int ai = 0;
			foreach (string answer in Cross.AnswerList)
			{
				ResultTable += (ai+1) + "\t";

				foreach (Result r in Cross.Results)
				{
					bool uinc = false;
					foreach (PersonSetting ps in this.CombinedPersons)
					{
						if ( ps.GetType().Equals(typeof(Person)) )
						{
							Person p = (Person)ps;
							if (p.ID == Eval.GetPersonIdByUser(r.UserID))
								uinc = true;
						}
						else
						{
							PersonCombo p = (PersonCombo)ps;
							if (p.ContainsID(Eval.GetPersonIdByUser(r.UserID)))
								uinc = true;
						}
					}

					if (!uinc) continue;

					bool inc = false;
					
					if (Cross.Display.Equals("multi"))
					{
						foreach (string ra in r.TextAnswer.Split(';'))
							if (ra.Equals(answer))
							{
								inc = true;
							}
					}
					else if (r.SelectedAnswer == ai || r.TextAnswer.Equals(answer))
					{
						inc = true;
					}


					if (inc)
					{
						int qi = 0;

						foreach (Question q in Questions)
						{
							//Console.WriteLine("qi of " + q.SID + " = " + qi);
							Result qr =  q.GetResultByUserID(r.UserID);
							if (qr == null)
							{
								qi++;
								continue;
								//sums[qi]+= 0;
								//counts[qi]+=0;
							}

							if (qr.SelectedAnswer != -1)
							{
								sums[qi]+=qr.SelectedAnswer;
								counts[qi]+=1;
							}
							
							qi++;
						}
					}

					
				}

				int qii = 0;
				foreach (Question q in Questions)
				{
					//Console.WriteLine("qii of " + q.SID + " is " + qii);
					double res = Math.Round(sums[qii]/counts[qii] + 1, this.Precision);
					string str = res.ToString();
					if (counts[qii] == 0)
						str = "-";

					//Console.WriteLine("result of " + qii + " is " + str + "\t");
					ResultTable += str + "\t";
					sums[qii] = 0;
					counts[qii] = 0;
					qii++;
				}


				ResultTable += "\r\n";
				ai++;
			}

			ResultTable += "\r\n\r\n";
			
			ResultTable += "LEGENDE\r\n\r\n";

			foreach (Question q in Questions)
			{
				if (q != null)
				ResultTable += q.SID + "...\t" + q.Text + "\r\n";
			}
			ResultTable += Cross.SID + "...\t" + Cross.Text + "\r\n";

			ResultTable += "\r\n\r\n";

			ai = 1;
			foreach (string answer in Cross.AnswerList)
			{
				ResultTable += ai + "...\t" + answer + "\r\n";
				ai++;
			}
		}

		public override void EditDialog()
		{
			OutputFormCrossAverages ofa = new OutputFormCrossAverages(eval, false, this);
			ofa.ShowDialog();
		}

        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_CrossAverages(eval, false, this);
        }

		public override void Save(string name, string path)
		{
			//
			Question[] baseq = Questions;
			
			//cross?
			
			Evaluation seval;
			//if (CrossTargets(Questions))
			//{
			//	seval = this.CrEval;
			//}
			if (this.OvEval != null)
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

				Cross = td.GetQuestion(Cross, Eval);

				Compute();

				FileStream fs = new FileStream(path + "\\" + SystemTools.Savable(name + " ("+td.Name+").txt"), FileMode.Create);
				StreamWriter sr = new StreamWriter(fs);
				sr.Write(ResultTable);
				sr.Close();
			}

//			seval = null;
			ResultTable = null;
		}
	}
}
