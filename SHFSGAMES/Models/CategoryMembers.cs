using System;
using System.Collections.Generic;

namespace SHFSGAMES.Models
{
    public partial class CategoryMembers
    {
        public int CategoryId { get; set; }
        public int MemberId { get; set; }

        public virtual Members Members { get; set; }
    }
}
