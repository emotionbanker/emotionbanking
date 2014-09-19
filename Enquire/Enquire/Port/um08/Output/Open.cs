using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Microsoft.Office.Interop.Excel;
using umfrage2;
using umfrage2._2007.Controls;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{
	/// <summary>
	/// Summary description for Open.
	/// </summary>
	/// 

    public enum OutputStyle
    {
        Standard, Group, User
    }

	[Serializable]
	public class Open : Output
	{
		public Question[] Questions;

		//public bool Group;
        public OutputStyle Style;


        public Open(Evaluation eval)
        {
            this.eval = eval;
			Questions = new Question[0];
			//Group = true;
            Style = OutputStyle.Group;
		}


        public override void LoadGlobalQ()
        {
            LoadQArray(Questions);
        }

        public override void LoadTargetQ(TargetData td)
        {
            LoadTQArray(td, Questions);
        }
		/// <summary>
		/// serialization functions
		/// </summary>
		/// <param name="info"></param>
		/// <param name="ctxt"></param>
		public override void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			LoadSerData(info, ctxt);

            Question.SetMultipartArray(Questions, Multipart);

			info.AddValue("Questions", Questions);
            info.AddValue("Style", Style);

		}

		public Open(SerializationInfo info, StreamingContext ctxt)
		{
			ReadSerData(info, ctxt);

			Questions = (Question[])info.GetValue("Questions", typeof(Question[]));

            try
            {
                Style = (OutputStyle)info.GetValue("Style", typeof(OutputStyle));
                
            }
            catch
            {
                try 
                {
                    Style = info.GetBoolean("Group") ? OutputStyle.Group : OutputStyle.Standard;
                }
                catch 
                {
                    Style = OutputStyle.Group;
                }
            }
		}

		public override void Compute()
		{
		}

		public override void EditDialog()
		{
			OutputFormOpen ofo = new OutputFormOpen(eval, false, this);
			ofo.ShowDialog();
		}

        public override Control EditControl()
        {
            return new OutputControl_Open(eval, false, this);
        }


		private static string IntToLetter(int i)
		{
			return ((char)(i+65)).ToString();
		}

        public string NumberToExcelRow(int num)
        {
            string x = string.Empty;

            while (num > 0)
            {
                int rest = (num % 26);
                if (rest == 0) rest = 26;
                x = ((char)( rest - 1 + 'A')) + x;
                num /= 26;
                if (rest == 26) num -= 1;
            }

            return x;
        }
       

        private void SaveOld(string name, string path, Evaluation seval)
        {
            foreach (TargetData td in seval.CombinedTargets)
            {
                if (!td.Included)
                    continue;

                object missing = Missing.Value;
                //string template = GetAppPath() + "custom.xlt";

                
                Application ExcelObject = new Application();
                Workbook book = ExcelObject.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

                Sheets sheets = book.Worksheets;
                Worksheet sheet = (Worksheet)sheets.get_Item(1);

                
                Style hrow = book.Styles.Add("hrow", missing);
                hrow.Font.Italic = true;

                sheet.Cells[1, "A"] = td.Name;
                //sheet.Cells[3,"A"] = "Person/Frage";

                //Hashtable counter = new Hashtable();

                int pos = 3;

                foreach (Question qq in Questions)
                {
                    sheet.Cells[pos, "A"] = "(" + qq.SID + ") " + qq.Text;
                    Range arange = (Range)sheet.Cells[pos, "A"];
                    arange.Style = hrow;

                    ArrayList ResultRows = new ArrayList();
                    ArrayList counters = new ArrayList();

                    Hashtable IdRows = new Hashtable();

                    int l;
                    if (Style == OutputStyle.Group)
                    {
                        l = 1;
                        foreach (PersonSetting ps in CombinedPersons)
                        {
                            sheet.Cells[pos, IntToLetter(l)] = ps.Short;
                            Hashtable c = new Hashtable();
                            counters.Add(c);
                            l++;
                        }
                    }

                    Question q = td.GetQuestion(qq, Eval);

                    l = 1;
                    foreach (PersonSetting ps in CombinedPersons)
                    {
                        if (Style == OutputStyle.Group)
                        {
                            Hashtable counter = (Hashtable)counters[l - 1];
                            foreach (Result r in q.GetResultsByPerson(ps, Eval))
                            {
                                bool add = true;
                                foreach (string s in ResultRows)
                                {
                                    if (s.Equals(r.TextAnswer))
                                        add = false;
                                }
                                if (add && !r.TextAnswer.Trim().Equals(string.Empty))
                                    ResultRows.Add(r.TextAnswer);

                                if (counter.ContainsKey(r.TextAnswer))
                                    counter[r.TextAnswer] = 1 + (int)counter[r.TextAnswer];
                                else
                                    counter[r.TextAnswer] = 1;
                            }
                        }
                        else if (Style == OutputStyle.Standard)
                        {
                            foreach (Result r in q.GetResultsByPerson(ps, Eval))
                            {
                                if (!r.TextAnswer.Trim().Equals(string.Empty))
                                {
                                    Console.WriteLine(r.UserID + ": " + IdRows.ContainsKey(r.UserID));
                                    IdRows[r.UserID] = r.TextAnswer;
                                }
                            }
                        }
                        else if (Style == OutputStyle.User)
                        {
                        }
                        l++;
                    }

                    if (Style == OutputStyle.Group)
                    {
                        ResultRows.Sort();

                        for (int j = 0; j < ResultRows.Count; j++)
                        {
                            string row = (string)ResultRows[j];

                            sheet.Cells[j + pos + 2, "A"] = row;

                            for (l = 0; l < CombinedPersons.Length; l++)
                            {
                                Hashtable cl = (Hashtable)counters[l];
                                if (!cl.ContainsKey(row)) cl[row] = 0;

                                sheet.Cells[(j + pos + 2), IntToLetter(l + 1)] = (int)cl[row];
                            }
                        }
                    }
                    else
                    {
                        int j = 0;
                        foreach (int id in IdRows.Keys)
                        {
                            string ans = (string)IdRows[id];
                            sheet.Cells[j + pos + 2, "A"] = id.ToString();
                            sheet.Cells[j + pos + 2, "B"] = ans;
                            j++;
                        }

                    }



                    //next question
                    if (Style == OutputStyle.Group)
                        pos += ResultRows.Count + 4;
                    else
                        pos += IdRows.Keys.Count + 4;

                    Marshal.ReleaseComObject(arange);
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }


                //book.Close(true, path + "\\" + SystemTools.Savable(name + " (" + td.Name + ").xls"), missing);
                book.Close(true, path + "\\" + SystemTools.Savable(name + " (" + td.Name + ").xlsx"), missing);
                ExcelObject.Quit();
                while (Marshal.ReleaseComObject(ExcelObject) != 0) ;

                book = null;
                ExcelObject = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private void Save2007(string name, string path, Evaluation seval)
        {
            foreach (TargetData td in seval.CombinedTargets)
            {
                if (!td.Included)
                    continue;

                object missing = Missing.Value;

                Application ExcelObject = new Application();
                Workbook book = ExcelObject.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

                Sheets sheets = book.Worksheets;
                Worksheet sheet = (Worksheet)sheets.get_Item(1);

                Style hrow = book.Styles.Add("hrow", missing);
                hrow.Font.Italic = true;

                sheet.Cells[1, "A"] = td.Name;
                //sheet.Cells[3,"A"] = "Person/Frage";

                //Hashtable counter = new Hashtable();

                int ypos = 3;
                int xpos = 0;

                Hashtable ResultRows = new Hashtable();

                foreach (Question qq in Questions)
                {
                    xpos = 1;

                    sheet.Cells[ypos, "A"] = "(" + qq.SID + ") " + qq.Text;
                    Range arange = (Range)sheet.Cells[ypos, "A"];
                    arange.Style = hrow;

                    Question q = td.GetQuestion(qq, Eval);

                    foreach (PersonSetting ps in CombinedPersons)
                    {
                        foreach (Result r in q.GetResultsByPerson(ps, Eval))
                        {
                            string uid = "(" + ps.Short + ") " + r.UserID;
                            int rpos;
                            if (ResultRows.ContainsKey(uid))
                            {
                                rpos = (int)ResultRows[uid];
                            }
                            else
                            {
                                xpos++;
                                rpos = xpos;
                                ResultRows[uid] = rpos;
                            }

                            Console.WriteLine(rpos + " == " + this.NumberToExcelRow(rpos));
                            sheet.Cells[ypos, this.NumberToExcelRow(rpos)] = r.TextAnswer;
                        }
                    }

                    ypos++;
                }

                foreach (string user in ResultRows.Keys)
                {
                    sheet.Cells[2, NumberToExcelRow((int)ResultRows[user])] = user;
                }

                //book.Close(true, (object)(path + "\\" + SystemTools.Savable(name + " (" + td.Name + ").xls")), missing);
                book.Close(true, (object)(path + "\\" + SystemTools.Savable(name + " (" + td.Name + ").xlsx")), missing);
                book = null;
                ExcelObject.Quit();
                while (Marshal.ReleaseComObject(ExcelObject) != 0) ;

                ExcelObject = null;

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

		public override void Save(string name, string path)
		{
			Evaluation seval;
			
			if (CrossTargets(Questions))
			{
				seval = CrEval;
			}
			else if (OvEval != null)
			{
				seval = OvEval;
			}
			else
			{
				seval = eval;
			}

            if (Style == OutputStyle.Group || Style == OutputStyle.Standard) SaveOld(name, path, seval);
            else Save2007(name, path, seval);
		}

	}
}
