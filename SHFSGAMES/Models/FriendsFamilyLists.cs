using System;
using System.Collections.Generic;

namespace SHFSGAMES.Models
{
    public partial class FriendsFamilyLists
    {
        public FriendsFamilyLists()
        {
            MemberFriendsFamilyLists = new HashSet<MemberFriendsFamilyLists>();
        }

        public int FriendsFamilyListId { get; set; }
        public int MemberId { get; set; }

        public virtual Members Members { get; set; }

        public virtual ICollection<MemberFriendsFamilyLists> MemberFriendsFamilyLists { get; set; }
    }
}
