using System.Windows.Forms;
using Compucare.Enquire.Common.Controls.DataItems;
using NUnit.Framework;

namespace Compucare.Enquire.Common.Controls.Tests
{
    [TestFixture]
    public class SingleQuestionSelectorTests
    {
        [Test]
        public void ManualTest()
        {
            Application.EnableVisualStyles();
           
            Application.Run(new SingleControlTestForm());
        }
    }
}
