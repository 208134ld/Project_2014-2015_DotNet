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

       public int[] temps;
       public int[] sed;
       public int[] temps2;
       public int[] sed2;
       public int[] temps3;
       public int[] sed3;
       public int[] temps4;
       public int[] sed4;
       public DeterminateTable dTable;
       public ClimateChart chart;
       public ClimateChart chart2;
       public ClimateChart chart3;
       public ClimateChart chart4;

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
           Parameter mw = new MW("Wat is de warmste maand?");
           Parameter mk = new MK("Wat is de temperatuur van de koudste maand?");
           Parameter tk = new TK("Wat is de temperatuur van de koudste maand (TK)?");
           Parameter d = new D("Hoeveel droge maanden zijn er?");
           Parameter nz = new NZ("Hoeveelheid neerslag in de zomer?");
           Parameter nw = new NW("Hoeveelheid neerslag in de winter?");
           Parameter tj = new TJ("");
           Parameter nj = new NJ("");
           Parameter tm = new TM("");
           //ClauseComponent tw10 = new Clause("TW <= 10", tw, "<=", 10);
           //ClauseComponent CC2 = new Clause("TW <= 10", tw, "<", 10);
           //ClauseComponent CC3 = new Clause("TW <= 10", tw, ">=", 10);
           //ClauseComponent CC4 = new Clause("TW <= 10", tw, ">", 10);
           //ClauseComponent res1 = new Result("YES", "geen woestijn");
           //ClauseComponent res2 = new Result("NO", "woestijn");
           //tw10.ClauseComponentId = 1;
           //res1.ClauseComponentId = 2;
           //res2.ClauseComponentId = 3;
           //tw10.Add(true, res1);
           //tw10.Add(false, res2);
           //CC2.Add(true, res1);
           //CC2.Add(false, res2);
           //CC3.Add(true, res1);
           //CC3.Add(false, res2);
           //CC4.Add(true, res1);
           //CC4.Add(false, res2);
           //DetTable = new DeterminateTable();
           
           //DetTable2 = new DeterminateTable();
           
           //DetTable3 = new DeterminateTable();
           
           //DetTable4 = new DeterminateTable();
           Graad.DeterminateTableProp = DetTable;

           Country belgië = new Country { Name = "België" };
           temps = new int[] { 10, 12, 12, 14, 15, 20, 28, 32, 28, 16, 6, 2 };
           sed = new[] { 120, 145, 200, 120, 150, 100, 140, 40, 100, 120, 130, 100 };
           chart = new ClimateChart("Gent", 1990, 1991, temps, sed, 55, 6);
           chart.Country = belgië;

           temps2 = new int[] { 14, 15, 17, 21, 25, 27, 28, 27, 26, 23, 19, 15 };
           sed2 = new[] { 7, 4, 4, 2, 0, 0, 0, 0, 0, 1, 3, 5 };
           chart2 = new ClimateChart("Kaïro", 1961, 1990, temps2, sed2, -20, 2);
           Country egypte = new Country { Name = "Egypte" };
           //egypte.AboveEquator = false;
           chart2.Country = egypte;

           temps3 = new int[] { 0, 1, 5, 11, 17, 22, 25, 24, 20, 14, 9, 3 };
           sed3 = new[] { 77, 73, 91, 96, 97, 91, 103, 95, 86, 77, 97, 86 };
           chart3 = new ClimateChart("New York", 1961, 1990, temps3, sed3, 50, -50);
           Country newyork = new Country { Name = "New York" };
           chart3.Country = newyork;

           temps4 = new int[] { 25, 1, 5, 11, 17, 22, 25, 24, 20, 14, 9, 3 };
           sed4 = new[] { 1, 2, 0, 0, 0, 100, 100, 100, 100, 100, 0, 0 };
           chart4 = new ClimateChart("Fictief", 1961, 1990, temps4, sed4, 60, 20);
           Country fictief = new Country { Name = "Fictief" };
           chart4.Country = fictief;
           

           byte[] picture = null;
           ClauseComponent tw10 = new Clause("TW <= 10", tw, "<=", 10);
           ClauseComponent tw0 = new Clause("TW <= 0", tw, "<=", 0);
           ClauseComponent tw0Yes = new Result("Koud klimaat zonder dooiseizoen", "Ijswoestijnklimaat", picture);
           ClauseComponent tw0No = new Result("Koud klimaat met dooiseizoen", "Toendraklimaat", picture);
           tw0.Add(true, tw0Yes);
           tw0.Add(false, tw0No);
           tw10.Add(true, tw0);
           ClauseComponent tj0 = new Clause("TJ <= 0", tj, "<=", 0);
           tw10.Add(false, tj0);


           ClauseComponent tj0Yes = new Result("Koudgematigd klimaat met strenge winter", "Taigaklimaat", picture);
           tj0.Add(true, tj0Yes);
           ClauseComponent nj200 = new Clause("NJ <= 200", nj, "<=", 200);

           ClauseComponent tk15 = new Clause("TK <= 15", tk, "<=", 15);
           ClauseComponent tk15Yes = new Result("Gematigd altijd droog klimaat", "Woestijnklimaat van de middelbreedten", picture);
           ClauseComponent tk15No = new Result("Warm altijd droog klimaat", "Woestijnklimaat van de tropen", picture);
           tk15.Add(true, tk15Yes);
           tk15.Add(false, tk15Yes);
           nj200.Add(true, tk15);
           tj0.Add(false, nj200);

           ClauseComponent tk18 = new Clause("TK <= 18", tk, "<=", 18);
           ClauseComponent nj400 = new Clause("NJ <= 400", nj, "<=", 400);
           ClauseComponent nj400Yes = new Result("Gematigd, droog klimaat", "Steppeklimaat", picture);
           ClauseComponent tk10N = new Clause("TK <= -10", tk, "<=", -10);
           ClauseComponent tk10NYes = new Result("Koudgematigd klimaat met strenge winter", "Taigaklimaat", picture);
           ClauseComponent d1 = new Clause(" D <= 1", d, "<=", 1);
           ClauseComponent tk3N = new Clause("TK <= -3", tk, "<=", -3);
           ClauseComponent tk3NYes = new Result("Koelgematigd klimaat met koude winter", "Gemengd-woudklimaat", picture);
           ClauseComponent tw22 = new Clause(" TW <= 22", tw, "<=", 22);
           ClauseComponent tw22Yes = new Result("Koelgematigd klimaat met zachte winter", "Loofbosklimaat", picture);
           ClauseComponent tw22No = new Result("Warmgematigd altijd nat klimaat", "Subtropisch regenwoudklimaat", picture);
           ClauseComponent nznw = new Clause("NZ <= NW", nz, nw);
           ClauseComponent tw222 = new Clause("TW <= 22", tw, "<=", 22);
           ClauseComponent tw222Yes = new Result("Koelgematigd klimaat met natte winter", "Hardbladige-vegetatieklimaat van de centrale middelbreedten", picture);
           ClauseComponent tw222No = new Result("Warmgematigd klimaat met natte winter", "Hardbladige-vegetatieklimaat van de subtropen", picture);
           ClauseComponent nznwNo = new Result("Warmgematigd klimaat met natte zomer", "Subtropisch savanneklimaat", picture);

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

           ClauseComponent d12 = new Clause("D <= 1", d, "<=", 1);
           ClauseComponent d12Yes = new Result("Warm klimaat met nat seizoen", "Tropisch savanneklimaat", picture);
           ClauseComponent d12No = new Result("Warm altijd nat klimaat", "Tropisch regenwoudklimaat", picture);
           d12.Add(true, d12Yes);
           d12.Add(false, d12No);
           tk18.Add(false, d12);
           dTable = new DeterminateTable();

           List<ClauseComponent> results1 = (new ClauseComponent[]
                {
                    tw0, tj0,nj200, tk15,tk18, nj400, tk10N, d1, tk3N, tw22, nznw, tw222, d12,
                    tw0Yes, tw0No, tj0Yes,
                    tk15Yes, tk15No, nj400Yes, tk10NYes, tk3NYes,
                    tw22Yes, tw22No, tw222Yes, tw222No, nznwNo,
                    d12Yes, d12No, tw10
                }).ToList();

           results1.ForEach(r => dTable.AllClauseComponents.Add(r));
       }
    }
}
