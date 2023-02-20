namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Login
    {
        [Key]
        public int LoginId { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string UserId { get; set; }

        public int? UserRole { get; set; }

        public virtual tbl_Role tbl_Role { get; set; }
    }
}
