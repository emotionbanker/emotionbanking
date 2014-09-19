using System;
using System.Runtime.Serialization;
using umfrage2._2008;
using umfrage2._2008.Dialogs;

namespace compucare.Enquire.Legacy.Umfrage2Lib.System
{
	/// <summary>
	/// Summary description for HistoricData.
	/// </summary>
	/// 

	[Serializable]
	public class HistoricData
	{
	    public String Name;

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

                    MultipartLoadDialog dialog = new MultipartLoadDialog();
                    dialog.LoadFile(DocumentPath);

                    //MultipartStatus status = new MultipartStatus();
                    
                    //umfrage2._2008.Tools.EvaluationLoader es = new umfrage2._2008.Tools.EvaluationLoader();
                    //es.LoadFrom(DocumentPath, status);
                    //es.LoadFromSimple(DocumentPath);

					//DialogShortmessage saving = new DialogShortmessage("datei wird geladen...");
					//saving.Show();
					//saving.Refresh();
					//Evaluation e = new Evaluation();
                    //eval = es.eval; // Evaluation.Deserialize(DocumentPath);
					//saving.Close();

				    eval = dialog.eval;

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

        #region Serialization

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("DocumentPath", DocumentPath);
            info.AddValue("LastUpdate", LastUpdate);
            info.AddValue("DatabaseName", DatabaseName);
            info.AddValue("Percent", Percent);
            info.AddValue("Name", Name);
        }

        public HistoricData(SerializationInfo info, StreamingContext ctxt)
        {
            DocumentPath = info.GetString("DocumentPath");
            LastUpdate = info.GetString("LastUpdate");
            DatabaseName = info.GetString("DatabaseName");
            Percent = info.GetSingle("Percent");

            try
            {
                Name = info.GetString("Name");
            }
            catch (Exception)
            {
                Name = "Unknown";
            }
        }

        #endregion Serialization

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
