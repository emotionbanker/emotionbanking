using System;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark.Wizard.WizardPages
{
    public enum ExclamationType
    {
        Single,
        Comparison,
        Gap,

        None
    }

    public enum ResultType
    {
        Average,
        Nps,
        Percent
    }

    public class ExclamationTypeWizardPage : BaseWizardPage
    {
        private readonly ExclamationTypeWizardPageControl _control;       

        public ExclamationType Type
        {
            get
            {
                if (_control._radioSingle.Checked) return ExclamationType.Single;
                if (_control._radioAdvanced.Checked) return ExclamationType.Comparison;
                if (_control._radioGapAdvanced.Checked) return ExclamationType.Gap;

                return ExclamationType.None;
            }
        }

        public ResultType ResultType
        {
            get 
            { 
                return (ResultType)Enum.Parse(typeof (ResultType), (String)_control._resultTypeSelector.SelectedItem); 
            }
        }

        public ExclamationTypeWizardPage(IndicatorGraphics graphicsType)
        {
            _control = new ExclamationTypeWizardPageControl();


            PageControl = _control;

            if (graphicsType == IndicatorGraphics.ExclamationMark)
            {
                Header = "Select Exclamation Mark Type";
                Description = "Choose the type of exclamation mark graphic to be included.";
            }
            else if (graphicsType == IndicatorGraphics.TrafficLight)
            {
                Header = "Select Traffic Light Type";
                Description = "Choose the type of traffic light graphic to be included.";
            }

            _control._resultTypeSelector.Items.AddRange(Enum.GetNames(typeof (ResultType)));
            _control._resultTypeSelector.SelectedItem = Enum.GetName(typeof (ResultType), ResultType.Average);
        }

        public override void Validate()
        {
            if (!_control._radioSingle.Checked && 
                !_control._radioAdvanced.Checked &&
                !_control._radioGapAdvanced.Checked)
            {
                throw new WizardValidationException("A type must be selected.");
            }

            /*if (_control._radioGapAdvanced.Checked && 
                (String)_control._resultTypeSelector.SelectedItem != Enum.GetName(typeof(ResultType), ResultType.Average))*/
            if (_control._radioGapAdvanced.Checked &&
                (String)_control._resultTypeSelector.SelectedItem == Enum.GetName(typeof(ResultType), ResultType.Nps) )
            
            {
                throw new WizardValidationException("Only average values are allowed for GAPs.");
            }
        }
    }
}
