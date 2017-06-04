namespace Photographers.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Photographers.Data.PhotographerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Photographers.Data.PhotographerContext context)
        {
            Photographer teo = new Photographer()
            {
                Username = "teo",
                Password = "ldkhef978q3",
                Email = "teo@softuni.bg",
                BirthDate = DateTime.Now,
                RegisterDate = DateTime.Now.AddDays(-20)
            };

            context.Photographers.AddOrUpdate(p => p.Username, teo);
            context.SaveChanges();

            Photographer bojo = new Photographer()
            {
                Username = "bojo",
                Password = "ldkhef978q3",
                Email = "teo@softuni.bg",
                BirthDate = DateTime.Now,
                RegisterDate = DateTime.Now.AddDays(-20)
            };

            context.Photographers.AddOrUpdate(p => p.Username, bojo);
            context.SaveChanges();

            Picture demoPicture = new Picture()
            {
                Title = "Demo",
                Caption = "Demo",
                FileSystempath = "/public/images/demo.png"
            };

            context.Pictures.AddOrUpdate(i => i.Title, demoPicture);

            Album vitosha = new Album()
            {
                Name = "Vitosha",
                BackgroundColor = "Black",
                IsPublic = true
            };            

            context.Albums.AddOrUpdate(a => a.Name, vitosha);

            vitosha.Pictures.Add(demoPicture);
            context.SaveChanges();

            PhotographerAlbum ph = new PhotographerAlbum()
            {
                Photographer_Id = teo.Id,
                Album_Id = vitosha.Id,
                Role = Role.Viewer
            };

            vitosha.Photographers.Add(ph);
            context.PhotographerAlbums.Add(ph);          

            Tag mountainTag = new Tag()
            {
                Label = "#mountain"
            };
            context.Tags.AddOrUpdate(t => t.Label, mountainTag);
            mountainTag.Albums.Add(vitosha);
            context.SaveChanges();
        }
    }
}
