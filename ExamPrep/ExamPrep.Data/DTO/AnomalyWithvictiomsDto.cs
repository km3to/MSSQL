namespace ExamPrep.Data.DTO
{
    using System;
    using System.Collections.Generic;

    public class AnomalyWithvictiomsDto
    {
        public string OriginPlanet { get; set; }

        public string TeleportPlanet { get; set; }

        public ICollection<string> Victims { get; set; }
    }
}
