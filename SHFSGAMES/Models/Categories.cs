using System;
using System.Collections.Generic;

namespace SHFSGAMES.Models
{
    public partial class Categories
    {
        public Categories()
        {
            GameCategories = new HashSet<GameCategories>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<GameCategories> GameCategories { get; set; }
    }
}
