namespace RelationsLive
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class RelationsLiveContext : DbContext
    {
        public RelationsLiveContext()
            : base("name=RelationsLiveContext")
        {
            Database.SetInitializer(new MyInitializer());
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public virtual DbSet<ProjectEmployees> ProjectEmployees { get; set; }
    }    
}