using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2groep11.Net.Models
{
    interface IContinentRepository
    {
        void Remove(Continent continent);
        void SaveChanges();
        Continent FindById(int continentId);
    }
}
