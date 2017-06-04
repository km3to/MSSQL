namespace Intro_EntityFramework_Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    class Startup
    {
        static void Main(string[] args)
        {
            SoftUniExercisesContext context = new SoftUniExercisesContext();
            //GrongottsContext context = new GrongottsContext();

            // 8 ================================================
            //var addresses = context.Addresses
            //    .OrderByDescending(a => a.Employees.Count)
            //    .ThenBy(a => a.Town.Name)
            //    .Take(10);

            //foreach (var adr in addresses)
            //{
            //    Console.WriteLine($"{adr.AddressText}, {adr.Town.Name} - {adr.Employees.Count} employees");
            //}
            //==========================================

            // 9 ============================================
            //var employeeWithId = context.Employees.Find(147);
            //Console.WriteLine($"{employeeWithId.FirstName} {employeeWithId.LastName} {employeeWithId.JobTitle}");

            //foreach (var proj in employeeWithId.Projects.OrderBy(p => p.Name))
            //{
            //    Console.WriteLine($"{proj.Name}");
            //}
            //==============================================

            // 10
            //===========================================
            //var depatrments = context.Departments
            //    .Where(d => d.Employees.Count > 5)
            //    .OrderBy(d => d.Employees.Count);

            //foreach (var dep in depatrments)
            //{
            //    Console.WriteLine($"{dep.Name} {dep.Manager.FirstName}");
            //    foreach (var emp in dep.Employees)
            //    {
            //        Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.JobTitle}");
            //    }
            //}
            //===========================================

            // 11 ===============================================
            //var latestProjects = context.Projects
            //    .OrderByDescending(p => p.StartDate)
            //    .Take(10)
            //    .OrderBy(p => p.Name);

            //foreach (var lp in latestProjects)
            //{
            //    var startDate = lp.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            //    var endDate = lp.EndDate?.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            //    Console.WriteLine($"{lp.Name} {lp.Description} {startDate} {endDate}");
            //}
            //==================================================

            // 12 ===================================================
            //var employees = context.Employees
            //    .Where(e => e.Department.Name == "Engineering" ||
            //                e.Department.Name == "Tool Design" ||
            //                e.Department.Name == "Marketing" ||
            //                e.Department.Name == "Information Services");

            //foreach (var emp in employees)
            //{
            //    emp.Salary *= 1.12m;
            //}
            //context.SaveChanges();

            //foreach (var emp in employees)
            //{
            //    Console.WriteLine($"{emp.FirstName} {emp.LastName} (${emp.Salary})");
            //}

            //=======================================================

            // 13 =========================================================
            //var employees = context.Employees
            //    .Where(e => e.FirstName.ToLower().StartsWith("sa"));

            //foreach (var emp in employees)
            //{
            //    Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle} - (${emp.Salary:f4})");
            //}
            //=========================================================

            // 14 =========================================================
            //var letters = context.WizzardDeposits
            //    .Where(w => w.DepositGroup == "Troll Chest")
            //    .Select(w => w.FirstName)
            //    .ToList()
            //    .Select(fn => fn[0])
            //    .Distinct()
            //    .OrderBy(c => c);

            //foreach (var letter in letters)
            //{
            //    Console.WriteLine(letter);
            //}                
            //=============================================================

            // 15 =========================================================
            //var project = context.Projects.Find(2);

            //foreach (var emp in project.Employees)
            //{
            //    emp.Projects.Remove(project);
            //}

            //context.Projects.Remove(project);
            //context.SaveChanges();

            //var projects = context.Projects
            //    .Select(p => p.Name)
            //    .Take(10);

            //foreach (var proj in projects)
            //{
            //    Console.WriteLine(proj);
            //}
            //=============================================================

            // 16 =========================================================
            //var inputTown = Console.ReadLine();

            //var towtoDelete = context.Towns
            //    .Where(t => t.Name == inputTown);

            //var addressesToDelete = context.Addresses
            //    .Where(a => a.Town.Name == inputTown);

            //List<Employee> employeesToNull = new List<Employee>();

            //foreach (var adr in addressesToDelete)
            //{
            //    foreach (var e in context.Employees)
            //    {
            //        if (e.Address == adr)
            //            e.Address = null;
            //    }
            //}
            //=============================================================

            // 17 =========================================================
            context.Projects.Count();

            Stopwatch timer = new Stopwatch();
            timer.Start();
            LinqQuery(context);
            timer.Stop();
            Console.WriteLine($"Linq: {timer.Elapsed}");

            timer.Reset();
            timer.Start();
            NativeQuery(context);
            timer.Stop();
            Console.WriteLine($"Native: {timer.Elapsed}");
            //============================================================
        }

        private static void NativeQuery(SoftUniExercisesContext context)
        {
            int result = context.Database.SqlQuery<int>("SELECT COUNT(*) FROM Projects WHERE YEAR(StartDate) > 2000").First();
            Console.WriteLine(result);
        }

        private static void LinqQuery(SoftUniExercisesContext context)
        {
            var emp = context.Employees
                .Where(e => e.Projects == context.Projects.Where(p => p.StartDate.Year == 2002));

            Console.WriteLine(emp.Count());

            //var projects = context.Projects
            //    .Where(p => p.StartDate.Year == 2002);

            //Console.WriteLine(context.Projects.Where(p => p.StartDate.Year > 2000).Count());
        }
    }
}
