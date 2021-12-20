using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SHFSGAMES.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int OrderId { get; set; }
        public int MemberId { get; set; }
        public int PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total { get; set; }

        public virtual Members Members { get; set; }
        public virtual Payments Payments { get; set; }


        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
