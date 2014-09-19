using System;
using System.Windows.Forms;
using Compucare.Enquire.Common.Controls.DataItems;
using Compucare.Enquire.Common.Controls.Utils;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Wizards;
using compucare.Enquire.Legacy.Umfrage2Lib.Dialogs;

namespace Compucare.Enquire.Common.Calculation.Texts.TopFlop.Wizard.WizardPages
{
    public class TopFlopSettingsWizardPage : BaseWizardPage
    {
        private readonly Evaluation _eval;
        private readonly TopFlopSettingsWizardPageControl _control;
        private readonly DropDownTextBoxController _usergController;
        private readonly DropDownTextBoxController _usergGapController;
        private readonly TargetData _td;
        
        public Int32 NumResults
        {
            get { return (Int32)_control._numSpinner.Value; }
        }

        public ResultOrdering ResultOrdering
        {
            get
            {
                if (_control._radioTop.Checked) return ResultOrdering.Highest;
                return ResultOrdering.Lowest;
            }
        }

        public ResultType ResultType
        {
            get
            {
                if (_control._radioAvg.Checked) return ResultType.Averages;
                return ResultType.Gaps;
            }
        }

        public QuestionTopFlop QuestionTopFlop
        {
            get
            {
                if(_control._radioAllQuestion.Checked){
                    return QuestionTopFlop.All;
                    
                }else{
                    return QuestionTopFlop.Select;
                    
                }
            }
        }

        public ResultSorting ResultSorting
        {
            get
            {
                if (_control._radioCurrentOnly.Checked) return ResultSorting.CurrentOnly;
                if (_control._radioCurrent.Checked) return ResultSorting.Current;
                if (_control._radioHistoric.Checked) return ResultSorting.Historic;
                return ResultSorting.Change;
            }
        }

        public HistoricData History
        {
            get { return _control._historySelector.SelectedItem as HistoricData; }
        }

        internal PersonSetting UserGroup
        {
            get { return _usergController.SelectedItem.Value as PersonSetting; }
        }

        internal PersonSetting GapUserGroup
        {
            get { return _usergGapController.SelectedItem != null ? _usergGapController.SelectedItem.Value as PersonSetting : null; }
        }

        public TopFlopSettingsWizardPage(Evaluation eval)
        {
            _eval = eval;
            _control = new TopFlopSettingsWizardPageControl();
            _td = new TargetData();
            PageControl = _control;

            Header = "Top/Flop Table Settings";
            Description = "Choose the type of top/flop table to be included.";

            _usergController = new DropDownTextBoxController(_control._personBox);
            _usergController.Images = new ImageList();
            _usergController.Images.Images.Add(Pictures.system_users_4);

            _usergGapController = new DropDownTextBoxController(_control._gapPersonBox);
            _usergGapController.Images = new ImageList();
            _usergGapController.Images.Images.Add(Pictures.system_users_4);

            _control._radioGap.CheckedChanged += RadioGapCheckedChanged;
            RadioGapCheckedChanged(null, null);

            //Samet
            _control._radioSelectQuestion.CheckedChanged += RadioSelectCheckedChanged;
            RadioSelectCheckedChanged(null,null);
            
            //Samet
            
             _control.buttonSelectQuestion.Click += buttonSelectQuestion_Click;
              //buttonSelectQuestion_Click(null, null);
           
        }

        ~TopFlopSettingsWizardPage()
        {
             _control.buttonSelectQuestion.Click -= buttonSelectQuestion_Click;
             // buttonSelectQuestion_Click(null, null);
        }

        private void RadioGapCheckedChanged(object sender, EventArgs e)
        {
            _control._gapLabel.Visible = _control._gapPersonBox.Visible = _control._radioGap.Checked;
        }

        public void RadioSelectCheckedChanged(object sender, EventArgs e)
        {
            _control.buttonSelectQuestion.Enabled = _control._radioSelectQuestion.Checked;
        }

        private void buttonSelectQuestion_Click(object sender, EventArgs e)
        {
            QuestionSelect qs = new QuestionSelect(_eval);
            Question[] selectedQuestions = null;
            int count = 0;
            if (qs.ShowDialog() == DialogResult.OK)
            {
                selectedQuestions = new Question[qs.SelectedQuestions.Length];
                foreach (Question q in qs.SelectedQuestions)
                {
                    selectedQuestions[count] = q;
                    count++;
                }
            }
            _td.setSelectedQuestions(selectedQuestions);
        }

        public override void Initialise()
        {
            if (_eval.History.Length > 0)
            {
                foreach (HistoricData data in _eval.History)
                {
                    _control._historySelector.Items.Add(data);
                }
            }
            else
            {
                _control._historySelector.Enabled = false;
                _control._radioCurrent.Enabled = false;
                _control._radioHistoric.Enabled = false;
                _control._radioChange.Enabled = false;
            }

            foreach (PersonSetting ps in _eval.CombinedPersons)
            {
                _usergController.AddItem(new DropDownTextBoxPerson(ps));
                _usergGapController.AddItem(new DropDownTextBoxPerson(ps));
            }
        }

        public override void Validate()
        {
            if (_usergController.SelectedItem == null)
            {
                throw new WizardValidationException("No user group selected");
            }

            if (ResultType == ResultType.Gaps && _usergGapController.SelectedItem == null)
            {
                throw new WizardValidationException("No gap user group selected");
                
            }
        }//end Validate
    }
}
