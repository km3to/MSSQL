namespace ChirperLive
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using ModelConfigurations;
    using Migrations;

    public class ChirperContext : DbContext
    {       
        public ChirperContext()
            : base("name=ChirperContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChirperContext, Configuration>());
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Chirp> Chirps { get; set; }

        public virtual DbSet<ChImg> Images { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        public virtual DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());

            modelBuilder.Configurations.Add(new ChirpConfiguration());

            modelBuilder.Configurations.Add(new ChImgConfiguration());            

            modelBuilder.Entity<Comment>()
                .HasRequired(c => c.Chirp)
                .WithMany(c => c.Comments)
                .HasForeignKey(c => c.ChirpRefId);

            modelBuilder.Entity<Tag>()
                .HasKey(t => t.TagRef)
                .HasMany(t => t.Chirps)
                .WithMany(t => t.Tags)
                .Map(m =>
                {
                    m.ToTable("ChirpTags");
                    m.MapLeftKey("TagRef");
                    m.MapRightKey("ChirpId");
                });

            modelBuilder.Entity<Person>()
                .HasOptional(p => p.PLaceOfBirth)
                .WithMany(t => t.Natives)
                .HasForeignKey(p => p.PLaceOfBirthId);

            modelBuilder.Entity<Person>()
                .HasOptional(p => p.CurrentResidence)
                .WithMany(t => t.Residents)
                .HasForeignKey(p => p.CurrentResidenceId);

            base.OnModelCreating(modelBuilder);
        }
    }
}