using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LPDoctorsApp.Models;
using LPDoctorsApp.Services;
using System.ComponentModel.DataAnnotations;

namespace LPDoctorsApp.Pages
{
    public class IndexModel : PageModel
    {
        [Required(ErrorMessage = "Required name")]
        [Display(Name = "Input Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required Email")]
        [EmailAddress(ErrorMessage = "Incorrect Email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Select a date")]
        [DataType(DataType.Date)]
        public DateTime VisitDate { get; set; }

        public string MessageSended { get; set; }

        public void OnGet()  {}

        public async Task OnPostAsync(string name, string email, DateTime visitDate)
        {
            if (ModelState.IsValid)
            {
                string mesaage = name + " " + email + " " + visitDate.ToShortDateString();
                EmailSender sendEmail = new EmailSender();
                await sendEmail.SendEmailAsync("New visit registration", mesaage);
                ViewData["MessageSuccess"] = "Thank you for ordering our services.";
                //ViewData["MessageDanger"] = null;
            }
            else
            {
                //ViewData["MessageSuccess"] = null;
                ViewData["MessageDanger"] = "Please correct your data.";
            }
        }
    }
}
