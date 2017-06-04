namespace AnotherApp.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AnotherAppEntities : DbContext
    {        
        public AnotherAppEntities()
            : base("name=AnotherAppEntities")
        {
        }

        public virtual DbSet<Person> People { get; set; }
    }    
}