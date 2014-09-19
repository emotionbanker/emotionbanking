using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Frontends.Common.Wizards;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using Compucare.Enquire.Common.Controls.DataItems;
using Compucare.Enquire.Common.DataModule.Settings;

using Compucare.Enquire.Common.Calculation.Texts.Benchmarking.Wizard.WizardPages;
using Compucare.Enquire.Common.Calculation.Graphics.Benchmarking.Wizard.WizardPages;
using System.Windows.Forms;

namespace Compucare.Enquire.Common.Calculation.Texts.Benchmarking.Wizard.WizardPages
{
    public class BenchmarkValueWizardPage : BaseWizardPage
    {
        private readonly Evaluation _eval;
        private readonly QuestionDataItem _qditem;
        private readonly TargetData _targetData;
        private readonly SingleQuestionSelectorCrossing _crossingnSelector;
        private readonly SingleQuestionSelector _questionSelector;
        

        private readonly BenchmarkWizardPageControl _control;

        public BenchmarkValueWizardPage(Evaluation eval, TargetData targetData)
        {
            _eval = eval;
            _targetData = targetData;
            _control = new BenchmarkWizardPageControl();
            AddListeners();
            Header = "Benchmark settings";
            Description = "Choose the benchmark you want to create.";
            _qditem = new QuestionDataItem();
            _qditem.setValueIndex(0);
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

        void AddListeners()
        {
            _control._btn_bestValue.CheckedChanged += best_SelectedValueChanged;
            _control._btn_worstValue.CheckedChanged += worst_SelectedValueChanged;
            _control._btn_downValue.CheckedChanged += own_SelectedValueChanged;
            _control._btn_averageValue.CheckedChanged += average_SelectedValueChanged;
        }



        void best_SelectedValueChanged(object sender, EventArgs e)
        {
            _qditem.setValueIndex(1);
        }

        void worst_SelectedValueChanged(object sender, EventArgs e)
        {
            _qditem.setValueIndex(2);
        }

        void own_SelectedValueChanged(object sender, EventArgs e)
        {
            _qditem.setValueIndex(3);
        }

        void average_SelectedValueChanged(object sender, EventArgs e)
        {
            _qditem.setValueIndex(4);
        }

    }
}
