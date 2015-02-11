using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace p2groep11.Net.Models.DAL
{
    public class StudentRepository : IStudentRepository
    {
        private KlimaatContext context;
        private DbSet<Student> studenten;
        public StudentRepository(KlimaatContext context)
        {
            this.context = context;
            studenten = context.Studenten;
        }
        public Student FindById(int id)
        {
            return studenten.Find(id);
        }

        public IQueryable<Student> FindAll()
        {
            return studenten;
        }

        public Student FindByUsername(string username)
        {
            return studenten.Find(username);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

    }
}