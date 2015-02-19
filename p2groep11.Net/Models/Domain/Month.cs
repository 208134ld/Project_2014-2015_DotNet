using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep11.Net.Models.Domain
{
    public class Month
    {
      

        public int MonthID { get; set; }
        //Gemiddelde Temperatuur
        public MonthsOfTheYear month { get; set; }
        public int AverTemp { get; set; }
        public int Sediment { get; set; }

        public Month(MonthsOfTheYear month, int temp, int sed)
        {
            month = month;
            AverTemp = temp;
            Sediment = sed;
        }

    }
}
