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
           Belgium.AboveEquator = true;
           England.AboveEquator = false; //voor te testen. England ligt obviously boven de Equator
           int[] temp = new int[]{1,2,3,4,5,6,7,8,9,10,11,12};
           int[] sed = new int[] {10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120};
           int[] temp2 = new int[] { 1, 2, 3, 0, -10, -5, 7, 8, 9, 10, 11, 12 };
           int[] sed2 = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120 };
           NegTempClimateChart = new ClimateChart("Chelsea",2000,2030,temp2,sed2);
           NegTempClimateChart.Country = England;
           NegTempClimateChart.ClimateChartID = 2;
           England.ClimateCharts = new List<ClimateChart>{NegTempClimateChart};
           Gent = new ClimateChart("gent",1950,1960,temp,sed);
           Gent.Country = Belgium;
           Gent.ClimateChartID = 1;
           ClimateCharts = new List<ClimateChart>{ Gent };
           Belgium.ClimateCharts = ClimateCharts;  
           Countries = new List<Country>{ Belgium,England };
           Europa.Countries = Countries;
           Continenten = new List<Continent>{ Europa };
           Graad.Continents = Continenten;
       }
    }
}
