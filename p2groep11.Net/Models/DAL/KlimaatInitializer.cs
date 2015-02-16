using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using p2groep11.Net.Models.Domain;

namespace p2groep11.Net.Models.DAL
{
    public class KlimaatInitializer : DropCreateDatabaseAlways<KlimaatContext>
    {
        protected override void Seed(KlimaatContext context)
        {
            base.Seed(context);
            Continent europa = new Continent { Name = "Europa"};
            context.Continenten.Add(europa);

            context.SaveChanges();
        }
    }
}