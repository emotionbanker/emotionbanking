using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Collections;

namespace Compucare.Enquire.System
{
	/// <summary>
	/// Summary description for Person.
	/// </summary>
	/// 
	[Serializable]
	public class Person : PersonSetting, ISerializable
	{
		public string Name;
		public int ID;

        new public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
            ReadSerData(info);

            info.AddValue("Name", Name);
            info.AddValue("ID", ID);
		}

		public Person(SerializationInfo info, StreamingContext ctxt)
		{
            LoadSerData(info);

            //try
            //{
                Name = info.GetString("Name");
                ID = info.GetInt32("ID");
            //}
            //catch { }
        }


		public Person(string PersonName, int PersonID)
		{
			Name = PersonName;
			ID   = PersonID;

			Color1 = Color.White;
			Color2 = Color.Gray;
		}

		public Person()
		{
			Name = string.Empty;
			ID = -1;

			Color1 = Color.White;
			Color2 = Color.Gray;
		}

		public override string ToString()
		{
			return Name;
		}

        public override ArrayList GetAllUsers(Evaluation eval)
        {
            ArrayList l = new ArrayList();

            foreach (User u in eval.Users)
            {
                if (u.PersonID == this.ID)
                    l.Add(u);
            }

            return l;
        }

	}
}
