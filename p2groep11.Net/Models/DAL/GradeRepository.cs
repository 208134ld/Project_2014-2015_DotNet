using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models.DAL
{
    public class GradeRepository : IGradeRepository
    {
        private ProjectContext context;
        private DbSet<Grade> grades;

        public GradeRepository(ProjectContext context)
        {
            this.context = context;
            grades = context.Grades;
        }

        public IQueryable<Grade> FindAll()
        {
            return grades.OrderBy(g => g.GradeInt);
            //return continents.Include(l => l.Countries).OrderBy(c => c.Name);
            //return continents.OrderBy(c => c.Name);
        }

        public Grade FindById(int gradeId)
        {
            return grades.Include(l => l.DeterminateTableProp).FirstOrDefault(g => g.GradeInt == gradeId);
            //return continents.Include(l => l.Countries.Select(c=>c.ClimateCharts.Select(mon=>mon.Months))).FirstOrDefault(c => c.ContinentID == continentId); 
        }

        public void Remove(Grade grade)
        {
            grades.Remove(grade);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        
    }
}