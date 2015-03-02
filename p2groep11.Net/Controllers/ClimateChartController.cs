using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using p2groep11.Net.Models;
using p2groep11.Net.Models.DAL;
using p2groep11.Net.Models.Domain;
using p2groep11.Net.ViewModels;
using Point = DotNet.Highcharts.Options.Point;

namespace p2groep11.Net.Controllers
{
    public class ClimateChartController : Controller
    {
        private IContinentRepository continentRepository;

        public ClimateChartController(IContinentRepository continentRepository)
        {
            this.continentRepository = continentRepository;
        }
        
        public ActionResult ShowClimateChart(int selectedYear,int continentId,int countryId,int climateId)
        {
            @ViewBag.SchoolYear = selectedYear;
            if(ModelState.IsValid)
            {
                try
                {
                    ClimateChart c = continentRepository.FindById(continentId).Countries.FirstOrDefault(co=>co.CountryID==countryId).ClimateCharts.FirstOrDefault(cl=>cl.ClimateChartID==climateId);
                    
                    return View(new ClimateChartViewModel(c,new DeterminateTable()));
                }
                catch (SqlException sqlExc)
                {
                    ModelState.AddModelError("", "Connection lost with the database \n" + sqlExc.Message);

                }
                catch (NullReferenceException nullEx)
                {
                    ModelState.AddModelError("",
                        "Could not find the climateChart associated with this continentId or countryId or climateId \n" +
                        nullEx.Message);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("",e.Message);
                }
            }
            return RedirectToAction("Index","SchoolYear");
        }
        #region privateMethods
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
        #endregion
    }
}