namespace PlanetHunters.Data.Store
{
    using DTO;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class PlanetStore
    {
        public static void AddPlanets(IEnumerable<PlanetDto> planets)
        {
            using (var context = new PlanetHuntersContext())
            {
                foreach (var planetDto in planets)
                {
                    if (planetDto.Name == null || planetDto.StarSystem == null || planetDto.Mass <= 0)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {                        
                        var planet = new Planet
                        {
                            Name = planetDto.Name,
                            Mass = planetDto.Mass,
                            HostStarSystem = StarSystemStore.GetStarSystemByName(planetDto.Name)
                        };

                        context.Planets.Add(planet);
                        Console.WriteLine($"Record {planet.Name} successfully imported.");
                    }
                }
                context.SaveChanges();
            }
        }

        public static IEnumerable<PlanetDto> GetPlanets()
        {
            using (var context = new PlanetHuntersContext())
            {
                var planets = context.Planets.Select(p => new PlanetDto { Name = p.Name, Mass = p.Mass, StarSystem = p.HostStarSystem.Name }).ToList();

                return planets;
            }
        }
    }
}
