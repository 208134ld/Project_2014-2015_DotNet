using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Tests.Controllers
{
   public class DummyDataContext
   {
       public IList<Continent> Continenten { get; set; }
       public IList<Country> Countries { get; set; }
       public IList<ClimateChart> ClimateCharts { get; set; }
       public Continent Europa { get; set; }
       public Country Belgium { get; private set; }
       public Country England { get; private set; }
       public ClimateChart Gent { get; private set; }
       public Grade Graad { get; private set; }
       public ClimateChart NegTempClimateChart { get; private set; }
       public DeterminateTable DetTable { get; private set; }
       public DeterminateTable DetTable2 { get; set; }
       public DeterminateTable DetTable3  { get; set; }
       public DeterminateTable DetTable4 { get; set; }

       public DummyDataContext()
       {
           
           Europa = new Continent();
           Europa.ContinentID = 1;
           Europa.Name = "Europa";

           Graad = new Grade(1);
          
           Belgium = new Country("Belgie",Europa);
           England = new Country("England",Europa);
           Belgium.CountryID = 1;
           England.CountryID = 2;
           //Belgium.AboveEquator = true;
           //England.AboveEquator = false; //voor te testen. England ligt obviously boven de Equator
           int[] temp = new int[]{1,5,3,4,5,6,7,8,9,10,40,12};
           int[] sed = new int[] {10, 206, 30, 200, 50, 60, 70, 80, 20, 100, 110, 120};
           int[] temp2 = new int[] { 1, 2, 3, 0, -10, -12, 7, 8, 9, 10, 11, 12 };
           int[] sed2 = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120 };
           NegTempClimateChart = new ClimateChart("Chelsea",2000,2030,temp2,sed2, -20, 10);
           NegTempClimateChart.Country = England;
           NegTempClimateChart.ClimateChartID = 2;
           England.ClimateCharts = new List<ClimateChart>{NegTempClimateChart};
           Gent = new ClimateChart("gent",1950,1960,temp,sed, 55, 6);
           Gent.Country = Belgium;
           Gent.ClimateChartID = 1;
           ClimateCharts = new List<ClimateChart>{ Gent };
           Belgium.ClimateCharts = ClimateCharts;  
           Countries = new List<Country>{ Belgium,England };
           Europa.Countries = Countries;
           Continenten = new List<Continent>{ Europa };
           Graad.Continents = Continenten;
           Parameter tw = new TW("Wat is de temperatuur van de warmste maand (TW)?");
           ClauseComponent tw10 = new Clause("TW <= 10", tw, "<=", 10);
           ClauseComponent CC2 = new Clause("TW <= 10", tw, "<", 10);
           ClauseComponent CC3 = new Clause("TW <= 10", tw, ">=", 10);
           ClauseComponent CC4 = new Clause("TW <= 10", tw, ">", 10);
           ClauseComponent res1 = new Result("YES", "geen woestijn");
           ClauseComponent res2 = new Result("NO", "woestijn");
           tw10.ClauseComponentId = 1;
           res1.ClauseComponentId = 2;
           res2.ClauseComponentId = 3;
           tw10.Add(true, res1);
           tw10.Add(false, res2);
           CC2.Add(true, res1);
           CC2.Add(false, res2);
           CC3.Add(true, res1);
           CC3.Add(false, res2);
           CC4.Add(true, res1);
           CC4.Add(false, res2);
           DetTable = new DeterminateTable(tw10);
           DetTable.ClauseComponent = tw10;
           DetTable2 = new DeterminateTable(CC2);
           DetTable2.ClauseComponent = CC2;
           DetTable3 = new DeterminateTable(CC3);
           DetTable3.ClauseComponent = CC3;
           DetTable4 = new DeterminateTable(CC4);
           DetTable4.ClauseComponent = CC4;
           Graad.DeterminateTableProp = DetTable;
       }
    }
}
