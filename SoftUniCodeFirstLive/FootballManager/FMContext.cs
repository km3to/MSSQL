﻿namespace FootballManager
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class FMContext : DbContext
    {
        public FMContext() 
            : base("FootballManagerContext") { }

        public virtual DbSet<Team> Teams { get; set; }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<Manager> Managers { get; set; }

        public virtual DbSet<League> Leagues { get; set; }
    }
}
