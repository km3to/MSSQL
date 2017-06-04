namespace PlanetHunters.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Telescope
    {
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string Location { get; set; }

        // Make it non-negaitive and zero
        public double? MirrorDiameter { get; set; }
    }
}
