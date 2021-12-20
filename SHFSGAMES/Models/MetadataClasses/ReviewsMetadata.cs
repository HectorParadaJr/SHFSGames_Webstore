using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHFSGAMES.Models
{
    [ModelMetadataType(typeof(ReviewsMetadata))]

    public partial class Reviews { }
    public class ReviewsMetadata
    {
        public int ReviewId { get; set; }

        [Display(Name = "Game")]
        public int GameId { get; set; }

        [Display(Name = "Member")]
        public int MemberId { get; set; }
        
        [Required]
        [Display(Name = "Title")]
        [StringLength(30, MinimumLength = 2)]
        public string ReviewTitle { get; set; }

        [Required]
        [Display(Name = "Review")]
        [StringLength(200, MinimumLength = 10)]
        public string ReviewDetails { get; set; }

        [Display(Name = "Approved")]
        public bool Approved { get; set; }

        [Display(Name = "Date")]
        //[DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime ReviewDate { get; set; }
    }
}
