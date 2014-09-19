using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Frontends.Common.Wizards;

namespace Compucare.Enquire.Common.Calculation.Texts.Gaps.Wizard.WizardPages
{
    public enum GapType
    {
        Text,
        TrafficLight,
        ExclamationMark
    }

    public class GapTypeWizardPage : BaseWizardPage
    {
        private readonly GapTypeWizardPageControl _control;

        public GapTypeWizardPage()
        {
            _control = new GapTypeWizardPageControl();

            PageControl = _control;

            Header = "Select Gap Type";
            Description = "Choose the type of gap or gap graphic to be included.";
        }
    }
}
