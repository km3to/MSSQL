namespace PlanetHunters.Data.Store
{
    using DTO;
    using Models;
    using System;
    using System.Collections.Generic;

    public static class DiscoveryStore
    {
        public static void AddDiscovery(IEnumerable<DiscoveryDto> discoveries)
        {
            using (var context = new PlanetHuntersContext())
            {
                foreach (var discoveryDto in discoveries)
                {
                    if (discoveryDto.DateMade == null )
                    {
                        Console.WriteLine("Invalid data format.");
                    }
                    else
                    {
                        var discovery = new Discovery
                        {
                            DateMade = discoveryDto.DateMade,
                            Observers = null,
                            Pioneers = null,
                            Planets = null,
                            Stars = null,
                            TelescopeUsed = TelescopeStore.GetTelescopeByName(discoveryDto.Telescope)
                        };
                        context.Discoveries.Add(discovery);
                        Console.WriteLine($"Discovery ({discovery.DateMade}-{discovery.TelescopeUsed.Name}) with {discovery.Stars.Count} star(s), {discovery.Planets.Count} planet(s), {discovery.Pioneers.Count} pioneer(s) and {discovery.Observers.Count} observers successfully  imported.");
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
