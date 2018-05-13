using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CVWebsite.Models
{
    public class ContactModel
    {
        [Display (Name = "Name")]
        [StringLength(100,  ErrorMessage = "Name cannot exceed 100 characters")]
        [Required (ErrorMessage = "Name is required")]
        public string name { get; set; }

        [Display(Name = "Email")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Email is required")]
        public string email { get; set; }

        [Display(Name = "Subject")]
        [StringLength(200, ErrorMessage = "Subject cannot exceed 200 characters")]
        public string subject { get; set; }

        [Display(Name = "Message")]
        [StringLength(2000, ErrorMessage = "Message cannot exceed 2000 characters")]
        [Required(ErrorMessage = "Message is required")]
        public string message { get; set; }
    }
}