﻿namespace Organizer.Models.Contacts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Phone
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}
