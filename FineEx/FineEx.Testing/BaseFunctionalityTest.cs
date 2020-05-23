using System;
using FineEx.DataLayer.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FineEx.Testing
{
    [TestClass]
    public class BaseFunctionalityTest
    {
        [TestMethod]
        public void GivenNumber1_ThenCompareNumbers_WhenNumberEqual()
        {
            Assert.AreEqual(1, 1);
        }
    }
}
