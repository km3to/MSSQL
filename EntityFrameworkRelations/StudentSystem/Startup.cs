namespace StudentSystem
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
            var ctx = new StudentSystemContext();

            ctx.Database.Initialize(true);

            PrintInitialScreen(ctx);
        }

        private static void PrintInitialScreen(StudentSystemContext ctx)
        {
            Console.Clear();
            Console.WriteLine($"1. List all students and homeworks;");
            Console.WriteLine($"2. List all Courses with resouces");
            Console.WriteLine($"3. List Courses with more than 5 resources");
            Console.WriteLine($"4. List students with courses and prices.");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ListStudentsHomeworks(ctx);
                    break;
                case "2":
                    ListCourses(ctx);
                    break;
                case "3":
                    ListCoursesWithMoreThan5Reso(ctx);
                    break;
                case "4":
                    ListStudentsWithMoney(ctx);
                    break;
                default:
                    break;
            }
        }

        private static void ListStudentsWithMoney(StudentSystemContext ctx)
        {
            foreach (var student in ctx.Students)
            {
                Console.WriteLine($"Name: {student.Name}");
                Console.WriteLine($"Numbers of courses: {student.Courses.Count}");
                decimal sum = 0;
                foreach (var course in student.Courses)
                {
                    sum += course.Price;
                }
                Console.WriteLine($"Total price: {sum}");
                if (student.Courses.Count > 0)
                {
                    Console.WriteLine($"Average: {sum / student.Courses.Count}");
                }
                else
                {
                    Console.WriteLine("Average: 0");
                }
                
            }
            var c = Console.ReadLine();
            PrintInitialScreen(ctx);
        }

        private static void ListCoursesWithMoreThan5Reso(StudentSystemContext ctx)
        {
            foreach (var course in ctx.Courses
                                      .Where(x => x.Resources.Count > 5)
                                      .OrderByDescending(x => x.Resources.Count)
                                      .ThenByDescending(x => x.StartDate))
            {
                Console.WriteLine(course.Name);
                Console.WriteLine(course.Resources.Count);
            }
            var c = Console.ReadLine();
            PrintInitialScreen(ctx);
        }

        private static void ListCourses(StudentSystemContext ctx)
        {
            foreach (var course in ctx.Courses
                                        .OrderBy(x => x.StartDate)
                                        .ThenByDescending(x => x.EndDate))
            {
                Console.WriteLine(course.Name);
                Console.WriteLine(course.Description);
                foreach (var resourse in course.Resources)
                {
                    Console.WriteLine(resourse.Name);
                    Console.WriteLine(resourse.TypeOfResource);
                    Console.WriteLine(resourse.Url);
                }
            }
            var c = Console.ReadLine();
            PrintInitialScreen(ctx);
        }

        private static void ListStudentsHomeworks(StudentSystemContext ctx)
        {
            foreach (var student in ctx.Students)
            {
                var numberOfHomeworks = student.Homeworks.Count();
                Console.WriteLine($"{student.Name} has {numberOfHomeworks} homeworks submitted.");
                Console.WriteLine(new string('=', 10));
                foreach (var hw in student.Homeworks)
                {
                    Console.WriteLine($"Content: {hw.Content}");
                    Console.WriteLine($"Type: {hw.ContentType}");
                    Console.WriteLine(new string('-', 10));
                }
                Console.WriteLine();
            }

            var c = Console.ReadLine();
            PrintInitialScreen(ctx);
        }
    }
}
