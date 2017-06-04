using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input.ToLower() != "end")
            {
                
                var stud = new Student(input);
                input = Console.ReadLine();
            }

            Console.WriteLine(Student.studentsCount);
        }
    }

    public class Student
    {
        public static int studentsCount = 0;

        public Student(string name)
        {
            this.Name = name;
            studentsCount++;
        }

        public string Name { get; set; }

    }
}
