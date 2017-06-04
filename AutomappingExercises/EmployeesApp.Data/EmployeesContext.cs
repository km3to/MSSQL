namespace EmployeesApp.Data
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EmployeesContext : DbContext
    {
        public EmployeesContext()
            : base("name=EmployeesContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}