namespace FrameTrappedUnitTests
{
    using System;
    using System.Diagnostics; 
    using FrameTrapped.ComboTrainer.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ComboTrainerUnitTests
    {
        [TestMethod]
        public void RunStreetFighterIVAE()
        {
            Process PR = SF4ProcessHandler.Instance.GetSF4();

            if (PR.ProcessName != "SSFIV")
            {
                Assert.Fail("The SF4ProcessHandler failed to create a SF4 process.");
            }
        }

        [TestMethod]
        public void CloseStreetFighterIVAE()
        {
            Process PR = SF4ProcessHandler.Instance.GetSF4();
            
            if (PR.ProcessName != "SSFIV")
            {
                Assert.Fail("The SF4ProcessHandler failed to create a SF4 process.");
            }

            SF4ProcessHandler.Instance.StopSF4();

            if (!PR.HasExited)
            {
                Assert.Fail("The SF4ProcessHandler failed to close the SF4 process.");
            }
        }
    }
}
