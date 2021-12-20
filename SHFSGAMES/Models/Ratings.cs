using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SHFSGAMES.Models
{
    public partial class Ratings
    {
        public int RatingId { get; set; }

        [Display(Name = "Game")]
        public int GameId { get; set; }
        public int MemberId { get; set; }
        public double Rate { get; set; }

        public virtual Members Members { get; set; }
        public virtual Games Games { get; set; }
    }
}
