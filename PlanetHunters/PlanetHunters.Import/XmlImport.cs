namespace PlanetHunters.Import
{
    using Data.DTO;
    using Data.Store;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;

    public static class XmlImport
    {
        public static void ImportStars()
        {
            XDocument xml = XDocument.Load("../../../datasets/stars.xml");
            var stars = xml.Root.Elements();
            var result = new List<StarDto>();

            foreach (var star in stars)
            {
                var starDto = new StarDto
                {
                    Name = star.Element("Name").Value,
                    Temperature = int.Parse(star.Element("Temperature").Value),
                    StarSystem = star.Element("StarSystem").Value
                };

                result.Add(starDto);
            }
            StarStore.AddStars(result);
        }

        public static void ImportDiscoveries()
        {
            XDocument xml = XDocument.Load("../../../datasets/discoveries.xml");
            var discoveries = xml.Root.Elements();
            var result = new List<DiscoveryDto>();

            foreach (var discovery in discoveries)
            {
                var discoveryDto = new DiscoveryDto
                {
                    DateMade = DateTime.Parse(discovery.Attribute("DateMade").Value),
                    Telescope = discovery.Attribute("Telescope").Value,
                    Planets = discovery.Element("Planets").Elements().Select(e => e.Element("Planet").Value).ToList(),
                    Stars = discovery.Element("Stars").Elements().Select(e => e.Element("Star").Value).ToList(),
                    Pioneers = discovery.Element("Pioneers").Elements().Select(e => e.Element("Astronomer").Value).ToList(),
                    Observers = discovery.Element("observers").Elements().Select(e => e.Element("Astronomer").Value).ToList()
                };

                result.Add(discoveryDto);
            }
        }
    }
}
