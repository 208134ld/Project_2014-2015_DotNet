using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Linq;
using p2groep11.Net.ViewModels;
using DotNet.Highcharts;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using System.Drawing;
using System.Web.Mvc;

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
                return Months.Sum(m => m.Sediment);
            }
        }

        public int RainInSummer //NZ
        {
            get
            {
                if (Country.AboveEquator)
                {
                    var count = 0;
                    for (var i = 4; i < 10; i++)
                    {
                        count += Months[i].Sediment;
                    }
                    return count;
                }
                var count2 = 0;
                for (var i = 10; i < 13; i++)
                {
                    count2 += Months[i].Sediment;
                }
                for (var i = 1; i < 4; i++)
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
                    for (var i = 4; i < 10; i++)
                    {
                        count += Months[i].Sediment;
                    }
                    return count;
                }
                var count2 = 0;
                for (var i = 10; i < 13; i++)
                {
                    count2 += Months[i].Sediment;
                }
                for (var i = 1; i < 4; i++)
                {
                    count2 += Months[i].Sediment;
                }
                return count2;
            }
        }

        public int MaandenOnder10 //TM
        {
            get
            {
                return Months.Count(m => m.AverTemp >= 10);
            }
        }



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
    }
}
