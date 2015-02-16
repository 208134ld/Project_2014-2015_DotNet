using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep11.Net.Models;

namespace p2groep11.Net.Controllers
{
    public class ContinentController : Controller
    {
        private IContinentRepository repository;

        public ContinentController(IContinentRepository continentRepository)
        {
            repository = continentRepository;
        }

        public ViewResult ListContinents()
        {
            return View(repository.FindAll());
        }

    }
}