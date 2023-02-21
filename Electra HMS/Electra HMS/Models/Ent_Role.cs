using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Electra_HMS.Models
{
    public class Ent_Role
    {
        [ScaffoldColumn(false)]
        public int RoleId { get; set; }

        public string RollName { get; set; }
    }
}