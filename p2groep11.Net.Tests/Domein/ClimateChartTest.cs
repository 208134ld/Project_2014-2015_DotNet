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
        private ClimateChart chart;

        [TestInitialize]
        public void init()
        {
            temps = new int[] {10,12,12,14,15,20,28,32,28,16,6,2};
            sed = new[] {120, 145, 200, 120, 150, 100, 140, 40, 100, 120, 130, 100};
            context = new DummyDataContext();
            chart = new ClimateChart("Gent", 1961, 1990, temps, sed, 51.054342, 3.717424);
        }

        [TestMethod]
        public void CalculateMaxGivesMax()
        {
            Assert.AreEqual(200,chart.CalculateMaxForChart());
        }
        [TestMethod]
        public void CalculateMinGivesMin()
        {
            Assert.AreEqual(2, chart.CalculateMinForChart());
        }
        [TestMethod]
        public void ConstructorMakesAClimateChartWithMonthList()
        {
            Assert.AreEqual(12,chart.Months.Count);
        }

        [TestMethod]
        public void ConstructorMakesAClimateChartWithFirstMonthJan()
        {
            Assert.AreEqual(MonthsOfTheYear.Jan,chart.Months[0].MonthProp);
        }

        [TestMethod]
        public void ConstructorMakesAClimateChartWithLastMonthDec()
        {
            Assert.AreEqual(MonthsOfTheYear.Dec,chart.Months[chart.Months.Count-1].MonthProp);
        }

        [ExpectedException(typeof (ArgumentException))]
        [TestMethod]
        public void ArrayTempSmallerThan12WillThrowException()
        {
            temps = new int[] { 10, 12, 12, 14, 15, 20, 28, 32, 28, 16, 6};
            chart = new ClimateChart("Gent", 1961, 1990, temps, sed, 51.054342, 3.717424);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ArraySedSmallerThan12WillThrowException()
        {
            sed = new int[] { 10, 12, 12, 14, 15, 20, 28, 32, 28, 16, 6 };
            chart = new ClimateChart("Gent", 1961, 1990, temps, sed, 51.054342, 3.717424);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ArrayTempBiggerThan12WillThrowException()
        {
            temps = new int[] { 10, 12, 12, 14, 15, 20, 28, 32, 28, 16, 6 ,15,30};
            chart = new ClimateChart("Gent", 1961, 1990, temps, sed, 51.054342, 3.717424);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ArraySedBiggerThan12WillThrowException()
        {
            sed = new int[] { 10, 12, 12, 14, 15, 20, 28, 32, 28, 16, 6,15,30 };
            chart = new ClimateChart("Gent", 1961, 1990, temps, sed, 51.054342, 3.717424);
        }

        [ExpectedException(typeof (ArgumentException))]
        public void SedimentHaveToBeGreaterThan0()
        {
            sed = new int[] { 10, 12, 12, 14, 15, 20, 28, 32, 28, 16, 6,-15};
            chart = new ClimateChart("Gent", 1961, 1990, temps, sed, 51.054342, 3.717424);
        }

        [TestMethod]
        public void MonthsAbove10DegreeGivesRightAmountOfMonthes()
        {
            ClimateChart c = context.Gent;
            Assert.AreEqual(3,c.MonthsAbove10Degree);
        }

        [TestMethod]
        public void MonthsAbove10DegreeGivesRightAmountWithNegativValueInChart()
        {
            ClimateChart c = context.NegTempClimateChart;
            Assert.AreEqual(3,c.MonthsAbove10Degree);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void NegativeSedementsGivesException()
        {
            int[] temp = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int[] sed = new int[] { 10, 20, 30, -20, 50, 60, 70, 80, 90, 100, 110, 120 };
            ClimateChart c = new ClimateChart("Chelsea",2000,2010,temp,sed, -20, 10);

        }

        [TestMethod]
        public void RainInWinterUnderEqGivesCorrectAmount()
        {
            ClimateChart c = context.NegTempClimateChart;
            Assert.AreEqual(390,c.RainInWinter);
        }
        [TestMethod]
        public void RainInSummerCalculatesRainAboveEq()
        {
            ClimateChart c = context.Gent;
            Assert.AreEqual(480,c.RainInSummer);
        }

        [TestMethod]
        public void RainInSummerCalculatesRainUnderEq()
        {
            ClimateChart c = context.NegTempClimateChart;
            Assert.AreEqual(390, c.RainInSummer);
        }

        [TestMethod]
        public void EmptyCtrSerialisedMonthsList()
        {
            ClimateChart c = new ClimateChart();
            c.Months.Add(new Month(MonthsOfTheYear.Apr, 10,12));
            Assert.AreEqual(12,c.Months[0].Sediment);
        }
    }
}
