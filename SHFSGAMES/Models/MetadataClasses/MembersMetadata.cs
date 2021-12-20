using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHFSGAMES.Models
{
    [ModelMetadataType(typeof(MembersMetadata))]

    public partial class Members { }
    public class MembersMetadata
    {
        public int MemberId { get; set; }
        public int ShippingAddressId { get; set; }
        public int MailingAddressId { get; set; }
        
        [StringLength(25)]
        [Required]
        //[Remote("UniqueUsername", "Members")]
        public string Username { get; set; }
        
        [StringLength(20, MinimumLength = 8)]
        [DataType(DataType.Password)]
        //[Required]
        //[Remote("StrongPassword", "Members")]
        public string Password { get; set; }
        
        [Display(Name = "First Name")]
        [StringLength(100)]
        [Required]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        [StringLength(100)]
        [Required]
        public string LastName { get; set; }
        
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [Required]
        //[Remote("UniqueEmail", "Members")]
        public string Email { get; set; }
        
        [StringLength(25)]
        [Required]
        [Remote("Gender", "Members")]
        public string Gender { get; set; }
        
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy}")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be exactly 10 digits")]
        //[Required]
        public string Phone { get; set; }
        
        [Display(Name = "Receive Email")]
        public bool ReceiveEmail { get; set; }
    }
}
