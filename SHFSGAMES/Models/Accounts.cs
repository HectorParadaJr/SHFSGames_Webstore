using System;
using System.Collections.Generic;

namespace SHFSGAMES.Models
{
    public partial class Accounts
    {
        public int AccountId { get; set; }
        public int MemberId { get; set; }

        public virtual Members Members { get; set; }
    }
}
