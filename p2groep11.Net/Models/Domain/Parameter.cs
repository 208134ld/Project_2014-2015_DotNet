using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2groep11.Net.Models.Domain
{
    public abstract class Parameter
    {
        public int ParameterId { get; set; }
        /*public int Waarde { get; set; }
        public String Code { get; set; }

        public Parameter(int waarde, String code)
        {
            this.Waarde = waarde;
            this.Code = code;
        }*/
        public abstract int Execute(ClimateChart chart);
    }
}