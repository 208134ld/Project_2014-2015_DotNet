using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2groep11.Net.Models;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Tests.Domein
{
    [TestClass]
    public class SchoolYearTest
    {
        private SchoolYear schoolYear;

        [TestInitialize]
        public void InitSchoolYearTest()
        {
            schoolYear = new SchoolYear();
        }

        [TestMethod]
        public void SetSchoolYearTo1()        
        {
            schoolYear.Year = 1;
            Assert.AreEqual(1,schoolYear.Year);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Jaar moet tussen 1 en 6 liggen")]
        public void YearCanNotBeLowerThan1()
        {
            schoolYear.Year = 0;
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException), "Jaar moet tussen 1 en 6 liggen")]
        public void YearCanNotBeHigherThan6()
        {
            schoolYear.Year = 7;
        }

        [TestMethod]
        public void ConstructorSchoolyearCreatesNewSchoolyear()
        {
            SchoolYear s = new SchoolYear(2);
            Assert.AreEqual(2,s.Year);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorSchoolyearThrowsExceptionWhenGreaterThan6()
        {
            SchoolYear s = new SchoolYear(7);
        }
   }
}
