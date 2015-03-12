using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2groep11.Net.Models;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Tests.Domein
{
    [TestClass]
    public class MonthTest
    {
        [TestMethod]
        public void ConstructorSetsVariables()
        {
            Month m = new Month(MonthsOfTheYear.Apr, 3,4);
            Assert.AreEqual(MonthsOfTheYear.Apr,m.MonthProp);
        }
        [TestMethod]
        public void EmptyConstructorDoesNothing()
        {
            Month m = new Month();
            m.MonthProp = MonthsOfTheYear.Apr;
            Assert.AreEqual(MonthsOfTheYear.Apr,m.MonthProp);
            
        }
   }
}
