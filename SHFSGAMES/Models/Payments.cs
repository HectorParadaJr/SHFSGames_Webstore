using System;
using System.Collections.Generic;

namespace SHFSGAMES.Models
{
    public partial class Payments
    {
        public Payments()
        {
            Orders = new HashSet<Orders>();
        }

        public int PaymentId { get; set; }
        public int MemberId { get; set; }
        public string CardNumber { get; set; }
        public string Name { get; set; }
        public int ExpirationMonth { get; set; }
        public int ExpirationYear { get; set; }

        public virtual Members Members { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
