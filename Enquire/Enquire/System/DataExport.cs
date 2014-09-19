using System;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Collections;
using System.Threading;

namespace Compucare.Enquire.System
{
	public class DataExport
	{
		private Evaluation eval;
		private string filename;
		private DialogExport d;
		private bool numbers;

		public DataExport(Evaluation eval, bool numbers)
		{
			this.eval = eval;
			this.numbers = numbers;
		}

		public void Debug()
		{
		}

		public void SaveAsExcel(string filename, DialogExport d)
		{
			this.filename = filename;
			this.d = d;
			Thread t = new Thread(new ThreadStart(this.SaveAsExcelThread));
			t.Start();
		}

        public bool InPersons(Person p)
        {
            foreach (Person sp in d.cpc.SelectedPersons)
                if (p == sp) return true;

            return false;
        }

        public bool InTargets(TargetData t)
        {
            foreach (TargetData st in d.ctc.SelectedTargets)
                if (t == st) return true;

            return false;
        }

        private int SpecUserCount()
        {
            int i = 0;
            foreach (User u in eval.Users)
            {
                bool y = false;

                foreach (TargetData td in d.ctc.SelectedTargets)
                    foreach (Person p in d.cpc.SelectedPersons)
                        if (u.targetID.Equals(td.iD) && p.ID == u.PersonID) y = true;

                if (y) i++;
            }

            return i;
        }

		public void SaveAsExcelThread()
		{
			System.Globalization.CultureInfo oldCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

			DateTime Start = DateTime.Now;
			File.Delete(filename);

			object missing = System.Reflection.Missing.Value;

			Microsoft.Office.Interop.Excel.Application ExcelObject = new Microsoft.Office.Interop.Excel.ApplicationClass();

            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("en-US");

            //Microsoft.Office.Interop.Excel.Workbook book = ExcelObject.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);

            Microsoft.Office.Interop.Excel.Workbook book = (Microsoft.Office.Interop.Excel.Workbook) ExcelObject.Workbooks.GetType().InvokeMember("Add", System.Reflection.BindingFlags.InvokeMethod, null, ExcelObject.Workbooks, null, ci);

			Microsoft.Office.Interop.Excel.Sheets sheets = book.Worksheets;

			Microsoft.Office.Interop.Excel.Worksheet sheet;
			Microsoft.Office.Interop.Excel.Range arange;

            d.GlobalStatus.Max = SpecUserCount(); // eval.UserCount;
			d.GlobalStatus.Value = 0;

            Console.WriteLine("=======================> selected targets");
            foreach (TargetData td in d.ctc.SelectedTargets)
				Console.WriteLine(td.ID + " - " + td.Name);

			foreach (Person p in eval.Persons)
			{
                if (!InPersons(p)) continue;
				//FIXME
				//if (!p.Name.Equals("Privatkunde")) continue;

				
				
				int pid = 0;
				int added=0;
				
				Console.WriteLine();
				Console.WriteLine();
				Console.WriteLine(p);
				Console.WriteLine();

				ArrayList byp = eval.GetUsersByPerson(p);

				Console.WriteLine("ubyp = " + eval.UsersByPerson(p));
				Console.WriteLine("byp = " + eval.UsersByPerson(p));

				Hashtable k = new Hashtable();
				foreach (User u in byp)
				{
					k[u] = false;
				}

                foreach (TargetData td in d.ctc.SelectedTargets)
				{
                    if (!InTargets(td)) continue;
					ArrayList user = eval.UsersByTarget(td, p);

					//Console.WriteLine(td + "...." + user.Count);

					if (td.ID.Equals("rri"))
						Console.WriteLine(td + "...." + user.Count);

					foreach (User u in user)
						k[u] = true;

					pid += user.Count;
				}

				//discrepancy?


				int dis = 0;
				foreach (User u in k.Keys)
				{
					if (!(bool)k[u])
					{
						//u.Debug();
						dis++;
					}
				}

				Console.WriteLine("total ...." + pid);
				Console.WriteLine("discrepacy ...." + dis);

				//return;
				//continue;

                
				d.LocalStatus.Max = pid;//eval.UsersByPerson(p);
				d.LocalStatus.Value = 0;

				sheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.GetType().InvokeMember("Add", System.Reflection.BindingFlags.InvokeMethod, null, sheets, null, ci);

				sheet.Cells.Font.Name = "Arial";
				sheet.Cells.Font.Size = 8;

				sheet.Name = p.Name;

				sheet.Cells[1,"A"] = "";
				arange = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[1,"A"];
				arange.EntireColumn.ColumnWidth = 20;

				((Microsoft.Office.Interop.Excel.Range)sheet.Cells[1,"A"]).EntireColumn.NumberFormat = "@";
				((Microsoft.Office.Interop.Excel.Range)sheet.Cells[1,"A"]).EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;

				//Survey s = eval.Global.GetSurvey(p.ID);

				d.Status(p.Name + " (Initialisiere)");
				
				//header
				int i = 2;

				Hashtable row2id = new Hashtable();
				Hashtable incQ = new Hashtable();

                ArrayList datasheets = new ArrayList();

                datasheets.Add(sheet);

				//foreach (int id in s.QList)
                float qcounter = 0;
                int sheetcounter = 2;
				foreach (Question mq in eval.Global.Questions)
				{
                    
                     

					if (!mq.ContainsPerson(eval,p))
					{
						incQ[mq.ID] = false;
						continue;
					}

                    if ( qcounter++ == 250)
                    {
                        qcounter = 0;
                        //new sheet

                        sheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.GetType().InvokeMember("Add", System.Reflection.BindingFlags.InvokeMethod, null, sheets, null, ci);

                        sheet.Cells.Font.Name = "Arial";
                        sheet.Cells.Font.Size = 8;

                        sheet.Name = p.Name + " (" + sheetcounter + ")";

                        sheet.Cells[1, "A"] = "";
                        arange = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[1, "A"];
                        arange.EntireColumn.ColumnWidth = 20;

                        ((Microsoft.Office.Interop.Excel.Range)sheet.Cells[1, "A"]).EntireColumn.NumberFormat = "@";
                        ((Microsoft.Office.Interop.Excel.Range)sheet.Cells[1, "A"]).EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;

                        sheetcounter++;

                        i = 2;
                        datasheets.Add(sheet);
                    }

					incQ[mq.ID] = true;
					int id = mq.ID;
					
					//Question oq = eval.Global.GetQuestion(id, eval);

					string cell = Tools.NumberToExcelRow(i);

					//Console.WriteLine(cell);

                    try
                    {

                        string s = "F" + id.ToString() + p.Short;
                        sheet.Cells[1, cell] = s;

                        arange = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[1, cell];
                        row2id[id] = cell;
                        arange.EntireColumn.ColumnWidth = 6;
                        arange.EntireColumn.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlRight;
                    }
                    catch { }

					i++;
				}

				//data

				int line = 3;
				d.Status(p.Name + " - " + d.LocalStatus.Value + "/" + d.LocalStatus.Max + " Benutzern exportiert");

                sheet = (Microsoft.Office.Interop.Excel.Worksheet)datasheets[0];

                float tqcounter = 0;
                int tsheetcounter = 0;

                foreach (TargetData td in d.ctc.SelectedTargets)
				{
                    if (!InTargets(td)) continue;
					//FIXME
					//if (!td.ID.Equals("rri")) continue;

					int tdcount = 1;
					foreach (User u in eval.UsersByTarget(td, p))
					{
						//if (u.PersonID == p.ID && u.TargetID.Equals(td.ID))
						{
                            sheet = (Microsoft.Office.Interop.Excel.Worksheet)datasheets[0];
                            tqcounter = 0;
                            tsheetcounter = 0;
							d.Status(p.Name + " - " + d.LocalStatus.Value + "/" + d.LocalStatus.Max + " Benutzern exportiert");
							sheet.Cells[line,"A"] = td.Name + " (" + tdcount + "/" + u.ID + ")";

							added ++;

							i = 2;
							//foreach (int id in s.QList)
                            
                           
                            
                            /*
                            tqcounter++;
                            if (tqcounter == 0)
                            {
                                tqcounter = 0;
                                tsheetcounter++;

                                i = 2;

                                sheet = (Microsoft.Office.Interop.Excel.Worksheet)datasheets[tsheetcounter];
                                sheet.Cells[line, "A"] = td.Name + " (" + tdcount + "/" + u.ID + ")";

                            }*/



							foreach (Question mq in eval.Global.Questions)
							{
                                int id = mq.ID;

                                if (!(bool)incQ[id]) continue;
								//if (!mq.ContainsPerson(eval,p)) continue;

                                if (tqcounter++ == 250)
                                {
                                    tqcounter = 0;
                                    tsheetcounter++;

                                    sheet = (Microsoft.Office.Interop.Excel.Worksheet)datasheets[tsheetcounter];

                                    sheet.Cells[line, "A"] = td.Name + " (" + tdcount + "/" + u.ID + ")";
                                    i = 2;
                                }

								Question q = td.GetQuestion(id, eval);
								if (q != null)
								{
									//string cell = Tools.NumberToExcelRow(i);

									string cell = (string)row2id[id];

									Result r = q.GetResultByUserID(u.ID);
									if (r == null)
									{
										i++;
										continue;
									}

                                    try
                                    {
                                        if (r.TextAnswer != null && !r.TextAnswer.Trim().Equals(string.Empty))
                                        {
                                            /*if (q.Display.ToLower().Equals("multi"))
                                            {
                                                sheet.Cells[line,cell] = string.Empty;
                                            }
                                            else
                                            {*/
                                            sheet.Cells[line, cell] = r.TextAnswer;
                                            //}
                                        }
                                        else if (r.SelectedAnswer != -1)
                                        {
                                            if (this.numbers)
                                            {
                                                sheet.Cells[line, cell] = (r.SelectedAnswer + 1);
                                            }
                                            else
                                            {
                                                sheet.Cells[line, cell] = q.AnswerList[r.SelectedAnswer];
                                            }
                                        }
                                        else
                                        {
                                            //FIXME
                                            sheet.Cells[line, cell] = string.Empty; //Console.WriteLine("minus 1!");
                                        }
                                    }
                                    catch { }
									
								}
								i++;
							}


							d.LocalStatus.Value++;
							d.GlobalStatus.Value++;

							if (d.GlobalStatus.Percent > 0)
							{
								TimeSpan elapsed = DateTime.Now - Start;
								long ticks = (long)(((double) elapsed.Ticks) / ((double)d.GlobalStatus.Percent));
								TimeSpan remaining = new TimeSpan(ticks) - elapsed;
								d.TimeRemainingLabel.Text = remaining.Hours + "h " + remaining.Minutes + "m " + remaining.Seconds + "s ";
								d.TimeElapsedLabel.Text   = elapsed.Hours + "h " + elapsed.Minutes + "m " + elapsed.Seconds + "s ";
							}
							d.LocalPercent.Text  = Math.Round((d.LocalStatus.Percent * 100),0)  + "%";
							d.GlobalPercent.Text = Math.Round((d.GlobalStatus.Percent * 100),0) + "%";
							d.Refresh();

							d.Refresh();
							line++;
							tdcount++;
                            d.Status(p.Name + " - " + d.LocalStatus.Value + "/" + d.LocalStatus.Max + " Benutzern exportiert");
						}
					}
				}

				d.LocalStatus.Value = d.LocalStatus.Max;
				d.LocalPercent.Text  = "100%";

				//book.SaveAs((object)filename, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);

                //book.Save();
				//next person
				//FIXME
				//break;
			}
			
			d.LocalStatus.Value = d.LocalStatus.Max;
			d.GlobalStatus.Value = d.GlobalStatus.Max;
			d.LocalPercent.Text  = "100%";
			d.GlobalPercent.Text = "100%";

			book.Close(true, (object)filename, missing);
			book = null;
			
			while (System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelObject) != 0);
			ExcelObject = null;

			GC.Collect();
			GC.WaitForPendingFinalizers();

			d.DoneButton.Enabled = true;

            System.Threading.Thread.CurrentThread.CurrentCulture = oldCI;
		}
	}
}
