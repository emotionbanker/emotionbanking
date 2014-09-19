using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compucare.Enquire.Common.Calculation.Texts.MatrixCrossings.Wizard;
using NUnit.Framework;

namespace Compucare.Enquire.Common.Calculation.Texts.Tests.MatrixCrossing
{
    [TestFixture]
    public class WizardTest
    {
        [Test]
        public void RunWizard()
        {
            MatrixCrossingWizard wiz = new MatrixCrossingWizard(null);
            wiz.ShowDialog();
        }
    }
}
    