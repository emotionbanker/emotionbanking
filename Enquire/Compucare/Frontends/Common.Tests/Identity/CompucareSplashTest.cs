using System;
using System.Threading;
using Compucare.Frontends.Common.Command;
using Compucare.Frontends.Common.Identity;
using NUnit.Framework;
using System.Drawing;
using System.Collections.Generic;


namespace Compucare.Frontends.Common.Tests.Identity
{
    [TestFixture]
    public class CompucareSplashTest
    {
        [Test, Explicit]
        public void ManualTest()
        {
            CompucareSplashController.ShowSplash("Suite", "Name", "2005-2011", "",
                new CommandController(), new WaitCommand(10), new Image[0]);
        }
    }
}
