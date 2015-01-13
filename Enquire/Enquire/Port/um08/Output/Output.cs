using System;
using System.Drawing;
using System.Collections;
using System.Runtime.Serialization;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{
	/// <summary>
	/// Summary description for Output.
	/// </summary>
	/// 

    public enum SortOrder { Ascending, Descending, None }

	[Serializable]
	public abstract class Output : ISerializable
	{
        public const int Victor2006 = 0;
        public const int Victor2007 = 1;

		public const int FORMAT_SCALED = 0;
		public const int FORMAT_BASIC  = 1;
		public const int GRID_BASIC    = 2;
		public const int GRID_SCALED   = 3;

		public const int SHAPE_ELLIPSED = 5;
		public const int SHAPE_ELLIPSE = 4;
		public const int SHAPE_TRIANGLED = 3;
		public const int SHAPE_TRIANGLE = 2; 
		public const int SHAPE_CIRCLE = 1;
		public const int SHAPE_BOX = 0;

		public Evaluation eval;

		public Evaluation Eval
		{
			get
			{
				if (OvEval != null) return OvEval;
				else return eval;
			}
			set
			{
				this.eval = value;
			}
		}

		public Bitmap     OutputImage;
		public Person[]   PersonList;
		public PersonCombo[] ComboList;

		public Question Cross;

		public string Name = "Neue Auswertung";

		public int width;
		public int height;

		[NonSerialized]
		public Evaluation CrEval;

		[NonSerialized]
		public Evaluation OvEval;

        public bool Multipart;

		public virtual Output Clone
		{
			get
			{
				//geht das?
                Output clone = (Output)this.MemberwiseClone();
			    return clone;
			}

		}

       /* public virtual Output Clone2
        {
            get
            {
                //geht das?
                Output clone = (Output)this;
                
                return clone;
            }
        }*/

        /*public Output Output(Output o)
        {
            Output ou = this;
            ou.Eval = o.eval;
            ou.PersonList = o.PersonList;
            ou.ComboList = o.ComboList;
            ou.Cross = o.Cross;
            ou.Name = "Test Samet von " + o.Name;
            ou.width = o.width;
            ou.height = o.height;
            return ou;
        }*/

		public PersonSetting[] CombinedPersons
		{
			get
			{
				PersonSetting[] ps = new PersonSetting[PersonList.Length + ComboList.Length];

				int i = 0;
				foreach (PersonSetting p in PersonList)
					ps[i++] = p;
				foreach (PersonSetting p in ComboList)
					ps[i++] = p;

				return ps;
			}
		}

		public Output()
		{
			PersonList = new Person[0];
			ComboList = new PersonCombo[0];
            Multipart = false;
		}


        public void LoadQArray(Question[] qs)
        {
            foreach (Question q in qs)
                LoadQ(q);
        }

        public void LoadQ(Question q)
        {
            if (q != null)
            {
                Question globq = eval.Global.GetQuestion(q, eval);
                if (globq != null) q.Results = globq.Results;
            }
        }

        public void LoadTQArray(TargetData td, Question[] qs)
        {
            foreach (Question q in qs)
                LoadTQ(td, q);
        }

        public void LoadTQ(TargetData td, Question q)
        {
            if (q != null)
            {
                Question globq = td.GetQuestion(q, eval);
                if (globq != null) q.Results = globq.Results;
            }
        }

        public abstract void LoadGlobalQ();

        public abstract void LoadTargetQ(TargetData td);
		
		/// <summary>
		/// serialization functions
		/// </summary>
		/// <param name="info"></param>
		/// <param name="ctxt"></param>
		public virtual void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			this.LoadSerData(info, ctxt);
		}

		public void LoadSerData(SerializationInfo info, StreamingContext ctxt)
		{
            Question.SetMultipart(Cross, Multipart);

			try
			{
				//info.AddValue("OutputImage", this.OutputImage);
				info.AddValue("eval", this.Eval);
				info.AddValue("PersonList", this.PersonList);
				info.AddValue("ComboList", this.ComboList);
				info.AddValue("Cross", this.Cross);
				info.AddValue("Name", this.Name);
				info.AddValue("width", this.width);
				info.AddValue("height", this.height);
			}
			catch
			{
				Console.WriteLine("LoadSerData!");
			}
		}

		public void ReadSerData(SerializationInfo info, StreamingContext ctxt)
		{
			try
			{
				this.eval = (Evaluation)info.GetValue("eval", typeof(Evaluation));

				this.PersonList = (Person[])info.GetValue("PersonList", typeof(Person[]));
				this.ComboList = (PersonCombo[])info.GetValue("ComboList", typeof(PersonCombo[]));
				this.Cross = (Question)info.GetValue("Cross", typeof(Question));
				this.Name = info.GetString("Name");
				this.width = info.GetInt32("width");
				this.height = info.GetInt32("height");
			}
			catch
			{
				Console.WriteLine("in readserdata");
			}
		}

		public Output(SerializationInfo info, StreamingContext ctxt)
		{
			this.ReadSerData(info, ctxt);
		}


		public bool CrossTargets()
		{
			Question[] List = new Question[0];
			return CrossTargets(List, true);
		}

		public bool CrossTargets(Question q)
		{
			Question[] List = new Question[]{q};
			return CrossTargets(List, false);
		}

		public bool CrossTargets(Question[] List)
		{
			return CrossTargets(List, false);
		}

		public static string CleanString(string s)
		{
			//     \ / : * ? " < > |

			s = s.Replace("\\", "_");
			s = s.Replace("/", "_");
			s = s.Replace(":", "_");
			s = s.Replace("*", "_");
			s = s.Replace("?", "_");
			s = s.Replace("\"", "'");
			s = s.Replace("<", "kl");
			s = s.Replace(">", "gr");
			s = s.Replace(":", "_");

			return s;
		}

        public bool CrossTargets(Question[] List, bool all)
        {
            return CrossTargets(List, all, false);
        }

		public bool CrossTargets(Question[] List, bool all, bool cleanstring)
		{
			if (all || Cross == null)
			{
				Console.WriteLine("all...");
				return false;
			}

			int i;

			Console.WriteLine("crossing with " + Cross.SID);

			bool wasnull = false;

			if (this.OvEval == null)
			{
				OvEval = eval;
				wasnull = true;
			}

            bool crosserr = false;

			CrEval = OvEval.EmptyCopy;

			CrEval.Targets = new TargetData[OvEval.CountIncludedCombinedTargets * Cross.AnswerList.Length];
			CrEval.global = OvEval.Global;

			i = 0;
			foreach (TargetData target in OvEval.CombinedTargets)
			{
				if (!target.Included)
					continue;

				Question lCross = target.GetQuestion(Cross, OvEval);

                if (lCross == null) { crosserr = true;  continue; }

				for (int s=0; s<Cross.AnswerList.Length; s++)
				{
					string answer = Cross.AnswerList[s];
				    String name = target.name + ", " + answer;
                    if (cleanstring)
                    {
                        name = CleanString(name);
                    }
					TargetData ntarget = new TargetData("", name, "");

					
					ArrayList UIDs = new ArrayList();
					foreach (Result r in lCross.Results)
					{
						if (Cross.Display.Equals("multi"))
						{
							foreach (string ra in r.TextAnswer.Split(';'))
							{
								if (ra.Equals(answer))
								{
									UIDs.Add(r.UserID);
									break;
								}
							}
						}
						else if (r.SelectedAnswer == s || r.TextAnswer.Equals(answer))
						{
							UIDs.Add(r.UserID);
						}
					}

					ntarget.Questions = new Question[List.Length];

					int j = 0;
					foreach (Question q in target.Questions)
					{
						if (!all)
						{
							bool add = false;
							foreach (Question l in List)
							{
								if (q.ID == l.ID)
									add = true;
							}
							if (!add)
								continue;
						}
						Question nq = new Question(q);
						foreach (int uid in UIDs)
						{
							Result rs = q.GetResultByUserID(uid);
							if (rs != null)
								nq.Results.Add(rs.Copy);
						}
						ntarget.Questions[j++] = nq;
					}
					CrEval.Targets[i++] = ntarget;
				}
			}

            if (crosserr)
                MessageBox.Show("Es konnte für zumindest eine eingestellte Bank keine Kreuzungsfrage gefunden werden.\nDiese Kreuzungen wurden nicht berechnet.", "Fehler bei Kreuzung", MessageBoxButtons.OK, MessageBoxIcon.Error);

			if (wasnull) OvEval = null;
			return true;
		}

		public abstract void Compute();

		public abstract void Save(string name, string path);

		public override string ToString()
		{
			if (Name.Equals(string.Empty) || Name == null)
				return "unbenannt";

			return Name;
		}

		public abstract void EditDialog();
        
        public virtual Control EditControl()
        {
            return new Panel();
        }

	}
}
