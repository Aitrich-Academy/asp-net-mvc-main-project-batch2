using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Electra_HMS.Models
{
    public class Ent_Dept
    {
        [Key]
        public int DeptId { get; set; }

        [Required(ErrorMessage = "Required!!")]
        [DisplayName("Department Name")]
        public string DeptName { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }
    }
}