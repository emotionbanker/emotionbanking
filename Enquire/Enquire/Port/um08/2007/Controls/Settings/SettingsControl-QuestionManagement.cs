using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;
using Compucare.Enquire.Legacy.Umfrage2Lib._2007.Controls.Settings;
using System.Collections;

namespace Compucare.Enquire.Legacy.Umfrage2Lib._2007.Controls.Settings
{
    public partial class SettingsControl_QuestionManagement : UserControl
    {

        private Evaluation eval;
        private Hashtable hashtable;
        //private Question newQuestion;
        private Question selectedQuestion;
        private int x = 2;
        private Label[,] labels;
        private TextBox[] textboxes; 

        public SettingsControl_QuestionManagement(Evaluation eval)
        {
            InitializeComponent();
            //Resultate der geladenen Daten anpassen

            foreach (Question q in eval.QuestionConvert)
            {
                QuestionList.Items.Add(q);
            }
            this.eval = eval;
           
        }

        private void addDefaultValues()
        {
            this.hashtable = new Hashtable();

            this.hashtable.Add(1, 10);
        }

        private void addColumnsAndRows()
        {
            int spaltenX = 55;
            int spaltenY = 36;
            textBoxColumnName.Text = "";
            this.labels = new Label[hashtable.Count, x];
            this.textboxes = new TextBox[hashtable.Count];
            for (int i = 0; i < hashtable.Count; i++)
            {
                for (int j = 0; j < x+1; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        
                        labels[i, j] = new Label();
                        labels[i, j].Text = "0";
                        labels[i, j].Location = new Point(spaltenX, spaltenY);
                        labels[i, j].Size = new Size(20,13);
                        //MessageBox.Show("1");
                        this.Step2_1.Controls.Add(labels[i, j]);
                    }
                    else if (j == 0)
                    {
                        labels[i, j] = new Label();
                        labels[i, j].Text = (Convert.ToInt32(this.hashtable[i])+1).ToString();
                        labels[i, j].Location = new Point(spaltenX, spaltenY);
                        //MessageBox.Show("2");
                        labels[i, j].Size = new Size(20, 20);
                        this.Step2_1.Controls.Add(labels[i, j]);
                    }
                    else if (j == 1)
                    {
                        labels[i, j] = new Label();
                        labels[i, j].Location = new Point(spaltenX, spaltenY);
                        labels[i, j].Text = " - ";
                        labels[i, j].Size = new Size(20, 10);
                     
                        this.Step2_1.Controls.Add(labels[i, j]);
                    }
                    else if(j==2){
                        //MessageBox.Show("Textfelder");
                        textboxes[i] = new TextBox();
                        textboxes[i].Name = (i+1).ToString();
                        textboxes[i].Location = new Point(spaltenX, spaltenY-4);
                        textboxes[i].Text = ((int)hashtable[i + 1]).ToString();
                        textboxes[i].Size = new Size(25, 13);
                        textboxes[i].TextChanged += new System.EventHandler(this.TextBox_TextChanged);
                        this.Step2_1.Controls.Add(textboxes[i]);
                    }
                    spaltenX += 35;
                }//end 1st for
                
                textBoxColumnName.Text += "Spalte" + (i+1)+ ";";
                spaltenX = 55;
                spaltenY += 20;
            }//end 2nd for
            
        }

        private void TextBox_TextChanged(object sender, System.EventArgs e)
        {
            TextBox txtBoxSender = (TextBox)sender;

            String strTextBoxID = txtBoxSender.Name;
           
            int n = Convert.ToInt32(txtBoxSender.Name);

            //if (txtBoxSender.Text.Length > 0)
                this.hashtable[n] = Convert.ToInt32(txtBoxSender.Text);
            /*else
                this.hashtable[n] = "";*/

            Step2_1.Controls.Clear();
            textBoxColumnName.Text = "";
            addColumnsAndRows();
            //txtBoxSender.Focus();
            textboxes[n-1].Focus();

            /*textboxes[n] = new TextBox();
            textboxes[n].Name = (i + 1).ToString();
            textboxes[n].Location = new Point(spaltenX, spaltenY - 4);
            //textboxes[i].Text = ((int)hashtable[i+1]-1).ToString();
            textboxes[n].Text = ((int)hashtable[i + 1]).ToString();
            textboxes[i].Size = new Size(25, 13);
            textboxes[i].TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            this.Step2_1.Controls.Add(textboxes[i]);*/

        }

        private void QuestionButton_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(eval);
            
            if (qs.ShowDialog() == DialogResult.OK)
            {
                
                if (qs.SelectedQuestion != null )
                    //&& qs.SelectedQuestion.Display.Equals("onlynumber"))
               {
                    selectedQuestion = qs.SelectedQuestion;
                    QuestionButton.Text = qs.SelectedQuestion.ID.ToString();
                    Step2.Enabled = true;
                    textBoxColumnName.Text = "";
                    addDefaultValues();
                    addColumnsAndRows();
                    Step1.Enabled = false;
                    
                }
                else
                {
                    MessageBox.Show("Bitte eine Frage auswählen");
                    //MessageBox.Show("Bitte eine Frage der Typ 'onlynumber' auswählen");
                    Step2.Enabled = false;
                    Step3.Enabled = false;
                }
               
            }
            else
            {
                QuestionButton.Text = "?";
                Step2.Enabled = false;
                Step3.Enabled = false;
            }

        }

        private void removeColumn_Click(object sender, EventArgs e)
        {
            int key=0;
           
            if (this.hashtable.Count > 1)
            {
                foreach (DictionaryEntry entry in hashtable)
                {
                    key = (int)entry.Key;
                    break;
                }
                
                Step2_1.Controls.Clear();
                this.hashtable.Remove(key);
                textBoxColumnName.Text = "";
                addColumnsAndRows();
            }
            
        }

        private void addColumn_Click(object sender, EventArgs e)
        {
            if (this.hashtable.Count > 0)
                this.hashtable.Add(this.hashtable.Count+1, (int)hashtable[this.hashtable.Count]+2);
                
            
            Step2_1.Controls.Clear();
            textBoxColumnName.Text = "";
            addColumnsAndRows();
        }
        private void createQuestion_Click1(object sender, EventArgs e)
        {
            string[] rows = null;
            string rowstext = "";
            try
            {
                if (selectedQuestion != null)
                {
                    try
                    {
                        rows = textBoxColumnName.Text.Split(';');
                        if (rows.Length >= hashtable.Count)
                        {
                            for (int i = 0; i < hashtable.Count; i++)
                            {
                                rowstext += rows[i] + ";";
                            }
                            rowstext = rowstext.Substring(0, rowstext.Length - 1);
                        }
                        progressBar1.Minimum = 0;
                        progressBar1.Value = 1;
                        progressBar1.Maximum = eval.Targets.Length;
                        progressBar1.Step = 1;
                    }
                    catch
                    {
                        MessageBox.Show("Keine Ergebnisse für die Frage " + selectedQuestion.ID);
                        return;
                    }

                    ArrayList targetResults = new ArrayList();
                    ArrayList questionResults = new ArrayList();
                    ArrayList XQuestions = new ArrayList();
                    String x = "";

                    int counter = 0;
                    string ergebnisse = "";

                    string bereiche = "";
                    for (int i = 0; i < this.hashtable.Count - 1; i++)
                    {
                        bereiche += this.hashtable[i + 1] + ";";
                    }

                    /////////////////////ANFANG/////////////////////////////
                    //newQuestion = Question.Create(selectedQuestion.ID * 10000, selectedQuestion.Text, "radio", rowstext, selectedQuestion.Shortcut, 0);
                    //newQuestion = Question.Copy(selectedQuestion, selectedQuestion.ID, 0);  //Frage wird erstellt
                    //newQuestion.ID = 10001;
                    //newQuestion.Display = "radio";
                    
                    //newQuestion.NullAnswers = selectedQuestion.ID;
                    //newQuestion.Results = new ArrayList();

                    bereiche += this.hashtable[this.hashtable.Count];
                    //newQuestion.Shortcut = bereiche;

                    ArrayList[] targetResultsArray = new ArrayList[eval.Targets.Length];
                    int targetResultsArrayCounter = 0;

                    foreach (TargetData t in eval.Targets)//durchlaufe alle Ziele
                    {
                        foreach (Question qtarget in t.Questions)//durchlaufe alle Fragen der einzelnen Ziele
                        {
                            if (qtarget.ID == selectedQuestion.ID)//wenn selektierte Frage 
                            {
                                //MessageBox.Show("Anzahl der Resultate: "+q.Results.Count.ToString());
                                foreach (Result r in qtarget.Results)//durchlaufe alle Ergebnisse
                                {
                                    int textToInt = 0;
                                    try{
                                        if (r.TextAnswer != null){ textToInt = int.Parse(r.TextAnswer.ToString().Trim());}
                                        else if (selectedQuestion.Display.Equals("radio")){textToInt = r.SelectedAnswer;}
                                    }catch{textToInt = -1;}

                                    int selektor = -1;
                                    try
                                    {
                                        for (int i = 0; i < this.textboxes.Length; i++)
                                        {
                                            int convert = int.Parse(textboxes[i].Text.ToString().Trim());
                                            if (textToInt <= convert && textToInt != -1){
                                                selektor = i;
                                                break;
                                            }
                                        }
                                    }catch{ MessageBox.Show("Convert Exception"); }

                                    Result tmp = r.Copy;
                                    if (selektor > -1)
                                    {
                                        tmp.AliasId = r.AliasId;
                                        tmp.UserID = r.UserID;
                                        tmp.SelectedAnswer = selektor;
                                        targetResults.Add(tmp);
                                    }

                                }//end foreach Result
                                break;
                            }
                        }//end foreach Question
                        targetResultsArray[targetResultsArrayCounter] = targetResults;
                        targetResults = new ArrayList();  
                        targetResultsArrayCounter++;
                        progressBar1.PerformStep();
                    }//end foreach TargetData

                    for (int i = 0; i < targetResultsArray.Length; i++)
                    {
                        ArrayList list = targetResultsArray[i];
                        MessageBox.Show(list.Count.ToString());
                        //newQuestion.Results = list;
                        //eval.Targets[i].AddQuestion(newQuestion);
                        if (QuestionList.Items.Count > 0)
                        {
                            Question q = (Question)QuestionList.Items[QuestionList.Items.Count - 1];
                            //newQuestion.ID = q.ID + 1;
                        }

                        //eval.QuestionConvert.Add(newQuestion);
                        //QuestionList.Items.Add(newQuestion);
                    }//end foreach

                    QuestionList.Refresh();
                    Step3.Enabled = false;

                }
            }//end try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
            }//end catch

        }

        private void createQuestion_Click(object sender, EventArgs e)
        {
            string[] rows = null;
            string rowstext = "";
            try{
                if (selectedQuestion != null)
                {
                    try
                    {
                        rows = textBoxColumnName.Text.Split(';');
                        if (rows.Length >= hashtable.Count)
                        {
                            for (int i = 0; i < hashtable.Count;i++ )
                            {
                                rowstext += rows[i] + ";";
                            }
                            rowstext=rowstext.Substring(0, rowstext.Length - 1);
                        }
                        progressBar1.Minimum = 0;
                        progressBar1.Value = 1;
                        progressBar1.Maximum = eval.Targets.Length;
                        progressBar1.Step = 1;
                    }
                    catch
                    {
                        MessageBox.Show("Keine Ergebnisse für die Frage "+selectedQuestion.ID);
                        return;
                    }

                    ArrayList newResults = new ArrayList();
                    String x = "";
                    
                    int counter = 0;

                    string bereiche = "";
                    for (int i = 0; i < this.hashtable.Count-1; i++)
                        bereiche += this.hashtable[i+1] + ";";
                    
                    bereiche += this.hashtable[this.hashtable.Count];

                    newResults = new ArrayList();
                    ArrayList Targetlist = new ArrayList();

                    foreach (TargetData t in eval.Targets)   
                    {
                        foreach (Question q in t.Questions)
                        {
                            if (q.ID == selectedQuestion.ID)
                            {
                                ArrayList list = q.Results;
                                foreach (Result r in list)
                                {
                                    int textToInt = 0;
                                    try
                                    {
                                        textToInt = int.Parse(r.TextAnswer.ToString().Trim());
                                    }
                                    catch
                                    {
                                        textToInt = -1;
                                    }
                                    int selektor = -1;

                                    try
                                    {
                                        for (int i = 0; i < this.textboxes.Length; i++)
                                        {
                                            int convert = int.Parse(textboxes[i].Text.ToString().Trim());
                                            if (textToInt <= convert && textToInt != -1)
                                            {
                                                selektor = i;
                                                break;
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.StackTrace);
                                    }

                                    Result tmp = r.Copy;
                                    if (selektor > -1)
                                    {

                                        tmp.AliasId = r.AliasId;
                                        tmp.UserID = r.UserID;
                                        tmp.SelectedAnswer = selektor;
                                        newResults.Add(tmp);
                                        Targetlist.Add(tmp);
                                    }
           
                                }
                                q.Results = Targetlist;
                            }
                        }//end foreach 2nd
                        Targetlist = new ArrayList();
                        progressBar1.PerformStep();
                    }//end foreach 1st
                    
                    selectedQuestion.Answers = rowstext;
                    selectedQuestion.Display = "radio";
                    selectedQuestion.Results = newResults;
                    
                    eval.Global.GetQuestionById(selectedQuestion.ID).Results = newResults;
                    eval.Global.GetQuestionById(selectedQuestion.ID).Display = "radio";
                    eval.Global.GetQuestionById(selectedQuestion.ID).Answers = rowstext;
                    eval.QuestionConvert.Add(selectedQuestion);
                    QuestionList.Items.Add(selectedQuestion);
                    QuestionList.Refresh();
                    Step3.Enabled = false;
                }
            }//end try
            catch(Exception ex){
                MessageBox.Show(ex.Message+"\n"+ex.StackTrace);
            }//end catch
                
            }

        private void button2_Click(object sender, EventArgs e)
        {
            eval.QuestionConvert.Remove((Question)QuestionList.SelectedItem);
            QuestionList.Items.Remove(QuestionList.SelectedItem);
            QuestionList.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            umfrage2._2008.Dialogs.QuestionDetails.ShowStats((Question)QuestionList.SelectedItem, eval);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Step2_2.Enabled = true;
            Step2.Enabled = false;
            Step2_1.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Step2_2.Enabled = false;
            Step3.Enabled = true;
        }//end erstellenClick  


        
    }
}
