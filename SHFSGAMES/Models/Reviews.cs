using System;
using System.Collections.Generic;

namespace SHFSGAMES.Models
{
    public partial class Reviews
    {
        public int ReviewId { get; set; }
        public int GameId { get; set; }
        public int MemberId { get; set; }
        public string ReviewTitle { get; set; }
        public string ReviewDetails { get; set; }
        public bool Approved { get; set; }
        public DateTime ReviewDate { get; set; }

        public virtual Games Games { get; set; }
        public virtual Members Members { get; set; }
    }
}
