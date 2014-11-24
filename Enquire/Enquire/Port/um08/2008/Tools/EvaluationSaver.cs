using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading;
using System.IO;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using System.Windows.Forms;
using Compucare.Enquire.Legacy.Umfrage2Lib.SystemExtensions;

namespace umfrage2._2008.Tools
{
    class EvaluationSaver
    {
        private Evaluation eval;
        private string Filename;
        private MultipartStatus status;

        public EvaluationSaver(Evaluation eval)
        {
            this.eval = eval;
        }

        private void SetMultipart(bool val)
        {
            if (val) eval.SavedAs = Evaluation.SaveMethod.Multipart;
            else eval.SavedAs = Evaluation.SaveMethod.Classic;

            foreach (TargetData td in eval.Targets)
                foreach (Question q in td.Questions)
                    Question.SetMultipart(q, val);

            if (eval.Reports == null) return;
            foreach (Report r in eval.Reports)
                foreach (Output o in r.Outputs)
                    o.Multipart = val;
        }

        public void SaveTo(string filename, MultipartStatus status)
        {
            this.Filename = filename;
            this.status = status;

            status.TitleBox.Text = "Daten werden gespeichert";

            Thread SaveThread = new Thread(new ThreadStart(this.SaveThread));
            SaveThread.Start();
        }

        private int getTotal()
        {
            int c = 0;
            foreach (TargetData td in eval.Targets)
                foreach (Question q in td.Questions)
                    c += q.Results.Count;

            return c;
        }


        public void SaveThreadBefore(bool remove, string targetAndQuestion)
        {
            ArrayList targetchilds = new ArrayList(); //Liste für die Kinder der Zielknoten
            ArrayList targetsAndQuestions = new ArrayList(); //Liste für Zielknoten und Splitfrage(mit dem gesplittet wird)
            TargetData[] old = eval.CombinedTargets; //alle Zielknoten werden auf "old" zugewiesen
            foreach (TargetData td in eval.CombinedTargets) //alle Zielknoten durchlaufen
            {
                if (td.WasCombo == true && !td.name.Equals("Global"))  //Wenn "Zielknoten eine Kombi" und "keine Globalknoten" ist
                {
                    foreach (TargetData tdata in td.Children)//durchlaufe alle Kinder von der kombinierten Zielknoten
                    {

                        bool exist = false;
                        TargetAndSplitQuestion temp = new TargetAndSplitQuestion(tdata.masterSplit.master, tdata.masterSplit.splitter.ID);
                        foreach (TargetAndSplitQuestion tasQ in targetsAndQuestions)
                        {
                            if (tasQ.tostring().Equals(temp.tostring()))
                            {
                                exist = true;
                                break;
                            }
                            else
                            {
                                exist = false;
                            }
                        }


                        if (exist == false)
                        {
                            targetsAndQuestions.Add(temp);
                            targetchilds.Add(td);
                        }
                    }
                }
                else if (td.masterSplit != null) //Wenn der Zielknoten ein Vaterknoten besitzt
                {
                    TargetSplit tdata = td.masterSplit;
                    if (tdata.master.masterSplit != null) 
                    {
                        bool exist = false; 
                        TargetAndSplitQuestion temp = new TargetAndSplitQuestion(td.masterSplit.master, tdata.splitter.ID);
                        foreach(TargetAndSplitQuestion tasQ in targetsAndQuestions){
                            if (tasQ.tostring().Equals(temp.tostring()))
                            {
                                exist = true;
                                break;
                            }
                            else { exist = false; }
                        }


                        if (exist==false)
                        {
                            targetsAndQuestions.Add(new TargetAndSplitQuestion(td.masterSplit.master, tdata.splitter.ID));
                            targetchilds.Add(td);
                        }
                    }//end 2nd if
                }//end 1st if
            }//end for each

            eval.TargetChilds = targetchilds;
            eval.TargetChildsParent = targetsAndQuestions;

          
        

            if(remove==true){
                int index = 0;
                foreach (TargetAndSplitQuestion tdParent in eval.TargetChildsParent)
                {
                    string t = tdParent.getTargetData().name + "_" + tdParent.getQuestionId();
                    if (t.Equals(targetAndQuestion))
                    {
                        break;
                    }
                    else
                    {
                        index++;
                    }

                   
                }
                eval.TargetChildsParent.RemoveAt(index);
            }

            TargetData[] firstData = new TargetData[1000];
            int i = 0;

            foreach (TargetData td in eval.CombinedTargets)
            { 
                try
                {
                    if (td.masterSplit != null || td.WasCombo == true && !td.name.Equals("Global"))
                    {
                        td.Children = new ArrayList();
                        td.Splits = new ArrayList();
                    }
                }
                catch
                {

                }
            }


            foreach (TargetData td in eval.CombinedTargets)
                if (!targetchilds.Contains(td))
                    firstData[i++] = td;

            TargetData[] secondData = new TargetData[i];
            for (int j = 0; j < i; j++)
                secondData[j] = firstData[i];

            //Die Zieldaten wieder in die Liste einfügen

            foreach (TargetAndSplitQuestion tdParent in eval.TargetChildsParent)
            {

                foreach (TargetData td in eval.CombinedTargets)
                {

                    if (tdParent.getTargetData().Name.Equals(td.name))
                    {
                        try
                        {
                            int id = tdParent.getQuestionId();
                            Question q = eval.Global.GetQuestionbyId(id, eval);

                            td.Splits.Add(new TargetSplit(td, q));
                            eval.ComputeTargetSplits2(eval, td.Name);
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                }//end 2nd
            }//end 1st 

            //eval.CombinedTargets = secondData;
        }

        private void SaveThread()
        {
            SaveThreadBefore(false,null);

            string Data = Path.GetDirectoryName(Filename) + "\\" + Path.GetFileNameWithoutExtension(Filename) + " data\\";

            //if (!Directory.Exists(Folder)) Directory.CreateDirectory(Folder);
            if (!Directory.Exists(Data)) Directory.CreateDirectory(Data);


            status.goBox1.Visible = status.goBox2.Visible = status.goBox3.Visible = false;
            status.kayBox1.Visible = status.kayBox2.Visible = status.kayBox3.Visible = false;

            status.label5.Visible = status.InitLabel.Visible = false;

            status.SingleBar.Visible = false;
            status.MarqueeBar.Visible = true;

            status.goBox1.Visible = true;
            status.MainLabel.Text = "speichere...";
            //save clean copy
            SetMultipart(true);
            eval.FileName = Filename; // Folder + "main.um3";
            eval.Serialize();
            SetMultipart(false);

            status.MainLabel.Text = "abgeschlossen";
            status.goBox1.Visible = false;
            status.kayBox1.Visible = true;


            status.MarqueeBar.Visible = false;
            status.SingleBar.Visible = true;

            status.goBox2.Visible = true;
            status.TargetLabel.Text = "speichere...";

            int total = getTotal();

            status.MultiBar.Maximum = total;
            status.MultiBar.Minimum = status.MultiBar.Value = 0;

            int speeder = 0;

            //save result data

            foreach (TargetData td in eval.Targets)
            {
                status.CurrentTarget.Text = td.Name;

                int counter = 0;
                foreach (Question q in td.Questions)
                    counter += q.Results.Count;

                status.SingleBar.Maximum = counter;
                status.SingleBar.Minimum = status.SingleBar.Value = 0;

                string file = Data + td.iD;


                // StreamWriter bw = new StreamWriter(File.CreateText(file));
                BinaryWriter bw = new BinaryWriter(File.OpenWrite(file));


                bw.Write(counter);
                bw.Write(td.Questions.Length);

                foreach (Question q in td.Questions)
                {
                    bw.Write(q.ID);
                    bw.Write(q.Results.Count);
                    foreach (Result r in q.Results)
                    {
                        bw.Write(r.SelectedAnswer);
                        bw.Write(r.TextAnswer);
                        bw.Write(r.UserID);
                        bw.Write(r.AliasId);

                        speeder++;

                        if (speeder % 100 == 0)
                        {
                            status.MultiBar.Increment(100);
                            status.SingleBar.Increment(100);
                        }
                    }
                }
                bw.Close();

            }

            status.MultiBar.Value = status.MultiBar.Maximum = 1;
            status.SingleBar.Value = status.SingleBar.Maximum = 1;

            BinaryWriter bwx = new BinaryWriter(File.OpenWrite(Data + "index"));
            bwx.Write(total);
            bwx.Write(true); //has alias
            bwx.Close();

            status.CurrentTarget.Text = "";
            status.goBox2.Visible = false;
            status.kayBox2.Visible = true;
            status.TargetLabel.Text = "abgeschlossen";

            status.Continue();
        }//end Metohede SaveThread

        private void SaveThreadBinary()
        {
            
            string Data = Path.GetDirectoryName(Filename) + "\\" + Path.GetFileNameWithoutExtension(Filename) + " data\\";

            //if (!Directory.Exists(Folder)) Directory.CreateDirectory(Folder);
            if (!Directory.Exists(Data)) Directory.CreateDirectory(Data);


            status.goBox1.Visible = status.goBox2.Visible = status.goBox3.Visible = false;
            status.kayBox1.Visible = status.kayBox2.Visible = status.kayBox3.Visible = false;

            status.label5.Visible = status.InitLabel.Visible = false;

            status.SingleBar.Visible = false;
            status.MarqueeBar.Visible = true;

            status.goBox1.Visible = true;
            status.MainLabel.Text = "speichere...";
            //save clean copy
            SetMultipart(true);
            eval.FileName = Filename; // Folder + "main.um3";
            eval.Serialize();
            SetMultipart(false);

            status.MainLabel.Text = "abgeschlossen";
            status.goBox1.Visible = false;
            status.kayBox1.Visible = true;


            status.MarqueeBar.Visible = false;
            status.SingleBar.Visible = true;

            status.goBox2.Visible = true;
            status.TargetLabel.Text = "speichere...";

            int total = getTotal();

            status.MultiBar.Maximum = total;
            status.MultiBar.Minimum = status.MultiBar.Value = 0;

            int speeder = 0;

            //save result data
            foreach (TargetData td in eval.Targets)
            {
                status.CurrentTarget.Text = td.Name;

                int counter = 0;
                foreach (Question q in td.Questions)
                    counter += q.Results.Count;

                status.SingleBar.Maximum = counter;
                status.SingleBar.Minimum = status.SingleBar.Value = 0;

                string file = Data + td.iD;

                BinaryWriter bw = new BinaryWriter(File.OpenWrite(file));

                bw.Write(counter);
                bw.Write(td.Questions.Length);

                foreach (Question q in td.Questions)
                {
                    bw.Write(q.ID);
                    bw.Write(q.Results.Count);
                    foreach (Result r in q.Results)
                    {
                        bw.Write(r.SelectedAnswer);
                        bw.Write(r.TextAnswer);
                        bw.Write(r.UserID);
                        bw.Write(r.AliasId);

                        speeder++;

                        if (speeder % 100 == 0)
                        {
                            status.MultiBar.Increment(100);
                            status.SingleBar.Increment(100);
                        }
                    }
                }
                bw.Close();
            }

            status.MultiBar.Value = status.MultiBar.Maximum = 1;
            status.SingleBar.Value = status.SingleBar.Maximum = 1;

            BinaryWriter bwx = new BinaryWriter(File.OpenWrite(Data + "index"));
            bwx.Write(total);
            bwx.Write(true); //has alias
            bwx.Close();

            status.CurrentTarget.Text = "";
            status.goBox2.Visible = false;
            status.kayBox2.Visible = true;
            status.TargetLabel.Text = "abgeschlossen";

            status.Continue();
        }//end Metohede SaveThread
    }
}
