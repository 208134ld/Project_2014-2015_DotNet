using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net
{
    public class MW : p2groep11.Net.Models.Domain.Parameter
    {

        public MW()
        {
            
        }

        public MW(String beschr)
        {
            this.Beschrijving = beschr;
        }
        public override double Execute(ClimateChart chart)
        {
            return chart.HottestMonthMW;
        }

        public override string[] GiveOptAnswers(ClimateChart chart)
        {
            return chart.GetMonthsOfYear();
        }

        public override string GiveAnswer(ClimateChart chart)
        {
            return chart.HottestMonthMW.ToString();
        }
    }
}
