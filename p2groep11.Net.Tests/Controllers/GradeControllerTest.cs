using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using p2groep11.Net.Controllers;
using p2groep11.Net.Models;

namespace p2groep11.Net.Tests.Controllers
{
    [TestClass]
    public class GradeControllerTest
    {
        private GradeController controller;
        private Mock<IStudentRepository> mockStudentenRepository;
        private dummyContext dummy = new dummyContext();
        private Student student;
        [TestInitialize]
        public void Init()
        {
            student = new Student("Jos", "Swagger");
            mockStudentenRepository = new Mock<IStudentRepository>();
            mockStudentenRepository.Setup(s => s.FindById(1)).Returns(student);
            controller = new GradeController(mockStudentenRepository.Object);
        }
        [TestMethod]
        public void GradeFormSearchesForLoggedInStudent()
        {
            Schoolyear g = new Schoolyear();
            g.Number = 1;
            ViewResult result = controller.GradeForm(new GradeFormViewModel(g),1) as ViewResult;
            mockStudentenRepository.Verify(m=>m.FindById(1),Times.Once);
        }


    }
}
