using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2groep11.Net.Models;

namespace p2groep11.Net.Tests.Domein
{
    [TestClass]
    public class SchoolYearTest
    {
        private SchoolYear grade;
        [TestInitialize]
       public void InitSchoolYearTest()
        {    
            grade = new SchoolYear();
        }
        [TestMethod]
       public void SetGraadSetsGraadl()        {
            grade.Number = 1;
            Assert.AreEqual(1,grade.Number);
        }
        [TestMethod]
        public void SetGraadSetsGraad6()
        {
            grade.Number = 6;
            Assert.AreEqual(6, grade.Number);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Graad moet tussen 1 en 6 liggen")]
        public void GraadKanNiet0zijn()
        {
            grade.Number = 0;
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException), "Graad moet tussen 1 en 3 liggen")]
        public void GraadKanNiet7Zijn()
        {
            grade.Number = 7;
        }
        [TestMethod]
        [ExpectedException(typeof (ArgumentException), "Graad moet tussen 1 en 3 liggen")]
        public void GraadKanNietGroterZijnDan6()        {
            grade.Number= 1200;
        }

        [TestMethod]
        public void CalculateGradeGeeftCorrecteGraad()
        {
            grade.Number = 1;
            Assert.AreEqual(1, grade.CalculateGrade());
            grade.Number = 2;
            Assert.AreEqual(1, grade.CalculateGrade());
            grade.Number = 3;
            Assert.AreEqual(2, grade.CalculateGrade());
            grade.Number = 4;
            Assert.AreEqual(2, grade.CalculateGrade());
            grade.Number = 5;
            Assert.AreEqual(3, grade.CalculateGrade());
            grade.Number = 6;
            Assert.AreEqual(3, grade.CalculateGrade());
        }
   }
}
