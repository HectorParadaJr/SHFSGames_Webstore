using System;
using System.Collections.Generic;

namespace SHFSGAMES.Models
{
    public partial class PlatformMembers
    {
        public int PlatformId { get; set; }
        public int MemberId { get; set; }

        public virtual Platforms Platforms { get; set; }
        public virtual Members Members { get; set; }
    }
}
