using System;
using System.Collections.Generic;
using System.Linq;

namespace p2groep11.Net.Models.Domain
{
    public class ClimateChart
    {
        public int ClimateChartID { get; set; }
        public string Location { get; set; }
        public int BeginPeriod { get; set; }
        public int EndPeriod { get; set; }
        public virtual Country Country { get; set; }
        public virtual List<Month> Months { get; private set; }

        public ClimateChart()
        {
            Months = new List<Month>();
        }

        public ClimateChart(string loc, int begin, int end, int[] temperatures, int[] sediments)
        {

            Location = loc;
            BeginPeriod = begin;
            EndPeriod = end;
            Months = new List<Month>();
            MakeMonthsList(temperatures, sediments);
        }

        public int HottestMonth //TW
        {
            get
            {
                return Months.Select(month => month.AverTemp).Max();
            }
        }
        public int AverageYearTemp //TJ
        {
            get
            {
                return (int)(Months.Average(month => month.AverTemp));
            }
        }

        public int ColdestMonth  //TK
        {
            get
            {
                return Months.Select(m => m.AverTemp).Min();
            }
        }

        public int TotalRainOfYear //NJ
        {
            get
            {
                return Months.Sum(m => m.Sediment);
            }
        }

        public int TotalDryMonths //D
        {
            get
            {
                return Months.Count(m => (m.AverTemp*2) > m.Sediment);
            }
        }

        public int RainInSummer //NZ
        {
            get
            {
                if (Country.AboveEquator)
                {
                    var count = 0;
                    for (var i = 3; i < 9; i++)
                    {
                        count += Months[i].Sediment;
                    }
                    return count;
                }
                var count2 = 0;
                for (var i = 9; i < 12; i++)
                {
                    count2 += Months[i].Sediment;
                }
                for (var i = 0; i < 3; i++)
                {
                    count2 += Months[i].Sediment;
                }
                return count2;
            }
        }

        public int RainInWinter //NW
        {
            get
            {
                if (!Country.AboveEquator)
                {
                    var count = 0;
                    for (var i = 3; i < 9; i++)
                    {
                        count += Months[i].Sediment;
                    }
                    return count;
                }
                var count2 = 0;
                for (var i = 9; i < 12; i++)
                {
                    count2 += Months[i].Sediment;
                }
                for (var i = 0; i < 3; i++)
                {
                    count2 += Months[i].Sediment;
                }
                return count2;
            }
        }

        public int MonthsAbove10Degree //TM
        {
            get
            {
                return Months.Count(m => m.AverTemp >= 10);
            }
        }

        private void MakeMonthsList(int[] temperatures,int[] sediments)
        {
            if (temperatures.Length != 12 || sediments.Length != 12)
                throw new ArgumentException("Temperatures and sediments have to contain 12 values");
            if(sediments.Min()<0)
                throw new ArgumentException("Sediments have to be greater than 0");
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
    }
}
