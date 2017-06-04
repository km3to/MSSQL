namespace CreatePersonConstructors
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            if (input.Length == 0)
            {
                Person p = new Person();
                Console.WriteLine(p);
            }
            else if (input.Length == 1)
            {
                int age = -1;
                if (int.TryParse(input[0], out age))
                {
                    Person p = new Person(age);
                    Console.WriteLine(p);
                }
                else
                {
                    Person p = new Person(input[0]);
                    Console.WriteLine(p);
                }
            }
            else if (input.Length == 2)
            {
                Person p = new Person(input[0], int.Parse(input[1]));
                Console.WriteLine(p);
            }
        }
    }

    public class Person
    {
        public Person() : this("No name", 1)
        {
        }

        public Person(int age) : this("No name", age)
        {
        }

        public Person(string name) : this(name, 1)
        {
        }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}
