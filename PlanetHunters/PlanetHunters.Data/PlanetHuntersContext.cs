namespace PlanetHunters.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PlanetHuntersContext : DbContext
    {
        public PlanetHuntersContext()
            : base("name=PlanetHuntersContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discovery>()
                .HasMany(d => d.Observers)
                .WithMany(o => o.ObservatingDiscorevies)
                .Map(disOb =>
                {
                    disOb.ToTable("DiscoveryObservers");
                    disOb.MapLeftKey("DiscoveryId");
                    disOb.MapRightKey("ObserverId");
                });

            modelBuilder.Entity<Discovery>()
                .HasMany(d => d.Pioneers)
                .WithMany(p => p.PioneeringDiscoveries)
                .Map(disPi =>
                {
                    disPi.ToTable("DiscoveryPioneers");
                    disPi.MapLeftKey("DiscoveryId");
                    disPi.MapRightKey("PoineerId");
                });            
        }

        public virtual DbSet<Astronomer> Astronomers { get; set; }

        public virtual DbSet<Discovery> Discoveries { get; set; }

        public virtual DbSet<Telescope> Telescopes { get; set; }

        public virtual DbSet<StarSystem> StarSystems { get; set; }

        public virtual DbSet<Star> Stars { get; set; }

        public virtual DbSet<Planet> Planets { get; set; }
    }
}