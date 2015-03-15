using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2groep11.Net.Models.Domain;
using p2groep11.Net.Tests.Controllers;

namespace p2groep11.Net.Tests.Domein
{
    [TestClass]
    public class ContinentTest
    {
        private DummyDataContext context;
        [TestInitialize]
        public void init()
        {
            context = new DummyDataContext();
        }
        [TestMethod]
        public void EmptyConstructorInitCountryList()
        {
            Continent c = new Continent();
            c.Countries.Add(context.Belgium);
            Assert.AreEqual(1,c.Countries.Count);
        }

        [TestMethod]
        public void ConstructorSetsNameAndInitList()
        {
            Continent c = new Continent("Europa");
            c.Countries.Add(context.Belgium);
            Assert.AreEqual("Europa",c.Name);
        }

        [TestMethod]
        public void GetCountryGetsCountry()
        {
            Continent c = context.Europa;
            Country co = c.getCountry(1);
            Assert.AreEqual(co,context.Belgium);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetCountryThrowsExceptionWhenNotFound()
        {
            Continent c = context.Europa;
            Country co = c.getCountry(0);
            
        }

    }
}
