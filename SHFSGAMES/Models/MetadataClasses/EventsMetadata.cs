using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHFSGAMES.Models
{
    [ModelMetadataType(typeof(EventsMetadata))]

    public partial class Events { }
    public class EventsMetadata
    {
        
        public int EventId { get; set; }
        
        [Required]
        [Display(Name = "Created By")]
        public int EmployeeId { get; set; }
        
        [Required]
        [Display(Name = "Event")]
        [StringLength(50)]
        public string EventTitle { get; set; }

        [Required]
        [Display(Name = "Description")]
        [StringLength(200)]
        public string EventDescription { get; set; }

        //[Required]
        //[Display(Name = "Date/Time")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy hh:mm tt}")]

        //[Required]
        //[Display(Name = "Date/Time")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yyyy hh:mm tt}")]
        //public DateTime EventTimeDate { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime EventDate { get; set; }

        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        [Range(typeof(TimeSpan), "00:00", "23:59")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan EventTime { get; set; }

        [Required]
        [Display(Name = "Location")]
        [StringLength(100)]
        public string EventLocation { get; set; }
    }
}
