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

        public ClimateChartController(IContinentRepository continentRepository)
        {
            this.continentRepository = continentRepository;
        }
        
        public ActionResult ShowClimateChart(int selectedYear,int continentId,int countryId,int climateId)
        {
            @ViewBag.SchoolYear = selectedYear;
            if(ModelState.IsValid)
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
            //determinatetable aanmaken, efkes zonder database werken
            Parameter tw = new Parameter(0, "TW");
            Parameter tj = new Parameter(0, "TJ");
            Parameter nj = new Parameter(0, "NJ");
            Parameter tk = new Parameter(0, "TK");
            Parameter d = new Parameter(0, "D");
            Parameter nz = new Parameter(0, "NZ");
            Parameter nw = new Parameter(0, "NW");


            ClauseComponent tw10 = new Clause("TW <= 10", tw, 10);
            ClauseComponent tw0 = new Clause("TW <= 0", tw, 0);
            ClauseComponent tw0Yes = new Result("Koud klimaat zonder dooiseizoen", "Ijswoestijnklimaat");
            ClauseComponent tw0No = new Result("Koud klimaat met dooiseizoen", "Toendraklimaat");
            tw0.Add(true, tw0Yes);
            tw0.Add(false, tw0No);
            tw10.Add(true, tw0);
            ClauseComponent tj0 = new Clause("TJ <= 0", tj, 0);
            tw10.Add(false, tj0);


            ClauseComponent tj0Yes = new Result("Koudgematigd klimaat met strenge winter", "Taigaklimaat");
            tj0.Add(true, tj0Yes);
            ClauseComponent nj200 = new Clause("NJ <= 200", nj, 200);
            


            ClauseComponent tk15 = new Clause("TK <= 15", tk, 15);
            ClauseComponent tk15Yes = new Result("Gematigd altijd droog klimaat", "Woestijnklimaat van de middelbreedten");
            ClauseComponent tk15No = new Result("Warm altijd droog klimaat", "Woestijnklimaat van de tropen");
            tk15.Add(true, tk15Yes);
            tk15.Add(false, tk15Yes);
            nj200.Add(true, tk15);
            tj0.Add(false, nj200);


            ClauseComponent tk18 = new Clause("TK <= 18", tk, 18);
            ClauseComponent nj400 = new Clause("NJ <= 400", nj, 400);
            ClauseComponent nj400Yes = new Result("Gematigd, droog klimaat", "Steppeklimaat");
            ClauseComponent tk10N = new Clause("TK <= -10", tk, -10);
            ClauseComponent tk10NYes = new Result("Koudgematigd klimaat met strenge winter", "Taigaklimaat");
            ClauseComponent d1 = new Clause("D <= 1", d, 1);
            ClauseComponent tk3N = new Clause("TK <= -3", tk, -3);
            ClauseComponent tk3NYes = new Result("Koelgematigd klimaat met koude winter", "Gemengd-woudklimaat");
            ClauseComponent tw22 = new Clause("TW <= 22", tw, 22);
            ClauseComponent tw22Yes = new Result("Koelgematigd klimaat met zachte winter", "Loofbosklimaat");
            ClauseComponent tw22No = new Result("Warmgematigd altijd nat klimaat", "Subtropisch regenwoudklimaat");
            ClauseComponent nznw = new Clause("NZ <= NW", nz, nw);
            ClauseComponent tw222 = new Clause("TW <= 22", tw, 22);
            ClauseComponent tw222Yes = new Result("Koelgematigd klimaat met natte winter", "Hardbladige-vegetatieklimaat van de centrale middelbreedten");
            ClauseComponent tw222No = new Result("Warmgematigd klimaat met natte winter", "Hardbladige-vegetatieklimaat van de subtropen");
            ClauseComponent nznwNo = new Result("Warmgematigd klimaat met natte zomer", "Subtropisch savanneklimaat");

            tw222.Add(true, tw222Yes);
            tw222.Add(false, tw222No);
            nznw.Add(true, tw222);
            nznw.Add(false, nznwNo);
            tw22.Add(true, tw22Yes);
            tw22.Add(false, tw22No);
            tk3N.Add(true, tk3NYes);
            tk3N.Add(false, tw22);
            d1.Add(true, tk3N);
            d1.Add(false, nznw);
            tk10N.Add(true, tk10NYes);
            tk10N.Add(false, d1);
            nj400.Add(true, nj400Yes);
            nj400.Add(false, tk10N);
            tk18.Add(true, nj400);
            nj200.Add(false, tk18);

            ClauseComponent d12 = new Clause("D <= 1", d, 1);
            ClauseComponent d12Yes = new Result("Warm klimaat met nat seizoen", "Tropisch savanneklimaat");
            ClauseComponent d12No = new Result("Warm altijd nat klimaat", "Tropisch regenwoudklimaat");
            d12.Add(true, d12Yes);
            d12.Add(false, d12No);
            tk18.Add(false, d12);

            DeterminateTable table = new DeterminateTable(tw10);



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
                        Max = c.CalculateMaxForChart()/2,
                        Min = c.CalculateMinForChart()
                        
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
                        Max = c.CalculateMaxForChart(),
                        Min = c.CalculateMinForChart()*2
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

            return new ClimateChartViewModel(chart,c.Months, table);
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