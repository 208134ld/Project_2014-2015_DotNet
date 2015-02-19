using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep11.Net.Models;
using p2groep11.Net.ViewModels;

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
            ContinentsListViewModel model = new ContinentsListViewModel
            {
                Continents = repository.FindAll()
            };
             
            return View(model);
        }

    }
}