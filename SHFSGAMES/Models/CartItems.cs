using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SHFSGAMES.Models
{
    public partial class CartItems
    {
        public int CartItemId { get; set; }
        public int CartId { get; set; }
        public int GameId { get; set; }
        public int PlatformId { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }
        public int Quantity { get; set; }

        public virtual Carts Carts { get; set; }
        public virtual Games Games { get; set; }
        public virtual Platforms Platforms { get; set; }
    }
}
