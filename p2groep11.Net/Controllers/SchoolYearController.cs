using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep11.Net.Models;
using p2groep11.Net.ViewModels;

namespace p2groep11.Net.Controllers
{
    public class SchoolYearController : Controller
    {
        // GET: SchoolYear
        [HttpGet]
        public ActionResult SchoolYearForm()
        {
            List<SchoolYear> years = new List<SchoolYear>();
            for (int i = 1; i < 7; i++)
            {
                years.Add(new SchoolYear(i));
            }
            return View(new SchoolYearFormViewModel(GetYears()));
        }
    
        [HttpPost]
        public ActionResult SchoolYearForm(SchoolYearFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                Session["SchoolYear"] = new SchoolYear(model.SelectedYear);
                return View("homepage"); // verwissel met volgende view en controller.
            }
            else
            {
                return View(new SchoolYearFormViewModel(GetYears()));
            }
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