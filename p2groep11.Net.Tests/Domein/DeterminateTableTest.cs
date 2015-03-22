using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2groep11.Net.Models.Domain;
using p2groep11.Net.Tests.Controllers;

namespace p2groep11.Net.Tests.Domein
{
    [TestClass]
    public class DeterminateTableTest
    {

        private DummyDataContext context;
        
        [TestInitialize]
        public void init()
        {
            context = new DummyDataContext();
        }

        [TestMethod]
        public void DeterminateReturnsString()
        {
            Assert.AreNotEqual(true, System.String.IsNullOrEmpty(context.dTable.Determinate(context.chart)[0]));
        }

        [TestMethod]
        public void DeterminateReturnsCorrectSolution()
        {
            Assert.AreEqual("Warmgematigd altijd nat klimaat", context.dTable.Determinate(context.chart)[0]);
            Assert.AreEqual("Subtropisch regenwoudklimaat", context.dTable.Determinate(context.chart)[1]);
            Assert.AreEqual("Gematigd altijd droog klimaat", context.dTable.Determinate(context.chart2)[0]);
            Assert.AreEqual("Woestijnklimaat van de middelbreedten", context.dTable.Determinate(context.chart2)[1]);
            Assert.AreEqual("Warmgematigd altijd nat klimaat", context.dTable.Determinate(context.chart3)[0]);
            Assert.AreEqual("Subtropisch regenwoudklimaat", context.dTable.Determinate(context.chart3)[1]);
            Assert.AreEqual("Warmgematigd klimaat met natte winter", context.dTable.Determinate(context.chart4)[0]);
            Assert.AreEqual("Hardbladige-vegetatieklimaat van de subtropen", context.dTable.Determinate(context.chart4)[1]);
        }

        [TestMethod]
        public void GetHtmlTest()
        {
            DeterminateTable det = context.dTable;
            String html =det.AllClauseComponents.ElementAt(det.AllClauseComponents.Count-1).GetHtmlCode(true);
            Assert.AreEqual(3185,html.Length);
        }

        [TestMethod]
        public void GetHtmlTestReverseTreeNode()
        {
            DeterminateTable det = context.dTable;
            String html = det.AllClauseComponents.ElementAt(det.AllClauseComponents.Count - 1).GetHtmlCode(false);
            Assert.AreEqual(3188, html.Length);
        }

        [TestMethod]
        public void TestCorrectPath()
        {
            DeterminateTable det = context.dTable;
            List <ClauseComponent> lijst = det.CorrectPath(context.Gent);
            Assert.AreEqual(lijst[lijst.Count-1].ClauseComponentId,0);
        }

    }
}
