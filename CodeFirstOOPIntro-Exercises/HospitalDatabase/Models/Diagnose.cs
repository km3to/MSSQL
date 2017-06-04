namespace HospitalDatabase.Models
{
    using System;
    using System.Collections.Generic;

    public class Diagnose
    {
        public Diagnose()
        {
            this.Comments = new HashSet<Comment>();
        }

        public int DiagnoseId { get; set; }

        public string Name { get; set; }

        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
