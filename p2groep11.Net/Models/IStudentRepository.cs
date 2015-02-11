using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2groep11.Net.Models
{
    public interface IStudentRepository
    {
        Student FindById(int id);
        IQueryable<Student> FindAll();
        Student FindByUsername(String username);

        
        void saveChanges();
    }
}
