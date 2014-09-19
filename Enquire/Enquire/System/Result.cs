using System;

namespace Compucare.Enquire.System
{
	/// <summary>
	/// One Answer to one Question
	/// </summary>

	[Serializable]
	public class Result
	{
		/// <summary>
		/// Array Index of selected Answer
		/// </summary>
		public int    SelectedAnswer;
		/// <summary>
		/// Text Answer for open Questions
		/// </summary>
		public string TextAnswer;
		/// <summary>
		/// User ID of answering User
		/// </summary>
		public int UserID;

		public Result(int SelectedAnswer, int UserID)
		{
			this.SelectedAnswer = SelectedAnswer;
			this.UserID = UserID;
			this.TextAnswer = string.Empty;
		}

		public Result(string TextAnswer, int UserID)
		{
			this.TextAnswer = TextAnswer;
			this.UserID = UserID;
			this.SelectedAnswer = -1;
		}

		public Result(string TextAnswer, int SelectedAnswer, int UserID)
		{
			this.SelectedAnswer = SelectedAnswer;
			this.TextAnswer = TextAnswer;
			this.UserID = UserID;
		}
	}
}
