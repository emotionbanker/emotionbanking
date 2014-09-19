using Compucare.Enquire.Common.Controls.DataItems;
using Compucare.Enquire.Common.DataModule.Settings;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Graphics.Benchmarking.Wizard.WizardPages
{
    public class BenchmarkWizardPage : BaseWizardPage
    {
        private readonly Evaluation _eval;
        private readonly TargetData _targetData;
        private readonly SingleQuestionSelectorCrossing _crossingnSelector;
        private readonly SingleQuestionSelector _questionSelector;

        private readonly BenchmarkWizardPageControl _control;


        public BenchmarkWizardPage(Evaluation eval, TargetData targetData)
        {
            _eval = eval;
            _targetData = targetData;
            _control = new BenchmarkWizardPageControl();
            
            Header = "Benchmark settings";
            Description = "Choose the benchmark you want to create.";

            PageControl = _control;
            _crossingnSelector = new SingleQuestionSelectorCrossing(_control._crossingControl, _targetData, _eval);
            _questionSelector = new SingleQuestionSelector(_control._selectQ);

        }

        public override void Initialise()
        {
            _questionSelector.LoadItems(_eval);
            _crossingnSelector.LoadItems(_eval);
        }

        public override void Validate()
        {
            if (_control._comparativePanel.Visible)
            {
                if (!_crossingnSelector.Validate()) throw new WizardValidationException("Comparison settings are invalid");
            } 
            else
            {
                if (!_questionSelector.Validate()) throw new WizardValidationException("Question settings are invalid");
            }
        }

        public QuestionDataItem GetItem()
        {
            return _questionSelector.GetDataItem();
        }

        public QuestionDataItem GetSeparatorItem()
        {
            return _crossingnSelector.GetDataItem();
        }

        public void SetType(BenchmarkingType type)
        {
            _control._comparativePanel.Visible = type == BenchmarkingType.Comparative;
        }
    }
}
