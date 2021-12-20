using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHFSGAMES.Models
{
    [ModelMetadataType(typeof(ShippingAddressesMetadata))]

    public partial class ShippingAddresses { }
    public class ShippingAddressesMetadata
    {
        public int ShippingAddressId { get; set; }
        public int MemberId { get; set; }

        [Required]
        [StringLength(70, MinimumLength = 5)]
        public string Address { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string City { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
    }
}
