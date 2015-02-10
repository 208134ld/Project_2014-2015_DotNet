using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace p2groep11.Net.Tests.Controllers
{
    [TestClass]
    public class GradeControllerTest
    {
        private GradeController controller;
        private Mock<IStudentenRepository> mockStudentenRepository;
        private dummyContext dummy = new dummyContext();
        private Student student;
        [TestInitialize]
        public void Init()
        {
            student = new Student("Jos","Swagger");
            mockStudentenRepository = new Mock<IStudentenRepository>();
            mockStudentenRepository.Setup(s => s.FindById(1)).returns(student);
            controller = new GradeController(mockStudentenRepository.Object);
        }
        [TestMethod]
        public void KiesGradeReturnsgradeKiesView()
        {
           
        }

        [TestMethod]
        public void KiesGradeHaaltJuistStudentOp()
        {
            
        }
        [TestMethod]
       
    }
}
