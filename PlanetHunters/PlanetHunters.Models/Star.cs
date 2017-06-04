namespace PlanetHunters.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Star
    {
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string Name { get; set; }
        
        //Cannot be lower than 2400K
        [Required]
        public int Temperature { get; set; }
        
        public int HostStarSystemId { get; set; }

        [Required]
        public virtual StarSystem HostStarSystem { get; set; }
    }
}
