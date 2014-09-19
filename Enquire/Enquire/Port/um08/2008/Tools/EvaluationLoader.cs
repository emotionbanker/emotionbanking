using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using Compucare.Enquire.Common.Tools.Logging;
using compucare.Enquire.Legacy.Umfrage2Lib.Output;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using log4net;
using Compucare.Enquire.Legacy.Umfrage2Lib.SystemExtensions;

namespace umfrage2._2008.Tools
{
    public class EvaluationLoader
    {
        private readonly ILog _logger = LogHelper.GetLogger();
        
        private string filename;
        public Evaluation eval;
        private MultipartStatus status;
        

        public void LoadFrom(string filename, MultipartStatus status)
        {
            this.filename = filename;
            this.status = status;

            status.TitleBox.Text = "Daten werden geladen";

            Thread loadThread = new Thread(this.LoadThread);
            loadThread.Start();
        }

        public void LoadFromSimple(string filename)
        {
            this.filename = filename;
            this.status = new MultipartStatus();

            LoadThread();
        }

        private void ReloadOutputQuestions()
        {
            status.MultiBar.Value = 0;
            
            status.SingleBar.Visible = false;
            status.MarqueeBar.Visible = true;
            
            status.MarqueeBar.Value = 0;

            int max = 0;

            if (eval.Reports != null)
            {
                foreach (Report r in eval.Reports)
                    max += r.Outputs.Length;

                status.MultiBar.Maximum = max;

                foreach (Report r in eval.Reports)
                    foreach (Output o in r.Outputs)
                    {
                        if (o != null) o.LoadGlobalQ();
                        status.MultiBar.Value++;
                    }
            }
        }  

        private void LoadThread()
        {
            status.goBox1.Visible = status.goBox2.Visible = status.goBox3.Visible = false;
            status.kayBox1.Visible = status.kayBox2.Visible = status.kayBox3.Visible = false;

            status.SingleBar.Visible = false;
            string Data = Path.GetDirectoryName(filename) + "\\" + Path.GetFileNameWithoutExtension(filename) + " data\\";

            if (!Directory.Exists(Data))
            {
                status.TargetLabel.Text = "Altes Format. Bitte Warten.";
                status.CurrentTarget.Visible =
                    status.MultiBar.Visible =
                    status.SingleBar.Visible =
                    status.label3.Visible = false;

            }

            
            status.goBox1.Visible = true;
            status.MainLabel.Text = "lade...";

            //load um3
            eval = Evaluation.Deserialize(filename);

            status.MainLabel.Text = "abgeschlossen";
            status.goBox1.Visible = false;
            status.kayBox1.Visible = true;


            status.MarqueeBar.Visible = false;
            status.SingleBar.Visible = true;

            //set questions
            if (eval.GlobalQ != null)
            {
                foreach (TargetData td in eval.Targets)
                {
                    td.Questions = eval.CloneGlobalQ();
                }
            }

            if (Directory.Exists(Data))
            {
                _logger.Debug("Loading data.");
                //load data!
                status.TargetLabel.Text = "lade...";
                status.goBox2.Visible = true;

                //1. load index

                BinaryReader brx = new BinaryReader(File.OpenRead(Data + "index"));
                int total = brx.ReadInt32();
                bool aliasMode = false;
                try
                {
                    aliasMode = brx.ReadBoolean();
                }
                catch (Exception)
                {
                    aliasMode = false;
                }
                brx.Close();

                _logger.DebugFormat("Total: {0}", total);
                _logger.DebugFormat("Alias mode: {0}", aliasMode);

                status.MultiBar.Minimum = 0;
                status.MultiBar.Maximum = total;

                int speeder = 0;

                //2. result data
                foreach (TargetData td in eval.Targets)
                {
                    status.CurrentTarget.Text = td.Name;
                    BinaryReader br = new BinaryReader(File.OpenRead(Data + td.iD));

                    int counter = br.ReadInt32();
                    status.SingleBar.Minimum = 0;
                    status.SingleBar.Maximum = counter;
                    status.SingleBar.Value = 0;

                    int imax = br.ReadInt32();
                    for (int i = 0; i < imax; i++)
                    {
                        int id = br.ReadInt32();
                        Question q = td.GetQuestionById(id);

                        int jmax = br.ReadInt32();
                        for (int j = 0; j < jmax; j++)
                        {
                            Result r = Result.CreateEmpty();
                            r.SelectedAnswer = br.ReadInt32();
                            r.TextAnswer = br.ReadString();
                            r.UserID = br.ReadInt32();
                            if (aliasMode)
                            {
                                r.AliasId = br.ReadInt32();
                            }

                            if (q != null)
                            {
                                q.Results.Add(r);
                            }

                            speeder++;

                            if (speeder % 100 == 0)
                            {
                                status.MultiBar.Increment(100);
                                status.SingleBar.Increment(100);
                            }
                        }
                    }

                    br.Close();
                }
            }

            /*string temp = "";
            foreach (TargetData td in eval.CombinedTargets)
                temp += td.name + "\n";

            MessageBox.Show(temp);*/
            //compute splits
            eval.ComputeTargetSplits(eval);

            //clean up
            eval.FileName = filename;

            //rest
            status.CurrentTarget.Text = "";

            status.MultiBar.Value = status.MultiBar.Maximum = 1;
            status.SingleBar.Value = status.SingleBar.Maximum = 1;

            status.TargetLabel.Text = "abgeschlossen";
            status.goBox2.Visible = false;
            status.kayBox2.Visible = true;

            status.goBox3.Visible = true;
            status.InitLabel.Text = "lade...";

            ReloadOutputQuestions();

            status.SingleBar.Value = status.MultiBar.Value = status.SingleBar.Maximum = status.MultiBar.Maximum = 1;

            status.CurrentTarget.Text = "";

            status.TargetLabel.Text = "abgeschlossen";

            status.goBox3.Visible = false;
            status.kayBox3.Visible = true;

            status.MarqueeBar.Visible = false;
            status.SingleBar.Visible = true;

            status.InitLabel.Text = "Berechne Kombinationen/Teilungen...";

            eval.InvalidateCombos();

            try
            {
                eval.ComputeTargetSplits(eval);
            }
            catch
            {

            }

            

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
                }
            }//end for*/

            EvaluationSaver save = new EvaluationSaver(eval);
            save.SaveThreadBefore();

            status.InitLabel.Text = "abgeschlossen";

            /*foreach (TargetData td in eval.CombinedTargets)
                td.Debug(eval);*/

            status.Continue();


        }
    }
}
