using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETennis2.Model
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }

        [Display(Name = "Event")]
        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }

        [Display(Name = "Member")]
        public int MemberId { get; set; }
  
        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }
    }
}
