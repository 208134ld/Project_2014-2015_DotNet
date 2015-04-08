using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net
{
    public class TJ : Parameter
    {

        public TJ()
        {
            
        }

        public TJ(String beschr)
        {
            this.Beschrijving = beschr;
        }
        public override double Execute(ClimateChart chart)
        {
            return chart.AverageYearTemp;
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
