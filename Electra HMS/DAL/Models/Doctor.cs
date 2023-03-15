namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Doctor")]
    public partial class Doctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doctor()
        {
            Appointment = new HashSet<Appointment>();
            Schedule = new HashSet<Schedule>();
        }

        public int DoctorID { get; set; }

        [StringLength(30)]
        public string D_Name { get; set; }

        public string D_PhoneNo { get; set; }

        [StringLength(40)]
        public string D_Email { get; set; }

        public int DeptId { get; set; }

        public string D_Address { get; set; }

        [StringLength(100)]
        public string D_Specialization { get; set; }

        public string D_Gender { get; set; }

        public DateTime? D_DOB { get; set; }

        public string D_Status { get; set; }

        [StringLength(50)]
        public string D_Password { get; set; }

        [StringLength(50)]
        public string D_Image { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointment { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
