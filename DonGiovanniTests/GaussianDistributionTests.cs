using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leporello;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leporello.Tests
{
    [TestClass()]
    public class GaussianDistributionTests
    {
        [TestMethod()]
        public void NormSDistInvTest()
        {
            Assert.AreEqual(GaussianDistribution.NormSDistInv(0.975), 1.96);
        }
    }
}