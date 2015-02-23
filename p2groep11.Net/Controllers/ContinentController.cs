using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep11.Net.Models;
using p2groep11.Net.Models.Domain;
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

        public ViewResult ListCountries(int grade, int continentId, string search)
        {
            ViewBag.Grade = grade;
            IEnumerable<Country> countryList = repository.FindCountriesByContinentID(continentId);
            if (!String.IsNullOrEmpty(search))
            {
                countryList = repository.FindCountriesByContinentID(continentId).Where(c => c.Name.ToLower().Contains(search));
            };

            CountryListViewModel model = new CountryListViewModel
            {
                Countries = countryList
            };

            return View(model);
        }

        public ViewResult ListLocations(int grade, int continentId, int countryId, string search)
        {
            ViewBag.Grade = grade;
            IEnumerable<ClimateChart> locationList = repository.FindLocationsByCountryID(1, 1);
            if (!String.IsNullOrEmpty(search))
            {
                locationList = repository.FindLocationsByCountryID(continentId, countryId)
                    .Where(c => c.Location.ToLower().Contains(search));
            };

            LocationListViewModel model = new LocationListViewModel
            {
                Locations = locationList
            };

            return View(model);
        }

    }
}