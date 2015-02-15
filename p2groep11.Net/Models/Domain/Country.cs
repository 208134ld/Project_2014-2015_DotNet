using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep11.Net.Models.Domain
{
    public class Country
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public ICollection<ClimateChart> Locations { get; set; }
    }
}
