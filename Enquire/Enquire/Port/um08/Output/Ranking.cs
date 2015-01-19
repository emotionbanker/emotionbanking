using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using umfrage2;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{
	/// <summary>
	/// Summary description for Ranking.
	/// </summary>
	/// 

	[Serializable]
	public class RankingResult
	{
		public Question q;
		public PersonSetting ps;
		public float Avg;

		public RankingResult(Question q, PersonSetting ps, float Avg)
		{
			this.q = q;
			this.ps = ps;
			this.Avg = Avg;
		}
	}

	[Serializable]
	public class Ranking : Output
	{
		public bool Flops;
		public Question[] Questions;

		public string ResultTable;

		[NonSerialized]
		private RankingResult[] rr;

        public Ranking(Evaluation eval)
        {
            this.eval = eval;
			Flops = false;
			Questions = new Question[0];
			ResultTable = string.Empty;
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
			info.AddValue("Flops", this.Flops);

		}

		public Ranking(SerializationInfo info, StreamingContext ctxt)
		{
			base.ReadSerData(info, ctxt);

			this.Questions = (Question[])info.GetValue("Questions", typeof(Question[]));
			this.ResultTable = info.GetString("ResultTable");
			this.Flops = info.GetBoolean("Flops");
		}

		public void QuicksortI(int lo, int hi)
		{
			if(rr.Length == 0)
				return;

			int i = lo, j = hi;
			float x = rr[(lo+hi)/2].Avg;
			RankingResult h;

			do
			{
			while (rr[i].Avg > x) i++;
			while (rr[j].Avg < x) j--;
				if (i<=j)
				{
					h = rr[i];
					rr[i] = rr[j];
					rr[j] = h;
					i++;
					j--;
				}
			}while (i<=j);

			if (lo<j) QuicksortI(lo, j);
			if (i<hi) QuicksortI(i, hi);
		}

		public void Quicksort(int lo, int hi)
		{
			if(rr.Length == 0)
				return;

			int i = lo, j = hi;
			float x = rr[(lo+hi)/2].Avg;
			RankingResult h;

			do
			{
			while (rr[i].Avg < x) i++;
			while (rr[j].Avg > x) j--;

				if (i<=j)
				{
					h = rr[i];
					rr[i] = rr[j];
					rr[j] = h;
					i++;
					j--;
				}
			}while (i<=j);

			if (lo<j) Quicksort(lo, j);
			if (i<hi) Quicksort(i, hi);
		}

		public override void Compute()
		{
			///sort!
			///

			//rr = new RankingResult[CombinedPersons.Length * Questions.Length];

			ResultTable = string.Empty;

			ResultTable += "RANKING\r\n\r\n";


			ArrayList al = new ArrayList();
			//compute
			//int c = 0;
			foreach (Question q in Questions)
			{
				if (q == null) continue;
				for (int i = 0; i < (CombinedPersons.Length); i++)
				{
					RankingResult r = new RankingResult(q, CombinedPersons[i], q.GetAverageByPersonAsMark(Eval, CombinedPersons[i]));
					//rr[c] = r;
					al.Add(r);
					//c++;
				}
			}

			int c = 0;
			rr = new RankingResult[al.Count];
			foreach (RankingResult r in al)
				rr[c++] = r;
			


			//sort
			if (!Flops)
				Quicksort(0, rr.Length-1);
			else
				QuicksortI(0, rr.Length-1);

			//print
			int rank = 1;
			bool nores = false;
			for (int i = 0; i < rr.Length; i++)
			{
				string val;

				if (rr[i].Avg != -1)
				{
					val = Math.Round(rr[i].Avg,1).ToString();
					ResultTable += (rank) + ". Platz: " + rr[i].q.SID + ", " + rr[i].ps.Short + "\tMW="+val+"\r\n";
					rank++;
				}
				else
					nores = true;
			}

			if (nores)
			{
				ResultTable += "\r\n\r\nKeine Ergebnisse für:\r\n";

				for (int i = 0; i < rr.Length; i++)
				{
					if (rr[i].Avg == -1)
					{
						ResultTable += rr[i].q.SID + ", " + rr[i].ps.Short + "\r\n";
					}			
				}
			}

			ResultTable += "\r\n\r\n";
			
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
			OutputFormRank ofa = new OutputFormRank(eval, false, this);
			ofa.ShowDialog();
		}

        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_Rank(eval, false, this);
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
				{
					if (q != null)
					Questions[i++] = td.GetQuestion(q, Eval);
				}

				Compute();

				FileStream fs = new FileStream(path + "\\" + SystemTools.Savable(name + " ("+td.Name+").txt"), FileMode.Create);
				StreamWriter sr = new StreamWriter(fs);
				sr.Write(ResultTable);
				sr.Close();
			}

			seval = null;
			ResultTable = string.Empty;
		}
	}
}
