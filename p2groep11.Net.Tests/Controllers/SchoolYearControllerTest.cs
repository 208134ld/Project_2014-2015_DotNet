using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2groep11.Net.Controllers;
using p2groep11.Net.Models.Domain;
using p2groep11.Net.ViewModels;

namespace p2groep11.Net.Tests.Controllers
{
    [TestClass]
    public class SchoolYearControllerTest
    {
        private SchoolYearController controller;
        private List<SelectListItem> years;
        [TestInitialize]
        public void Init()
        {
            controller = new SchoolYearController();
            years = new List<SelectListItem>();
            years.Add(new SelectListItem { Value = "1", Text = "1ste Leerjaar" });
            for (int i = 2; i < 7; i++)
            {
                years.Add(new SelectListItem { Value = i + "", Text = i + "de Leerjaar" });
            }
        }
        //[TestMethod]
        //public void SelectASchoolYearPostRedirectToListContinents()
        //{
            
        //    SchoolYearFormViewModel model = new SchoolYearFormViewModel(years) {SelectedYear = 1};
        //    RedirectToRouteResult result =  controller.SchoolYearForm(model) as RedirectToRouteResult;
        //    Assert.AreEqual("ListContinents",result.RouteValues["Action"]);
        //}

        [TestMethod]
        public void ErrorInSchoolYearPostPassesTheModel()
        {
            controller.ModelState.AddModelError("key", "error");
            SchoolYearFormViewModel model = new SchoolYearFormViewModel(years) { SelectedYear = 1 };
            ViewResult result = controller.SchoolYearForm(model) as ViewResult;
            SchoolYearFormViewModel yearVM = result.Model as SchoolYearFormViewModel;
            Assert.AreEqual(1, yearVM.SelectedYear);
        }
    }
}
