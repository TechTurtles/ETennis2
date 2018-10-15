using System;
using System.Collections.Generic;

namespace ETennis2.Model
{
    public partial class Schedule
    {
        public int ScheduleId { get; set; }
        public int EventId { get; set; }
        public int MemberId { get; set; }
    }
}
