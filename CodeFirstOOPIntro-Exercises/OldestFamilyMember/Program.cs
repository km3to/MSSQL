namespace OldestFamilyMember
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Family myFamily = new Family();
            int numberOfInputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfInputs; i++)
            {
                var arguments = Console.ReadLine().Split(' ');
                Person personToAdd = new Person(arguments[0], int.Parse(arguments[1]));
                myFamily.AddMember(personToAdd);
            }

            var result = myFamily.GetOldestMember();
            Console.WriteLine(result);
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

    public class Family
    {
        List<Person> members;

        public Family()
        {
            this.members = new List<Person>();
        }

        public void AddMember(Person member)
        {
            this.members.Add(member);
        }

        public Person GetOldestMember()
        {
            return this.members.OrderByDescending(m => m.Age).FirstOrDefault();
        }
    }    
}
