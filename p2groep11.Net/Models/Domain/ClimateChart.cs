using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep11.Net.Models.Domain
{
    public class ClimateChart
    {
        public int ClimateChartID { get; set; }
        public string Location { get; set; }
        public virtual List<Month> Months { get; set; }
        public int BeginPeriod { get; set; }
        public int EndPeriod { get; set; }
        public Country Country { get; set; }

        public ClimateChart()
        {
            
        }
        public ClimateChart(string loc, int begin, int end,int[]temperatures,int[] sediments)
        {
            if (temperatures.Length != 12 || sediments.Length != 12)
                throw new ArgumentException("Temperatures and sediments have to contain 12 values");
            Location = loc;
            BeginPeriod = begin;
            EndPeriod = end;
            Months = new List<Month>();
            MakeMonthsList(temperatures,sediments);
        }

        private void MakeMonthsList(int[] temperatures,int[] sediments)
        {
            int counter = 0;
            foreach (MonthsOfTheYear month in Enum.GetValues(typeof(MonthsOfTheYear)))
            {
                Months.Add(new Month(month,temperatures[counter],sediments[counter]));
                counter++;
            }
        }
    }
}
