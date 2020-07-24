using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPEvents.Models
{
    public class CustomEventModel
    {
        public Event ev { get; set; }
        public List<EventUser> evul { get; set; }
    }
}
