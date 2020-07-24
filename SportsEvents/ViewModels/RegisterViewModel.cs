using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPEvents.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password need to be matched")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string contactnumber { get; set; }

        public string workcontact { get; set; }

        [Required]
        public DateTime dob { get; set; }

        [Required]
        public string address1 { get; set; }

        [Required]
        public string address2 { get; set; }
        [Required]
        public string postcode { get; set; }
        [Required]
        public string city { get; set; }

        [Required]
        public string workplace { get; set; }
    }
}
