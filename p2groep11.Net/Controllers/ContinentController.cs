using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep11.Net.Models;
using p2groep11.Net.Models.DAL;
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

        public ActionResult ListContinents(int SelectedYear)
        {
            ViewBag.SchoolYear = SelectedYear;
            ContinentsListViewModel model = new ContinentsListViewModel
            {
                Continents = repository.FindAll()
            };
             
            return View(model);
        }

        public ActionResult ListCountries(int SelectedYear, int continentId, string search)
        {
            ViewBag.SchoolYear = SelectedYear;
            IEnumerable<Country> countryList = repository.FindCountriesByContinentID(continentId);
            if (!String.IsNullOrEmpty(search))
            {
                countryList = repository.FindCountriesByContinentID(continentId).Where(c => c.Name.ToLower().Contains(search.ToLower()));
            };

            CountryListViewModel model = new CountryListViewModel
            {
                Countries = countryList
            };

            return View(model);
        }

        public ActionResult ListLocations(int SelectedYear, int continentId, int countryId, string search)
        {
            ViewBag.SchoolYear = SelectedYear;
            IEnumerable<ClimateChart> locationList = repository.FindLocationsByCountryID(continentId, countryId);
            if (!String.IsNullOrEmpty(search))
            {
                locationList = repository.FindLocationsByCountryID(continentId, countryId)
                    .Where(c => c.Location.ToLower().Contains(search));
            };

            LocationListViewModel locationListViewModel = new LocationListViewModel
            {
                Locations = locationList
            };

            if (!locationListViewModel.Locations.Any())
            {
                TempData["Error"] = "Er zijn geen locaties gevonden voor dit land.";
                return RedirectToAction("ListCountries", new{SelectedYear, continentId});

            }
            return View(locationListViewModel);
        }

    }
}