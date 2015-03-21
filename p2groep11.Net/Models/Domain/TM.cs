using p2groep11.Net.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace p2groep11.Net
{
    public class TM : Parameter
    {

        public TM()
        {
            
        }

        public TM(String beschr)
        {
            this.Beschrijving = beschr;
        }
        public override int Execute(ClimateChart chart)
        {
            return chart.MonthsAbove10Degree;
        }

        public override string[] GiveOptAnswers(ClimateChart chart)
        {
            throw new ApplicationException();
        }

        public override string GiveAnswer(ClimateChart chart)
        {
            throw new ApplicationException();
        }
    }
}
