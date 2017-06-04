namespace HospitalDatabase.Models
{
    using System;
    using System.Collections.Generic;

    public class Visitation
    {
        public Visitation()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int VisitationId { get; set; }

        public DateTime Date { get; set; }

        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
