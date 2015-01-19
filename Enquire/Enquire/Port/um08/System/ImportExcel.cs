using System;
using System.Data;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Specialized;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace compucare.Enquire.Legacy.Umfrage2Lib.System
{
	/// <summary>
	/// Zusammenfassung für ImportMicrosoft.Office.Interop.Excel.
	/// </summary>
	public class ImportExcel
	{
		private Evaluation eval;

		public ImportExcel(Evaluation eval)
		{
			this.eval = eval;
		}

		public string RandomCode()
		{
			string[] vals = new string[] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "A",
			"B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T",
			"U", "V", "W", "X", "Y", "Z"};

			Random r = new Random();

			string code = string.Empty;

			for (int i = 0; i < 4; i++)
				code += vals[r.Next(vals.Length-1)];

			return code;
		}

		public Hashtable CreateLogin(TargetData bank, Person p, MySqlConnection db)
		{
			Hashtable l = new Hashtable();
			MySqlCommand cmd;
			MySqlDataReader d;

			bool found = true;

			string code = string.Empty;

			while (found)
			{
				code = RandomCode();
				cmd = new MySqlCommand("select count(*) from " + eval.DatabasePrefix + "zugangsdaten where code='" + code + "'", db);

				d = cmd.ExecuteReader();

				d.Read();

				if (d.GetInt32(0) == 0) found = false;
			}


			l["code"] = code;
			l["b_id"] = bank.ID;

			l["p_id"] = p.ID;
			l["used"] = 1;

			cmd = new MySqlCommand("insert into " + eval.DatabasePrefix + "zugangsdaten (code, z_b_id, z_p_id, used) values ('" + l["code"] + "', '" + l["b_id"] + "', '" + l["p_id"] + "','" + l["used"] + "')", db);
			cmd.ExecuteNonQuery();

			Console.WriteLine("created user!");


			cmd = new MySqlCommand("select z_id from " + eval.DatabasePrefix + "zugangsdaten where code='" + code + "'", db);
			d = cmd.ExecuteReader();

			d.Read();

			l["z_id"] = d.GetInt32(0);

			return l;
		}

		public int ImportFolder(string folder, TargetData bank, Person p)
		{
			int c = 0;
			DirectoryInfo di = new DirectoryInfo(folder);
			FileInfo[] rgFiles = di.GetFiles("*.xls");
			
			foreach(FileInfo fi in rgFiles)
			{
				Console.WriteLine("importing " + fi.Name);
				if (ImportFile(folder + "\\" + fi.Name, bank, p))
					c++;
			}

			return c;
		}

		public bool ImportFile(string filename, TargetData bank, Person p)
		{
			StringCollection statements = new StringCollection();

			var sqlConnectionStringBuilder = new MySqlConnectionStringBuilder();
			sqlConnectionStringBuilder.Server = eval.DatabaseHost;
			sqlConnectionStringBuilder.Database = eval.DatabaseName;
			sqlConnectionStringBuilder.UserID = eval.DatabaseUser;
			sqlConnectionStringBuilder.Password = eval.DatabasePassword;

			//MySQLConnection db = new MySQLConnection(new MySQLConnectionString("95.129.200.10", "bdj_db", "banksql", "ma10R58z").AsString);
			MySqlConnection db = new MySqlConnection(sqlConnectionStringBuilder.ConnectionString);

			try
			{
				db.Open();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Fehler beim öffnen der Datenbank!\n" + ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}


			if (db.State != ConnectionState.Open)
				return false;

			//create id
			Hashtable l = CreateLogin(bank,p,db);

			//cmd = new MySQLCommand("select z_id from " + eval.DatabasePrefix + "zugangsdaten where z_b_id"

			object missing = Missing.Value;
			//string template = GetAppPath() + "custom.xlt";

			Microsoft.Office.Interop.Excel.Application ExcelObject = new Microsoft.Office.Interop.Excel.Application();

			Microsoft.Office.Interop.Excel.Workbook book = ExcelObject.Workbooks.Open(filename, missing, true, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);

			Microsoft.Office.Interop.Excel.Sheets sheets = book.Worksheets;
			Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(1);

		
			for (int row = 1; row <= 1000; row++)
			{
				string aval = "" + ((Range)sheet.Cells[row, "A"]).get_Value(missing);

					
				try
				{
					int qid = Int32.Parse(aval);
					//question row!

					string answer = string.Empty;

					//get question
					Question q = eval.Global.GetQuestion(qid, eval);

					if (q.Display.Equals("radio"))
					{
						int j;
						for (j = 3; j < 27; j++)
						{
							string colval = "" + ((Range)sheet.Cells[row, SystemTools.NumberToExcelRow(j)]).get_Value(missing);

							if (!colval.Trim().Equals(string.Empty))
								break;
						}

						int found = j -3;

						if (found < q.AnswerList.Length)
							answer = q.AnswerList[found];
					}
					else if (q.Display.Equals("text"))
					{
						answer  = "" + ((Range)sheet.Cells[row, "C"]).get_Value(missing);
					}
					else if (q.Display.Equals("multi"))
					{
						int j;
						for (j = 3; j < 27; j++)
						{
							string colval = "" + ((Range)sheet.Cells[row, SystemTools.NumberToExcelRow(j)]).get_Value(missing);

							if (!colval.Trim().Equals(string.Empty))
							{
								int found = j -3;
								
								if (found < q.AnswerList.Length)
									answer += q.AnswerList[found] + ";";
							}
						}
						answer = answer.Substring(0, answer.Length-1);
					}

					statements.Add("insert into " + eval.DatabasePrefix + "ergebnisse (e_z_id, e_fr_id, antwort) values ('"+l["z_id"]+"','"+qid+"','"+answer+"')");
				}
				catch
				{
				}
			}

			book.Close(false, missing, missing);
			book = null;
			ExcelObject.Quit();
			while (Marshal.ReleaseComObject(ExcelObject) != 0);

			ExcelObject = null;

			GC.Collect();
			GC.WaitForPendingFinalizers();

			foreach (string s in statements)
			{
				MySqlCommand cmd = new MySqlCommand(s, db);
				cmd.ExecuteNonQuery();
			}

			Console.WriteLine("executed " + statements.Count + " inserts");

			db.Close();

			return true;
		}
	}
}
