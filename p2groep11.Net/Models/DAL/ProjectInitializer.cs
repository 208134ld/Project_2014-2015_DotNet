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
                Continent azië = new Continent { Name = "Azië" };
                Continent afrika = new Continent { Name = "Afrika" };
                Continent noordCentraalAmerika = new Continent { Name = "Noord- en Centraal-Amerika" };
                Continent zuidAmerika = new Continent { Name = "Zuid-Amerika" };
                Continent oceanië = new Continent { Name = "Oceanië" };

                List<Continent> continents = (new Continent[] { europa, azië, afrika, noordCentraalAmerika, zuidAmerika, oceanië }).ToList();
                continents.ForEach(c => context.Continents.Add(c));

                //AFRIKA
                Country algerije = new Country { Name = "Algerije" };
                Country benin = new Country { Name = "Benin" };
                Country djibouti = new Country { Name = "Djibouti" };
                Country egypte = new Country { Name = "Egypte" };
                Country eritrea = new Country { Name = "Eritrea" };
                Country gabon = new Country { Name = "Gabon" };
                Country guinea = new Country { Name = "Guinea" };
                Country ivoorkust = new Country { Name = "Ivoorkust" };
                Country kaapverdië = new Country { Name = "Kaapverdië" };
                Country kenia = new Country { Name = "Kenia" };
                Country madagascar = new Country { Name = "Madagascar" };
                Country madeira = new Country { Name = "Madeira (Portugal)" };
                Country malawi = new Country { Name = "Malawi" };
                Country mali = new Country { Name = "Mali" };
                Country marokko = new Country { Name = "Marokko" };
                Country mauritius = new Country { Name = "Mauritius" };
                Country niger = new Country { Name = "Niger" };
                Country nigeria = new Country { Name = "Nigeria" };
                Country senegal = new Country { Name = "Senegal" };
                Country seychellen = new Country { Name = "Seychellen" };
                Country sierraLeone = new Country { Name = "Sierra Leone" };
                Country soedan = new Country { Name = "Soedan" };
                Country togo = new Country { Name = "Togo" };
                Country tsjaad = new Country { Name = "Tsjaad" };
                Country tunesië = new Country { Name = "Tunesië" };
                Country zambia = new Country { Name = "Zambia" };
                Country zimbabwe = new Country { Name = "Zimbabwe" };
                Country zuidAfrika = new Country { Name = "Zuid Afrika" };
                List<Country> countriesAfrika = (new Country[]
                {
                    algerije, benin, djibouti, egypte, eritrea, gabon, guinea,
                    ivoorkust, kaapverdië, kenia, madagascar, madeira, malawi,
                    mali, marokko, mauritius, niger, nigeria, senegal, seychellen,
                    sierraLeone, soedan, togo, tsjaad, tunesië, zambia, zimbabwe, zuidAfrika              
                }).ToList();
                countriesAfrika.ForEach(c => afrika.Countries.Add(c));


                Country belgië = new Country { Name = "België" };
                Country frankrijk = new Country {Name = "Frankrijk"};

                List<Country> countries = (new Country[] { belgië, frankrijk }).ToList();
                countries.ForEach(c => europa.Countries.Add(c));
                int []temps = new int[] { 10, 12, 12, 14, 15, 20, 28, 32, 28, 16, 6, 9 };
                int []sed = new[] { 120, 145, 200, 120, 150, 100, 140, 40, 100, 120, 130, 100 };
                ClimateChart gent = new ClimateChart("Gent", 1920, 1921,temps,sed);
                ClimateChart brugge = new ClimateChart("Brugge", 1550,1551,temps,sed);

                List<ClimateChart> climateCharts = (new ClimateChart[] { gent, brugge }).ToList();
                climateCharts.ForEach(c => belgië.ClimateCharts.Add(c));
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