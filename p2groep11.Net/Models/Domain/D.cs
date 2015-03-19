using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using Microsoft.SqlServer.Server;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net
{
    public class D : Parameter
    {
        public string Beschrijving { get; set; }

        public D()
        {
            
        }
        public D(String beschr)
        {
            this.Beschrijving = beschr;
        }
        public override int Execute(ClimateChart chart)
        {
            return chart.TotalDryMonths;
        }

        public override string[] GiveOptAnswers(ClimateChart chart)
        {
            return chart.AmountOfMonths();
        }

        public override string GiveAnswer(ClimateChart chart)
        {
            return chart.TotalDryMonths.ToString();
        }
    }
}
