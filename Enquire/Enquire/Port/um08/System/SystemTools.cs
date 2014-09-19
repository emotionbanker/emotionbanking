using System;

namespace compucare.Enquire.Legacy.Umfrage2Lib.System
{
	/// <summary>
	/// Summary description for SystemTools.
	/// </summary>
	public class SystemTools
	{
		public SystemTools()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static string Savable(string src)
		{
			return src.Replace("/","_").Replace("\\","_");
		}

		public static string GetAppPath() 
		{
            /*
			System.Reflection.Module[] modules = System.Reflection.Assembly.GetExecutingAssembly().GetModules();

			string aPath = System.IO.Path.GetDirectoryName (modules[0].FullyQualifiedName);

			if ((aPath != "") && (aPath[aPath.Length-1] != '\\'))

				aPath += '\\';

			return aPath;
             * */
		    return AppDomain.CurrentDomain.BaseDirectory;

		}

		public static string NumberToExcelRow(int num)
		{
			//Console.Write("converting " + num + "... ");
			if (num > ((26*26)-1))
			{
				//Console.WriteLine("out of range! >> 'A'");
				return "A";
			}
			string row = string.Empty;

			char a = (char)('A' - 1);
			while (num > 26)
			{
				row += (char)(a + (num/26));
				num %= 26;
			}
			row += (char)(a + num);

			//Console.WriteLine(row);

			return row;
		}
	}
}
