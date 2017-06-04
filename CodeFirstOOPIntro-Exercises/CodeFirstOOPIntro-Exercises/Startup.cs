namespace CodeFirstOOPIntro_Exercises
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
            Person p1 = new Person();
            Person p2 = new Person();
            p1.Age = 20;
            p1.Name = "Pesho";

            Person p3 = new Person();
            p3.Name = "Statamat";
            p3.Age = 43;

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);
        }
    }
}
