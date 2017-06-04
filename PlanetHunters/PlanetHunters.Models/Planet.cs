namespace PlanetHunters.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Planet
    {
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }

        // TODO: Cannot be zero or negative 
        [Required]
        public double Mass { get; set; }

        public int HostStarSystemId { get; set; }

        [Required]
        public virtual StarSystem HostStarSystem { get; set; }
    }
}
