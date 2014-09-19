using System;
using System.Runtime.Serialization;

namespace compucare.Enquire.Legacy.Umfrage2Lib.System
{
	[Serializable]
	public class User : ISerializable
	{
		public int ID;
		public string targetID;
		public int PersonID;

        public int Start;
        public int End;

		public string TargetID
		{
			set {targetID = value;}
			get {return targetID.ToLower();}
		}

		public User(int UserID, string UserTargetID, int UserPersonID)
		{
			ID = UserID;
			TargetID = UserTargetID;
			PersonID = UserPersonID;
		}

		public User()
		{
			ID = PersonID = -1;
			TargetID = string.Empty;
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("ID",ID);
			info.AddValue("TargetID",targetID);
			info.AddValue("PersonID",PersonID);

            info.AddValue("Start", Start);
            info.AddValue("End", End);
		}

   

		public User(SerializationInfo info, StreamingContext ctxt)
		{
			ID = info.GetInt32("ID");
			PersonID = info.GetInt32("PersonID");
			TargetID = info.GetString("TargetID");

            try
            {
                Start = info.GetInt32("Start");
                End = info.GetInt32("End");
            }
            catch
            {
                Start = End = 0;
            }
		}

		public void Debug()
		{
			Console.WriteLine(ID + "\t'" + PersonID + "'\t'" + TargetID + "'");
		}
	}
}
