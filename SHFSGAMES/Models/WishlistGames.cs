using System;
using System.Collections.Generic;

namespace SHFSGAMES.Models
{
    public partial class WishlistGames
    {
        public int WishlistId { get; set; }
        public int GameId { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual Wishlists Wishlists { get; set; }
        public virtual Games Games { get; set; }
    }
}
