using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using p2groep11.Net.Models;
using p2groep11.Net.Models.DAL;
using p2groep11.Net.Models.Domain;
using p2groep11.Net.ViewModels;
using Point = DotNet.Highcharts.Options.Point;

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
        
        public ActionResult ShowClimateChart(int selectedYear,int continentId,int countryId,int climateId)
        {
            @ViewBag.SchoolYear = selectedYear;
            if (ModelState.IsValid)
            {
                try
                {
                    ClimateChart c = continentRepository.FindClimateChartById(continentId,countryId, climateId);
                    ClimateChartViewModel cViewModel = DrawClimateChart(c);
                    return View(cViewModel);
                }
                catch (SqlException sqlExc)
                {
                    ModelState.AddModelError("", "Connection lost with the database \n" + sqlExc.Message);

                }
                catch (NullReferenceException nullEx)
                {
                    ModelState.AddModelError("",
                        "Could not find the climateChart associated with this continentId or countryId or climateId \n" +
                        nullEx.Message);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("",e.Message);
                }
            }
            return RedirectToAction("Index","SchoolYear");
        }
        #region privateMethods
        private ClimateChartViewModel DrawClimateChart(ClimateChart climateChart)
        {
            ClimateChart c = climateChart;
            int m = c.CalculateMaxForChart();
            int[] sed = c.Months.Select(p => p.Sediment).ToArray();
            int[] tem = c.Months.Select(p => p.AverTemp).ToArray();
            Object[] sediments = new object[12];
            Object[] temp = new object[12];
            CopyIntArrayToObjectArray(sed, sediments);
            CopyIntArrayToObjectArray(tem, temp);
            Highcharts chart = new Highcharts("chart")
               .InitChart(new Chart { ZoomType = ZoomTypes.Xy })
               .SetTitle(new Title { Text = "klimatogram " + c.Location + " (" + c.Country.Name + ")" })
               .SetSubtitle(new Subtitle { Text = c.BeginPeriod + " - " + c.EndPeriod })
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
                        Max = c.CalculateMaxForChart()/2
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
                        Max = c.CalculateMaxForChart()
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

            return new ClimateChartViewModel(chart,c.Months);
        }

        private void CopyIntArrayToObjectArray(int [] intArray,Object[] objectAr)
        {
            intArray.CopyTo(objectAr,0);
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
        #endregion
    }
}