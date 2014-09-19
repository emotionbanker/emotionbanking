using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Collections;

namespace Compucare.Enquire.System
{
	/// <summary>
	/// Summary description for PersonSetting.
	/// </summary>
	/// 
	[Serializable]
	public abstract class PersonSetting : ISerializable
	{
		public Color Color1;
		public Color Color2;

		public string Short = string.Empty;

        //deprecated
		public int Shape = Output.SHAPE_BOX;

        public Symbol Sym;

        public int Group = 0;

        public bool Grouped
        {
            get { return (Group != 0); }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
            ReadSerData(info);
		}

		public PersonSetting(SerializationInfo info, StreamingContext ctxt)
		{
            LoadSerData(info);
            
        }

        public void ReadSerData(SerializationInfo info)
        {
            info.AddValue("Color1", Color1);
            info.AddValue("Color2", Color2);

            info.AddValue("Short", Short);

            info.AddValue("Shape", Shape);
            info.AddValue("Sym", Sym);

            info.AddValue("Group", Group);
        }

        public void LoadSerData(SerializationInfo info)
        {
            Color1 = (Color)info.GetValue("Color1", typeof(Color));
            Color2 = (Color)info.GetValue("Color2", typeof(Color));

            Short = info.GetString("Short");

            Shape = info.GetInt32("Shape");

            try { Group = info.GetInt32("Group"); }
            catch { Group = 0; }

            try
            {
                Sym = (Symbol)info.GetValue("Sym", typeof(Symbol));
            }
            catch
            {
                Sym = new Symbol();
                Sym.Shape = Shape;
            }
        }

		public PersonSetting()
		{
            Sym = new Symbol();
		}

        public abstract ArrayList GetAllUsers(Evaluation eval);

        public bool ContainsID(int PID)
        {
            if (this.GetType() == typeof(Person))
            {
                Person p = (Person)this;
                return (p.ID == PID);
            }
            else if (this.GetType() == typeof(PersonCombo))
            {
                PersonCombo p = (PersonCombo)this;
                return p.ContainsID(PID);
            }

            return false;
        }

	}
}
