using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.Calculation.Tests;
using Compucare.Enquire.Common.Calculation.Texts.TopFlop.Wizard;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using NUnit.Framework;

namespace Compucare.Enquire.Common.Calculation.Texts.Tests.TopFlop
{
    [TestFixture]
    public class WizardTest : BaseWizardTest
    {
        [Test]
        public void ShowWizard()
        {
            TopFlopWizard wizard = new TopFlopWizard(new Evaluation());
            wizard.ShowDialog();
        }
    }
}
