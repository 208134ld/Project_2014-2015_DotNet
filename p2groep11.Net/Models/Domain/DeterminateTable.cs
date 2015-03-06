using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2groep11.Net.Models.Domain
{
    public class DeterminateTable
    {
        public int DeterminateTableId { get; set; }
        public int GradeId { get; set; }
        public ClauseComponent ClauseComponent { get; set; }

        //tijdelijk
        public ClauseComponent tw10Temp;

        public DeterminateTable(ClauseComponent component)
        {
            this.ClauseComponent = component;
            this.GradeId = 1;
        }

        public DeterminateTable()
        {
            // temp default constructor
            CreateParameters();
            this.ClauseComponent = tw10Temp;
            this.GradeId = 1; //moet nog aangepast worden
        }

        public String Determinate(ClimateChart chart)
        {
            return ClauseComponent.Determinate(chart);
        }

        public void CreateParameters()
        {
            //determinatetable aanmaken, efkes zonder database werken
            Parameter tw = new Parameter(0, "TW");
            Parameter tj = new Parameter(0, "TJ");
            Parameter nj = new Parameter(0, "NJ");
            Parameter tk = new Parameter(0, "TK");
            Parameter d = new Parameter(0, "D");
            Parameter nz = new Parameter(0, "NZ");
            Parameter nw = new Parameter(0, "NW");

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

            /*DeterminateTable table = new DeterminateTable(tw10);*/

            tw10Temp = tw10; //  <-- Temp voor te testen
        }

    }
}