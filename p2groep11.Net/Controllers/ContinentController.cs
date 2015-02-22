using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep11.Net.Models;
using p2groep11.Net.ViewModels;

namespace p2groep11.Net.Controllers
{
    public class ContinentController : Controller
    {
        private IContinentRepository repository;

        public ContinentController(IContinentRepository continentRepository)
        {
            repository = continentRepository;
        }

        public ViewResult ListContinents(int grade)
        {
            ViewBag.Grade = grade;
            ContinentsListViewModel model = new ContinentsListViewModel
            {
                Continents = repository.FindAll()
            };
             
            return View(model);
        }

        public ViewResult ListCountries(int grade, int continentId)
        {
            //ViewBag.Grade = grade;
            //CountryListViewModel model = new CountryListViewModel
            //{
            //    Countries = repository.FindCountryByID(continentId)
            //};

            //return View(model);
            return View();
        }

    }
}