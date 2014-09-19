using System;
using System.Collections;
using System.Runtime.Serialization;

namespace compucare.Enquire.Legacy.Umfrage2Lib.System
{
	/// <summary>
	/// Summary description for TargetCombo.
	/// </summary>
	/// 
	[Serializable]
	public class TargetCombo : ISerializable
	{
		public string[] TargetIDs;

		public int Index;

		public string Name;

		public string LongName;

        public ArrayList Splits;

		public string CombinedID
		{
			get
			{
				string name = string.Empty;

				int	i = 0;
				foreach (string p in TargetIDs)
				{
					name += p;
					i++;
					if (TargetIDs.Length > i)
						name += ", ";
				}

				return name;
			}
		}

		[NonSerialized]
		public bool Included = true;

		public TargetCombo(string Name)
		{
			this.Name = Name;
			Index = -1;
			TargetIDs = new string[0];
            Splits = new ArrayList();
		}

        public virtual void GetObjectData(SerializationInfo info, StreamingContext ctxt)
	    {
            info.AddValue("TargetIDs", TargetIDs);
            info.AddValue("Index", Index);
            info.AddValue("Name", Name);
            info.AddValue("LongName", LongName);
            info.AddValue("Splits", Splits);
	    }


	    public TargetCombo(SerializationInfo info, StreamingContext ctxt)
	    {
            this.TargetIDs = (string[])info.GetValue("TargetIDs", typeof(string[]));
            this.Index = info.GetInt32("Index");
            this.Name = info.GetString("Name");
            this.LongName = info.GetString("LongName");


            try { this.Splits = (ArrayList)info.GetValue("Splits", typeof(ArrayList)); }
            catch { this.Splits = new ArrayList(); }
	    }

		public void SetTargets(TargetData[] targets)
		{
			TargetIDs = new string[targets.Length];

			int i = 0;
			foreach (TargetData td in targets)
				TargetIDs[i++] = td.ID;

			string name = string.Empty;

			i = 0;
			foreach (TargetData p in targets)
			{
				name += p.Name;
				i++;
				if (targets.Length > i)
					name += ", ";
			}

			LongName = name;
		}

		public bool ContainsTarget(TargetData target)
		{
			foreach (string id in TargetIDs)
				if (id.Equals(target.ID))
					return true;

			return false;
		}

		public override string ToString()
		{
			if (!Name.Equals(string.Empty))
				return Name;
			else
				return LongName;
				
		}
	}
}
