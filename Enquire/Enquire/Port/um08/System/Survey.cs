using System;
using System.Collections;

namespace compucare.Enquire.Legacy.Umfrage2Lib.System
{
	/// <summary>
	/// Summary description for Survey.
	/// </summary>
	/// 

	[Serializable]
	public class Survey
	{
		public int PID;

		public string[] QuestionList;

		public ArrayList QList
		{
			get
			{
				ArrayList al = new ArrayList();

				for (int i = 0; i < QuestionList.Length; i++)
				{
					try
					{
						al.Add(Int32.Parse(QuestionList[i]));
					}
					catch {}
				}

				return al;
			}
		}

		public Survey()
		{
			QuestionList = new string[0];
		}

		public bool ContainsQuestion(Question q)
		{
			for (int i = 0; i < QuestionList.Length; i++)
			{
				try
				{
					if (Int32.Parse(QuestionList[i]) == q.ID)
						return true;
				}
				catch {}
			}

			return false;
		}
	}
}
