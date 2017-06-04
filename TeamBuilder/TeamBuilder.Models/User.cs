namespace TeamBuilder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum Gender
    {
        Male,
        Female
    }

    public class User
    {
        public User()
        {
            this.Teams = new HashSet<Team>();
            this.CreatedTeams = new HashSet<Team>();
        }

        public int Id { get; set; }

        [Required, MinLength(3), MaxLength(25)]
        public string Username { get; set; }

        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }

        [Required, MinLength(6), MaxLength(30)]
        public string Password { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public virtual ICollection<Team> CreatedTeams { get; set; }
    }
}
