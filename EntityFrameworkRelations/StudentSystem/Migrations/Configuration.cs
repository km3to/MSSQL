namespace StudentSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    public class Configuration : DbMigrationsConfiguration<StudentSystem.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "StudentSystem.StudentSystemContext";
        }

        protected override void Seed(StudentSystem.StudentSystemContext context)
        {
            Course java = new Course()
            {
                Name = "Java",
                Description = "Course about Java",
                EndDate = DateTime.Now,
                Price = 180m,
                StartDate = DateTime.Now
            };
            java.Resources.Add(new Resource()
            {
                Name = "Resource1",
                TypeOfResource = ResourceType.Document,
                Url = "www.Resource1.com"
            });
            java.Resources.Add(new Resource()
            {
                Name = "Resource2",
                TypeOfResource = ResourceType.Presentation,
                Url = "www.Resource2.com"
            });
            java.Resources.Add(new Resource()
            {
                Name = "Resource3",
                TypeOfResource = ResourceType.Video,
                Url = "www.Resource3.com"
            });
            java.Resources.Add(new Resource()
            {
                Name = "Resource4",
                TypeOfResource = ResourceType.Video,
                Url = "www.Resource4.com"
            });
            java.Resources.Add(new Resource()
            {
                Name = "Resource5",
                TypeOfResource = ResourceType.Video,
                Url = "www.Resource5.com"
            });
            java.Resources.Add(new Resource()
            {
                Name = "Resource6",
                TypeOfResource = ResourceType.Video,
                Url = "www.Resource6.com"
            });

            Student pesho = new Student()
            {
                Birthday = DateTime.Now,
                Name = "Pesho",
                PhoneNumber = "+239843294",
                RegistrationDate = DateTime.Now
            };
            pesho.Courses.Add(java);

            pesho.Homeworks.Add(new Homework()
            {
                Content = "This is Pesho's first homework.",
                ContentType = ContentType.Application,
                Course = pesho.Courses.FirstOrDefault(),
                SubmissionDate = DateTime.Now
            });
            pesho.Homeworks.Add(new Homework()
            {
                Content = "This is Pesho's second homework.",
                ContentType = ContentType.Pdf,
                Course = pesho.Courses.FirstOrDefault(),
                SubmissionDate = DateTime.Now
            });
            pesho.Homeworks.Add(new Homework()
            {
                Content = "This is Pesho's third homework.",
                ContentType = ContentType.Zip,
                Course = pesho.Courses.FirstOrDefault(),
                SubmissionDate = DateTime.Now
            });

            Student gosho = new Student()
            {
                Birthday = DateTime.Now,
                Name = "Gosho",
                PhoneNumber = "+239843294",
                RegistrationDate = DateTime.Now
            };
            pesho.Courses.Add(new Course()
            {
                Name = "C#",
                Description = "Course about C#",
                EndDate = DateTime.Now,
                Price = 220m,
                StartDate = DateTime.Now
            });

            context.Students.AddOrUpdate(s => s.Name, pesho);
            context.Students.AddOrUpdate(s => s.Name, gosho);
            context.SaveChanges();
        }
    }
}
