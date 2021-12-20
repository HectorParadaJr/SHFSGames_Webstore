using System;
using System.Collections.Generic;

namespace SHFSGAMES.Models
{
    public partial class Carts
    {
        public Carts()
        {
            CartItems = new HashSet<CartItems>();
        }

        public int CartId { get; set; }
        public int MemberId { get; set; }

        public virtual Members Members { get; set; }
        public virtual ICollection<CartItems> CartItems { get; set; }

    }
}
