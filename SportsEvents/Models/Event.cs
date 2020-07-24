using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SPEvents.Models
{
    public class Event
    {
        public Event() => EventsUsers = new List<EventsUsers>();

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string id { get; set; }

        [Display(Name = "Event Name")]
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "The name cannot be empty.", MinimumLength = 2)]
        public string title { get; set; }

        [Display(Name = "Location")]
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "The location cannot be empty.", MinimumLength = 2)]
        public string location { get; set; }

        
        public DateTime datetime { get; set; }

        [Display(Name = "Description")]
        [Required]
        [StringLength(maximumLength: 300, ErrorMessage = "The description cannot be empty.", MinimumLength = 2)]
        public string description { get; set; }

        [Display(Name = "Category")]
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "The category cannot be empty.", MinimumLength = 2)]
        public string category { get; set; }

        public List<EventsUsers> EventsUsers { get; set; }
    }
}
