namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Appointment")]
    public partial class Appointment
    {
        [Key]
        public int AppointID { get; set; }

        public int DoctorID { get; set; }

        public int PatientID { get; set; }

        public DateTime? AppointmentDate { get; set; }

        public bool Appointment_Status { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public virtual Doctor Doctor { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
