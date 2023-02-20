namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient")]
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int PatientID { get; set; }

        [StringLength(50)]
        public string P_Name { get; set; }

        [StringLength(50)]
        public string P_PhoneNo { get; set; }

        [Required]
        [StringLength(50)]
        public string P_Email { get; set; }

        [StringLength(50)]
        public string P_Address { get; set; }

        [StringLength(50)]
        public string P_BloodGroup { get; set; }

        [StringLength(50)]
        public string P_Gender { get; set; }

        public DateTime P_DOB { get; set; }

        [StringLength(50)]
        public string P_Status { get; set; }

        [StringLength(50)]
        public string P_Image { get; set; }

        [StringLength(50)]
        public string P_Password { get; set; }

        [StringLength(50)]
        public string P_Cpassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
