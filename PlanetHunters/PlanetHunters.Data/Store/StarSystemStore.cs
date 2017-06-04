namespace PlanetHunters.Data.Store
{
    using Models;
    using System;
    using System.Linq;

    public static class StarSystemStore
    {
        public static StarSystem GetStarSystemByName(string name)
        {
            using (var context = new PlanetHuntersContext())
            {
                return context.StarSystems.Where(ss => ss.Name == name).FirstOrDefault();
            }
        }
    }
}
