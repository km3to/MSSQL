namespace SoftUni
{
    using SoftUni.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ViewModels;

    class Program
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();

            

        }

        // 17
        private static void CallAStriredProcedure(SoftUniContext context)
        {
            var input = Console.ReadLine().Split(' ');

            var projects = context.Database.SqlQuery<ProjectViewModel>($"EXEC dbo.usp_FindProjectsByEmployeeName {input[0]}, {input[1]}");

            foreach (ProjectViewModel p in projects)
            {
                Console.WriteLine($"{p.Name} - {p.Description},  {p.StartDate}");
            }
        }

        // 18
        private static void EmployeesMaxSalaries(SoftUniContext context)
        {
            context.Departments.Where(d => d.Employee.Salary > 70000 || d.Employee.Salary < 30000)
                .ToList().ForEach(d =>
                {
                    Console.WriteLine($"{d.Name} {d.Employees.Max(e => e.Salary):f2}");
                });
        }
    }
}
