using System;
using System.Collections.Generic;

namespace SHFSGAMES.Models
{
    public partial class EventRegistrations
    {
        public int MemberId { get; set; }
        public int EventId { get; set; }
        public bool Registered { get; set; }

        public virtual Members Members { get; set; }
        public virtual Events Events { get; set; }
    }
}
