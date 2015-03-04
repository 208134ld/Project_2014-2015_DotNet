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
            return View(new SchoolYearFormViewModel());
        }
    
        [HttpPost]
        public ActionResult Index(int SelectedYear)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //de Businesslogica in de controller moet hier weg (switch case) --> grade klasse maken
                    SchoolYear schoolYear = new SchoolYear(SelectedYear);
                    Grade grade = new Grade(schoolYear);
                    int gradeInt = grade.GradeInt;
                    switch (gradeInt)
                    {
                        case 1:
                            return RedirectToAction("ListCountries", "Continent", new { SelectedYear, continentId = 1});
                        case 2:
                            return RedirectToAction("ListContinents", "Continent", new { SelectedYear });
                        default:
                            return RedirectToAction("Error");
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("",e.Message);
                }
               
            }
                return View(new SchoolYearFormViewModel());
        }

        public ActionResult Error()
        {
            return View();
        }

    }
}