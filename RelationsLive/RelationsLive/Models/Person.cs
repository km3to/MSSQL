namespace RelationsLive.Models
{
    using System.Collections.Generic;

    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual Town PlaceOfBirth { get; set; }

        public virtual Town CurrentResidence { get; set; }
    }
}
