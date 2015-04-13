using System;
using Compucare.Enquire.Common.Calculation.Graphics.Common.Controls.ColorRanges;
using Compucare.Frontends.Common.Wizards;
using System.Windows.Forms;

namespace Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark.Wizard.WizardPages
{
    public class TrafficLightRangeWizardPage : BaseWizardPage
    {
        private readonly TrafficLightRangeWizardPageControl _control;

        public TripleColorRangeControl RangeControl { get; private set; }
    
        public Int32 SelectedSize { get { return _control._textSize.Int32Value; } set { _control._textSize.Int32Value = value; } }

        public String InsertString
        {
            get
            {
                String i = "" + RangeControl.ColorHigh.R + "-" + RangeControl.ColorHigh.G + "-" + RangeControl.ColorHigh.B + ":";
                i += "" + RangeControl.ColorMid.R + "-" + RangeControl.ColorMid.G + "-" + RangeControl.ColorMid.B + ":";
                i += "" + RangeControl.ColorLow.R + "-" + RangeControl.ColorLow.G + "-" + RangeControl.ColorLow.B + ":";

                i += RangeControl.RangeHigh + ":" + RangeControl.RangeMid + ":" + SelectedSize;

                return i;
            }
        }

        public TrafficLightRangeWizardPage()
        {
            _control = new TrafficLightRangeWizardPageControl();

            PageControl = _control;

            RangeControl = _control._colorRangeControl;

            Header = "Select Ranges and Colors";
            Description = "Choose the range limits and range colors.";    
        }

        public override void Validate()
        {
            if (!RangeControl.IsValid())
            {
                throw new WizardValidationException("Text ranges are invalid.");
            }
        }

        public void Preset()
        {
            double max = 0, min = 0, rHigh = 0, rLow = 0;

            max = 100;
            min = -100;
            rHigh = 4.05;
            rLow = -4.04;

            RangeControl.MaxValue = max;
            RangeControl.MinValue = min;
            RangeControl.RangeHigh = rHigh;
            RangeControl.RangeMid = rLow;

        }

        public void Preset(ExclamationType type, ResultType resultType)
        {
            double max = 0, min = 0, rHigh = 0, rLow = 0;

         
            if (type == ExclamationType.Comparison)
            {
                if (resultType == ResultType.Average)
                {
                    max = 5;
                    min = -5;
                    rHigh = 1;
                    rLow = -1;
                }
                else if (resultType == ResultType.Nps || resultType == ResultType.Percent)
                {
                    max = 100;
                    min = -100;
                    rHigh = 20;
                    rLow = 20;
                }
            }
            else if (type == ExclamationType.Gap)
            {
                if (resultType == ResultType.Average)
                {
                    max = 4;
                    min = 0;
                    rHigh = 2.5;
                    rLow = 1;
                }
                //extension Samet
                else if (resultType == ResultType.Percent)
                {
                    max = 100;
                    min = 0;
                    rHigh = 75;
                    rLow = 25;
                }
                //extension Samet
            }
            else if (type == ExclamationType.Single)
            {
                if (resultType == ResultType.Average)
                {
                    max = 5;
                    min = 1;
                    rHigh = 3.5;
                    rLow = 2;
                }
                else if (resultType == ResultType.Nps)
                {
                    max = 100;
                    min = -100;
                    rHigh = 20;
                    rLow = -20;
                }
                else if (resultType == ResultType.Percent)
                {
                    max = 100;
                    min = 0;
                    rHigh = 75;
                    rLow = 25;
                }
            }


            RangeControl.MaxValue = max;
            RangeControl.MinValue = min;
            RangeControl.RangeHigh = rHigh;
            RangeControl.RangeMid = rLow;
        }
    }
}
