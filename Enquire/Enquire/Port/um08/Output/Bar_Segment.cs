using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using dotnetCHARTING.WinForms;
using umfrage2;
using umfrage2._2007;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace compucare.Enquire.Legacy.Umfrage2Lib.Output
{
	/// <summary>
	/// Summary description for Bar.
	/// </summary>
	/// 
	[Serializable]
	public class Bar_Segment : Output
	{
        public bool ShowQuestion;  //Frage sichtbar/unsichtbar
        public bool ShowPerson;    //Persongruppe sichtbar/unsichtbar
        public bool ShowValue;     //Wert sichtbar/unsichtbar

        public bool Base = false;  //Basis Frage ja/nein
        public Question BaseQ = null;  //ausgewählte Basisfrage

        public Question[] Questions;

        public Font Txt;

        public Color BackColor;
        public Color BrushColor; 
        

        public StringCollection HideAnswers;
        public List<String> AnswerOrder;

        public Hashtable PersonGroups;

        public SortOrder sort;

        #region SET & GET

        public int GetHeight()
        {
            return this.height;
        }

        public void SetHeight(int height)
        {
            this.height = height;
        }

        public int GetWidth()
        {
            return this.width;
        }

        public void SetWidth(int width)
        {
            this.width = width;
        }

        public bool GetShowText()
        {
            return this.ShowQuestion;
        }

        public void SetShowText(bool ShowText2)
        {
            this.ShowQuestion = ShowText2;
        }

        public bool GetShowPerson()
        {
            return this.ShowPerson;
        }

        public void SetShowPerson(bool ShowPerson)
        {
            this.ShowPerson = ShowPerson;
        }

        public bool GetShowValue()
        {
            return this.ShowValue;
        }

        public void SetShowValue(bool ShowValue)
        {
            this.ShowValue = ShowValue;
        }
      
        public Font GetTxt()
        {
            return this.Txt;
        }

        public void SetTxt(Font txt)
        {
            this.Txt = txt;
        }

        public Color GetBackColor()
        {
            return this.BackColor;
        }

        public void SetBackColor(Color backColor)
        {
            this.BackColor = backColor;
        }

        public Color GetBrushColor()
        {
            return this.BrushColor;
        }

        public void SetBrushColor(Color BrushColor)
        {
            this.BrushColor = BrushColor;
        } 

        public Question[] GetQuestionList()
        {
            return Questions;
        }

        public void SetQuestionList(Question[] question)
        {
            this.Questions = question;
        }

        public SortOrder GetSort()
        {
            return this.sort;
        }

        public void SetSort(SortOrder sort2)
        {
            this.sort = sort2;
        }

        public StringCollection GetHideAnswers()
        {
            return this.HideAnswers;
        }

        public void SetHideAnswers(StringCollection HideAnswers2)
        {
            this.HideAnswers = HideAnswers2;
        }

        public List<String> GetAnswerOrder()
        {
            return this.AnswerOrder;
        }

        public void SetAnswerOrder(List<String> AnswerOrder2)
        {
            this.AnswerOrder = AnswerOrder2;
        }

        public Hashtable GetPersonGroups()
        {
            return this.PersonGroups;
        }

        public void SetPersonGroups(Hashtable PersonGroups2)
        {
            this.PersonGroups = PersonGroups2;
        }

        #endregion

        public Bar_Segment(Evaluation eval)
		{
            this.eval = eval;
            this.ShowPerson = false;
            this.ShowQuestion = false;
            this.ShowValue = false;


            Txt = new Font("Verdana", 8, FontStyle.Bold);

            BackColor = Color.White;
            BrushColor = Color.Black;

            Questions = new Question[0];

            sort = SortOrder.None;

            HideAnswers = new StringCollection();
            AnswerOrder = new List<String>();

            PersonGroups = new Hashtable();

            this.width = 450;
            this.height = 60;
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
            try
            {
                Question.SetMultipartArray(Questions, Multipart);

                info.AddValue("ShowText", this.ShowQuestion);
                info.AddValue("ShowPerson", this.ShowPerson);
                info.AddValue("ShowValue", this.ShowValue);

                info.AddValue("Height", this.height);
                info.AddValue("Width", this.width);

                info.AddValue("Questions", this.Questions);

                info.AddValue("Txt", this.Txt);

                info.AddValue("BackColor", this.BackColor);
                info.AddValue("BrushColor", this.BrushColor);
                

                info.AddValue("HideAnswers", this.HideAnswers);
                info.AddValue("AnswerOrder", this.AnswerOrder);

                info.AddValue("sort", this.sort);

                info.AddValue("PersonGroups", this.PersonGroups);
            }
            catch
            {
                Console.WriteLine("Bar_Segment!");
            }

        }

		public Bar_Segment(SerializationInfo info, StreamingContext ctxt)
		{
			ReadSerData(info, ctxt);

			try
			{
				this.Questions = (Question[])info.GetValue("Questions", typeof(Question[]));

				try
				{
                    this.ShowQuestion = info.GetBoolean("ShowText");
				}
				catch
				{
                    this.ShowQuestion = false;
				}

                try
                {
                    this.ShowPerson = info.GetBoolean("ShowPerson");
                }
                catch
                {
                    this.ShowPerson = false;
                }

                try
                {
                    this.ShowValue = info.GetBoolean("ShowValue");
                }
                catch
                {
                    this.ShowValue = false;
                }

                try { this.height = (int)info.GetValue("Height", typeof(int)); }
                catch { this.height = 60; }

                try { this.width = (int)info.GetValue("Width", typeof(int)); }
                catch { this.width = 450; }


				try {this.Txt = (Font)info.GetValue("Txt", typeof(Font));}
				catch{Txt=new Font("Arial", 8, FontStyle.Bold);}

                try { this.BackColor = (Color)info.GetValue("BackColor", typeof(Color)); }
                catch { BackColor = Color.White; }

                try { this.BrushColor = (Color)info.GetValue("BrushColor", typeof(Color)); }
                catch { BrushColor = Color.Black; }

                try { this.sort = (SortOrder)info.GetValue("sort", typeof(SortOrder)); }
                catch { sort = SortOrder.None; }

                try { this.HideAnswers = (StringCollection)info.GetValue("HideAnswers", typeof(StringCollection)); }
                catch { HideAnswers = new StringCollection(); }

                try { this.AnswerOrder = (List<String>)info.GetValue("AnswerOrder", typeof(List<String>)); }
                catch { AnswerOrder = new List<String>(); }

                

                try { this.PersonGroups = (Hashtable)info.GetValue("PersonGroups", typeof(Hashtable)); }
                catch
                {
                    PersonGroups = new Hashtable();
                    foreach (PersonSetting ps in CombinedPersons)
                        PersonGroups[ps] = 0;
                }

               
			}
			catch (Exception ex)
			{
				Console.WriteLine("Bar@Const");
				Console.WriteLine(ex.Message);
			}
		}

        private Question CombineQ(Question a, Question b)
        {
            Question c = new Question(a);

            foreach (Result r in a.Results)
                c.Results.Add(r);

            foreach (Result r in b.Results)
                c.Results.Add(r);

            return c;
        }

        Hashtable elTOQ;
        Hashtable drawList;

        public void Compute07()
        {
            int countPersons = this.CombinedPersons.Length;
            int countQuestions = this.Questions.Length;
            //this.height = 60 * countPersons * countQuestions;
            SolidBrush red = new SolidBrush(Color.Red);
            SolidBrush yellow = new SolidBrush(Color.Yellow);
            SolidBrush green = new SolidBrush(Color.Green);

            if (this.CombinedPersons.Length >= 1 && this.Questions.Length >= 1)
            {

                OutputImage = new Bitmap(this.width, this.height, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(OutputImage);
                Graphics formGraphics = g;  
               
                g.Clear(BackColor);
                int xAchse = 15;
                int yAchse = 15;

                SolidBrush draw = null;
                foreach (PersonSetting ps in this.CombinedPersons)
                {
                    foreach (Question q in this.Questions)
                    {

                        /*****   Berechnung    **/
                        double val = q.GetAverageByPersonAsMark(Eval, ps, 1);  //muss noch ьberprьft werden
                        double valC = 0.0;
                        if (val > 0)
                        {
                            valC = (125 - val * 25);
                            if (valC > 100)
                            {
                                MessageBox.Show("Wert größer als 100:\nWert:" + valC);
                                valC = 100;
                            }
                        }
                        else
                        {
                            valC = (125 - 1 * 25);
                        }
                        /*****   Berechnung    **/

                        // je nach Ergebnis Stiftfarbe einstellen
                        if (valC >= 80) draw = green;
                        else if (valC >= 60) draw = yellow;
                        else draw = red;

                        int ganze = (int)valC / 10;

                        for (int i = 0; i < ganze; i++)
                        {
                            g.FillRectangle(draw, new Rectangle(xAchse, yAchse, 30, 30));
                            xAchse += 40;
                        }
                        bool restOk = false;
                        if (valC % 10 != 0)
                        {
                            int rest = (int)valC % 10;
                            restOk = true;
                            g.FillRectangle(draw, new Rectangle(xAchse, yAchse, 3 * rest, 30));
                            xAchse += ((3 * rest) +15);
                        }

                        string text = "";

                        if (this.ShowPerson == true)
                        {
                            text += ps.ToString();
                        } 
                        if (this.ShowQuestion == true)
                        {
                            if (this.ShowPerson == true)
                            {
                                if (eval.TextOverloads.ContainsKey(q.ID))
                                    text += "/\n"+(string)eval.TextOverloads[q.ID];
                                else
                                    text += "/\n" + q.Text; 
                            }
                            else
                            {
                                if (eval.TextOverloads.ContainsKey(q.ID))
                                    text += (string)eval.TextOverloads[q.ID];
                                else
                                    text += q.Text;
                            }
                        } 
                        if (this.ShowValue == true)
                        {
                            if (this.ShowPerson == true | this.ShowQuestion == true) text += "/" + Math.Round(valC);
                            else text += Math.Round(valC);
                        }
                        //Schriftart, Schriftgrößenbereich, 
                        formGraphics.DrawString(text, this.Txt, new SolidBrush(this.BrushColor), xAchse, yAchse, new StringFormat());
                        

                        
                        xAchse = 15;
                        yAchse += 45;



                    }//end foreach Questions 
                }//end foreach CombinedPersons
                formGraphics.Dispose();
                draw.Dispose();
                g.Dispose();
            }//end if (length == 1)
            else
            {
                OutputImage = new Bitmap(450, 60, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(OutputImage);
                g.Clear(BackColor);
                g.Dispose();
            }
               
        }

        public override void Compute()
        {
            Compute07();
        }

        public override void EditDialog()
        {
            /*OutputFormBar ofb = new OutputFormBar(eval, false, this);
            ofb.ShowDialog();*/
        }

        public override Control EditControl()
        {
            return new umfrage2._2007.Controls.OutputControl_Bar_Segment(eval, false, this);
        }

        public override void Save(string name, string path)
        {
            //
            Question[] baseq = Questions;

            //cross?
            Evaluation seval;
            if (CrossTargets(Questions))
            {
                seval = this.CrEval;
            }
            else if (this.OvEval != null)
            {
                seval = OvEval;
            }
            else
            {
                seval = this.eval;
            }
            //Targets


            foreach (TargetData td in seval.CombinedTargets)
            {
                if (!td.Included)
                    continue;

                int i = 0;
                foreach (Question q in baseq)
                    Questions[i++] = td.GetQuestion(q, Eval);

                Compute();

                FileStream myFileOut = new FileStream(path + "\\" + SystemTools.Savable(name + " (" + td.Name + ").png"), FileMode.Create);
                OutputImage.Save(myFileOut, ImageFormat.Png);
                myFileOut.Close();
            }

            seval = null;
            OutputImage = null;
        }   

	}
}
