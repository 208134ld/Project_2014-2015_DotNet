using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Windows.Forms;
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
        private IGradeRepository gradeRepository;

        public ClimateChartController(IContinentRepository continentRepository, IGradeRepository gradeRepository)
        {
            this.continentRepository = continentRepository;
            this.gradeRepository = gradeRepository;
        }

        public ActionResult ShowClimateChart(int selectedYear, int continentId, int countryId, int climateId)
        {
            ViewBag.SchoolYear = selectedYear;
            ViewBag.ContinentId = continentId;
            ViewBag.CountryId = countryId;
            ViewBag.ClimateId = climateId;

            if (ModelState.IsValid)
            {
                
                try
                {
                    ClimateChart c =
                        continentRepository.FindById(continentId)
                            .Countries.FirstOrDefault(co => co.CountryID == countryId)
                            .ClimateCharts.FirstOrDefault(cl => cl.ClimateChartID == climateId);
                    
                    Grade gr = gradeRepository.FindById(1);
                    String html = "";
                    html = gr.DeterminateTableProp.ClauseComponent.GetHtmlCode(true);
                    return View(new ClimateChartViewModel(c, gr.DeterminateTableProp));
                }
                catch (SqlException sqlExc)
                {
                    MessageBox.Show(sqlExc.InnerException.ToString());
                    ModelState.AddModelError("", "Connection lost with the database \n" + sqlExc.Message);

                }
                catch (NullReferenceException nullEx)
                {
                    MessageBox.Show(nullEx.InnerException.ToString());
                    ModelState.AddModelError("",
                        "Could not find the climateChart associated with this continentId or countryId or climateId \n" +
                        nullEx.Message);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.InnerException.ToString());
                    ModelState.AddModelError("", e.Message);
                }
            }
            return RedirectToAction("Index", "SchoolYear");
        }

        public ActionResult ListLocations(int selectedyear, int continentid, int countryid)
        {
            return RedirectToAction("ListLocations", "Continent", new {selectedYear = selectedyear, continentId = continentid, countryId = countryid});
        }

        public ActionResult ListCountries(int selectedyear, int continentid)
        {
            return RedirectToAction("ListCountries", "Continent", new { selectedYear = selectedyear, continentId = continentid});
        }

        public ActionResult ListContinents(int schoolyear)
        {
            return RedirectToAction("ListContinents", "Continent", new { selectedYear = schoolyear});
        }
    }
}