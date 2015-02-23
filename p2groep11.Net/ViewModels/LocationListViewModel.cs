using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.ViewModels
{
    public class LocationListViewModel
    {
        public IEnumerable<ClimateChart> Locations { get; set; }
        
    }
}