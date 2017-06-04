namespace VideoMigrations.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<VideoMigrations.SalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "VideoMigrations.SalesContext";
        }

        protected override void Seed(VideoMigrations.SalesContext context)
        {           
        }
    }
}
