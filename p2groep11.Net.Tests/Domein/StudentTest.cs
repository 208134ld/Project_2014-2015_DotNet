using System;
using System.CodeDom;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p2groep11.Net.Tests.Domein
{
    [TestClass]
    public class StudentTest
    {
        private Student student;
        [TestInitialize]
        public void initStudentTest()
        {
            student = new Student();
        }

        [TestMethod]
        public void propVoornaamSetsVoornaam()
        {
            student.Voornaam = "Franske";
            Assert.AreEqual("Franske",student.Voornaam);
        }

        [TestMethod]
        public void propNaamSetsNaam()
        {
            student.Naam = "Van Mechelen";
            Assert.AreEqual("Van Mechelen", student.Naam);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException), "firstname mag niet null zijn")]
        public void NaamThrowsExceptionWhenNull()
        {
            student.Naam = null;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "lastname mag niet null zijn")]
        public void voornaamThrowsExceptionWhenNull()
        {
            student.Voornaam = null;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "firstname mag niet leeg zijn")]
        public void NaamThrowsExceptionWhenEmpty()
        {
            student.Naam = "";
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "lastname mag niet leeg zijn")]
        public void VoornaamThrowsExceptionWhenEmpty()
        {
            student.Naam = "";
        }

        [TestMethod]
        public void setGraadSetsGrade()
        {
           Grade g = new Grade();
            student.Grade = g;
            Assert.AreEqual(g,student.Grade);
        }

    }
}
