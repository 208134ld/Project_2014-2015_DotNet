using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.ViewModels
{
    public class ClimateChartViewModel
    {
        private Image picture;
        public Highcharts Chart { get; private set; }
        public IEnumerable<Month> Months { get; private set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double AvgTemp { get; private set; }
        public int SumSed { get; private set; }
        public DeterminateTable table { get; private set; }
        public String[] ResultaatDeterminate { get;  set; }
        public List<Clause> CorrectPath { get; set; }
        public Result CorrectResult { get; set; }

        public Image Picture
        {
            get { return picture; }
            set { picture = CorrectResult.byteArrayToImage(); }
        }

        public String HtmlDetTabel { get; private set; }

        public ClimateChartViewModel(ClimateChart c,DeterminateTable table)
        {
            this.Months = c.Months;
            this.Chart = DrawClimateChart(c);
            
            AvgTemp =  Months.Average(m => m.AverTemp);
            SumSed = Months.Sum(m => m.Sediment);
            this.table = table;
            ResultaatDeterminate = Determinate(c, table);
            HtmlDetTabel = table.ClauseComponent.GetHtmlCode(true);
            CorrectPath = new List<Clause>();
            CorrectResult = new Result();

            foreach (ClauseComponent cc in table.CorrectPath(c))
            {
                if (cc.GetType().BaseType.ToString() == "p2groep11.Net.Models.Domain.Clause")
                    CorrectPath.Add((Clause)cc);
                else
                    CorrectResult = (Result)cc;
                
            }
        }

        public String[] Determinate(ClimateChart c, DeterminateTable t)
        {
            return t.Determinate(c);
        }

        public Highcharts DrawClimateChart(ClimateChart climateChart)
        {
            


            /*ClimateChart c = climateChart;*/

            int m = climateChart.CalculateMaxForChart();
            int[] sed = this.Months.Select(p => p.Sediment).ToArray();
            int[] tem = this.Months.Select(p => p.AverTemp).ToArray();
            Object[] sediments = new object[12];
            Object[] temp = new object[12];
            CopyIntArrayToObjectArray(sed, sediments);
            CopyIntArrayToObjectArray(tem, temp);
            Highcharts chart = new Highcharts("chart")
               .InitChart(new Chart { ZoomType = ZoomTypes.Xy })
               .SetTitle(new Title { Text = "klimatogram " + climateChart.Location + " (" + climateChart.Country.Name + ")" })
               .SetSubtitle(new Subtitle { Text = climateChart.BeginPeriod + " - " + climateChart.EndPeriod }).SetCredits(new Credits{Enabled = false})
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
                        Max = climateChart.CalculateMaxForChart()/2,
                        Min = climateChart.CalculateMinForChart()
                        
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
                        Max = climateChart.CalculateMaxForChart(),
                        Min = climateChart.CalculateMinForChart()*2
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
                   Y = 10,
                   Floating = true,
                   //BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFFFFF"))
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

            return chart;
        }
        private void CopyIntArrayToObjectArray(int[] intArray, Object[] objectAr)
        {
            intArray.CopyTo(objectAr, 0);
        }
    }
}