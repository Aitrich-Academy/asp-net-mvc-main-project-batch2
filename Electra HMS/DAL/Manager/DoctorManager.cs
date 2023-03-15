using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
    public class DoctorManager
    {
        Model1 db = new Model1();
        public List<Doctor> DoctorsList()
        {
            return db.Doctor.Where(e => e.D_Status == "A").ToList();
        }

        public Doctor IsExistEmail(string emailId)
        {
            return db.Doctor.Where(e => e.D_Email == emailId).SingleOrDefault();
        }
    }

}

