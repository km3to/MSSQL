namespace SoftUniADOLive
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Startup
    {
        static void Main(string[] args)
        {
            // Window initialization
            Console.WindowHeight = 17;
            Console.BufferHeight = 17;
            Console.WindowWidth = 50;
            Console.BufferWidth = 50;
            Console.WriteLine(Console.WindowHeight);

            // DB Init
            var context = new SoftUniEntities();
            ListAll(context);
            //ShowDetails(context, 5);
        }

        static void ListAll(SoftUniEntities context)
        {
            int pageSize = 14;

            var projects = context.Projects.ToList();
            int page = 0;
            int maxPages = (int)Math.Ceiling(projects.Count / (double)pageSize);
            int pointer = 1;

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.Clear();
                Console.WriteLine($" ID |  Project Name (Page {page + 1} of {maxPages})");
                Console.WriteLine($"----+--------------");

                int currentRow = 1;
                foreach (var project in projects.Skip(pageSize * page).Take(pageSize))
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;

                    if (currentRow == pointer)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine($"{project.ProjectID,4}| {project.Name}");
                    currentRow++;
                }
                
                var key = Console.ReadKey();

                switch (key.Key.ToString())
                {
                    case "Enter":
                        var currentProject = projects.Skip(pageSize * page + pointer - 1).First();
                        ShowDetails(currentProject);
                        break;
                    case "UpArrow":                        
                        if (pointer > 1)
                        {
                            pointer--;
                        }
                        else if (page > 0)
                        {
                            page--;
                            pointer = pageSize;
                        }
                        break;
                    case "DownArrow":
                        if (pointer < pageSize)
                        {
                            pointer++;
                        }
                        else if (page + 1 < maxPages)
                        {
                            page++;
                            pointer = 1;
                        }                            
                        break;
                    case "Escape":
                        return;
                }                
            }   
        }

        static void ShowDetails(Project project)
        {
            Console.Clear();
            Console.WriteLine($"ID {project.ProjectID, 4}| {project.Name}");
            Utility.PrintHorizontalLine();
            Console.WriteLine($"{project.Description}");
            Utility.PrintHorizontalLine();
            Console.WriteLine($"{project.StartDate, -24}| {project.EndDate}");
            Utility.PrintHorizontalLine();
            var employees = project.Employees.ToList();
            foreach (var emp in employees)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName}");
            }
            Console.ReadKey();
        }        
    }
}
