using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using p2groep11.Net.Models;
using p2groep11.Net.ViewModels;

namespace p2groep11.Net.Controllers
{
    public class ClimateChartController : Controller
    {
        private IContinentRepository continentRepository;
        //repositories voor landen en locaties

        public ClimateChartController(IContinentRepository continentRepository)
        {
            this.continentRepository = continentRepository;
            //rest van de repositories gelijkstellen
        }
        [HttpGet]
        public ActionResult ChooseKlimatogram()
        {
            //locaties, landen en locaties uit de repository halen
            return View(new KlimatogramViewModel(GetContinents(), GetCountrys(), GetLocations()));
        }
        //setUp voor demo als chooseklimatogram nog niet werkt.
        public ActionResult ShowClimateChart()
        {

            Highcharts chart = new Highcharts("chart")
               .InitChart(new Chart { ZoomType = ZoomTypes.Xy })
               .SetTitle(new Title { Text = "klimatogram" })
               .SetSubtitle(new Subtitle { Text = "cont - land - loc" })
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
                        Max = 110
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
                        Max = 220
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
                        Data = new Data(new object[] { 49.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4 })
                    },
                    new Series
                    {
                        Name = "Temperatuur",
                        Color = ColorTranslator.FromHtml("#DE091E"),
                        Type = ChartTypes.Spline,
                        Data = new Data(new object[] { 7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6 })
                    }
                });

            return View(chart);
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