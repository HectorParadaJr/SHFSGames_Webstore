using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SHFSGAMES.Models
{
    public partial class OrderItems
    {
        public int OrderItemsId { get; set; }
        public int OrderId { get; set; }
        public int GameId { get; set; }
        public int Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }
        public int PlatformId { get; set; }

        public virtual Orders Orders { get; set; }
        public virtual Games Games { get; set; }
        public virtual Platforms Platforms { get; set; }
    }
}
