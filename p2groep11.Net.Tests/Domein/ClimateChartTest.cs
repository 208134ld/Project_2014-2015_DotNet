using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Tests.Domein
{
    [TestClass]
    public class ClimateChartTest
    {
        private int[] temps;
        private int[] sed;

        [TestInitialize]
        public void init()
        {
            temps = new int[] {10,12,12,14,15,20,28,32,28,16,6,2};
            sed = new[] {120, 145, 200, 120, 150, 100, 140, 40, 100, 120, 130, 100};
        }

        [TestMethod]
        public void CalculateMaxGivesMax()
        {
            ClimateChart chart = new ClimateChart("Gent", 1990, 1991, temps, sed);
            Assert.AreEqual(200,chart.CalculateMaxForChart());
        }
        [TestMethod]
        public void CalculateMinGivesMin()
        {
            ClimateChart chart = new ClimateChart("Gent", 1990, 1991, temps, sed);
            Assert.AreEqual(2, chart.CalculateMinForChart());
        }
        [TestMethod]
        public void ConstructorMakesAClimateChartWithMonthList()
        {
            ClimateChart chart = new ClimateChart("Gent",1990,1991,temps,sed);
            Assert.AreEqual(12,chart.Months.Count);
        }

        [TestMethod]
        public void ConstructorMakesAClimateChartWithFirstMonthJan()
        {
            ClimateChart chart = new ClimateChart("Gent", 1990, 1991, temps, sed);
            Assert.AreEqual(MonthsOfTheYear.Jan,chart.Months[0].MonthProp);
        }

        [TestMethod]
        public void ConstructorMakesAClimateChartWithLastMonthDec()
        {
            ClimateChart chart = new ClimateChart("Gent", 1990, 1991, temps, sed);
            Assert.AreEqual(MonthsOfTheYear.Dec,chart.Months[chart.Months.Count-1].MonthProp);
        }

        [ExpectedException(typeof (ArgumentException))]
        [TestMethod]
        public void ArrayTempSmallerThan12WillThrowException()
        {
            temps = new int[] { 10, 12, 12, 14, 15, 20, 28, 32, 28, 16, 6};
            ClimateChart chart = new ClimateChart("Gent", 1990, 1991, temps, sed);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ArraySedSmallerThan12WillThrowException()
        {
            sed = new int[] { 10, 12, 12, 14, 15, 20, 28, 32, 28, 16, 6 };
            ClimateChart chart = new ClimateChart("Gent", 1990, 1991, temps, sed);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ArrayTempBiggerThan12WillThrowException()
        {
            temps = new int[] { 10, 12, 12, 14, 15, 20, 28, 32, 28, 16, 6 ,15,30};
            ClimateChart chart = new ClimateChart("Gent", 1990, 1991, temps, sed);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ArraySedBiggerThan12WillThrowException()
        {
            sed = new int[] { 10, 12, 12, 14, 15, 20, 28, 32, 28, 16, 6,15,30 };
            ClimateChart chart = new ClimateChart("Gent", 1990, 1991, temps, sed);
        }
    }
}
