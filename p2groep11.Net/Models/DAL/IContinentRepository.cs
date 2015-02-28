using System.Linq;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models.DAL
{
    public interface IContinentRepository
    {
        IQueryable<Continent> FindAll();
        Continent FindById(int continentId);
        void Remove(Continent continent);
        void SaveChanges();      
    }
}
