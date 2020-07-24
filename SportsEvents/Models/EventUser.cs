using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPEvents.Models
{
    public class EventUser
    {
        public EventUser() => EventsUsers = new List<EventsUsers>();

        [Key]
        public int euid { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(maximumLength: 100, ErrorMessage = "Firstname cannot be empty.", MinimumLength = 2)]
        public string firstname { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(maximumLength: 100, ErrorMessage = "Lastname cannot be empty.", MinimumLength = 2)]
        public string lastname { get; set; }

        [Required]
        [Display(Name = "Personal Contact")]
        [StringLength(maximumLength: 100, ErrorMessage = "Personal contact cannot be empty.", MinimumLength = 8)]
        public string contactnumber { get; set; }

        [Required]
        [Display(Name = "Work Contact")]
        [StringLength(maximumLength: 100, ErrorMessage = "Work contact cannot be empty.", MinimumLength = 8)]
        public string workcontact { get; set; }

        [Required]

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        [StringLength(maximumLength: 100, ErrorMessage = "Address Line 1 cannot be empty.", MinimumLength = 2)]
        public string address1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string address2 { get; set; }

        [Required]
        [Display(Name = "Postcode")]
        [StringLength(maximumLength: 100, ErrorMessage = "Postcode cannot be empty.", MinimumLength = 4)]
        public string postcode { get; set; }

        [Required]
        [Display(Name = "City")]
        [StringLength(maximumLength: 100, ErrorMessage = "City cannot be empty.", MinimumLength = 3)]
        public string city { get; set; }

        [Required]
        [Display(Name = "Work Location")]
        [StringLength(maximumLength: 100, ErrorMessage = "Place of work cannot be empty.", MinimumLength = 3)]
        public string workplace { get; set; }

        public ICollection<EventsUsers> EventsUsers  { get; set; }
    }
}
