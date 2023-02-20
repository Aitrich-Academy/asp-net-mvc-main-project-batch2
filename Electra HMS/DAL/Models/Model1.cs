using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Appointment> Appointment { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<tbl_Login> tbl_Login { get; set; }
        public virtual DbSet<tbl_Role> tbl_Role { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .Property(e => e.Appointment_Status)
                .IsUnicode(false);

            modelBuilder.Entity<Appointment>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.DeptName)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Doctor)
                .WithRequired(e => e.Department)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.D_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.D_Email)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.D_Specialization)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .Property(e => e.D_Password)
                .IsUnicode(false);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Appointment)
                .WithRequired(e => e.Doctor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.P_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.P_PhoneNo)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.P_Email)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.P_Address)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.P_BloodGroup)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.P_Gender)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.P_Status)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.P_Image)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .Property(e => e.P_Password)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Appointment)
                .WithRequired(e => e.Patient)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_Login>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Login>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Login>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Role>()
                .Property(e => e.RollName)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Role>()
                .HasMany(e => e.tbl_Login)
                .WithOptional(e => e.tbl_Role)
                .HasForeignKey(e => e.UserRole)
                .WillCascadeOnDelete();
        }
    }
}
