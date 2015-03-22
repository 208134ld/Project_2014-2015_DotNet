using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class ContinentControllerTest
    {
        private ContinentController continentController;
        private Mock<IGradeRepository> gradeRepository;
        private DummyDataContext context;

        [TestInitialize]
        public void Initialize()
        {
            context = new DummyDataContext();
            gradeRepository = new Mock<IGradeRepository>();
            gradeRepository.Setup(m => m.FindBySchoolyear(1)).Returns(context.Graad);
            continentController = new ContinentController(gradeRepository.Object);
        }

        [TestMethod]
        public void SelectAContinentRedirectToListCountries()
        {

            ContinentsListViewModel model = new ContinentsListViewModel(new Continent("België"));
            RedirectToRouteResult result = continentController.ListContinents(1) as RedirectToRouteResult;
            Assert.AreEqual("ListCountries", result.RouteValues["Action"]);
        }

        [TestMethod]
        public void SelectACountryRedirectToListlocations()
        {

            CountryListViewModel model = new CountryListViewModel();
            RedirectToRouteResult result = continentController.ListCountries(1, 1, "") as RedirectToRouteResult;
            Assert.AreEqual("ListCountries", result.RouteValues["Action"]);
        }

        //[TestMethod]
        //public void SelectALocationRedirectToShowExercises()
        //{

        //    LocationListViewModel model = new LocationListViewModel();
        //    RedirectToRouteResult result = continentController.ListLocations(1) as RedirectToRouteResult;
        //    Assert.AreEqual("ListLocations", result.RouteValues["Action"]);
        //}
    }
}
