using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models
{
    interface IClimateChartRepository
    {
        IQueryable<ClimateChart> FindAll();
        ClimateChart FindById(int climateChartId);
        void Remove(ClimateChart climateChart);
        void SaveChanges();
    }
}