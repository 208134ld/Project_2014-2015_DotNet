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
        public void SetGradeTo3()
        {
            schoolYear.Grade = 3;
            Assert.AreEqual(3, schoolYear.Grade);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Graad moet tussen 1 en 3 liggen")]
        public void GradeCanNotBeLowerThan1()
        {
            schoolYear.Grade = 0;
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException), "Graad moet tussen 1 en 3 liggen")]
        public void GradeCanNotBeHigherThan3()      
        {
            schoolYear.Grade = 5;
        }

        [TestMethod]
        public void CalculateGradeGeeftCorrecteGraad()
        {
            schoolYear.Year = 1;
            Assert.AreEqual( schoolYear.Grade = 1, schoolYear.CalculateGrade());
            schoolYear.Year = 2;
            Assert.AreEqual( schoolYear.Grade = 1, schoolYear.CalculateGrade());
            schoolYear.Year = 3;
            Assert.AreEqual( schoolYear.Grade = 2, schoolYear.CalculateGrade());
            schoolYear.Year = 4;
            Assert.AreEqual( schoolYear.Grade = 2, schoolYear.CalculateGrade());
            schoolYear.Year = 5;
            Assert.AreEqual( schoolYear.Grade = 3, schoolYear.CalculateGrade());
            schoolYear.Year = 6;
            Assert.AreEqual( schoolYear.Grade = 3, schoolYear.CalculateGrade());
        }
   }
}
