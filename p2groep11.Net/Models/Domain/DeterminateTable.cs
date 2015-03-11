using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace p2groep11.Net.Models.Domain
{
    public class DeterminateTable
    {
        public int DeterminateTableId { get; set; }
        public virtual ClauseComponent ClauseComponent { get; set; }
        public List<String> CorrectPath; 

        //tijdelijk
        public ClauseComponent tw10Temp;

        public DeterminateTable(ClauseComponent component)
        {
            this.ClauseComponent = component;
            CorrectPath = new List<string>();
        }

        public DeterminateTable(int grade)
        {
            this.DeterminateTableId = 2;
            this.ClauseComponent = CreateParameters(grade);
            tw10Temp = CreateParameters(grade);
            CorrectPath = new List<string>();
        }

        public DeterminateTable()
        {
            CorrectPath = new List<string>();
        }

        public String[] Determinate(ClimateChart chart)
        {
            return ClauseComponent.Determinate(chart, CorrectPath);
        }

        public ClauseComponent CreateParameters(int grade)
        {
            //determinatetable aanmaken, efkes zonder database werken
            Parameter tw = new TW();
            Parameter tj = new TJ();
            Parameter nj = new NJ();
            Parameter tk = new TK();
            Parameter d = new D();
            Parameter nz = new NZ();
            Parameter nw = new NW();
            Parameter tm = new TM();

            if (grade == 1)
            {
                ClauseComponent tw10V1 = new Clause("TW <= 10", tw, 10);
                ClauseComponent tw0V1 = new Clause("TW <= 0", tw, 0);
                ClauseComponent tw0YesV1 = new Result("Koud zonder dooiseizoen", "Koud");
                ClauseComponent tw0NoV1 = new Result("Koud met dooiseizoen", "Koud");
                tw0V1.Add(true, tw0YesV1);
                tw0V1.Add(false, tw0NoV1);
                tw10V1.Add(true, tw0V1);
                ClauseComponent tm10V1 = new Clause("Minder dan 4 maanden Tm >= 10", tm, 10);
                tw10V1.Add(false, tm10V1);

                ClauseComponent tm10YesV1 = new Result("Koud gematigd", "Gematigd");
                tw10V1.Add(true, tm10YesV1);
                ClauseComponent tk18V1 = new Clause("Tk < 18", tk, 18);
                tw10V1.Add(false, tk18V1);

                ClauseComponent nj400V1 = new Clause("Nj > 400mm", nj, 400);
                tk18V1.Add(true, nj400V1);
                ClauseComponent tk18NoV1 = new Result("Warm", "Warm");
                tk18V1.Add(false, tk18NoV1);

                ClauseComponent nj400YesV1 = new Clause("Tk < -3", tk, -3);
                nj400V1.Add(true, nj400YesV1);
                ClauseComponent nj400NoV1 = new Result("Gematigd en droog", "Droog");
                nj400V1.Add(false, nj400NoV1);

                ClauseComponent tkMin3Yes = new Result("Koel gematigd met strenge winter", "Gematigd");
                nj400YesV1.Add(true, tkMin3Yes);
                ClauseComponent tkMin3No = new Clause("Tw < 22", tw, 22);
                nj400YesV1.Add(false, tkMin3No);

                ClauseComponent tw22YesV1 = new Result("Koel gematigd met zachte winter", "Gematigd");
                ClauseComponent tw22NoV1 = new Result("warm gematigd met natte winter", "Gematigd");
                tkMin3No.Add(true, tw22YesV1);
                tkMin3No.Add(false, tw22NoV1);

                return tw10V1;
            }
            

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

            return tw10;
        }

    }
}