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


                Grade grade1 = new Grade("Graad 1");
                Grade grade2 = new Grade("Graad 2");
                Grade grade3 = new Grade("Graad 3");
                List<Grade> grades = (new Grade[] { grade1, grade2, grade3 }).ToList();

                Continent europa = new Continent { Name = "Europa" };
                Continent azië = new Continent { Name = "Azië" };
                Continent afrika = new Continent { Name = "Afrika" };
                Continent noordCentraalAmerika = new Continent { Name = "Noord- en Centraal-Amerika" };
                Continent zuidAmerika = new Continent { Name = "Zuid-Amerika" };
                Continent oceanië = new Continent { Name = "Oceanië" };
                List<Continent> continents = (new Continent[] { europa, azië, afrika, noordCentraalAmerika, zuidAmerika, oceanië }).ToList();
                continents.ForEach(c => context.Continents.Add(c));

                continents.ForEach(c => c.GradeId = grade2);
                
                SchoolYear year1 = new SchoolYear(1, grade1);
                SchoolYear year2 = new SchoolYear(2, grade1);
                SchoolYear year3 = new SchoolYear(3, grade2);
                SchoolYear year4 = new SchoolYear(4, grade2);
                SchoolYear year5 = new SchoolYear(5, grade3);
                SchoolYear year6 = new SchoolYear(6, grade3);

                grade1.SchoolYearProp.Add(year1);
                grade1.SchoolYearProp.Add(year2);
                grade2.SchoolYearProp.Add(year3);
                grade2.SchoolYearProp.Add(year4);
                grade3.SchoolYearProp.Add(year5);
                grade3.SchoolYearProp.Add(year6);

                grade1.ContinentProp.Add(europa);
                continents.ForEach(c => grade2.ContinentProp.Add(c));
                continents.ForEach(c => grade3.ContinentProp.Add(c));

                grades.ForEach(g => context.Grades.Add(g));

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

                //AZIË
                Country afghanistan = new Country { Name = "Afghanistan" };
                Country azerbeidzjan = new Country { Name = "Azerbeidzjan" };
                Country bahrein = new Country { Name = "Bahrein" };
                Country china = new Country { Name = "China" };
                Country filippijnen = new Country { Name = "Filippijnen" };
                Country hongKong = new Country { Name = "Hong Kong, China" };
                Country indiaN = new Country { Name = "India (Noord)" };
                Country indiaZ = new Country { Name = "India (Zuid)" };
                Country iran = new Country { Name = "Iran" };
                Country israël = new Country { Name = "Israël" };
                Country japan = new Country { Name = "Japan" };
                Country jordanië = new Country { Name = "Jordanië" };
                Country katar = new Country { Name = "Katar" };
                Country kazachstan = new Country { Name = "Kazachstan" };
                Country kirgizië = new Country { Name = "Kirgizië" };
                Country koeweit = new Country { Name = "Koeweit" };
                Country libanon = new Country { Name = "Libanon" };
                Country malediven = new Country { Name = "Malediven" };
                Country maleisië = new Country { Name = "Maleisië" };
                Country mongolië = new Country { Name = "Mongolië" };
                Country myanmar = new Country { Name = "Myanmar" };
                Country noordKorea = new Country { Name = "Noord-Korea" };
                Country oezbekistan = new Country { Name = "Oezbekistan" };
                Country oman = new Country { Name = "Oman" };
                Country pakistan = new Country { Name = "Pakistan" };
                Country ru = new Country { Name = "Russische Federatie" };
                Country saudi = new Country { Name = "Saudi-Arabië" };
                Country singapore = new Country { Name = "Singapore" };
                Country sriLanka = new Country { Name = "Sri Lanka" };
                Country syrië = new Country { Name = "Syrië" };
                Country tadzjikistan = new Country { Name = "Tadzjikistan" };
                Country thailand = new Country { Name = "Thailand" };
                Country turkije = new Country { Name = "Turkije" };
                Country turkmenistan = new Country { Name = "Turkmenistan" };
                Country vae = new Country { Name = "Verenigde Arabische Emiraten" };
                Country vietnam = new Country { Name = "Vietnam" };
                Country laos = new Country { Name = "Volksrepubliek Laos" };
                Country zuidKorea = new Country { Name = "Zuid-Korea" };
                List<Country> countriesAzië = (new Country[]
                {
                    afghanistan, azerbeidzjan, bahrein, china, filippijnen, hongKong, indiaN, indiaZ, iran, israël, japan, jordanië, katar, kazachstan, kirgizië,
                    koeweit, libanon, malediven, maleisië, mongolië, myanmar, noordKorea, oezbekistan, oman, pakistan, ru, saudi, singapore, sriLanka, syrië,
                    tadzjikistan, thailand, turkije, turkmenistan, vae, vietnam, laos, zuidKorea
                }).ToList();
                countriesAzië.ForEach(c => azië.Countries.Add(c));

                //EUROPA
                Country belgië = new Country { Name = "België" };
                Country bosnië = new Country { Name = "Bosnië-Hercegovina" };
                Country bulgarije = new Country { Name = "Bulgarije" };
                Country cyprus = new Country { Name = "Cyprus" };
                Country denemarken = new Country { Name = "Denemarken" };
                Country duitsland = new Country { Name = "Duitsland" };
                Country estland = new Country { Name = "Estland" };
                Country finland = new Country { Name = "Finland" };
                Country fr = new Country { Name = "Frankrijk" };
                Country lux = new Country { Name = "Luxemburg" };
                Country georgië = new Country { Name = "Georgië" };
                Country griekenland = new Country { Name = "Griekenland" };
                Country groenland = new Country { Name = "Groenland" };
                Country hongarije = new Country { Name = "Hongarije" };
                Country ierland = new Country { Name = "Ierland" };
                Country ijsland = new Country { Name = "Ijsland" };
                Country italië = new Country { Name = "Italië" };
                Country kroatië = new Country { Name = "Kroatië" };
                Country letland = new Country { Name = "Letland" };
                Country lithouwen = new Country { Name = "Lithouwen" };
                Country macedonië = new Country { Name = "Macedonië" };
                Country malta = new Country { Name = "Malta" };
                Country moldavië = new Country { Name = "Moldavische Republiek" };
                Country ned = new Country { Name = "Nederland" };
                Country noorwegen = new Country { Name = "Noorwegen" };
                Country oekraïne = new Country { Name = "Oekraïne" };
                Country oostenrijk = new Country { Name = "Oostenrijk" };
                Country polen = new Country { Name = "Polen" };
                Country portugal = new Country { Name = "Portugal" };
                Country roemenië = new Country { Name = "Roemenië" };
                Country russischeFed = new Country { Name = "Russische Federatie" };
                Country servië = new Country { Name = "Servië en Montenegro" };
                Country slovenië = new Country { Name = "Slovenië" };
                Country slowakije = new Country { Name = "Slowakije" };
                Country spanje = new Country { Name = "Spanje" };
                Country spanjeEilanden = new Country { Name = "Spanje (Canarische Eilanden)" };
                Country tsjechië = new Country { Name = "Tsjechië" };
                Country vk = new Country { Name = "Verenigd Koninkrijk" };
                Country zweden = new Country { Name = "Zweden" };
                Country zwitserland = new Country { Name = "Zwitserland" };
                List<Country> countriesEU = (new Country[]
                {
                    belgië, bosnië, bulgarije, cyprus, denemarken, duitsland, estland, finland, fr, lux, georgië, griekenland, groenland, hongarije, ierland, ijsland, italië, kroatië,
                    letland, lithouwen, macedonië, malta, moldavië, ned, noorwegen, oekraïne, oostenrijk, polen, portugal, roemenië, russischeFed, servië, slovenië, slowakije, spanje,
                    spanjeEilanden, tsjechië, vk, zweden, zwitserland
                }).ToList();
                countriesEU.ForEach(c => europa.Countries.Add(c));

                //Noord en centraan Amerika
                Country bahamas = new Country { Name = "Bahamas" };
                Country canada = new Country { Name = "Canada" };
                Country costa = new Country { Name = "Costa Rica" };
                Country cuba = new Country { Name = "Cuba" };
                Country doReMii = new Country { Name = "Dominkaanse Republiek" };
                Country salvador = new Country { Name = "El alvador" };
                Country guadeloupe = new Country { Name ="Guadeloupe" };
                Country honduras = new Country { Name = "Honduras" };
                Country mehico = new Country { Name = "Mexico" };
                Country aruba = new Country { Name = "Nederlandse Antillen en Aruba" };
                Country nicaragua = new Country { Name = "Nicaragua" };
                Country tobago = new Country { Name = "Trinidad en Tobago" };
                Country vs = new Country { Name = "Verenigde Staten" };
                List<Country> countriesVS = (new Country[]
                {
                    bahamas, canada, costa, cuba, doReMii, salvador, guadeloupe, honduras, mehico, aruba, nicaragua, tobago, vs
                }).ToList();
                countriesVS.ForEach(c => noordCentraalAmerika.Countries.Add(c));

                //Ocieaië
                Country au = new Country { Name = "Australië" };
                Country fiji = new Country { Name = "Fiji" };
                Country poly = new Country { Name = "Frans Polynesië" };
                Country celedonië = new Country { Name = "Nieuw Celedonië" };
                Country newZ = new Country { Name = "Nieuw Zeeland" };
                List<Country> countriesOceanië = (new Country[]
                {
                    au, fiji, poly, celedonië, newZ
                }).ToList();
                countriesOceanië.ForEach(c => oceanië.Countries.Add(c));

                //ZUID_AMERIKA HYPEEE
                Country argentinië = new Country { Name = "Argentinië" };
                Country brbrbr = new Country { Name = "Brazillië" };
                Country chili = new Country { Name = "Chili" };
                Country colombia = new Country { Name = "Colombia" };
                Country acuador = new Country { Name = "Ecuador" };
                Country fransGuyana = new Country { Name = "Frans Guyana" };
                Country guyana = new Country { Name = "Guyana" };
                Country paraguay = new Country { Name = "Paraguay" };
                Country peru = new Country { Name = "Peru" };
                Country uruguay = new Country { Name = "Uruguay" };
                Country vanazuala = new Country { Name = "Venezuela" };
                List<Country> countriesZAM = (new Country[]
                {
                    argentinië, brbrbr, chili, colombia, acuador, fransGuyana, guyana, paraguay, peru, uruguay, vanazuala
                }).ToList();
                countriesZAM.ForEach(c => zuidAmerika.Countries.Add(c));
                
                //DeterminateTable aanmaken met hun clauses
                //De parameters hun waarde is bijvoorbeeld de temperatuur van de warmste maand, nu voorlopig zonder database dus nog niet nodig
                Parameter tw = new TW();
                Parameter tj = new TJ();
                Parameter nj = new NJ();
                Parameter tk = new TK();
                Parameter d = new D();
                Parameter nz = new NZ();
                Parameter nw = new NW();

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

                DeterminateTable detTable1 = new DeterminateTable(tw10);


                grade1.DeterminateTableProp = detTable1;
                grade2.DeterminateTableProp = detTable1;
                grade3.DeterminateTableProp = detTable1;

                //_______________
                int[] temps = new int[] { 10, 12, 12, 14, 15, 20, 28, 32, 28, 16, 6, 9 };
                int[] sed = new[] { 120, 145, 200, 120, 150, 100, 140, 40, 100, 120, 130, 100 };
                int[] temps2 = new int[] { 10, -12, -12, -14, -15, -20, 28, 32, 28, 16, 6, 9 };
                int[] sed2 = new[] { 120, 145, 200, 120, 150, 100, 140, 40, 100, 120, 130, 100 };
                ClimateChart gent = new ClimateChart("Gent", 1920, 1921, temps, sed);
                ClimateChart brugge = new ClimateChart("Brugge", 1550, 1551, temps2, sed2);
                


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