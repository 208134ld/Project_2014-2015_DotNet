using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using System.Windows.Forms;
using p2groep11.Net.Models.DAL;
using p2groep11.Net.Models.Domain;
using p2groep11.Net.ViewModels;

namespace p2groep11.Net.Controllers
{
    public class ClimateChartController : Controller
    {
        private readonly IGradeRepository gradeRepository;

        public ClimateChartController(IGradeRepository gradeRepository)
        {
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
                        gradeRepository.FindBySchoolyear(selectedYear)
                            .GetContinent(continentId)
                            .getCountry(countryId)
                            .GetClimateChart(climateId);


                    Grade gr = gradeRepository.FindBySchoolyear(selectedYear);

                    DeterminateTable ta = gr.DeterminateTableProp;
                    ta.ClauseComponent = ta.AllClauseComponents.ElementAt(ta.AllClauseComponents.Count-1);
                    String html = "";
                    html = ta.ClauseComponent.GetHtmlCode(true);

                    return View(new ClimateChartViewModel(c, ta));
                }
                catch (SqlException sqlExc)
                {
                    MessageBox.Show(sqlExc.InnerException.ToString());
                    ModelState.AddModelError("", "Connection lost with the database \n" + sqlExc.Message);
                }
                catch (NullReferenceException nullEx)
                {
                    //MessageBox.Show(nullEx.InnerException.ToString());
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

        //alle redirects nodig wegens viewbag probleem tussen verschillende controllers
        //werken met tempdata, low priority
        public ActionResult ListLocations(int selectedyear, int continentid, int countryid)
        {
            return RedirectToAction("ListLocations", "Continent",
                new {selectedYear = selectedyear, continentId = continentid, countryId = countryid});
        }

        public ActionResult ListCountries(int selectedyear, int continentid)
        {
            return RedirectToAction("ListCountries", "Continent",
                new {selectedYear = selectedyear, continentId = continentid});
        }

        public ActionResult ListContinents(int schoolyear)
        {
            return RedirectToAction("ListContinents", "Continent", new {selectedYear = schoolyear});
        }

        [HttpPost]
        public ActionResult SelectVegetation(String selectedVegetation, String correctVegetation, int schoolYear)
        {
            
            if (ModelState.IsValid)
            {
                try{
                    if (selectedVegetation.Equals(correctVegetation))
                    {
                        MessageBox.Show("U heeft het juiste vegetatietype gekozen!");
                        return RedirectToAction("index", "SchoolYear");
                    }
                    TempData["FoutVegetatie"] = "U heeft het foute vegetatietype gekozen!";
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("",e.Message);
                }
            }
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }

        public ActionResult WatchPictureVegetation()
        {
            TempData["WatchPicture"] = "Yes";
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
    }
}