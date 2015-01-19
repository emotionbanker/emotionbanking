using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;

namespace compucare.Enquire.Legacy.Umfrage2Lib.System
{
	public class QuestionExport
	{
		private Evaluation eval;
		private Person[] persons;

		public QuestionExport(Evaluation eval, Person[] persons)
		{
			this.eval = eval;
			this.persons = persons;
		}

		public void SaveAsExcel(string filename)
		{
			File.Delete(filename);

			object missing = Missing.Value;

			Microsoft.Office.Interop.Excel.Application ExcelObject = new Microsoft.Office.Interop.Excel.Application();
			Microsoft.Office.Interop.Excel.Workbook book = ExcelObject.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);

			Microsoft.Office.Interop.Excel.Sheets sheets = book.Worksheets;

			Microsoft.Office.Interop.Excel.Worksheet sheet;

			sheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);

			sheet.Cells.Font.Name = "Arial";
			sheet.Cells.Font.Size = 8;

			sheet.Name = "Fragenexport";

			sheet.Cells[1,"A"] = "ID";
			((Microsoft.Office.Interop.Excel.Range)sheet.Cells[1,"A"]).EntireColumn.ColumnWidth = 10;
			((Microsoft.Office.Interop.Excel.Range)sheet.Cells[1,"A"]).EntireColumn.Font.Bold = true;
			
			sheet.Cells[1,"B"] = "Fragentext";
			((Microsoft.Office.Interop.Excel.Range)sheet.Cells[1,"B"]).EntireColumn.ColumnWidth = 65;

			sheet.Cells[1,"C"] = "Antworten";
			((Microsoft.Office.Interop.Excel.Range)sheet.Cells[1,"C"]).EntireColumn.ColumnWidth = 40;

			sheet.Cells[1,"D"] = "Typ";
			((Microsoft.Office.Interop.Excel.Range)sheet.Cells[1,"D"]).EntireColumn.ColumnWidth = 10;

			sheet.Cells[1,"E"] = "Kürzel";
			((Microsoft.Office.Interop.Excel.Range)sheet.Cells[1,"E"]).EntireColumn.ColumnWidth = 10;
			
			int line = 3;

			foreach (Question q in eval.Global.Questions)
			{
				bool inc = false;
				foreach (Person p in persons)
				{
					if (q.ContainsPerson(eval, p))
						inc = true;
				}

				if (inc)
				{
					Console.WriteLine("inc+/" + q.SID);
					sheet.Cells[line,"A"] = q.SID;
					sheet.Cells[line,"B"] = q.Text;
					sheet.Cells[line,"C"] = q.Answers;
					sheet.Cells[line,"D"] = q.Display;
					sheet.Cells[line,"E"] = q.Shortcut;
					line ++;
				}
				else Console.WriteLine("inc-/" + q.SID);

				
			}


			book.Close(true, (object)filename, missing);
			book = null;
			
			while (Marshal.ReleaseComObject(ExcelObject) != 0);
			ExcelObject = null;

			GC.Collect();
			GC.WaitForPendingFinalizers();
		}
	}
}
