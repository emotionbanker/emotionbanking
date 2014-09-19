using System.Windows.Forms;
using Compucare.Enquire.Common.Calculation.Graphics.TrafficLights.ExclamationMark.Wizard;
using compucare.Enquire.Legacy.Umfrage2Lib.System;
using NUnit.Framework;

namespace Compucare.Enquire.Common.Calculation.Graphics.Tests.TrafficLights.ExclamationMark
{
    [TestFixture]
    public class WizardTest
    {
        [TestFixtureSetUp]
        public void SetUp()
        {
            Application.EnableVisualStyles();
        }

        [Test]
        public void RunTest()
        {
            ExclamationMarkWizard wiz = new ExclamationMarkWizard(new Evaluation(), false, IndicatorGraphics.ExclamationMark);

            wiz.ShowDialog();
        }
    }
}
