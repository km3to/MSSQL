namespace ExtendedQuery.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Data;
    using Migrations;

    public class QueryContext : DbContext
    {
        public QueryContext()
            : base("name=QueryContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<QueryContext,
                Configuration>());
        }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Product> Products { get; set; }
    }
}