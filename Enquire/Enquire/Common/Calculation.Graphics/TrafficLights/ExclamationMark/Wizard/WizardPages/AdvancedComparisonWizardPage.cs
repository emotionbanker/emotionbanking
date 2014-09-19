using System;
using System.Collections.Generic;
using Compucare.Enquire.Common.Controls.DataItems;
using Compucare.Enquire.Common.DataModule.Settings;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark.Wizard.WizardPages
{
    public class AdvancedComparisonWizardPage : BaseWizardPage
    {
        private readonly AdvancedComparisonWizardPageControl _control;
        private readonly Evaluation _eval;

        private readonly SingleQuestionSelectorCrossing _q1Selector;
        private readonly SingleQuestionSelectorCrossing _q2Selector;

        public Boolean EnablePrecision
        {
            get { return _control._precisionPanel.Visible; }
            set { _control._precisionPanel.Visible = value; }
        }

        public Double Precision
        {
            get { return (Double)_control._precision.Value; }
        }

        public Boolean EnableQuestion2
        {
            get { return _control._selectQ2.Visible; }
            set { _control._selectQ2.Visible = value; }
        }

        public AdvancedComparisonWizardPage(Evaluation eval)
        {
            _control = new AdvancedComparisonWizardPageControl();
            _eval = eval;

            _q1Selector = new SingleQuestionSelectorCrossing(_control._selectQ1, eval.Global, eval);
            _q2Selector = new SingleQuestionSelectorCrossing(_control._selectQ2, eval.Global, eval);

            PageControl = _control;

            Header = "Advanced comparison options";
            Description = "Choose the questions you want to compare.";
        }

        public override void Initialise()
        {
            _q1Selector.LoadItems(_eval);
            _q2Selector.LoadItems(_eval);
        }

        public override void Validate()
        {
            if (!_q1Selector.Validate()) throw new WizardValidationException("Settings for Question 1 are invalid");
            if (EnableQuestion2 && !_q2Selector.Validate()) throw new WizardValidationException("Settings for Question 2 are invalid");
        }

        public List<QuestionDataItem> GetItems()
        {
            List<QuestionDataItem> items = new List<QuestionDataItem>();

            try
            {
                items.Add(_q1Selector.GetDataItem());
                items.Add(_q2Selector.GetDataItem());
            }
            catch (Exception)
            {
            }

            return items;
        }
    }
}
