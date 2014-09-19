using System;

namespace Compucare.Enquire.System
{
	/// <summary>
	/// Summary description for HistoricData.
	/// </summary>
	/// 

	[Serializable]
	public class HistoricData
	{
		public string DocumentPath;

		public string LastUpdate;

		public string DatabaseName;

		public float Percent;

		[NonSerialized]
		private Evaluation evaluation;

		public Evaluation Eval
		{
			get 
			{
				try
				{
					if (evaluation != null)
						return evaluation;

					Evaluation eval;

                    
                    umfrage2._2008.Tools.EvaluationLoader es = new umfrage2._2008.Tools.EvaluationLoader();
                    es.LoadFromSimple(DocumentPath);

					//DialogShortmessage saving = new DialogShortmessage("datei wird geladen...");
					//saving.Show();
					//saving.Refresh();
					//Evaluation e = new Evaluation();
                    eval = es.eval; // Evaluation.Deserialize(DocumentPath);
					//saving.Close();

					this.evaluation = eval;
					return eval;
				}
				catch {return null;}
			}
		}

		public HistoricData()
		{
			LastUpdate = DocumentPath = DatabaseName = string.Empty;
			Percent = 0f;
		}

		public override string ToString()
		{
			return Percent + "%, " + DatabaseName + " (" + LastUpdate + ")";
		}

		public bool LoadInfo()
		{
			Evaluation eval;
			try
			{
				eval = Eval;//Evaluation.Deserialize(DocumentPath);
				this.DatabaseName = eval.DatabaseName;
				this.LastUpdate = eval.LastResultUpdate;
			}
			catch {return false;}

			return (eval != null);
		}
	}
}
