using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETennis2.Model
{
    public partial class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public int Coach { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        
    }
}
