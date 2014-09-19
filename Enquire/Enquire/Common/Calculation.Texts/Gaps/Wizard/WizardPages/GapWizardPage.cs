using System;
using System.Collections.Generic;
using Compucare.Enquire.Common.Controls.DataItems;
using Compucare.Enquire.Common.DataModule.Settings;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Wizards;
using umfrage2;

namespace Compucare.Enquire.Common.Calculation.Texts.Gaps.Wizard.WizardPages
{
    public class GapWizardPage : BaseWizardPage
    {
        private readonly GapWizardPageControl _control;
        private readonly Evaluation _eval;

        private readonly SingleQuestionSelectorCrossing _q1Selector;
        private readonly SingleQuestionSelectorCrossing _q2Selector;

        public Double Precision
        {
            get { return (Double)_control._precision.Value; }
        }

        public String Type
        {
            get { return (String)_control._resultTypeSelector.SelectedItem.ToString(); }
            set { }
        }

        public GapWizardPage(Evaluation eval)
        {
            _control = new GapWizardPageControl();
            _eval = eval;

            _q1Selector = new SingleQuestionSelectorCrossing(_control._qSelect1, eval.Global, eval);
            _q2Selector = new SingleQuestionSelectorCrossing(_control._qSelect2, eval.Global, eval);

            PageControl = _control;

            Header = "Gap options";
            Description = "Choose the questions and user groups you want to compare.";
            _control._resultTypeSelector.SelectedIndex = 0;
            Type = _control._resultTypeSelector.SelectedItem.ToString();
        }

        public override void Initialise()
        {
            _q1Selector.LoadItems(_eval);
            _q2Selector.LoadItems(_eval);
        }

        public override void Validate()
        {
            if (!_q1Selector.Validate()) throw new WizardValidationException("Settings for Question 1 are invalid");
            if (!_q2Selector.Validate()) throw new WizardValidationException("Settings for Question 2 are invalid");
        }

        public List<QuestionDataItem> GetItems()
        {
            return new List<QuestionDataItem> {_q1Selector.GetDataItem(), _q2Selector.GetDataItem()};
        }
    }
}
