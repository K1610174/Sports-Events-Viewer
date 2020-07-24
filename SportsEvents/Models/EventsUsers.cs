using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPEvents.Models
{
    public class EventsUsers
    {
       
        public string EventId { get; set; }

        public int userId { get; set; }

        public Event thisevent { get; set; }

        public EventUser eu { get; set; }

    }
}
