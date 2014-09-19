using System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.System
{
	[Serializable]
	public class DatabasePrefix
	{
		public string Prefix;

		public DatabasePrefix ()
		{
			Prefix = string.Empty;
		}

		public DatabasePrefix (string p)
		{
			Prefix = p;
		}

		public override string ToString()
		{
			if (Prefix.Equals(string.Empty))
				return "Keine simulierte Datenbank (Altes Format)";
			else
				return "Simulierte Datenbank: " + Prefix;
		}

	}
}
