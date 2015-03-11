using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using p2groep11.Net.Controllers;
using p2groep11.Net.Models.DAL;
using p2groep11.Net.Models.Domain;
using p2groep11.Net.ViewModels;

namespace p2groep11.Net.Tests.Controllers
{
    [TestClass]
    public class SchoolYearControllerTest
    {
        private SchoolYearController controller;
        private Mock<GradeRepository> repo;
        private DummyDataContext context;
        [TestInitialize]
        public void Init()
        {
            context = new DummyDataContext();
            repo = new Mock<GradeRepository>();
            repo.Setup(m => m.FindById(1)).Returns(context.Graad);
            controller = new SchoolYearController(repo.Object);
            
           
        }
        [TestMethod]
        public void SelectASchoolYearPostRedirectToListContinents()
        {

            SchoolYearFormViewModel model = new SchoolYearFormViewModel(new List<SelectListItem>()) { SelectedYear = 1 };
            RedirectToRouteResult result = controller.Index(1) as RedirectToRouteResult;
            Assert.AreEqual("ListCountries", result.RouteValues["Action"]);
        }

        [TestMethod]
        public void ErrorInSchoolYearPostPassesTheModel()
        {
            controller.ModelState.AddModelError("key", "error");
            ViewResult result = controller.Index(1) as ViewResult;
            SchoolYearFormViewModel yearVM = result.Model as SchoolYearFormViewModel;
            Assert.AreEqual(0, yearVM.SelectedYear);
        }
    }
}
