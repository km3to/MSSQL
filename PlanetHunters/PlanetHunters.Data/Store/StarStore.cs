namespace PlanetHunters.Data.Store
{
    using DTO;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class StarStore
    {
        public static void AddStars(IEnumerable<StarDto> stars)
        {
            using (var context = new PlanetHuntersContext())
            {
                foreach (var starDto in stars)
                {
                    if (starDto.Name == null || starDto.StarSystem == null || starDto.Temperature < 2400)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        var star = new Star
                        {
                            Name = starDto.Name,
                            Temperature = starDto.Temperature,
                            HostStarSystem = StarSystemStore.GetStarSystemByName(starDto.StarSystem)
                        };
                        context.Stars.Add(star);
                        Console.WriteLine($"Record {star.Name} successfully imported");
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
