using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net
{
    public class NZ : Parameter
    {

        public NZ()
        {
            
        }

        public NZ(string beschr)
        {
            Beschrijving = beschr;
        }
        public override double Execute(ClimateChart chart)
        {
            return chart.RainInSummer;
        }

        public override string[] GiveOptAnswers(ClimateChart chart)
        {
            return chart.TotalRainfallInts();
        }

        public override string GiveAnswer(ClimateChart chart)
        {
            return chart.RainInSummer.ToString();
        }
    }
}
