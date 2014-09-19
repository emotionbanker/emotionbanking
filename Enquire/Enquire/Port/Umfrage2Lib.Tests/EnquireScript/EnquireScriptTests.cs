using NUnit.Framework;

namespace Compucare.Enquire.Legacy.Umfrage2Lib.Tests.EnquireScript
{
    [TestFixture]
    public class EnquireScriptTests
    {
        private Script.EnquireScript _script;

        [TestFixtureSetUp]
        public void SetUp()
        {
            _script = new Script.EnquireScript(null, null);
        }

        [Test]
        public void TestSimple()
        {
            Assert.AreEqual("4", _script.Evaluate("2 + 2"));
        }

        [Test]
        public void TestMath()
        {
            Assert.AreEqual("3", _script.Evaluate("Round(Pi)"));
        }

        [Test]
        public void TestDivisionByZero()
        {
            string val = _script.Evaluate("2/0");

            Assert.AreEqual(Script.EnquireScript.NA, val);
        }
    }
}
