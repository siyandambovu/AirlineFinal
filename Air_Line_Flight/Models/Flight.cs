using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Air_Line_Flight.Models
{
    public class Flight
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int flightID { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public string Date1 { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Source")]
        public string Source { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Destination")]
        public string Dest { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Number of Seats")]
        public int Number { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Adults")]
        public int Adults { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Children")]
        public int Child { get; set; }
    }

   
}

