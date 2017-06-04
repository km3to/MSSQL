namespace Organizer.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models.Contacts;

    internal sealed class Configuration : DbMigrationsConfiguration<Organizer.Data.OrganizerEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Organizer.Data.OrganizerEntities";
        }

        protected override void Seed(Organizer.Data.OrganizerEntities context)
        {
            context.People.AddOrUpdate(p => new
            {
                p.FirstName,
                p.LastName
            }, 
            new Person
            {
                FirstName = "Ivan",
                LastName = "Ivanov"
            }, 
            new Person
            {
                FirstName = "Peter",
                LastName = "Petrov",
                Alias = "Pepi"
            });

            context.SaveChanges();
        }
    }
}
