using System;
using System.Runtime.Serialization;

namespace compucare.Enquire.Legacy.Umfrage2Lib.System
{
	/// <summary>
	/// One Answer to one Question
	/// </summary>

	[Serializable]
	public class Result : ISerializable
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

	    public int AliasId;

	    public Result Copy
	    {
	        get
	        {
	            return new Result(this);
	        }
	    }

        public Result()
        {

        }

        public static Result Create(int selectedAnswer, int userId)
        {
            return new Result(selectedAnswer, userId);
        }

        public static Result Create(String textAnswer, int userId)
        {
            return new Result(textAnswer, userId);
        }

        public static Result CreateEmpty()
        {
            return new Result(-1, -1);
        }

		private Result(int SelectedAnswer, int UserID)
		{
			this.SelectedAnswer = SelectedAnswer;
			this.UserID = UserID;
			this.TextAnswer = string.Empty;
		}

        private Result(string TextAnswer, int UserID)
		{
			this.TextAnswer = TextAnswer;
			this.UserID = UserID;
			this.SelectedAnswer = -1;
		}

		private Result(Result copy)
		{
			this.SelectedAnswer = copy.SelectedAnswer;
			this.TextAnswer = copy.TextAnswer;
			this.UserID = copy.UserID;
		    this.AliasId = copy.AliasId;
		}

	    public void GetObjectData(SerializationInfo info, StreamingContext context)
	    {
	        info.AddValue("SelectedAnswer", SelectedAnswer);
            info.AddValue("TextAnswer", TextAnswer);
            info.AddValue("UserID", UserID);
            info.AddValue("AliasId", AliasId);
	    }

        public Result(SerializationInfo info, StreamingContext ctxt)
        {
            SelectedAnswer = info.GetInt32("SelectedAnswer");
            TextAnswer = info.GetString("TextAnswer");
            UserID = info.GetInt32("UserID");

            try
            {
                AliasId = info.GetInt32("AliasId");

            }
            catch (Exception)
            {
                AliasId = -1;
            }
        }
	}
}
