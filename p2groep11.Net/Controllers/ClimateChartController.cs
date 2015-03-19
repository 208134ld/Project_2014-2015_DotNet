using System;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
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
            //Voor breadcrumbs
            ViewBag.SchoolYear = selectedYear;
            ViewBag.ContinentId = continentId;
            ViewBag.CountryId = countryId;
            ViewBag.ClimateId = climateId;

            if (ModelState.IsValid)
            {
                try
                {

                    //repo wordt 2x aangesproken
                    ClimateChart c =
                        gradeRepository.FindBySchoolyear(selectedYear)
                            .GetContinent(continentId)
                            .getCountry(countryId)
                            .GetClimateChart(climateId);


                    Grade gr = gradeRepository.FindBySchoolyear(selectedYear);
                    
                    //moet in constructor
                    DeterminateTable ta = gr.DeterminateTableProp;
                    ta.ClauseComponent = ta.AllClauseComponents.ElementAt(ta.AllClauseComponents.Count-1);

                    return View(new ClimateChartViewModel(c, ta));
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

        [HttpPost]
        public ActionResult SelectVegetation(String selectedVegetation, String correctVegetation, int SelectedYear)
        {
            
            if (ModelState.IsValid)
            {
                try{
                    if (selectedVegetation.Equals(correctVegetation))
                    {
                        TempData["Succes"] =
                            "U heeft het juiste vegetatietype gekozen! U kan verder gaan met een andere locatie.";

                        //redirect niet nodig
                        return RedirectToAction("ListContinents", "Continent", new { SelectedYear });
                    
                    }
                    
                    TempData["FoutVegetatie"] = "U heeft het foute vegetatietype gekozen!";
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("",e.Message);
                }
            }
            //return View();
            return Redirect(HttpContext.Request.UrlReferrer.AbsoluteUri);
        }
    }
}