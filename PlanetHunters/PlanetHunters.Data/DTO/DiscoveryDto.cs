namespace PlanetHunters.Data.DTO
{
    using System;
    using System.Collections.Generic;

    public class DiscoveryDto
    {
        public DateTime DateMade { get; set; }

        public string Telescope { get; set; }

        public ICollection<string> Stars { get; set; }

        public ICollection<string> Planets { get; set; }

        public ICollection<string> Pioneers { get; set; }

        public ICollection<string> Observers { get; set; }
    }
}
