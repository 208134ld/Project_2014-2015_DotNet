using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep11.Net.Models;

namespace p2groep11.Net.Controllers
{
    public class GradeController : Controller
    {
        // GET: Grade
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult GradeForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult GradeForm(SchoolYear grade)
        {
            return View();
        }
    }
}