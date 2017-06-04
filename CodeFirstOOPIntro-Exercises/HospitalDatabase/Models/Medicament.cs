namespace HospitalDatabase.Models
{
    using System;

    public class Medicament
    {
        public int MedicamentId { get; set; }

        public string Name { get; set; }

        public int DiagnoseId { get; set; }

        public virtual Diagnose Diagnose { get; set; }
    }
}
