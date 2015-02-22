using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DotNet.Highcharts;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.ViewModels
{
    public class ClimateChartViewModel
    {
        public Highcharts Chart { get; private set; }
        public IEnumerable<Month> Months { get; private set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double AvgTemp { get; private set; }
        public int SumSed { get; private set; }
        public ClimateChartViewModel(Highcharts chart, IEnumerable<Month> months )
        {
            this.Chart = chart;
            this.Months = months;
            AvgTemp =  Months.Average(m => m.AverTemp);
            SumSed = months.Sum(m => m.Sediment);
        }
    }
}