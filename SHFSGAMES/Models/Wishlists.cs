using System;
using System.Collections.Generic;

namespace SHFSGAMES.Models
{
    public partial class Wishlists
    {
        public Wishlists()
        {
            WishlistGames = new HashSet<WishlistGames>();
        }

        public int WishlistId { get; set; }
        public int MemberId { get; set; }

        public virtual Members Members { get; set; }

        public virtual ICollection<WishlistGames> WishlistGames { get; set; }
    }
}
