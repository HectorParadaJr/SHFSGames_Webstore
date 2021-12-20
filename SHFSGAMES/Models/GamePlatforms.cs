using System;
using System.Collections.Generic;

namespace SHFSGAMES.Models
{
    public partial class GamePlatforms
    {
        public int PlatformId { get; set; }
        public int GameId { get; set; }

        public virtual Platforms Platforms { get; set; }
        public virtual Games Games { get; set; }
    }
}
