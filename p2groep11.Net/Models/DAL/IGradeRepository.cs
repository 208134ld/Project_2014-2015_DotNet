using System.Linq;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models.DAL
{
    public interface IGradeRepository
    {
        IQueryable<Grade> FindAll();
        Grade FindById(int gradeId);
        void Remove(Grade grade);
        void SaveChanges();      
    }
}
