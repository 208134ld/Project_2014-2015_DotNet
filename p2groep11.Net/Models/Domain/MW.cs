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
        public String Beschrijving { get; set; }

        public MW()
        {
            
        }

        public MW(String beschr)
        {
            this.Beschrijving = beschr;
        }
        public override int Execute(ClimateChart chart)
        {
            throw new ApplicationException();
        }



    }
}
