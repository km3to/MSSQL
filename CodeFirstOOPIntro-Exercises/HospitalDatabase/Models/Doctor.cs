namespace HospitalDatabase.Models
{
    using System;
    using System.Collections.Generic;

    class Doctor
    {
        public int DoctorId { get; set; }

        public string Name { get; set; }

        public string Specialty { get; set; }

        public ICollection<Visitation> Visitations { get; set; }
    }
}
