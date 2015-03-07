using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net
{
    public class TJ : Parameter
    {

        public TJ()
        {
        }
        public int Execute(ClimateChart chart)
        {
            return chart.CalculateAverageYeartemp();
        }
    }
}
