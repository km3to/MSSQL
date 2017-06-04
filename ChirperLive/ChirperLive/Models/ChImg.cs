﻿namespace ChirperLive.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ChImg
    {
        public byte[] Image { get; set; }

        public int ChirpId { get; set; }

        public virtual Chirp Chirp { get; set; }
    }
}
