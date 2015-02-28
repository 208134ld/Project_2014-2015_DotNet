using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Linq;

namespace p2groep11.Net.Models.Domain
{
    public class ClimateChart
    {
        public int ClimateChartID { get; set; }
        public string Location { get; set; }
        public virtual List<Month> Months { get; private set; }
        public int BeginPeriod { get; set; }
        public int EndPeriod { get; set; }
        public virtual Country Country { get; set; }
        public virtual DeterminateTable DeterminateTable { get; set; }

        public ClimateChart()
        {
            
        }
        public ClimateChart(string loc, int begin, int end, int[]temperatures, int[] sediments)
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

        public int CalculateMaxForChart()
        {
            int mTemp = Months.Select(m => m.AverTemp).Max();
            int mSed = Months.Select(m => m.Sediment).Max();
            int max = 0;
            if (mTemp > mSed)
            {
                max = mTemp;
            }
            else
            {
                max = mSed;
            }
            return max;
        }

        public int CalculateMinForChart()
        {
            int mTemp = Months.Select(m => m.AverTemp).Min();
            int mSed = Months.Select(m => m.Sediment).Min();
            int min = 0;
            if (mTemp < mSed)
            {
                min = mTemp;
            }
            else
            {
                min = mSed;
            }
            return min;
        }

        public int CalculateHottestMonth()
        {
            return Months.Select(month => month.AverTemp).Concat(new[] { -200 }).Max();
        }

        public int CalculateAverageYeartemp()
        {
            return (Months.Sum(month => month.AverTemp)) / 12;
        }


    }
}
