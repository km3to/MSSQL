

namespace RelationsLive.Models
{
    using System.Collections.Generic;

    public class Employee
    {
        public Employee()
        {
            this.Subordinates = new HashSet<Employee>();
            this.ProjectEmployees = new HashSet<ProjectEmployees>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual Employee Manager { get; set; }

        public virtual ICollection<Employee> Subordinates { get; set; }

        public virtual ICollection<ProjectEmployees> ProjectEmployees { get; set; }
    }
}
