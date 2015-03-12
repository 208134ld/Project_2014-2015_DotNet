using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2groep11.Net.Models.Domain;
using p2groep11.Net.Tests.Controllers;

namespace p2groep11.Net.Tests.Domein
{
    [TestClass]
    public class ClimateChartTest
    {
        private int[] temps;
        private int[] sed;
        private DummyDataContext context;
        [TestInitialize]
        public void init()
        {
            temps = new int[] {10,12,12,14,15,20,28,32,28,16,6,2};
            sed = new[] {120, 145, 200, 120, 150, 100, 140, 40, 100, 120, 130, 100};
            context = new DummyDataContext();
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

        [ExpectedException(typeof (ArgumentException))]
        public void SedimentHaveToBeGreaterThan0()
        {
            sed = new int[] { 10, 12, 12, 14, 15, 20, 28, 32, 28, 16, 6,-15};
            ClimateChart chart = new ClimateChart("Gent",1990,1991,temps,sed);
        }

        [TestMethod]
        public void MonthsAbove10DegreeGivesRightAmountOfMonthes()
        {
            ClimateChart c = context.Gent;
            Assert.AreEqual(2,c.MonthsAbove10Degree);
        }

        [TestMethod]
        public void MonthsAbove10DegreeGivesRightAmountWithNegativValueInChart()
        {
            ClimateChart c = context.NegTempClimateChart;
            Assert.AreEqual(3,c.MonthsAbove10Degree);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void NegativSedementsGivesException()
        {
            int[] temp = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int[] sed = new int[] { 10, 20, 30, -20, 50, 60, 70, 80, 90, 100, 110, 120 };
            ClimateChart c = new ClimateChart("chelsea",2000,2010,temp,sed);

        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void RainInSummerCalculatesRainAboveEq()
        {
            ClimateChart c = context.Gent;
            Assert.AreEqual(490,c.RainInSummer);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void RainInSummerCalculatesRainUnderEq()
        {
            ClimateChart c = context.NegTempClimateChart;
            Assert.AreEqual(390, c.RainInSummer);
        }
    }
}
