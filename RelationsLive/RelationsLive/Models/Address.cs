namespace RelationsLive.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class Address
    {
        [Key]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public string Text { get; set; }

        [ForeignKey("Town")]
        public int TownZip { get; set; }
        
        public virtual Town Town { get; set; }

        public virtual Student Student { get; set; }
    }
}
