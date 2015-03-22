using System;
using System.Collections.Generic;
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

        public ActionResult ShowExercises(int selectedYear, int continentId, int countryId, int climateId)
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
                    Grade gr = gradeRepository.FindBySchoolyear(selectedYear);
                    ClimateChart c = gr.GetContinent(continentId).getCountry(countryId).GetClimateChart(climateId);
                    DeterminateTable ta = gr.DeterminateTableProp;
                    List<Parameter> parameters = gr.QuestionListProp.Parameters.ToList();

                    return View( new ClimateChartViewModel(c, ta, parameters)); 
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
                    ModelState.AddModelError("", e.Message);
                }
            }
            return RedirectToAction("Index", "SchoolYear");
        }
    }
}