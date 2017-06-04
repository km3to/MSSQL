namespace CreateUser
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new CreateUserContext();
            //context.Database.Initialize(true);

            User user1 = new User("pesho123", "A2$5a1ff@aZ", "pesho@abv.bg")
            {
                RegisteredOn = new DateTime(2016, 10, 10),
                LastTimeLoggedIn = new DateTime(2017, 06, 03),
                Age = 31,
                IsDeleted  = false
            };

            User user2 = new User("veska29", "A2$5a1ff@aZ", "veska@abv.bg")
            {                
                RegisteredOn = new DateTime(2016, 10, 10),
                LastTimeLoggedIn = new DateTime(2017, 06, 03),
                Age = 13,
                IsDeleted = false
            };

            context.Users.Add(user2);

            context.SaveChanges();
        }
    }

    public class User
    {
        private string username;

        private string password;

        private string email;

        private byte[] profilePicture;

        private int age;


        public User(string username, string password, string email)
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }



        public int Id { get; set; }
                
        public string Username
        {
            get
            {
                return this.username;
            }
            set
            {
                if (value.Length < 4 || value.Length > 30)
                {
                    throw new Exception("Invalid Username!");
                }

                this.username = value;
            }
        }
                     
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                bool containsDigit = false;
                bool containsLower = false;
                bool containsUpper = false;
                bool containsSymbol = false;

                for (int i = 0; i < value.Length; i++)
                {
                    char c = value[i];

                    if (char.IsDigit (c))
                    {
                        containsDigit = true;
                    }
                    else if (char.IsLower(c))
                    {
                        containsLower = true;
                    }
                    else if (char.IsUpper(c))
                    {
                        containsUpper = true;
                    }
                    else if ("(!@#$%^&*()_+<>?".Contains(c.ToString()))
                    {
                        containsSymbol = true;
                    }
                }

                if (containsDigit && containsLower && containsUpper && containsSymbol)
                {
                    this.password = value;
                }
                else
                {
                    throw new Exception("Invalid password!");
                }
            }
        }
                
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                Regex regex = new Regex(@"^([a-zA-Z0-9]+(-|\.|_)?)*[a-zA-Z0-9]+@[\w]+\.[\w]+$");

                if (!regex.IsMatch(value))
                {
                    throw new Exception("Invalid email!");
                }

                this.email = value;
            }
        }
        
        public byte[] ProfilePicture
        {
            get
            {
                return this.profilePicture;
            }
            set
            {
                if (value.Length > 1000 * 1000)
                {
                    throw new Exception("Profile picture too large!");
                }

                this.profilePicture = value;
            }
        }

        public DateTime RegisteredOn { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }
        
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 1 || value > 120)
                {
                    throw new Exception("Invalid age!");
                }

                this.age = value;
            }
        }

        public bool IsDeleted { get; set; }
    }

    public class CreateUserContext : DbContext
    {
        
        public CreateUserContext()
            : base("name=CreateUserContext")
        {
        }

       public DbSet<User> Users { get; set; }
    }

    
}

