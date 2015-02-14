using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep11.Net.Models;
using p2groep11.Net.ViewModels;

namespace p2groep11.Net.Controllers
{
    public class KlimatogramController : Controller
    {

        /*
        private IContinentRepository continentRepository;
        //repositories voor landen en locaties

        public KlimatogramController(IContinentRepository continentRepository)
        {
            this.continentRepository = continentRepository;
            //rest van de repositories gelijkstellen
        }*/

        //
        // GET: /Klimatogram/
        [HttpGet]
        public ActionResult ChooseKlimatogram()
        {
            //locaties, landen en locaties uit de repository halen
            return View(new KlimatogramViewModel(GetContinents(), GetCountrys(), GetLocations()));
        }



        //voorlopig om strings in de selectlist te steken
        private List<SelectListItem> GetContinents()
        {
            List<SelectListItem> continentList = new List<SelectListItem>();
            continentList.Add(new SelectListItem { Value = "1", Text = "1ste Continent" });
            for (int i = 2; i < 5; i++)
            {
                continentList.Add(new SelectListItem { Value = i + "", Text = i + "de Continent" });
            }
            return continentList;
        }

        private List<SelectListItem> GetCountrys()
        {
            List<SelectListItem> countryList = new List<SelectListItem>();
            countryList.Add(new SelectListItem { Value = "1", Text = "1ste Land" });
            for (int i = 2; i < 10; i++)
            {
                countryList.Add(new SelectListItem { Value = i + "", Text = i + "de Land" });
            }
            return countryList;
        }

        private List<SelectListItem> GetLocations()
        {
            List<SelectListItem> locationList = new List<SelectListItem>();
            locationList.Add(new SelectListItem { Value = "1", Text = "1ste Locatie" });
            for (int i = 2; i < 7; i++)
            {
                locationList.Add(new SelectListItem { Value = i + "", Text = i + "de Locatie" });
            }
            return locationList;
        }
	}
}