using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SHFSGAMES.Models
{
    public partial class Games
    {
        public Games()
        {
            CartItems = new HashSet<CartItems>();
            GameCategories = new HashSet<GameCategories>();
            GamePlatforms = new HashSet<GamePlatforms>();
            OrderItems = new HashSet<OrderItems>();
            Ratings = new HashSet<Ratings>();
            Reviews = new HashSet<Reviews>();
            WishlistGames = new HashSet<WishlistGames>();
        }

        public int GameId { get; set; }
        
        [Display(Name = "Name")]
        public string GameName { get; set; }
        
        [Display(Name = "Description")]
        public string GameDescription { get; set; }
        
        [Display(Name = "Rating")]
        public string RatingTotal { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }
        
        [Display(Name = "Developer")]
        public string GameDeveloper { get; set; }
        
        [Display(Name = "Release Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime ReleaseDate { get; set; }
        
        public virtual ICollection<CartItems> CartItems { get; set; }
        public virtual ICollection<GameCategories> GameCategories { get; set; }
        public virtual ICollection<GamePlatforms> GamePlatforms { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
        public virtual ICollection<Ratings> Ratings { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
        public virtual ICollection<WishlistGames> WishlistGames { get; set; }

    }
}
