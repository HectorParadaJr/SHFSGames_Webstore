using System;
using System.Collections.Generic;

namespace SHFSGAMES.Models
{
    public partial class MemberFriendsFamilyLists
    {
        public int FriendsFamilyListId { get; set; }
        public int MemberId { get; set; }
        public string Username { get; set; }

        public virtual FriendsFamilyLists FriendsFamilyLists { get; set; }
        public virtual Members Members { get; set; }
    }
}
