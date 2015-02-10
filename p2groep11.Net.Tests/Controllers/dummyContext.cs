using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2groep11.Net.Tests.Controllers
{
    class dummyContext
    {
        public IQueryable<Student> Studenten { get; set; }

        public dummyContext()
        {
            Student s = new Student("Arne","De Bremme");
            Student s2 = new Student("Frans","Van ier nevest");
            Student s3 = new Student("karel","hoegebuur");
            Studenten =
                (new Student[] { s, s2, s3 }).ToList().AsQueryable();
        }
    }
}
