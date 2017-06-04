namespace ChirperLive.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? PLaceOfBirthId { get; set; }

        public int? CurrentResidenceId { get; set; }

        public virtual Town PLaceOfBirth { get; set; }

        public virtual Town CurrentResidence { get; set; }
    }
}
