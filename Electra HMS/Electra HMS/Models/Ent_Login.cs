using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Electra_HMS.Models
{
    public class Ent_Login
    {
        [ScaffoldColumn(false)]
        public string LoginId { get; set; }

        [Required(ErrorMessage = "Required!!")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}