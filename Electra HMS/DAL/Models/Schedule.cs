namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Schedule")]
    public partial class Schedule
    {
        public int ScheduleId { get; set; }

        public int? DoctorId { get; set; }

        public string AvailableStartDay { get; set; }

        public string AvailableEndDay { get; set; }

        public DateTime? AvailableStartTime { get; set; }

        public DateTime? AvailableEndTime { get; set; }

        public string TimePerPatient { get; set; }

        public string Status { get; set; }

        public virtual Doctor Doctor { get; set; }
    }
}
