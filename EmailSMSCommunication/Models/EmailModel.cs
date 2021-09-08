using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmailSMSCommunication.Models
{
    public class EmailModel
    {
        [Required, Display(Name = "Your Name")]
        public string toName { get; set; }
        [Required, Display(Name = "Your Email")]
        public string toEmail { get; set; }
        [Required]
        public string subject { get; set; }
        [Required]
        public string message { get; set; }

    }
}