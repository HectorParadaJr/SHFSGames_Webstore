using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SHFSGAMES.Models
{
    public partial class Members
    {
        public Members()
        {
            Accounts = new HashSet<Accounts>();
            Carts = new HashSet<Carts>();
            CategoryMembers = new HashSet<CategoryMembers>();
            EventRegistrations = new HashSet<EventRegistrations>();
            FriendsFamilyLists = new HashSet<FriendsFamilyLists>();
            Orders = new HashSet<Orders>();
            Reviews = new HashSet<Reviews>();
            Ratings = new HashSet<Ratings>();
            Payments = new HashSet<Payments>();
            PlatformMembers = new HashSet<PlatformMembers>();
            Wishlists = new HashSet<Wishlists>();
            ShippingAddresses = new HashSet<ShippingAddresses>();
            MailingAddresses = new HashSet<MailingAddresses>();
            MemberFriendsFamilyLists = new HashSet<MemberFriendsFamilyLists>();
        }

        public int MemberId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public bool ReceiveEmail { get; set; }


        public virtual ICollection<Accounts> Accounts { get; set; }
        public virtual ICollection<Carts> Carts { get; set; }
        public virtual ICollection<CategoryMembers> CategoryMembers { get; set; }
        public virtual ICollection<EventRegistrations> EventRegistrations { get; set; }
        public virtual ICollection<FriendsFamilyLists> FriendsFamilyLists { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
        public virtual ICollection<Ratings> Ratings { get; set; }
        public virtual ICollection<Payments> Payments { get; set; }
        public virtual ICollection<PlatformMembers> PlatformMembers { get; set; }
        public virtual ICollection<Wishlists> Wishlists { get; set; }
        public virtual ICollection<ShippingAddresses> ShippingAddresses { get; set; }
        public virtual ICollection<MailingAddresses> MailingAddresses { get; set; }
        public virtual ICollection<MemberFriendsFamilyLists> MemberFriendsFamilyLists { get; set; }
    }
}
