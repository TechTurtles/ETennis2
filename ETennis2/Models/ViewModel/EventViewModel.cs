using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETennis2.Model.ViewModel
{
    public class EventViewModel
    {
        public Event Event { get; set; }
        public IEnumerable<TennisUser> Coach { get; set; }
    }
}
