using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SHFSGAMES.Models
{
    public partial class MailingAddresses
    {

        public int MailingAddressId { get; set; }
        public int MemberId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        
        public virtual Members Members { get; set; }

    }
}
