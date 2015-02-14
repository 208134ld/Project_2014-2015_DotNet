using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace p2groep11.Net.ViewModels
{
    public class KlimatogramViewModel
    {
        public List<SelectListItem> Continents { set; get; }
        public List<SelectListItem> Countrys { set; get; }
        public List<SelectListItem> Locations { set; get; }
        public int SelectedContinent { get; set; }
        public int SelectedCountry { get; set; }
        public int SelectedLocation { get; set; }


        public KlimatogramViewModel(List<SelectListItem> Cont, List<SelectListItem> Count, List<SelectListItem> Loc)
        {
            Continents = Cont;
            Countrys = Count;
            Locations = Loc;
        }
    }
}