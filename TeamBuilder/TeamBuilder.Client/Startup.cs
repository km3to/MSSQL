namespace TeamBuilder.Client
{
    using Data;
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            //Utility.InitDB();

            Console.WriteLine("You can:");
            Console.WriteLine();
            Console.WriteLine($"[1]. Register user");

            var inputArgs = Console.ReadLine().Split(' ');
            var command = inputArgs[0].ToLower();

            switch (command)
            {
                case "registeruser":
                    RegisterUser(inputArgs);
                    break;
            }
        }

        public static void RegisterUser(string[] arr)
        {
            string username = arr[1];
            string password = arr[2];
            string repeatPassword = arr[3];
            string firstName = arr[4];
            string lastName = arr[5];
            int age = int.Parse(arr[6]);
            string gender = arr[7];

            if (username.Length < 3 || username.Length > 25)
            {
                throw new ArgumentException("Username must be between 3 and 25 charachters long.");
            }

            if (password.Length < 6 || username.Length > 30)
            {
                throw new ArgumentException("Password must be between 6 and 30 charachters long.");
            }

            if (age <= 0)
            {
                throw new ArgumentException();
            }

            if (gender != "Male" && gender != "Female")
            {
                throw new ArgumentException("Gender must be 'Male' or 'Female'");
            }

            if (password != repeatPassword)
            {
                throw new ArgumentException("Passwords do not match");
            }

            using(var context = new TeamBuilderContext())
            {                
                if (context.Users.Any(u => u.Username == username))
                {
                    throw new ArgumentException("Username already taken!");
                }
            }

            using (var context = new TeamBuilderContext())
            {
                context.Users.Add(new Models.User
                {
                    Username = username,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age
                });

                context.SaveChanges();
                Console.WriteLine($"User {username} successfully regustered.");
            }
        }
    }
}
