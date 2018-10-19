using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETennis2.Model
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }

        [Display(Name = "EventId")]
        public int EventId { get; set; }

        //[ForeignKey("Event")]
        public virtual Event Event { get; set; }

        [Display(Name = "UserId")]
        public int UserId { get; set; }

        //[ForeignKey("User")]
        public virtual TennisUser TennisUser { get; set; }
    }
}
