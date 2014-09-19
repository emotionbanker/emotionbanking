using System.Text;
using System.Threading;
using System.Windows.Forms;
using Compucare.Enquire.Common.Calculation.Texts.CsvExport.Wizard.WizardPages;
using Compucare.Enquire.Legacy.Umfrage2Lib.circular.Calculation.Graphics.CsvExport.Wizard;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Texts.CsvExport.Wizard
{
    public class CsvWizard : BaseWizard
    {
        private readonly CsvWizardPage _page;
        private readonly Evaluation _eval;

        private ProgressIndicatorDialog _indicatorDialog;

        private string _folder = "";

        public CsvWizard(Evaluation eval)
        {
            _eval = eval;

            Text = "CSV Export Wizard";

            _page = new CsvWizardPage(_eval);
            _page.AllowFinish = true;
            AddWizardPage(_page);
        }

        protected override void OnFinish()
        {
            FolderBrowserDialog folderSelector = new FolderBrowserDialog();
            if (folderSelector.ShowDialog() == DialogResult.OK)
            {
                _folder = folderSelector.SelectedPath;
                
                _indicatorDialog = new ProgressIndicatorDialog();

                Thread t = new Thread(Process);
                t.Start();

                _indicatorDialog.ShowDialog();
            }
        }


        private void Process()
        {
            foreach (TargetData data in _page.SelectedTargets)
            {
                CreateCSV(_eval, data, _page.SelectedSplitter, _page.SelectedPerson, _folder);
            }

            _indicatorDialog.Close();
        }


        private static void CreateCSV(Evaluation eval, 
            TargetData td, 
            int splitterId, 
            PersonSetting person,
            string path)
        {
            Question splitter = td.GetQuestion(splitterId, eval);
            TargetSplit ts = new TargetSplit(td, splitter);
            TargetData[] targets = ts.ComputeSplitTarget(eval);

            foreach (TargetData target in targets)
            {
                //new file
                // Example #3: Write only some strings in an array to a file. )
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(path + @"\" + person.Short + "_" + target.CleanName.Replace("/", "_") + ".csv"))
                {
                    foreach (Question q in target.Questions)
                    {
                        StringBuilder line = new StringBuilder();
                        if (!q.IsRadio)
                        {
                            continue;
                        }

                        line.Append(q.SID).Append(";");
                        //line.Append(q.Text).Append(";");
                        line.Append(q.NAnswersByPerson(eval, person)).Append(";");

                        for (int i= 0; i < q.AnswerList.Length; i++)
                        {
                            line.Append(q.GetAnswerPercentByPerson(i, eval, person).ToString()).Append(";");
                        }

                        file.WriteLine(line.ToString());
                    }
                }
            }
        }
    }
}
