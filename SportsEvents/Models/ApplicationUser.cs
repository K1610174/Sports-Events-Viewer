using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPEvents.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string contactnumber { get; set; }
        public string workcontact { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string postcode { get; set; }
        public string city { get; set; }
        public string workplace { get; set; }

    }
}
