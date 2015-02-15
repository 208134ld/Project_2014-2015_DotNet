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
        public int Id { get; set; }
        public string Location { get; set; }
        public ICollection<Month> Months { get; set; }
        public int BeginPeriod { get; set; }
        public int EndPeriod { get; set; }

        public ClimateChart(string loc, int begin, int end)
        {
            Location = loc;
            BeginPeriod = begin;
            EndPeriod = end;
        }
    }
}
