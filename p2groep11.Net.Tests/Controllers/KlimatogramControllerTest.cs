using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using p2groep11.Net.Controllers;
using p2groep11.Net.Models;
using p2groep11.Net.Models.Domain;
using p2groep11.Net.ViewModels;


namespace p2groep11.Net.Tests.Controllers
{
    //[TestClass]
    //public class ReservatieControllerTest
    //{
    //    private KlimatogramController controller;
    //    private Mock<IContinentRepository> continentRepository;

    //    private Continent continent;
    //    private KlimatogramViewModel model;
    //    private DummyDataContext context;

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        context = new DummyDataContext();
    //        continentRepository = new Mock<IContinentRepository>();
    //        continentRepository.Setup(c => c.FindById(1)).Returns(context.Europa);
    //        continent = context.Europa;
    //        controller = new KlimatogramController(continentRepository.Object);

    //        model = new KlimatogramViewModel(controller.GetContinents(), controller.GetCountrys(),
    //            controller.GetLocations());

    //    }

    //    [TestMethod]
    //    public void ChoosingKlimatogramReturnsModel()
    //    {
    //        ViewResult result = controller.ChooseKlimatogram() as ViewResult;
    //        KlimatogramViewModel kModel = result.Model as KlimatogramViewModel;
    //        Assert.AreEqual(context.Continenten, kModel.Continents);
    //    }
    //}
}
