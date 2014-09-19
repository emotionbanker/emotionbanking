using System.Windows.Forms;
using Compucare.Enquire.Common.Controls.DataItems;
using compucare.Enquire.Legacy.Umfrage2Lib.Controls;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Texts.CsvExport.Wizard.WizardPages
{
    public class CsvWizardPage : BaseWizardPage
    {
        private readonly Evaluation _eval;
        private readonly CsvWizardPageControl _control;

        private readonly ChooseTargetControl _ctc;

        private readonly SingleQuestionSelector _selector;

        public CsvWizardPage(Evaluation eval)
        {
            _eval = eval;
            _control = new CsvWizardPageControl();
            PageControl = _control;

            Header = "Select Export Settings";
            Description = "Choose the data to be exported.";

            _ctc = new ChooseTargetControl(eval, true, false);
            _ctc.Dock = DockStyle.Fill;
            _control._chooseTargetPanel.Controls.Add(_ctc);

            _selector = new SingleQuestionSelector(_control._questionSelector);
        }

        public override void Initialise()
        {
            _selector.LoadItems(_eval);
        }

        public override void Validate()
        {
            base.Validate();
            if (!_selector.Validate())
            {
                throw new WizardValidationException("Question/Person settings invalid");
            }
        }

        public PersonSetting SelectedPerson
        {
            get
            {
                return _selector.GetDataItem().Persons[0];
            }
        }

        public TargetData[] SelectedTargets
        {
            get { return _ctc.SelectedTargets; }
        }

        public int SelectedSplitter
        {
            get { return _selector.GetDataItem().QuestionId; }
        }

    }
}
