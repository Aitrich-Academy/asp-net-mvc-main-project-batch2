using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Electra_HMS.Models
{
    public class Ent_Patient
    {

        [Key]
        [ScaffoldColumn(false)]
        public int PatientID { get; set; }

        [Required(ErrorMessage = "Required!!")]


        [DisplayName("Name")]
        public string P_Name { get; set; }

        [Required(ErrorMessage = "Required!!")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Please enter a valid phone number")]
        [DisplayName("Phone NO")]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        public string P_PhoneNo { get; set; }

        [Required(ErrorMessage = "Required!!")]
        [DisplayName("Email Id"), EmailAddress]
        public string P_Email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [DisplayName("Address")]
        public string P_Address { get; set; }

        [DisplayName("BloodGroup")]
        [Required(ErrorMessage = "BloodGroup is required")]
        public string P_BloodGroup { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = "Gender is required")]
        public string P_Gender { get; set; }


        [Required(ErrorMessage = "Date Of Birth is required")]
        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]
       
        public DateTime? P_DOB { get; set; }

        [ScaffoldColumn(false)]
        public string P_Status { get; set; }

        [DisplayName("Image")]
        public string P_Image { get; set; }

        [Required(ErrorMessage = "Required!!")]
        [DisplayName("Profile picture")]
        [ValidateFileAttribute]
        public HttpPostedFileBase ImgUrl { get; set; }

        [Required(ErrorMessage = "Required!!")]
        [RegularExpression(@"^.*(?=.{8,})(?=.*[\d])(?=.*[\W]).*$", ErrorMessage = "- contains at least 8 characters \n - contains at least one digit \n - contains at least one special character")]
        [DisplayName("Password")]
        public string P_Password { get; set; }

        [Compare("P_Password", ErrorMessage = "Password mismatch!!")]
        [Required(ErrorMessage = "Required!!")]
        [DisplayName("ConfirmPassword")]
        public string ConfirmPassword { get; set; }


        public class ValidateFileAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                int maxContentLength = 1024 * 1024 * 2; //Max 2 MB is allowed
                string[] allowedFileExtensions = new string[] { ".jpg", ".jpeg", ".png" };
                var file = value as HttpPostedFileBase;
                if (file == null)
                {
                    return false;
                }
                else if (!allowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                {
                    ErrorMessage = "Image extension should be .jpg, .jpeg or .png";
                    return false;
                }
                else if (file.ContentLength > maxContentLength)
                {
                    ErrorMessage = "Your photo size is too large. Please upload image of size below 2 MB";
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }
    }

}
