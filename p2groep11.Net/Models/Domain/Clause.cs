using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep11.Net
{
    public class Clause : ClauseComponent
    {
        public ICollection<ClauseComponent> ClimateCharts { get; set; }
    }
}
