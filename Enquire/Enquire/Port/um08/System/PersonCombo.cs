using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Collections;

namespace compucare.Enquire.Legacy.Umfrage2Lib.System
{
	[Serializable]
	public class PersonCombo : PersonSetting, ISerializable
	{
		public Person[] Persons;

		public int Index;


        new public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
            ReadSerData(info);

            info.AddValue("Persons", Persons);
            info.AddValue("Index", Index);
		}

		public PersonCombo(SerializationInfo info, StreamingContext ctxt)
		{
            LoadSerData(info);

            Persons = (Person[])info.GetValue("Persons", typeof(Person[]));
            Index = info.GetInt32("Index");
        }

		public PersonCombo()
		{
			Persons = new Person[0];

			Color1 = Color.White;
			Color2 = Color.Gray;

			Index = -1;
		}

		public void AddPerson(Person person)
		{
			Person[] old = Persons;

			Persons = new Person[Persons.Length + 1];

			int i = 0;
			foreach (Person p in old)
				Persons[i++] = p;

			Persons[i] = person;
		}

		public override string ToString()
		{
			string name = string.Empty;

			int i = 0;
			foreach (Person p in Persons)
			{
				name += p.Name;
				i++;
				if (Persons.Length > i)
					name += ", ";
			}

			return name;
		}

		public bool ContainsID(int PID)
		{
			foreach (Person p in Persons)
				if (p.ID == PID)
					return true;

			return false;
		}

        public override ArrayList GetAllUsers(Evaluation eval)
        {
            ArrayList l = new ArrayList();

            foreach (User u in eval.Users)
            {
                foreach (Person p in Persons)
                {
                    if (u.PersonID == p.ID)
                        l.Add(u);
                    break;
                }
            }

            return l;
        }

	}
}
