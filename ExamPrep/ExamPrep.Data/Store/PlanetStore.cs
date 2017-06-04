namespace ExamPrep.Data.Store
{
    using DTO;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PlanetStore
    {
        public static void AddPlanets(IEnumerable<PlanetDto> planets)
        {
            using (var context = new MassDefectEntities())
            {
                foreach (var planetDto in planets)
                {
                    if (planetDto.Name == null || planetDto.SolarSystem == null || planetDto.Sun == null)
                    {
                        Console.WriteLine("Error: invalid data.");
                    }
                    else
                    {
                        var solarSystem = SolarSystemStore.GetSystemByName(planetDto.SolarSystem);
                        var sun = StarStore.GetStarByName(planetDto.Sun);

                        if (solarSystem == null || sun == null)
                        {
                            Console.WriteLine("Error: invalid data.");
                        }
                        else
                        {
                            var planet = new Planet
                            {
                                Name = planetDto.Name,
                                SunId = sun.Id,
                                SolarSystemId = solarSystem.Id
                            };

                            context.Planets.Add(planet);
                            Console.WriteLine($"Successfully importes Planet {planet.Name}.");
                        }
                    }
                }

                context.SaveChanges();
            }
        }

        public static Planet GetPlanetByName(string name)
        {
            using (var context = new MassDefectEntities())
            {
                return context.Planets
                    .Where(p => p.Name == name)
                    .FirstOrDefault();
            }
        }
    }
}
