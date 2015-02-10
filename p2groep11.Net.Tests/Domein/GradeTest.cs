using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void setGraadSetsGraadl()
        {
            grade.Graad = 1;
            Assert.AreEqual(1,grade.Graad);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Graad moet tussen 1 en 3 liggen")]
        public void graadKanNiet0zijn()
        {
            grade.Graad = 0;
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException), "Graad moet tussen 1 en 3 liggen")]
        public void graadKanNiet4Zijn()
        {
            grade.Graad = 4;
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException), "Graad mag niet null zijn")]
        public void graadKanNietNullZijn()
        {
            grade.Graad = null;
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException), "Graad moet tussen 1 en 3 liggen")]
        public void graadKanNietGroterZijnDan3()
        {
            grade.Graad = 1200;
        }

        [TestMethod]
        public void setFormSetsFormIfGradeIs2()
        {
            grade.Graad = 2;
            grade.Form = Form.EersteLeerjaar;
            Assert.AreEqual(Form.EersteLeerjaar,grade.Form);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException), "Grade.form throws exception als graad niet=2")]
        public void setFormThrowsExceptionWhenNot2()
        {
            grade.Graad = 1;
            grade.Form = Form.EersteLeerjaar;
        }
    }
}
