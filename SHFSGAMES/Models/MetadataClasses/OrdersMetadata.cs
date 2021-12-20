using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHFSGAMES.Models
{
    [ModelMetadataType(typeof(OrdersMetadata))]

    public partial class Orders { }
    public class OrdersMetadata
    {
        [Display(Name = "Order Id")]
        public int OrderId { get; set; }
        public int MemberId { get; set; }

        public int PaymentId { get; set; }

        [Display(Name = "Order Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Shipped Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime ShippedDate { get; set; }
        public string Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total { get; set; }
    }
}
