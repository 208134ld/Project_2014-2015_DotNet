using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Tests.Domein
{
    [TestClass]
    public class DeterminateTableTest
    {

        private int[] temps;
        private int[] sed;
        private DeterminateTable dTable;
        private ClimateChart chart;

        [TestInitialize]
        public void init()
        {
            temps = new int[] { 10, 12, 12, 14, 15, 20, 28, 32, 28, 16, 6, 2 };
            sed = new[] { 120, 145, 200, 120, 150, 100, 140, 40, 100, 120, 130, 100 };
            chart = new ClimateChart("Gent", 1990, 1991, temps, sed);
            dTable = new DeterminateTable();
        }

        [TestMethod]
        public void DeterminateReturnsString()
        {
            Assert.AreNotEqual(true, System.String.IsNullOrEmpty(dTable.Determinate(chart)));
        }

        [TestMethod]
        public void DeterminateReturnsCorrectSolution()
        {
            Assert.AreEqual("Klimaatkenmerk: Warmgematigd altijd nat klimaat. Vegetatiekenmerk: Subtropisch regenwoudklimaat.", dTable.Determinate(chart));
        }
    }
}
