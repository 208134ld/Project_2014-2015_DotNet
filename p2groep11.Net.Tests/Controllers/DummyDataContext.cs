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
       public  Continent Europa { get; private set; }

       public DummyDataContext()
       {
           Continent europa = new Continent();
           europa.ContinentID = 1;
           europa.Name = "Europa";
           Europa = europa;
           Continenten = new List<Continent>
                          {
                              europa
                          };
       }
    }
}
