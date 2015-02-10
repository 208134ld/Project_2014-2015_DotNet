using System;
using System.CodeDom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2groep11.Net.Models;

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
            student.Firstname = "Franske";
            Assert.AreEqual("Franske",student.Firstname);
        }

        [TestMethod]
        public void propNaamSetsNaam()
        {
            student.Lastname = "Van Mechelen";
            Assert.AreEqual("Van Mechelen", student.Lastname);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "firstname mag niet null zijn")]
        public void NaamThrowsExceptionWhenNull()
        {
            student.Lastname = null;
        }
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "lastname mag niet null zijn")]
        public void voornaamThrowsExceptionWhenNull()
        {
            student.Firstname = null;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "firstname mag niet leeg zijn")]
        public void NaamThrowsExceptionWhenEmpty()
        {
            student.Lastname = "";
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "lastname mag niet leeg zijn")]
        public void VoornaamThrowsExceptionWhenEmpty()
        {
            student.Lastname = "";
        }

        [TestMethod]
        public void setGraadSetsGrade()
        {
            Grade g = new Grade();
            student.Grade = g;
            Assert.AreEqual(g, student.Grade);
        }

    }
}
