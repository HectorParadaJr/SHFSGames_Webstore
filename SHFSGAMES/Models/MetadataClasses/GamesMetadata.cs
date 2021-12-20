using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHFSGAMES.Models
{
    [ModelMetadataType(typeof(GamesMetadata))]

    public partial class Games { }
    public class GamesMetadata
    {
        public int GameId { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(75)]
        public string GameName { get; set; }
        
        [Required]
        [StringLength(200)]
        [Display(Name = "Description")]
        public string GameDescription { get; set; }

        [Display(Name = "Rating")]
        public string RatingTotal { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Developer")]
        public string GameDeveloper { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime ReleaseDate { get; set; }
    }
}
