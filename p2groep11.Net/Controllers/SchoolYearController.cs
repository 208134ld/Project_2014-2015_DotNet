using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using p2groep11.Net.Models;
using p2groep11.Net.Models.Domain;
using p2groep11.Net.ViewModels;

namespace p2groep11.Net.Controllers
{
    public class SchoolYearController : Controller
    {
        // GET: SchoolYear
        [HttpGet]
        public ActionResult Index()
        {
            return View(new SchoolYearFormViewModel(GetYears()));
        }
    
        [HttpPost]
        public ActionResult Index(int SelectedYear)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SchoolYear schoolYear = new SchoolYear(SelectedYear);
                    int grade = schoolYear.CalculateGrade();
                    return RedirectToAction("ListContinents", "Continent", new { grade });
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("",e.Message);
                }
               
            }
                return View(new SchoolYearFormViewModel(GetYears()));
        }

        private List<SelectListItem> GetYears()
        {
            List<SelectListItem> years = new List<SelectListItem>();
            years.Add(new SelectListItem {Value = "1", Text = "1ste Leerjaar"});
            for (int i = 2; i < 7; i++)
            {
                years.Add(new SelectListItem{Value = i+"",Text = i+"de Leerjaar"});
            }
            return years;
        }
    }
}