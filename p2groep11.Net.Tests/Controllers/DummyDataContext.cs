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
       public  IList<Continent> Continenten { get; set; }
       public IList<Country> Countries { get; set; }
       public IList<ClimateChart> ClimateCharts { get; set; }
       public  Continent Europa { get; private set; }
       public Country Belgium { get; private set; }
       public Country England { get; private set; }
       public ClimateChart Gent { get; private set; }

       public DummyDataContext()
       {
           Europa = new Continent();
           Europa.ContinentID = 1;
           Europa.Name = "Europa";
          
           Belgium = new Country(1,"Belgie",Europa);
           England = new Country(2,"England",Europa);
           int[] temp = new int[]{1,2,3,4,5,6,7,8,9,10,11,12};
           int[] sed = new int[] {10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120};
           Gent = new ClimateChart("gent",1950,1960,temp,sed);
           Gent.Country = Belgium;
           ClimateCharts = new List<ClimateChart>
           {
               Gent
           };
           Belgium.ClimateCharts = ClimateCharts;
           Europa.Countries = Countries;
           Countries = new List<Country>
           {
               Belgium,England
           };
            Continenten = new List<Continent>
                          {
                              Europa
                          };
       }
    }
}
