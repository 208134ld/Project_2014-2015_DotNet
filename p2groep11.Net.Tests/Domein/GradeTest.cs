using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2groep11.Net.Models.Domain;
using p2groep11.Net.Tests.Controllers;

namespace p2groep11.Net.Tests.Domein
{
    [TestClass]
    public class GradeTest
    {
        private Grade grade;
        private DummyDataContext context;
        [TestInitialize]
        public void InitGradeTest()
        {
            grade = new Grade(1);
            context = new DummyDataContext();
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
        public void gradeConstructorInitGrade()
        {
            Grade g = new Grade();
            g.GradeId = 2;
            Assert.AreEqual(2,g.GradeId);
        }

        [TestMethod]
        public void GetContinentGetsContinent()
        {
            Grade graad = context.Graad;
            Assert.AreEqual(graad.GetContinent(1),context.Europa);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void GetContinentThrowExceptionWhenNothingFound()
        {
            Grade graad = context.Graad;
            graad.GetContinent(0);
        }
    }
}
