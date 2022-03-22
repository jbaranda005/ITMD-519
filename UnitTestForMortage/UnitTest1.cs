using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortgageHelperLibrary;

namespace UnitTestForMortgage
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMortagage()
        {
            var result = MortgageCalcHelper.ComputeMonthlyPayment(1000, 15, 5);
            Assert.AreEqual(7.91, result);

        }
            
    }
}
