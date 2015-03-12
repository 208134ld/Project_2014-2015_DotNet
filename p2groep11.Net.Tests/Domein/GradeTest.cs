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
            grade = new Grade(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Graad moet tussen 1 en 3 liggen")]
        public void YearCanNotBeLowerThan1()
        {
            grade.GradeId = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Graad moet tussen 1 en 3 liggen")]
        public void YearCanNotBeHigherThan3()
        {
            grade.GradeId = 5;
        }

        [TestMethod]
        public void CalculateGradeGivesCorrectGrade()
        {
            grade.CalculateGrade(1);
            Assert.AreEqual(1, grade.GradeId);
            grade.CalculateGrade(2);
            Assert.AreEqual(1,grade.GradeId);
            grade.CalculateGrade(3);
            Assert.AreEqual(2,grade.GradeId);
            grade.CalculateGrade(4);
            Assert.AreEqual(2, grade.GradeId);
            grade.CalculateGrade(5);
            Assert.AreEqual(3, grade.GradeId);
            
        }

        [TestMethod]
        public void gradeConstructorInitGrade()
        {
            Grade g = new Grade();
            g.GradeId = 2;
            Assert.AreEqual(2,g.GradeId);
        }
    }
}
