using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep11.Net.Models.Domain
{
    public class Month
    {
        private int monthDate; 

        public int MonthID { get; set; }
        //Gemiddelde Temperatuur
        public int MonthDate
        {
            get { return monthDate; }
            set
            {
                if (value > 0 && value <= 12)
                {
                    this.monthDate = value;
                }
                else throw new ArgumentException("Month needs to be between 1 and 12.");
            }
        }
        public int AverTemp { get; set; }
        public int Sediment { get; set; }
        public ClimateChart ClimateChart { get; set; }

        public Month(int month, int temp, int sed)
        {
            monthDate = month;
            AverTemp = temp;
            Sediment = sed;
        }

    }
}
