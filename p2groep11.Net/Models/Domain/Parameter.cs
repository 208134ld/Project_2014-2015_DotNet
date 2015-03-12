using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2groep11.Net.Models.Domain
{
    public abstract class Parameter
    {
        public int ParameterId { get; set; }
        public String Beschrijving { get; set; } //De vraag zelf
        //public String Code { get; set; }

        public abstract int Execute(ClimateChart chart);
    }
}