using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LPDoctorsApp.Models
{
    public class BookingVisitModel
    {
        [Required(ErrorMessage ="Required name")]
        [Display(Name ="Input Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage ="Incorrect Email address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }
    }
}
