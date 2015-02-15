using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models
{
    interface IContinentRepository
    {
        void Remove(Continent continent);
        void SaveChanges();
        Continent FindById(int continentId);
    }
}
