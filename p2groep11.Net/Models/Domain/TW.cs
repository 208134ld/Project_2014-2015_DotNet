using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net
{
    public class TW : Parameter
    {
        public String Beschrijving { get; set; }
        public string Answer { get; set; } 

        public TW()
        {
            
        }

        public TW(String beschr)
        {
            this.Beschrijving = beschr;
        }
        public override int Execute(ClimateChart chart)
        {
            Answer = chart.HottestMonth.ToString();
            return chart.HottestMonth;
        }

        public override string[] GiveOptAnswers(ClimateChart chart)
        {
            return chart.GetAllTemperatures();
        }
    }
}
