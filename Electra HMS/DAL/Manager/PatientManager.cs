using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
    public class PatientManager
    {

        Model1 db = new Model1();

        public List<Patient> PatientDetails(string emailId)
        {
            return db.Patient.Where(e => e.P_Email == emailId).ToList();
        }

        public List<Patient> PatientList()
        {
            return db.Patient.ToList();
        }
        public string PatientRegistration(Patient ObjMgr)
        {
            int result;

            var ObjUser = db.Patient.Where(e => e.P_Email == ObjMgr.P_Email && e.P_Status != "D").SingleOrDefault();
            if (ObjUser == null)
            {
                try
                {
                    db.Patient.Add(ObjMgr);
                    result = db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var eve in ex.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
            else
            {
                ObjUser.P_Name = ObjMgr.P_Name;
                ObjUser.P_Email = ObjMgr.P_Email;
                ObjUser.P_PhoneNo = ObjMgr.P_PhoneNo;
                ObjUser.P_Address = ObjMgr.P_Address;
                ObjUser.P_Password = ObjMgr.P_Password;
                ObjUser.P_BloodGroup = ObjMgr.P_BloodGroup;
                ObjUser.P_DOB = ObjMgr.P_DOB;
                ObjUser.P_Gender = ObjMgr.P_Gender;
                ObjMgr.P_Status = "A";
                ObjUser.P_Image = ObjMgr.P_Image;
                db.Entry(ObjUser).State = EntityState.Modified;
                //ObjMgr.Role = "Employee";
                result = db.SaveChanges();
            }
            if (result > 0)
            {
                return "Success";
            }
            else
            {
                return "Error";
            }
        }
        public Patient GetPerById(int? id)
        {
            Patient obj = db.Patient.Find(id);
            return obj;
        }
        public List<Patient> getAllUsers()
        {
            return db.Patient.ToList();
        }


    }
}








