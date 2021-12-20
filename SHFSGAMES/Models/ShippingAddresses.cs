using System;
using System.Collections.Generic;

namespace SHFSGAMES.Models
{
    public partial class ShippingAddresses
    {

        public int ShippingAddressId { get; set; }
        public int MemberId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }

        public virtual Members Members { get; set; }

    }
}
