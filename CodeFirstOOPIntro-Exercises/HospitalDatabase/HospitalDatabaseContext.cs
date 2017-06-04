namespace HospitalDatabase
{
    using System;
    using System.Data.Entity;
    using Models;

    public class HospitalDatabaseContext : DbContext
    {       
        public HospitalDatabaseContext()
            : base("name=HospitalDatabaseContext")
        {
        }
        
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Visitation> Visitations { get; set; }
    }
}