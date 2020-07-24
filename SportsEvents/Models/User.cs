using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPEvents.Models
{
    public class User
    {
        public string id { get; set; }
        [Display(Name = "Name")]
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Name cannot be empty.", MinimumLength = 2)]
        public string name { get; set; }

        [Display(Name = "User-ID")]
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "User ID cannot be empty.", MinimumLength = 2)]
        public string userid { get; set; }

        [Display(Name = "email")]
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Email cannot be empty.", MinimumLength = 7)]
        public string email { get; set; }

        [Display(Name = "Address")]
        [Required]
        [StringLength(maximumLength: 200, ErrorMessage = "Address cannot be empty.", MinimumLength = 2)]
        public string address { get; set; }

        [Display(Name = "Work Location")]
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Work Location cannot be empty.", MinimumLength = 2)]
        public string worklocation { get; set; }

        [Display(Name = "PostCode")]
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "PostCode cannot be empty.", MinimumLength = 2)]
        public string postcode { get; set; }

        [Display(Name = "Contact")]
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Contact cannot be empty.", MinimumLength = 2)]
        public string contact { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }

        [Display(Name = "Gender")]
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Must Select Gender", MinimumLength = 2)]
        public string gender { get; set; }
    }
}
