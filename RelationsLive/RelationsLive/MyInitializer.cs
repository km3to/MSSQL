using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RelationsLive.Models;

namespace RelationsLive
{
    public class MyInitializer : DropCreateDatabaseAlways<RelationsLiveContext>
    {
        protected override void Seed(RelationsLiveContext context)
        {
            context.Employees.Add(new Employee() {
                
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
