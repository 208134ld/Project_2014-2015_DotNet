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
        public ActionResult SchoolYearCreate()
        {
            List<SchoolYear> years = new List<SchoolYear>();
            for (int i = 1; i < 7; i++)
            {
                years.Add(new SchoolYear(i));
            }
            return View(new SchoolYearCreateViewModel(years,new SchoolYearViewModel()));
        }
        [HttpPost]
        public ActionResult SchoolYearCreate([Bind(Prefix = "SchoolYearCreateViewModel")]SchoolYearViewModel model)
        {
            Session["SchoolYear"] = 2;
            return View("homepage");
        }

       
    }
}