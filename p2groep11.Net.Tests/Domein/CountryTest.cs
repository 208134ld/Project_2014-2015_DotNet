using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2groep11.Net.Models.Domain;
using p2groep11.Net.Tests.Controllers;

namespace p2groep11.Net.Tests.Domein
{
    [TestClass]
    public class CountryTest
    {
        private DummyDataContext context;
        [TestInitialize]
        public void TestMethod1()
        {
            context = new DummyDataContext();
        }

        [TestMethod]
        public void GetClimateChartGetsClimateChart()
        {
            Country c = context.Belgium;
            ClimateChart climate = c.GetClimateChart(1);
            Assert.AreEqual(context.Gent,climate);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ThrowsExceptionWhenChartNotFound()
        {
            Country c = context.Belgium;
            ClimateChart climate = c.GetClimateChart(0); 
            
        }
    }
}
