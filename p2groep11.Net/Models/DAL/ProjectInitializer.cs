using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using p2groep11.Net.Models.Domain;
using Image = System.Drawing.Image;
using Parameter = p2groep11.Net.Models.Domain.Parameter;

namespace p2groep11.Net.Models.DAL
{
    public class ProjectInitializer :  CreateDatabaseIfNotExists<ProjectContext>
    {
        protected override void Seed(ProjectContext context)
        {
            try
            {
                // GRADES
                Grade grade1 = new Grade(1);
                Grade grade2 = new Grade(2);
                Grade grade3 = new Grade(3);
                List<Grade> grades = (new Grade[] {grade1, grade2, grade3}).ToList();

                

                // CONTINENTS
                Continent europa = new Continent("Europa");
                Continent azië = new Continent("Azië");
                Continent afrika = new Continent("Afrika");
                Continent noordCentraalAmerika = new Continent("Noord- en Centraal-Amerika");
                Continent zuidAmerika = new Continent("Zuid-Amerika");
                Continent oceanië = new Continent("Oceanië");
                List<Continent> continents =
                    (new Continent[] {europa, azië, afrika, noordCentraalAmerika, zuidAmerika, oceanië}).ToList();

                grade1.Continents.Add(europa);
                continents.ForEach(c => grade2.Continents.Add(c));
                continents.ForEach(c => grade3.Continents.Add(c));

                grades.ForEach(g => context.Grades.Add(g));

                //AFRIKA
                Country algerije = new Country ("Algerije");
                Country benin = new Country ( "Benin");
                Country congo = new Country ("Congo");
                Country djibouti = new Country ("Djibouti");
                Country egypte = new Country ("Egypte");
                Country eritrea = new Country ("Eritrea");
                Country gabon = new Country ("Gabon");
                Country guinea = new Country ("Guinea");
                Country ivoorkust = new Country ("Ivoorkust");
                Country kaapverdië = new Country ("Kaapverdië");
                Country kenia = new Country ("Kenia");
                Country madagascar = new Country ("Madagascar");
                Country madeira = new Country ("Madeira (Portugal)");
                Country malawi = new Country ("Malawi");
                Country mali = new Country ("Mali");
                Country marokko = new Country ("Marokko");
                Country mauritius = new Country ("Mauritius");
                Country niger = new Country ("Niger");
                Country nigeria = new Country ("Nigeria");
                Country senegal = new Country ("Senegal");
                Country seychellen = new Country ("Seychellen");
                Country sierraLeone = new Country ("Sierra Leone");
                Country soedan = new Country ("Soedan");
                Country togo = new Country ("Togo");
                Country tsjaad = new Country ("Tsjaad");
                Country tunesië = new Country ("Tunesië");
                Country zambia = new Country ("Zambia");
                Country zimbabwe = new Country ("Zimbabwe");
                Country zuidAfrika = new Country ("Zuid Afrika");
                List<Country> countriesAfrika = (new Country[]
                {
                    algerije, benin, congo, djibouti, egypte, eritrea, gabon, guinea,
                    ivoorkust, kaapverdië, kenia, madagascar, madeira, malawi,
                    mali, marokko, mauritius, niger, nigeria, senegal, seychellen,
                    sierraLeone, soedan, togo, tsjaad, tunesië, zambia, zimbabwe, zuidAfrika              
                }).ToList();
                countriesAfrika.ForEach(c => afrika.Countries.Add(c));

                //AZIË
                Country afghanistan = new Country ("Afghanistan");
                Country azerbeidzjan = new Country ("Azerbeidzjan");
                Country bahrein = new Country ("Bahrein");
                Country china = new Country ("China");
                Country filippijnen = new Country ("Filippijnen");
                Country hongKong = new Country ("Hong Kong, China");
                Country indiaN = new Country ("India (Noord)");
                Country indiaZ = new Country ("India (Zuid)");
                Country iran = new Country ("Iran");
                //Country israël = new Country ("Israël"};
                //Country japan = new Country {Name = "Japan"};
                //Country jordanië = new Country {Name = "Jordanië"};
                //Country katar = new Country {Name = "Katar"};
                //Country kazachstan = new Country {Name = "Kazachstan"};
                //Country kirgizië = new Country {Name = "Kirgizië"};
                //Country koeweit = new Country {Name = "Koeweit"};
                //Country libanon = new Country {Name = "Libanon"};
                //Country malediven = new Country {Name = "Malediven"};
                //Country maleisië = new Country {Name = "Maleisië"};
                //Country mongolië = new Country {Name = "Mongolië"};
                //Country myanmar = new Country {Name = "Myanmar"};
                //Country noordKorea = new Country {Name = "Noord-Korea"};
                //Country oezbekistan = new Country {Name = "Oezbekistan"};
                //Country oman = new Country {Name = "Oman"};
                //Country pakistan = new Country {Name = "Pakistan"};
                //Country ru = new Country {Name = "Russische Federatie"};
                //Country saudi = new Country {Name = "Saudi-Arabië"};
                //Country singapore = new Country {Name = "Singapore"};
                //Country sriLanka = new Country {Name = "Sri Lanka"};
                //Country syrië = new Country {Name = "Syrië"};
                //Country tadzjikistan = new Country {Name = "Tadzjikistan"};
                //Country thailand = new Country {Name = "Thailand"};
                //Country turkije = new Country {Name = "Turkije"};
                //Country turkmenistan = new Country {Name = "Turkmenistan"};
                //Country vae = new Country {Name = "Verenigde Arabische Emiraten"};
                //Country vietnam = new Country {Name = "Vietnam"};
                //Country laos = new Country {Name = "Volksrepubliek Laos"};
                //Country zuidKorea = new Country {Name = "Zuid-Korea"};
                List<Country> countriesAzië = (new Country[]
                {
                    afghanistan, azerbeidzjan, bahrein, china, filippijnen, hongKong, indiaN, indiaZ, iran
                    //, 
                    //israël,
                    //japan, jordanië, katar, kazachstan, kirgizië,
                    //koeweit, libanon, malediven, maleisië, mongolië, myanmar, noordKorea, oezbekistan, oman, pakistan,
                    //ru, saudi, singapore, sriLanka, syrië,
                    //tadzjikistan, thailand, turkije, turkmenistan, vae, vietnam, laos, zuidKorea
                }).ToList();
                countriesAzië.ForEach(c => azië.Countries.Add(c));

                //EUROPA
                Country belgië = new Country("België");
                Country bosnië = new Country ("Bosnië-Hercegovina");
                Country bulgarije = new Country ("Bulgarije");
                Country cyprus = new Country ("Cyprus");
                Country denemarken = new Country ("Denemarken");
                Country duitsland = new Country ("Duitsland");
                Country estland = new Country ("Estland");
                Country finland = new Country ("Finland");
                Country fr = new Country ("Frankrijk");
                Country lux = new Country ("Luxemburg");
                Country georgië = new Country ("Georgië");
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
                    belgië, bosnië, bulgarije, cyprus, denemarken, duitsland, estland, finland, fr, lux, georgië,
                    griekenland, groenland, hongarije, ierland, ijsland, italië, kroatië,
                    letland, lithouwen, macedonië, malta, moldavië, ned, noorwegen, oekraïne, oostenrijk, polen,
                    portugal, roemenië, russischeFed, servië, slovenië, slowakije, spanje,
                    spanjeEilanden, tsjechië, vk, zweden, zwitserland
                }).ToList();
                countriesEU.ForEach(c => europa.Countries.Add(c));

                //Noord en centraan Amerika
                Country bahamas = new Country ("Bahamas");
                Country canada = new Country ("Canada");
                Country costa = new Country ("Costa Rica");
                Country cuba = new Country ("Cuba");
                Country doReMii = new Country ("Dominicaanse Republiek");
                Country salvador = new Country ("El Salvador");
                Country guadeloupe = new Country ("Guadeloupe");
                Country honduras = new Country ("Honduras");
                Country mehico = new Country ("Mexico");
                Country aruba = new Country ("Nederlandse Antillen en Aruba");
                Country nicaragua = new Country ("Nicaragua");
                Country tobago = new Country ("Trinidad en Tobago");
                Country vs = new Country ("Verenigde Staten");
                List<Country> countriesVS = (new Country[]
                {
                    bahamas, canada, costa, cuba, doReMii, salvador, guadeloupe, honduras, mehico, aruba, nicaragua,
                    tobago, vs
                }).ToList();
                countriesVS.ForEach(c => noordCentraalAmerika.Countries.Add(c));

                //Ocieaië
                Country au = new Country ("Australië");
                Country fiji = new Country ("Fiji");
                Country poly = new Country ("Frans Polynesië");
                Country celedonië = new Country ("Nieuw Celedonië");
                Country newZ = new Country ("Nieuw Zeeland");
                List<Country> countriesOceanië = (new Country[]
                {
                    au, fiji, poly, celedonië, newZ
                }).ToList();
                countriesOceanië.ForEach(c => oceanië.Countries.Add(c));

                //ZUID_AMERIKA
                Country argentinië = new Country ("Argentinië");
                Country brbrbr = new Country ("Brazilië");
                Country chili = new Country ("Chili");
                Country colombia = new Country ("Colombia");
                Country acuador = new Country ("Ecuador");
                Country fransGuyana = new Country ("Frans Guyana");
                Country guyana = new Country ("Guyana");
                Country paraguay = new Country ("Paraguay");
                Country peru = new Country ("Peru");
                Country uruguay = new Country ("Uruguay");
                Country vanazuala = new Country ("Venezuela");
                List<Country> countriesZAM = (new Country[]
                {
                    argentinië, brbrbr, chili, colombia, acuador, fransGuyana, guyana, paraguay, peru, uruguay,
                    vanazuala
                }).ToList();
                countriesZAM.ForEach(c => zuidAmerika.Countries.Add(c));
                
                //DeterminateTable aanmaken met hun clauses
                //De parameters hun waarde is bijvoorbeeld de temperatuur van de warmste maand, nu voorlopig zonder database dus nog niet nodig
                Parameter mw = new MW("Wat is de warmste maand?");
                Parameter tw = new TW("Wat is de temeperatuur van de warmste maand (TW)?");
                Parameter mk = new MK("Wat is de temperatuur van de koudste maand?");
                Parameter tk = new TK("Wat is de temperatuur van de koudste maand (TK)?");
                Parameter d = new D("Hoeveel droge maanden zijn er?");
                Parameter nz = new NZ("Hoeveelheid neerslag in de zomer?");
                Parameter nw = new NW("Hoeveelheid neerslag in de winter?");
                Parameter tj = new TJ("");
                Parameter nj = new NJ("");
                Parameter tm = new TM("");

                //VragenLijst
                QuestionList list = new QuestionList();
                List<Parameter> parameters = (new Parameter[]
                {
                    mw, tw, mk, tk, d, nz, nw
                }).ToList();
                parameters.ForEach(p => list.Parameters.Add(p));

                grade1.QuestionListProp = list;
                grade2.QuestionListProp = list;
                grade3.QuestionListProp = list;

                // SCHOOLYEARS
                SchoolYear year1 = new SchoolYear(1);
                SchoolYear year2 = new SchoolYear(2);
                SchoolYear year3 = new SchoolYear(3);
                SchoolYear year4 = new SchoolYear(4);
                SchoolYear year5 = new SchoolYear(5);
                SchoolYear year6 = new SchoolYear(6);

                grade1.SchoolYears.Add(year1);
                grade1.SchoolYears.Add(year2);
                grade2.SchoolYears.Add(year3);
                grade2.SchoolYears.Add(year4);
                grade3.SchoolYears.Add(year5);
                grade3.SchoolYears.Add(year6);

                //Pictures aanmaken
                Image image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/img/ijswoestijn.JPG"));
                MemoryStream ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);
                byte[] picture1 = ms.ToArray();

                image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/img/toendra.JPG"));
                ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);
                byte[] picture2 = ms.ToArray();

                image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/img/taiga.JPG"));
                ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);
                byte[] picture3 = ms.ToArray();

                image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/img/woestijnklimaatmiddelbreedten.JPG"));
                ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);
                byte[] picture4 = ms.ToArray();

                image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/img/woestijnklimaattropen.JPG"));
                ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);
                byte[] picture5 = ms.ToArray();

                image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/img/steppeklimaat.JPG"));
                ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);
                byte[] picture6 = ms.ToArray();

                image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/img/gemengdwoud.JPG"));
                ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);
                byte[] picture8 = ms.ToArray();

                image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/img/loofbos.JPG"));
                ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);
                byte[] picture9 = ms.ToArray();

                image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/img/subtropischregenwoud.JPG"));
                ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);
                byte[] picture10 = ms.ToArray();

                image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/img/hardbladigemiddelbreedten.JPG"));
                ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);
                byte[] picture11 = ms.ToArray();

                image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/img/hardbladigesubtropen.JPG"));
                ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);
                byte[] picture12 = ms.ToArray();

                image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/img/subtropischsavanne.JPG"));
                ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);
                byte[] picture13 = ms.ToArray();

                image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/img/tropischsavanne.JPG"));
                ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);
                byte[] picture14 = ms.ToArray();

                image = Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/img/tropischregenwoud.JPG"));
                ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);
                byte[] picture15 = ms.ToArray();

                
                //ClauseComponents
                ClauseComponent tw10 = new Clause("TW <= 10", tw,"<=", 10);
                ClauseComponent tw0 = new Clause("TW <= 0", tw,"<=", 0);
                ClauseComponent tw0Yes = new Result("Koud klimaat zonder dooiseizoen", "Ijswoestijnklimaat", picture1);
                ClauseComponent tw0No = new Result("Koud klimaat met dooiseizoen", "Toendraklimaat", picture2);
                tw0.Add(true, tw0Yes);
                tw0.Add(false, tw0No);
                tw10.Add(true, tw0);
                ClauseComponent tj0 = new Clause("TJ <= 0", tj,"<=", 0);
                tw10.Add(false, tj0);


                ClauseComponent tj0Yes = new Result("Koudgematigd klimaat met strenge winter", "Taigaklimaat", picture3);
                tj0.Add(true, tj0Yes);
                ClauseComponent nj200 = new Clause("NJ <= 200", nj,"<=", 200);

                ClauseComponent tk15 = new Clause("TK <= 15", tk,"<=", 15);
                ClauseComponent tk15Yes = new Result("Gematigd altijd droog klimaat", "Woestijnklimaat van de middelbreedten", picture4);
                ClauseComponent tk15No = new Result("Warm altijd droog klimaat", "Woestijnklimaat van de tropen", picture5);
                tk15.Add(true, tk15Yes);
                tk15.Add(false, tk15No);
                nj200.Add(true, tk15);
                tj0.Add(false, nj200);

                ClauseComponent tk18 = new Clause("TK <= 18", tk,"<=", 18);
                ClauseComponent nj400 = new Clause("NJ <= 400", nj,"<=", 400);
                ClauseComponent nj400Yes = new Result("Gematigd, droog klimaat", "Steppeklimaat", picture6);
                ClauseComponent tk10N = new Clause("TK <= -10", tk, "<=", - 10);
                ClauseComponent tk10NYes = new Result("Koudgematigd klimaat met strenge winter", "Taigaklimaat", picture3);
                ClauseComponent d1 = new Clause(" D <= 1", d,"<=", 1);
                ClauseComponent tk3N = new Clause("TK <= -3", tk, "<=", - 3);
                ClauseComponent tk3NYes = new Result("Koelgematigd klimaat met koude winter", "Gemengd-woudklimaat", picture8);
                ClauseComponent tw22 = new Clause(" TW <= 22", tw,"<=", 22);
                ClauseComponent tw22Yes = new Result("Koelgematigd klimaat met zachte winter", "Loofbosklimaat", picture9);
                ClauseComponent tw22No = new Result("Warmgematigd altijd nat klimaat", "Subtropisch regenwoudklimaat", picture10);
                ClauseComponent nznw = new Clause("NZ <= NW", nz, nw);
                ClauseComponent tw222 = new Clause("TW <= 22", tw,"<=", 22);
                ClauseComponent tw222Yes = new Result("Koelgematigd klimaat met natte winter", "Hardbladige-vegetatieklimaat van de centrale middelbreedten", picture11);
                ClauseComponent tw222No = new Result("Warmgematigd klimaat met natte winter", "Hardbladige-vegetatieklimaat van de subtropen", picture12);
                ClauseComponent nznwNo = new Result("Warmgematigd klimaat met natte zomer", "Subtropisch savanneklimaat", picture13);

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

                ClauseComponent d12 = new Clause("D <= 1", d,"<=", 1);
                ClauseComponent d12Yes = new Result("Warm klimaat met nat seizoen", "Tropisch savanneklimaat", picture14);
                ClauseComponent d12No = new Result("Warm altijd nat klimaat", "Tropisch regenwoudklimaat", picture15);
                d12.Add(true, d12Yes);
                d12.Add(false, d12No);
                tk18.Add(false, d12);

                DeterminateTable detTable1 = new DeterminateTable();

                List<ClauseComponent> results1 = (new ClauseComponent[]
                {
                    tw0, tj0,nj200, tk15,tk18, nj400, tk10N, d1, tk3N, tw22, nznw, tw222, d12,
                    tw0Yes, tw0No, tj0Yes,
                    tk15Yes, tk15No, nj400Yes, tk10NYes, tk3NYes,
                    tw22Yes, tw22No, tw222Yes, tw222No, nznwNo,
                    d12Yes, d12No, tw10
                }).ToList();

                results1.ForEach(r => detTable1.AllClauseComponents.Add(r));

               
                //Determineertabel voor 1e graad opbouwen
                ClauseComponent tw10V1 = new Clause("TW <= 10", tw,"<=", 10);
                ClauseComponent tw0V1 = new Clause("TW <= 0", tw,"<=", 0);
                ClauseComponent tw0YesV1 = new Result("Koud zonder dooiseizoen", "Ijswoestijnklimaat", picture1);
                ClauseComponent tw0NoV1 = new Result("Koud met dooiseizoen", "Toendraklimaat", picture2);
                tw0V1.Add(true, tw0YesV1);
                tw0V1.Add(false, tw0NoV1);
                tw10V1.Add(true, tw0V1);
                ClauseComponent tm10V1 = new Clause("Minder dan 4 maanden Tm >= 10", tm,"<", 4);
                tw10V1.Add(false, tm10V1);

                ClauseComponent tm10YesV1 = new Result("Koud gematigd", "Taigaklimaat", picture3);
                tm10V1.Add(true, tm10YesV1);
                ClauseComponent tk18V1 = new Clause("Tk < 18", tk,"<", 18);
                tm10V1.Add(false, tk18V1);

                ClauseComponent nj400V1 = new Clause("Nj > 400mm", nj,">", 400);
                tk18V1.Add(true, nj400V1);
                ClauseComponent tk18NoV1 = new Result("Warm", "Tropisch regenwoudklimaat", picture15);
                tk18V1.Add(false, tk18NoV1);

                ClauseComponent nj400YesV1 = new Clause("Tk < -3", tk, "<", - 3);
                nj400V1.Add(true, nj400YesV1);
                ClauseComponent nj400NoV1 = new Result("Gematigd en droog", "Steppeklimaat", picture6);
                nj400V1.Add(false, nj400NoV1);

                ClauseComponent tkMin3Yes = new Result("Koel gematigd met strenge winter", "Gemengd-woudklimaat", picture8);
                nj400YesV1.Add(true, tkMin3Yes);
                ClauseComponent tkMin3No = new Clause("Tw < 22", tw,"<", 22);
                nj400YesV1.Add(false, tkMin3No);

                ClauseComponent tw22YesV1 = new Result("Koel gematigd met zachte winter", "Loofbosklimaat", picture9);
                ClauseComponent tw22NoV1 = new Result("warm gematigd met natte winter", "Hardbladige-vegetatieklimaat van de subtropen", picture12);
                tkMin3No.Add(true, tw22YesV1);
                tkMin3No.Add(false, tw22NoV1);


                DeterminateTable detTable2 = new DeterminateTable();

                List<ClauseComponent> results2 = (new ClauseComponent[]
                {
                    tw0V1, tm10V1, tk18V1, nj400V1, nj400YesV1, tkMin3No,
                    tw0YesV1, tw0NoV1, tm10YesV1, tk18NoV1,
                    nj400NoV1, tkMin3Yes, tw22YesV1, tw22NoV1, tw10V1
                }).ToList();

                results2.ForEach(r => detTable2.AllClauseComponents.Add(r));
                

                grade1.DeterminateTableProp = detTable2;
                grade2.DeterminateTableProp = detTable1;
                grade3.DeterminateTableProp = detTable1;

                //ClimateCharts
                double[] temps = new double[] {2, 3, 5.4, 8.5, 12.23, 15, 17, 17, 14, 10, 6, 3};
                int[] sed = new[] {51, 42, 46, 50, 59, 65, 72, 74, 72, 72, 64, 59};
                double[] temps2 = new double[] { 10, -12, -12, -14, -15, -20, 28, 32, 28, 16, 6, 9 };
                int[] sed2 = new[] {120, 145, 200, 120, 150, 100, 140, 40, 100, 120, 130, 100};
                double[] temps3 = new double[] { 1, 2, 5, 8, 12, 15, 17, 16, 14, 9, 5, 1 };
                int[] sed3 = new[] { 80, 65, 63, 59, 67, 72, 79, 78, 73, 76, 78, 83 };
                double[] temps4 = new double[] { 2, 3, 5, 8, 12, 15, 17, 16, 14, 10, 5, 3 };
                int[] sed4 = new[] { 58, 47, 50, 54, 66, 72, 78, 76, 70, 70, 66, 65 };
                double[] temps5 = new double[] { 29, 30, 30, 30, 30, 29, 28, 29, 30, 30, 29, 29 };
                int[] sed5 = new[] {9, 10, 19, 58, 21, 8, 20, 9, 5, 10, 28, 14};
                double[] temps6 = new double[] { 28, 28, 28, 28, 26, 25, 24, 24, 25, 26, 27, 27 };
                int[] sed6 = new[] {34, 14, 56, 154, 236, 88, 72, 68, 67, 103, 105, 76};
                double[] temps7 = new double[] { -15, -12, -6, 0, 7, 13, 16, 13, 8, 2, -5, -11 };
                int[] sed7 = new[] {34, 28, 27, 32, 41, 55, 62, 65, 61, 59, 54, 43};
                ClimateChart gent = new ClimateChart("Gent", 1961, 1990, temps, sed, 51.054342, 3.717424);
                ClimateChart ukkel = new ClimateChart("Ukkel", 1961, 1990, temps2, sed2, 50.802398, 4.340670);
                ClimateChart virton = new ClimateChart("Virton", 1961, 1990, temps3, sed3, 49.567574, 5.533507);
                ClimateChart chievres = new ClimateChart("Chièvres", 1961, 1990, temps4, sed4, 50.585970, 3.806090);
                ClimateChart lodwar = new ClimateChart("Lodwar", 1961, 1990, temps5, sed5, 3.116667, 35.600000);
                ClimateChart mombasa = new ClimateChart("Mombasa", 1961, 1990, temps6, sed6, -4.043477, 39.668206);
                //ClimateChart archangelsk = new ClimateChart("Archangelsk", 1961, 1990, temps7, sed7, 64.547251, 40.560155);

                List<ClimateChart> climateCharts = (new ClimateChart[] {gent, chievres, ukkel, virton}).ToList();
                climateCharts.ForEach(c => belgië.ClimateCharts.Add(c));
                List<ClimateChart> climateCharts2 = (new ClimateChart[] { lodwar, mombasa }).ToList();
                climateCharts2.ForEach(c => kenia.ClimateCharts.Add(c));
                //List<ClimateChart> climateCharts3 = (new ClimateChart[] {archangelsk}).ToList();
                //climateCharts3.ForEach(c => russischeFed.ClimateCharts.Add(c));

                Debug.WriteLine("Database created!");
                context.SaveChanges(); 
                              
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine("Een error in initializer");
            }
            catch (DataException ex)
            {
                Console.WriteLine(ex.InnerException.ToString());
            }
            
        }
    }
}