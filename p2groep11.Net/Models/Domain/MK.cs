using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net
{
    public class MK : p2groep11.Net.Models.Domain.Parameter
    {
        public string Beschrijving { get; set; }
        public string Answer { get; set; } 

        public MK()
        {
            
        }

        public MK(String beschr)
        {
            this.Beschrijving = beschr;
        }
        public override int Execute(ClimateChart chart)
        {
            Answer = chart.ColdestMonthMK.ToString();
            return chart.ColdestMonthMK;
        }

        public override string[] GiveOptAnswers(ClimateChart chart)
        {
            return chart.GetMonthsOfYear();
        }
    }
}
