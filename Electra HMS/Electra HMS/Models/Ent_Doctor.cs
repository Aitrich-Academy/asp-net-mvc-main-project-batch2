using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Electra_HMS.Models
{
    public class Ent_Doctor
    {
        [Key]
        [ScaffoldColumn(false)]
        public int DoctorID { get; set; }

        [Required(ErrorMessage = "Required!!")]
        public string D_Name { get; set; }

        [Required(ErrorMessage = "Required!!")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Please enter a valid phone number")]
        public string D_PhoneNo { get; set; }

        [Required(ErrorMessage = "Required!!")]
        [DisplayName("D_Email"), EmailAddress]
        public string D_Email { get; set; }

        public string Designation { get; set; }

        public int DeptId { get; set; }

        public string D_Address { get; set; }

        public string D_ContactNo { get; set; }
        [Required]
        public string D_Specialization { get; set; }

        public string D_Gender { get; set; }

        [Required(ErrorMessage = "Required!!")]
        [DisplayName("Date of birth")]
        public DateTime D_DOB { get; set; }

        public string D_Status { get; set; }

        [Required(ErrorMessage = "Required!!")]
        [RegularExpression(@"^.*(?=.{8,})(?=.*[\d])(?=.*[\W]).*$", ErrorMessage = "- contains at least 8 characters \n - contains at least one digit \n - contains at least one special character")]

        public string D_Password { get; set; }
    }
}