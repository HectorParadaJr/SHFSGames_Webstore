using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHFSGAMES.Models

{
    [ModelMetadataType(typeof(PaymentsMetadata))]

    public partial class Payments { }
    public class PaymentsMetadata
    {
        [Display(Name = "Payment")]
        public int PaymentId { get; set; }
        public int MemberId { get; set; }

        [Required]
        [Display(Name = "Card Number")]
        [StringLength(16, MinimumLength = 16)]
        //[DataType(DataType.CreditCard)]
        public string CardNumber { get; set; }
        
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }

        [Display(Name = "Expiration Month")]
        public int ExpirationMonth { get; set; }

        [Display(Name = "Expiration Year")]
        public int ExpirationYear { get; set; }

        public string CustomPaymentField { get { return "Number: " + CardNumber + " | Expiration Date: " + ExpirationMonth + "/" + ExpirationYear; } }
    }
}
