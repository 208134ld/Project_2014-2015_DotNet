using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using p2groep11.Net.Models.Domain;
using WebGrease.Css.Extensions;

namespace p2groep11.Net.Models.DAL
{
    public class ProjectInitializer : DropCreateDatabaseAlways<ProjectContext>
    {
        protected override void Seed(ProjectContext context)
        {
            try
            {
                Continent europa = new Continent { Name = "Europa" };
                //Continent azië = new Continent { Name = "Azië" };
                //Continent afrika = new Continent { Name = "Afrika" };
                //Continent noordCentraalAmerika = new Continent { Name = "Noord- en Centraal-Amerika" };
                //Continent zuidAmerika = new Continent { Name = "Zuid-Amerika" };
                //Continent oceanië = new Continent { Name = "Oceanië" };

                //List<Continent> continents = (new Continent[] { europa, azië, afrika, noordCentraalAmerika, zuidAmerika, oceanië }).ToList();
                //continents.ForEach(c => context.Continents.Add(c));
                context.Continents.Add(europa);
                Country belgië = new Country { Name = "België" };
                Country frankrijk = new Country {Name = "Frankrijk"};

                List<Country> countries = (new Country[] { belgië, frankrijk }).ToList();
                countries.ForEach(c => europa.Countries.Add(c));
                ClimateChart gent = new ClimateChart("Gent", 15, 19);
                ClimateChart brugge = new ClimateChart("Brugge", 1550, 1580);

                List<ClimateChart> climateCharts = (new ClimateChart[] { gent, brugge }).ToList();
                climateCharts.ForEach(c => belgië.ClimateCharts.Add(c));

                //Month maart2014 = new Month(3, 15, 195);
                //Month maart2015 = new Month(3, 25, 208);

                //List<Month> months = (new Month[] { maart2014, maart2015 }).ToList();
                //months.ForEach(m => gent.Months.Add(m));
                context.SaveChanges();
                System.Diagnostics.Debug.WriteLine("Database created!");                                
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine("Een error in initializer");
            }
            
        }
    }
}