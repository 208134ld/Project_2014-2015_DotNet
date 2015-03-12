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
        public override int Execute(ClimateChart chart)
        {
            return chart.MaandenOnder10;
        }
    }
}
