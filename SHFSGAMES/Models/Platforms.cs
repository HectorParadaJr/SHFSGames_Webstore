using System;
using System.Collections.Generic;

namespace SHFSGAMES.Models
{
    public partial class Platforms
    {
        public Platforms()
        {
            GamePlatforms = new HashSet<GamePlatforms>();
            PlatformMembers = new HashSet<PlatformMembers>();
            CartItems = new HashSet<CartItems>();
            OrderItems = new HashSet<OrderItems>();
        }

        public int PlatformId { get; set; }
        public string PlatformName { get; set; }

        public virtual ICollection<GamePlatforms> GamePlatforms { get; set; }
        public virtual ICollection<PlatformMembers> PlatformMembers { get; set; }
        public virtual ICollection<CartItems> CartItems { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
