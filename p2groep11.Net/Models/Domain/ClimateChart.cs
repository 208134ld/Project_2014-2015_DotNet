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

        //Private methods uit de controller -- aangepast
        public ClimateChartViewModel DrawClimateChart(/*ClimateChart climateChart*/)
        {
            DeterminateTable table = new DeterminateTable();


            /*ClimateChart c = climateChart;*/

            int m = this.CalculateMaxForChart();
            int[] sed = this.Months.Select(p => p.Sediment).ToArray();
            int[] tem = this.Months.Select(p => p.AverTemp).ToArray();
            Object[] sediments = new object[12];
            Object[] temp = new object[12];
            CopyIntArrayToObjectArray(sed, sediments);
            CopyIntArrayToObjectArray(tem, temp);
            Highcharts chart = new Highcharts("chart")
               .InitChart(new Chart { ZoomType = ZoomTypes.Xy })
               .SetTitle(new Title { Text = "klimatogram " + this.Location + " (" + this.Country.Name + ")" })
               .SetSubtitle(new Subtitle { Text = this.BeginPeriod + " - " + this.EndPeriod })
               .SetXAxis(new XAxis { Categories = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" } })
               .SetYAxis(new[]
                {
                    new YAxis
                    {
                        Labels = new YAxisLabels
                        {
                            Formatter = "function() { return this.value +'°C'; }",
                            Style = "color: '#DE091E'"
                        },
                        Title = new YAxisTitle
                        {
                            Text = "Temperatuur",
                            Style = "color: '#DE091E'"
                        },
                        Opposite = true,
                        Max = this.CalculateMaxForChart()/2,
                        Min = this.CalculateMinForChart()
                        
                    },
                    new YAxis
                    {
                        Labels = new YAxisLabels
                        {
                            Formatter = "function() { return this.value +'mm'; }",
                            Style = "color: '#4572A7'"
                        },
                        Title = new YAxisTitle
                        {
                            Text = "Neerslag",
                            Style = "color: '#4572A7'"
                        },
                        Max = this.CalculateMaxForChart(),
                        Min = this.CalculateMinForChart()*2
                    }
                })
               .SetTooltip(new Tooltip
               {
                   Formatter = "function() { return ''+ this.x +': '+ this.y + (this.series.name == 'Neerslag' ? ' mm' : '°C'); }"
               })
               .SetLegend(new Legend
               {
                   Layout = Layouts.Vertical,
                   Align = HorizontalAligns.Left,
                   X = 120,
                   VerticalAlign = VerticalAligns.Top,
                   Y = 100,
                   Floating = true,
                   BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFFFFF"))
               })
               .SetSeries(new[]
                {
                    new Series
                    {
                        Name = "Neerslag",
                        Color = ColorTranslator.FromHtml("#4572A7"),
                        Type = ChartTypes.Column,
                        YAxis = "1",
                        Data = new Data(sediments)
                         
                    },
                    new Series
                    {
                        Name = "Temperatuur",
                        Color = ColorTranslator.FromHtml("#DE091E"),
                        Type = ChartTypes.Spline,
                        Data = new Data(temp)
                    }
                });

            return new ClimateChartViewModel(chart, this.Months, table);
        }

        private void CopyIntArrayToObjectArray(int[] intArray, Object[] objectAr)
        {
            intArray.CopyTo(objectAr, 0);
        }

        //voorlopig om strings in de selectlist te steken
        private List<SelectListItem> GetContinents()
        {
            List<SelectListItem> continentList = new List<SelectListItem>();
            continentList.Add(new SelectListItem { Value = "1", Text = "1ste Continent" });
            for (int i = 2; i < 5; i++)
            {
                continentList.Add(new SelectListItem { Value = i + "", Text = i + "de Continent" });
            }
            return continentList;
        }

        private List<SelectListItem> GetCountrys()
        {
            List<SelectListItem> countryList = new List<SelectListItem>();
            countryList.Add(new SelectListItem { Value = "1", Text = "1ste Land" });
            for (int i = 2; i < 10; i++)
            {
                countryList.Add(new SelectListItem { Value = i + "", Text = i + "de Land" });
            }
            return countryList;
        }

        private List<SelectListItem> GetLocations()
        {
            List<SelectListItem> locationList = new List<SelectListItem>();
            locationList.Add(new SelectListItem { Value = "1", Text = "1ste Locatie" });
            for (int i = 2; i < 7; i++)
            {
                locationList.Add(new SelectListItem { Value = i + "", Text = i + "de Locatie" });
            }
            return locationList;
        }

    }
}
