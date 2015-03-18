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
        private IGradeRepository repository;

        public ContinentController(IGradeRepository gradeRepository)
        {
            repository = gradeRepository;
        }

        public ActionResult ListContinents(int SelectedYear)
        {
           ViewBag.SchoolYear = SelectedYear;
           IEnumerable<Continent> continents = repository.FindBySchoolyear(SelectedYear).Continents;
           return View(continents.Select(co=>new ContinentsListViewModel(co)).ToList());
        }

        public ActionResult ListCountries(int selectedYear, int continentId, string search)
        {
            
            if (TempData["SelectedYear"] != null)
            {
                selectedYear = (int)TempData["SelectedYear"];
                continentId = (int)TempData["continentId"];
            }

            ViewBag.SchoolYear = selectedYear;
            ViewBag.ContinentId = continentId;
            
            IEnumerable<Country> countryList = repository.FindBySchoolyear(selectedYear).GetContinent(continentId).Countries;
            if (!String.IsNullOrEmpty(search))
            {
                countryList = repository.FindBySchoolyear(selectedYear).GetContinent(continentId).Countries.Where(c => c.Name.ToLower().Contains(search.ToLower()));
            };
            return View(countryList.Select(c=>new CountryListViewModel(c)).ToList());
        }

        public ActionResult ListLocations(int selectedYear, int continentId, int countryId, string search)
        {
            ViewBag.SchoolYear = selectedYear;
            ViewBag.ContinentId = continentId;
            ViewBag.CountryId = countryId;
            
            try
            {
                //werken met getland, navigeren door domein
                IEnumerable<ClimateChart> locationList =
                    repository.FindBySchoolyear(selectedYear)
                        .GetContinent(continentId)
                        .getCountry(countryId)
                        .ClimateCharts;
                if (!String.IsNullOrEmpty(search))
                {
                    locationList = repository.FindBySchoolyear(selectedYear)
                        .GetContinent(continentId)
                        .getCountry(countryId)
                        .ClimateCharts.Where(c => c.Location.ToLower().Contains(search));
                }

                if (!locationList.Any())
                {
                    TempData["Error"] = "Er zijn geen locaties gevonden voor dit land.";
                    return RedirectToAction("ListCountries", new {selectedYear, continentId});

                }
                return View(locationList.Select(lo => new LocationListViewModel(lo)).ToList());
            }
            catch (Exception e)
            {
                TempData["Error"] = "Er is een onverwachte fout opgetreden";
                return RedirectToAction("ListCountries", new { selectedYear, continentId });
            }
        }
    }
}