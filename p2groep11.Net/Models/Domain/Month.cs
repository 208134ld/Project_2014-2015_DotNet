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
        public virtual MonthsOfTheYear MonthProp { get; set; }
        //Gemiddelde Temperatuur
        public int AverTemp { get; set; }
        public int Sediment { get; set; }

        public Month()
        {
            
        }

        public Month(MonthsOfTheYear month, int temp, int sed)
        {
            this.MonthProp = month;
            AverTemp = temp;
            Sediment = sed;
        }

    }
}
