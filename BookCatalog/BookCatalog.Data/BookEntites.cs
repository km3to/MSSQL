namespace BookCatalog.Data
{
    using Migrations;
    using Models;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Linq;

    public class BookEntites : DbContext
    {
        public BookEntites()
            : base("name=BookEntites")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookEntites, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Genre>()
                .Property(g => g.Name)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, 
                new IndexAttribute("IX_GenreName") { IsUnique = true });
            */
        }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Genre> Genres { get; set; }
    }
}