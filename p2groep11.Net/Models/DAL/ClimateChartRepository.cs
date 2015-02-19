using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models.DAL
{
    public class ClimateChartRepository : IClimateChartRepository
    {
        public IQueryable<ClimateChart> FindAll()
        {
            throw new NotImplementedException();
        }

        public ClimateChart FindById(int climateChartId)
        {
            throw new NotImplementedException();
        }

        public void Remove(ClimateChart climateChart)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}