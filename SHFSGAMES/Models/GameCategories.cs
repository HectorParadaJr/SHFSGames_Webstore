using System;
using System.Collections.Generic;

namespace SHFSGAMES.Models
{
    public partial class GameCategories
    {
        public int CategoryId { get; set; }
        public int GameId { get; set; }
        
        public virtual Categories Categories { get; set; }
        public virtual Games Games { get; set; }
    }
}
