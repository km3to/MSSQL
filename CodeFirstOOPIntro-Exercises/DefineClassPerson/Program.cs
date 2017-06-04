namespace DefineClassPerson
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Person();
            p1.Name = "Pesho";
            p1.Age = 20;

            Person p2 = new Person();
            p2.Name = "Gosho";
            p2.Age = 18;

            Person p3 = new Person()
            {
                Name = "Stamat",
                Age = 43
            };

            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
