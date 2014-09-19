namespace compucare.Enquire.Legacy.Umfrage2Lib.System
{
	/// <summary>
	/// Zusammenfassung für Tools.
	/// </summary>
	public class Tools
	{
		public Tools()
		{
		}

		public static string NumberToExcelRow(int num)
		{
			if (num > ((26*26)-1))
			{
				return "A";
			}
			string row = string.Empty;

			char a = (char)('A' - 1);

			// 1 ... A
			// 26 .. Z
			// 27 .. AA (1 ... 1)
			// 52 .. AZ (1 ... Z)

			while (num > 26)
			{
				//additional char
				row += (char)(a + ((num-1)/26));

				num = ((num - 1) % 26) + 1;
			}

			/*
			while (num > 26)
			{
				row += (char)(a + (num/25));
				num %= 25;
			}
			*/
			row += (char)(a + num);

			return row;
		}
	}
}
