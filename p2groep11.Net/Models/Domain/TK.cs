using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net
{
    public class TK : Parameter
    {
        public String Beschrijving { get; set; }

        public TK()
        {
            
        }

        public TK(String beschr)
        {
            this.Beschrijving = beschr;
        }
        public override int Execute(ClimateChart chart)
        {
            return chart.ColdestMonth;
        }

        public override string[] GiveOptAnswers(ClimateChart chart)
        {
            return chart.GetAllTemperatures();
        }

        public override string GiveAnswer(ClimateChart chart)
        {
            return chart.ColdestMonth.ToString();
        }
    }
}
