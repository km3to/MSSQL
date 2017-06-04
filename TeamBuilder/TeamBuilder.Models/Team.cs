namespace TeamBuilder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        public Team()
        {
            this.Events = new HashSet<Event>();
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(32)]
        public string Description { get; set; }
        
        public string Acronym { get; set; }

        public int CreatorId { get; set; }
         
        public virtual User Creator { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
