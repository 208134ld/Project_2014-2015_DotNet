using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web;
using System.Web.Mvc;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.ViewModels
{
    public class ClimateChartViewModel
    {

        //props ClimateChart
        public Highcharts Chart { get; private set; }
        public IEnumerable<Month> Months { get; private set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double AvgTemp { get; private set; }

        public int SumSed { get; private set; }


        //props DeterminateTable
        public String[] ResultaatDeterminate { get; set; }
        public String CorrectClimate { get; set; }
        public String CorrectVegetation { get; set; }
        public List<String> CorrectPath { get; set; }
        public String HtmlDetTabel { get; private set; }


        //props SelectVegetation
        public List<SelectListItem> OptionsVegetation { get; set; }
        private Image picture;
        public byte[] ByteArray { get; set; }

        [Required]
        [Display(Name = "Vegetatie")]
        public String SelectedVegetation { get; set; }


        //props Questions
        //geen objecten in de view
        public List<Parameter> Parameters { get; set; }
        public string[] Answers { get; set; }


        //viewmodel voor de "legende" van de determineertabel
        public VoorbeelViewModel Voorbeeld { get; set; }



        public ClimateChartViewModel(ClimateChart c, DeterminateTable table)
        {
            ClauseComponent headClauseComponent =
                table.AllClauseComponents.ElementAt(table.AllClauseComponents.Count - 1);
            Result correctResult = null;
            this.Months = c.Months;
            this.Chart = DrawClimateChart(c);
            AvgTemp = Months.Average(m => m.AverTemp);
            SumSed = Months.Sum(m => m.Sediment);

            Voorbeeld = new VoorbeelViewModel();

            ResultaatDeterminate = Determinate(c, table);
            HtmlDetTabel = headClauseComponent.GetHtmlCode(true);
            CorrectPath = new List<String>();
            Parameters = new List<Parameter>();

            //CorrectPath lijst opvullen met de namen van alle correcte clauses en CorrectResult toewijzen
            foreach (ClauseComponent cc in table.CorrectPath(c))
            {
                if (cc.GetType().BaseType.ToString() == "p2groep11.Net.Models.Domain.Clause")
                    CorrectPath.Add(((Clause) cc).Name);
                else
                {
                    correctResult = (Result) cc;
                }
            }

            //Juiste klimaatkenmerk en vegetatiekenmerk toekennen
            CorrectClimate = correctResult.Climatefeature;
            CorrectVegetation = correctResult.Vegetationfeature;

            //Lijst met results opvullen en de SelectList met de vegetatietypes opvullen
            List<String> allVegetationTypes = new List<String>();
            foreach (ClauseComponent cc in table.AllClauseComponents)
            {
                if (cc.GetType().BaseType.ToString() != "p2groep11.Net.Models.Domain.Clause")
                    if (!allVegetationTypes.Contains(((Result) cc).Vegetationfeature))
                        allVegetationTypes.Add(((Result) cc).Vegetationfeature);
            }
            Shuffle(allVegetationTypes);
            OptionsVegetation = allVegetationTypes.Select(v => new SelectListItem {Value = v, Text = v}).ToList();

            //foto van vegetatietype ophalen
            ByteArray = correctResult.VegetationPicture;
        }

        //hulpmethode om een lijst ad random te ordenen
        private void Shuffle<T>(List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        //Geeft klimaatkenmerk en vegetatiekenmerk in een string array
        private String[] Determinate(ClimateChart c, DeterminateTable t)
        {
            return t.Determinate(c);
        }

        private Highcharts DrawClimateChart(ClimateChart climateChart)
        {
            var m = climateChart.CalculateMaxForChart();
            var sed = Months.Select(p => p.Sediment).ToArray();
            var tem = Months.Select(p => p.AverTemp).ToArray();
            var sediments = new object[12];
            var temp = new object[12];
            CopyIntArrayToObjectArray(sed, sediments);
            CopyIntArrayToObjectArray(tem, temp);
            var chart = new Highcharts("chart")
                .InitChart(new Chart {ZoomType = ZoomTypes.Xy})
                .SetTitle(new Title
                {
                    Text = "klimatogram " + climateChart.Location + " (" + climateChart.Country.Name + ")"
                })
                .SetSubtitle(new Subtitle {Text = climateChart.BeginPeriod + " - " + climateChart.EndPeriod})
                .SetCredits(new Credits {Enabled = false})
                .SetXAxis(new XAxis
                {
                    Categories =
                        new[] {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"}
                })
                .SetYAxis(new[]
                {
                    new YAxis
                    {
                        Labels = new YAxisLabels
                        {
                            Formatter = "function() { return this.value; }",
                            Style = "color: '#DE091E'"
                        },
                        Title = new YAxisTitle
                        {
                            Text = "Temperatuur (T) in °C",
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
                            Formatter = "function() { return this.value; }",
                            Style = "color: '#4572A7'"
                        },
                        Title = new YAxisTitle
                        {
                            Text = "Neerslag (N) in mm",
                            Style = "color: '#4572A7'"
                        },
                        Max = climateChart.CalculateMaxForChart(),
                        Min = climateChart.CalculateMinForChart()*2
                    }
                })
                .SetTooltip(new Tooltip
                {
                    Formatter =
                        "function() { return ''+ this.x +': '+ this.y + (this.series.name == 'Neerslag' ? ' mm' : '°C'); }"
                })
                .SetLegend(new Legend
                {
                    Layout = Layouts.Vertical,
                    Align = HorizontalAligns.Left,
                    X = 120,
                    VerticalAlign = VerticalAligns.Top,
                    Y = 10,
                    Floating = true
                    //BackgroundColor = new BackColorOrGradient(ColorTranslator.FromHtml("#FFFFFF"))
                })
                .SetSeries(new[]
                {
                    new Series
                    {
                        Name = "Neerslag in mmN",
                        Color = ColorTranslator.FromHtml("#4572A7"),
                        Type = ChartTypes.Column,
                        YAxis = "1",
                        Data = new Data(sediments)
                    },
                    new Series
                    {
                        Name = "Temperatuur in °C",
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

    public class VoorbeelViewModel
    {
        public String Html { get; private set; }

        public VoorbeelViewModel()
        {
            Parameter tw = new TW("Wat is de temperatuur van de warmste maand (TW)?");
            ClauseComponent tw10 = new Clause("Is appel een fruit?", tw, "<=", 10);
            ClauseComponent res1 = new Result("Appel is een fruit", "geen woestijn");
            ClauseComponent res2 = new Result("Appel is geen fruit", "woestijn");
            tw10.Add(true, res1);
            tw10.Add(false, res2);
            Html = tw10.GetHtmlCode(true);
        }
    }
}