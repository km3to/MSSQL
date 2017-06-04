namespace PlanetHunters.Data.Store
{
    using DTO;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class TelescopeStore
    {
        public static void AddTelescopes(IEnumerable<TelescopeDto> telescopes)
        {
            using (var context = new PlanetHuntersContext())
            {
                foreach (var telescopeDto in telescopes)
                {
                    if (telescopeDto.Name == null || telescopeDto.Location == null || telescopeDto.MirrorDiameter <= 0)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        var telescope = new Telescope
                        {
                            Name = telescopeDto.Name,
                            Location = telescopeDto.Location,
                            MirrorDiameter = telescopeDto.MirrorDiameter
                        };
                        context.Telescopes.Add(telescope);
                        Console.WriteLine($"Record {telescope.Name} successfully imported.");
                    }
                }
                context.SaveChanges();
            }
        }

        public static IEnumerable<TelescopeDto> GetTelescopes()
        {
            using (var context = new PlanetHuntersContext())
            {
                var telecsopes = context.Telescopes.Select(t => new TelescopeDto { Name =  t.Name, Location = t.Location, MirrorDiameter = t.MirrorDiameter}).ToList();

                return telecsopes;
            }
        }

        public static Telescope GetTelescopeByName(string name)
        {
            using (var context = new PlanetHuntersContext())
            {
                return context.Telescopes.Where(t => t.Name == name).FirstOrDefault();
            }
        }
    }
}
