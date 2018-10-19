using ETennis2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETennis2.Model.ViewModel
{
    public class ScheduleViewModel
    {
        public Schedule Schedule { get; set; }
        public IEnumerable<Event> Event { get; set; }
        public IEnumerable<TennisUser> Member { get; set; }
    }
}
