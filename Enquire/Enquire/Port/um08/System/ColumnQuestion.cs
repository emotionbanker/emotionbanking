using System;
using System.Runtime.Serialization;

namespace compucare.Enquire.Legacy.Umfrage2Lib.System
{
	/// <summary>
	/// Summary description for ColumnQuestion.
	/// </summary>
	/// 
	[Serializable]

	public class ColumnQuestion : ISerializable
	{
		public int QuestionID;

		public string SID
		{
			get
			{
				if (QuestionID >= 0)
					return QuestionID.ToString();
				else
					return "C" + ( (QuestionID+100) * -1);
			}
		}

		public string Name;

		public int[] PersonIDs;

		public float Weight;

		public bool IncludeGap;

		public Category Cat;

		public Gap gap;

		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("Name", this.Name);

			info.AddValue("QuestionID", this.QuestionID);
			info.AddValue("PersonIDs", this.PersonIDs);
			info.AddValue("Weight", this.Weight);
			info.AddValue("IncludeGap", this.IncludeGap);
			info.AddValue("Cat", this.Cat);
			info.AddValue("gap", this.gap);
		}

		public ColumnQuestion(SerializationInfo info, StreamingContext ctxt)
		{
			this.Name = info.GetString("Name");

			this.QuestionID = info.GetInt32("QuestionID");
			this.PersonIDs = (int[])info.GetValue("PersonIDs", typeof(int[]));
			this.Weight = (float)info.GetValue("Weight", typeof(float));
			this.IncludeGap = info.GetBoolean("IncludeGap");
			this.Cat = (Category)info.GetValue("Cat", typeof(Category));

			try
			{
				this.gap = (Gap)info.GetValue("gap", typeof(Gap));
			}
			catch
			{
				this.gap = new Gap(this);
			}
		}

		public ColumnQuestion(Question q)
		{
			QuestionID = q.ID;
			PersonIDs = new int[0];
			Weight = 0;
			IncludeGap = false;
			Name = q.ToString();
			Cat = null;
			this.gap = new Gap(this);
		}

		public ColumnQuestion()
		{
			QuestionID = -1;
			PersonIDs = new int[0];
			Weight = 0;
			IncludeGap = false;
			Name = string.Empty;
			Cat = null;
			this.gap = new Gap(this);
		}

		public void SetPersons(Person[] persons)
		{
			PersonIDs = new int[persons.Length];

			int i = 0;
			foreach (Person p in persons)
				PersonIDs[i++] = p.ID;
		}

		public override string ToString()
		{
			return Name;
		}

	}
}
