﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net
{
    public class NW : Parameter
    {

        public String Beschrijving { get; set; }
        public string Answer { get; set; } 

        public NW()
        {
            
        }

        public NW(String beschr)
        {
            this.Beschrijving = beschr;
        }
        public override int Execute(ClimateChart chart)
        {
            Answer = chart.RainInWinter.ToString();
            return chart.RainInWinter;
        }

        public override string[] GiveOptAnswers(ClimateChart chart)
        {
            return chart.TotalRainfallInts();
        }
    }
}
