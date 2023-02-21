using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
    public class LoginManger
    {
        Model1 db = new Model1();

        public int LoginUser(tbl_Login checkObj)
        {
            tbl_Login isExist = db.tbl_Login.Where(e => e.Email == checkObj.Email && e.Password == checkObj.Password).SingleOrDefault();
            int roleId = 0;
            if (isExist != null)
            {
                roleId = Convert.ToInt32(isExist.UserRole);
                return roleId;
            }
            return roleId;
        }

        public Doctor DoctorDetails(string emailId)
        {

            return db.Doctor.Where(x => x.D_Email == emailId).FirstOrDefault();

        }
        public Patient PatientDetails(string emailId)
        {
            return db.Patient.Where(x => x.P_Email == emailId).FirstOrDefault();
        }
    }
}
