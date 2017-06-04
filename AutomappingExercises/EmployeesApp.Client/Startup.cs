namespace EmployeesApp.Client
{
    using AutoMapper;
    using EmployeesApp.Data;
    using EmployeesApp.Models;
    using EmployeesApp.Models.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper.QueryableExtensions;

    class Startup
    {
        static void Main(string[] args)
        {

            //Task1();

            //Task2();

            //Task3();         

        }    
        
        private static void Task3()
        {
            InitializeDatabase();
            IEnumerable<Employee> emps = CreateManagers();
            SeedDatabase(emps);
            ConfigureAutomapping();

            using (EmployeesContext context = new EmployeesContext())
            {
                var employees = context.Employees
                    .Where(e => e.Birthday.Value.Year < 1990)
                    .OrderByDescending(e => e.Salary)
                    .ProjectTo<EmployeeDto>();

                foreach (var employee in employees)
                {
                    Console.WriteLine(employee.ToString());
                }
            }
        }    

        private static void Task2()
        {
            ConfigureAutomapping();
            IEnumerable<Employee> managers = CreateManagers();
            IEnumerable<ManagerDto> managerDtos = Mapper.Map<IEnumerable<Employee>, IEnumerable<ManagerDto>>(managers);
            foreach (var managerDto in managerDtos)
            {
                Console.WriteLine(managerDto.ToString());
            }
        }

        private static void Task1()
        {
            ConfigureAutomapping();
            Employee emp = new Employee()
            {
                FirstName = "Kiril",
                LastName = "Kirilov",
                Salary = 50m,
                Birthday = DateTime.Now,
                Address = "nqkyde si"
            };

            EmployeeDto dto = Mapper.Map<EmployeeDto>(emp);

            Console.WriteLine($"{dto.FirstName} - {dto.LastName} - {dto.Salary}lv.");
        }

        private static void ConfigureAutomapping()
        {
            Mapper.Initialize(a =>
            {
                a.CreateMap<Employee, EmployeeDto>();
                a.CreateMap<Employee, ManagerDto>()
                    .ForMember(dto => dto.SubordinatesCount, configExpression => configExpression.MapFrom(e => e.Subordinates.Count));
            });
        }

        private static IEnumerable<Employee> CreateManagers()
        {
            var managers = new List<Employee>();
            for (int i = 0; i < 3; i++)
            {
                var manager = new Employee()
                {
                    FirstName = "Pesho",
                    LastName = "Peshev",
                    Address = "Sofia, Tintyava 10",
                    Birthday = new DateTime(1989, 3, 2),
                    Subordinates = new List<Employee>(),
                    IsOnHoliday = false,
                    Manager = new Employee() { FirstName = "Ivan", LastName = "Ivanov" },
                    Salary = 100m
                };
                var employee1 = new Employee()
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Salary = 120.20m,
                    Manager = manager
                };
                var employee2 = new Employee()
                {
                    FirstName = "Johny",
                    LastName = "Doing",
                    Salary = 120.22m,
                    Manager = manager
                };
                var employee3 = new Employee()
                {
                    FirstName = "Johnnie",
                    LastName = "Doable",
                    Salary = 120.23m,
                    Manager = manager
                };

                manager.Subordinates.Add(employee1);
                manager.Subordinates.Add(employee2);
                manager.Subordinates.Add(employee3);
                managers.Add(manager);
            }
            return managers;
        }

        private static void InitializeDatabase()
        {
            using (EmployeesContext context = new EmployeesContext())
            {
                context.Database.Initialize(true);
            }
        }

        private static void SeedDatabase(IEnumerable<Employee> employees)
        {
            var context = new EmployeesContext();
            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}
