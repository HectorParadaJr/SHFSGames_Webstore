using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SHFSGAMES.Models
{
    public partial class Events
    {
        public Events()
        {
            EventRegistrations = new HashSet<EventRegistrations>();
        }

        public int EventId { get; set; }
        public int EmployeeId { get; set; }
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime EventDate { get; set; }
        
        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        [Range(typeof(TimeSpan),"00:00","23:59")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan EventTime { get; set; }
        
        public string EventLocation { get; set; }

        
        public virtual Employees Employees { get; set; }

        public virtual ICollection<EventRegistrations> EventRegistrations { get; set; }

    }
}
