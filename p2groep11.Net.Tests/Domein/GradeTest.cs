using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Tests.Domein
{
    [TestClass]
    public class GradeTest
    {
        private Grade grade;

        [TestInitialize]
        public void InitGradeTest()
        {
            grade = new Grade();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Graad moet tussen 1 en 3 liggen")]
        public void YearCanNotBeLowerThan1()
        {
            grade.GradeInt = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Graad moet tussen 1 en 3 liggen")]
        public void YearCanNotBeHigherThan3()
        {
            grade.GradeInt = 5;
        }

        [TestMethod]
        public void CalculateGradeGivesCorrectGrade()
        {
            SchoolYear schoolYear = new SchoolYear();
            schoolYear.Year = 1;
            Assert.AreEqual(1, grade.CalculateGrade(schoolYear.Year));
            schoolYear.Year = 2;
            Assert.AreEqual(1, grade.CalculateGrade(schoolYear.Year));
            schoolYear.Year = 3;
            Assert.AreEqual(2, grade.CalculateGrade(schoolYear.Year));
            schoolYear.Year = 4;
            Assert.AreEqual(2, grade.CalculateGrade(schoolYear.Year));
            schoolYear.Year = 5;
            Assert.AreEqual(3, grade.CalculateGrade(schoolYear.Year));
            schoolYear.Year = 6;
            Assert.AreEqual(3, grade.CalculateGrade(schoolYear.Year));
        }
    }
}
