using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2groep11.Net.Models.Domain;
using p2groep11.Net.Tests.Controllers;

namespace p2groep11.Net.Tests.Domein
{
    [TestClass]
    public class ClauseComponentTest
    {
        [TestInitialize]
        public void init()
        {

        }
        [TestMethod]
        public void ClauseEmptyCtr()
        {
            Clause c = new Clause();
        }

        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void ResultAddGivesException()
        {
            ClauseComponent r = new Result();
            ClauseComponent r2 = new Result();

            r.Add(true, r2);
        }
    }
}
