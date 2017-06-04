namespace PlanetHunters.Data.Store
{
    using Models;
    using PlanetHunters.Data.DTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class AstronomerStore
    {
        public static void AddAstronomers(IEnumerable<AstronomerDto> astronomers)
        {
            using (var context = new PlanetHuntersContext())
            {
                foreach (var astronomerDto in astronomers)
                {
                    if (astronomerDto.FirstName == null || astronomerDto.LastName == null)
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        var astronomer = new Astronomer
                        {
                            FirstName = astronomerDto.FirstName,
                            LastName = astronomerDto.LastName,                             
                        };
                        context.Astronomers.Add(astronomer);
                        Console.WriteLine($"Record {astronomer.FirstName} {astronomer.LastName} successfully imported.");
                    }
                }
                context.SaveChanges();
            }
        }

        public static IEnumerable<AstronomerDto> GetAstronomers()
        {
            using (var context = new PlanetHuntersContext())
            {
                var astronomers = context.Astronomers.Select(p => new AstronomerDto { FirstName = p.FirstName, LastName = p.LastName}).ToList();

                return astronomers;
            }
        }

        public static IEnumerable<Astronomer> GetAstronomersByNamesArray(List<string> names)
        {
            var result = new List<Astronomer>();
            using (var context = new PlanetHuntersContext())
            {                
                foreach (var name in names)
                {
                    var tempName = name.Split(new char[] { ' ',','});
                    var lastName = tempName[0];
                    var firstName = tempName[1];
                    var astronomer = context.Astronomers.Where(a => a.FirstName == firstName && a.LastName == lastName).FirstOrDefault();

                    result.Add(astronomer);
                }
            }
            return result;
        }
    }
}
