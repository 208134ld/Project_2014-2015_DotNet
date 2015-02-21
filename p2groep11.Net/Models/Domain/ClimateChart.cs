using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace p2groep11.Net.Models.Domain
{
    public class ClimateChart
    {
        public int ClimateChartID { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Month> Months { get; private set; }
        public int BeginPeriod { get; set; }
        public int EndPeriod { get; set; }
        public Country Country { get; set; }

        /*public p2groep11.Net.DeterminateTableComponent DeterminateTableComponent
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }*/

        public ClimateChart(string loc, int begin, int end)
        {
            Location = loc;
            BeginPeriod = begin;
            EndPeriod = end;
            Months = new List<Month>();
        }
    }
}
