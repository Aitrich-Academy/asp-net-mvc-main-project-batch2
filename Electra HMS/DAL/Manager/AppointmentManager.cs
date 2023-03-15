using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
    public class AppointmentManager
    {
        Model1 db = new Model1();
        public string AddAppointment(Appointment insObj)
        {
            db.Appointment.Add(insObj);
            int result = db.SaveChanges();
            if (result > 0)
            {
                return "Success";
            }
            else
            {
                return "Failed";
            }

        }

        public string SelectName(int id)
        {
            var name = from n in db.Doctor where n.DoctorID == id select n;
            string nam = name.FirstOrDefault().D_Name;
            return nam;
        }


        public List<Appointment> GetAppointmentByDoctorId(int id)
        {
            return db.Appointment.Where(e => e.DoctorID == id).ToList();
        }


        //public string UpdateAppointment(int id)
        //{
        //    Appointment obj = db.Appointment.Where(e => e.AppointID == id).SingleOrDefault();

        //    obj.Appointment_Status = "C";

        //    db.Entry(obj).State = EntityState.Modified;

        //    int result = db.SaveChanges();
        //    if (result > 0)
        //    {
        //        return "Success";
        //    }
        //    else
        //    {
        //        return "Failed";
        //    }

        //}

        

        public Appointment GetAppointmentById(int? id)
        {
            return db.Appointment.Find(id);
        }

        public string UpdateAppointment(Appointment updObj)
        {
            Appointment obj = db.Appointment.Where(e => e.AppointID == updObj.AppointID).SingleOrDefault();
            obj.DoctorID = updObj.DoctorID;
            obj.AppointmentDate = updObj.AppointmentDate;
            obj.Description = updObj.Description;
            db.Entry(obj).State = EntityState.Modified;
            int result = db.SaveChanges();
            if (result > 0)
            {
                return "Success";
            }
            else
            {
                return "Failed";
            }

        }
        public Appointment GetAppointById(int id)
        {
            return db.Appointment.Find(id);
        }

        public string DeleteAppointById(int id)
        {
            Appointment remObj = db.Appointment.Find(id);
            db.Appointment.Remove(remObj);
            int status = db.SaveChanges();
            if (status > 0)
            {
                return "Success";
            }
            else
            {
                return "Failed";
            }
        }
    }
}
