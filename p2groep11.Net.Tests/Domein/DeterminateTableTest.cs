using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Tests.Domein
{
    [TestClass]
    public class DeterminateTableTest
    {

        private int[] temps;
        private int[] sed;
        private int[] temps2;
        private int[] sed2;
        private int[] temps3;
        private int[] sed3;
        private int[] temps4;
        private int[] sed4;
        private DeterminateTable dTable;
        private ClimateChart chart;
        private ClimateChart chart2;
        private ClimateChart chart3;
        private ClimateChart chart4;

        [TestInitialize]
        public void init()
        {

            Country belgië = new Country { Name = "België" };
            temps = new int[] { 10, 12, 12, 14, 15, 20, 28, 32, 28, 16, 6, 2 };
            sed = new[] { 120, 145, 200, 120, 150, 100, 140, 40, 100, 120, 130, 100 };
            chart = new ClimateChart("Gent", 1990, 1991, temps, sed);
            chart.Country = belgië;

            temps2 = new int[] { 14, 15, 17, 21, 25, 27, 28, 27, 26, 23, 19, 15 };
            sed2 = new[] { 7, 4, 4, 2, 0, 0, 0, 0, 0, 1, 3, 5 };
            chart2 = new ClimateChart("Kaïro", 1961, 1990, temps2, sed2);
            Country egypte = new Country { Name = "Egypte" };
            egypte.AboveEquator = false;
            chart2.Country = egypte;

            temps3 = new int[] { 0, 1, 5, 11, 17, 22, 25, 24, 20, 14, 9, 3 };
            sed3 = new[] { 77, 73, 91, 96, 97, 91, 103, 95, 86, 77, 97, 86 };
            chart3 = new ClimateChart("New York", 1961, 1990, temps3, sed3);
            Country newyork = new Country { Name = "New York" };
            chart3.Country = newyork;

            temps4 = new int[] { 25, 1, 5, 11, 17, 22, 25, 24, 20, 14, 9, 3 };
            sed4 = new[] { 1, 2, 0, 0, 0, 100, 100, 100, 100, 100, 0, 0 };
            chart4 = new ClimateChart("Fictief", 1961, 1990, temps4, sed4);
            Country fictief = new Country { Name = "Fictief" };
            chart4.Country = fictief;


            
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
            dTable = new DeterminateTable(tw10);
        }

        [TestMethod]
        public void DeterminateReturnsString()
        {
            Assert.AreNotEqual(true, System.String.IsNullOrEmpty(dTable.Determinate(chart)[0]));
        }

        [TestMethod]
        public void DeterminateReturnsCorrectSolution()
        {
            Assert.AreEqual("Warmgematigd altijd nat klimaat", dTable.Determinate(chart)[0]);
            Assert.AreEqual("Subtropisch regenwoudklimaat", dTable.Determinate(chart)[1]);
            Assert.AreEqual("Gematigd altijd droog klimaat", dTable.Determinate(chart2)[0]);
            Assert.AreEqual("Woestijnklimaat van de middelbreedten", dTable.Determinate(chart2)[1]);
            Assert.AreEqual("Warmgematigd altijd nat klimaat", dTable.Determinate(chart3)[0]);
            Assert.AreEqual("Subtropisch regenwoudklimaat", dTable.Determinate(chart3)[1]);
            Assert.AreEqual("Warmgematigd klimaat met natte zomer", dTable.Determinate(chart4)[0]);
            Assert.AreEqual("Subtropisch savanneklimaat", dTable.Determinate(chart4)[1]);
        }

    }
}
