namespace TeamBuilder.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class TeamBuilderContext : DbContext
    {
        public TeamBuilderContext()
            : base("name=TeamBuilderContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(t => t.Teams)
                .WithMany(u => u.Users)
                .Map(ut => 
                {
                    ut.ToTable("UserTeams");
                    ut.MapLeftKey("UserId");
                    ut.MapRightKey("TeamId");
                });

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Teams)
                .WithMany(t => t.Events)
                .Map(et =>
                {
                    et.ToTable("EventTeams");
                    et.MapLeftKey("EventId");
                    et.MapRightKey("TeamId");
                });

            modelBuilder.Entity<Team>()
                .HasRequired(t => t.Creator)
                .WithMany(c => c.CreatedTeams)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>().Property(p => p.Username).IsRequired();

            modelBuilder.Entity<Team>().Property(p => p.Acronym).IsFixedLength().HasMaxLength(3);
            
        }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Invitation> Invitations { get; set; }
    }
}