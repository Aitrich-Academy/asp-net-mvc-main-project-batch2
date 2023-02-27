using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
    public class AdminManager
    {
        Model1 db = new Model1();

        public List<Department> DeptList()
        {
            return db.Department.Where(e => e.Status == "A").ToList();
        }
        public Department DeptById(int id)
        {
            return db.Department.Where(e => e.Status == "A" && e.DeptId == id).SingleOrDefault();
        }


        public List<Department> DepartmentList()
        {
            return db.Department.ToList();
        }
        public Department DepartmentById(int id)
        {
            return db.Department.Find(id);
        }
        public string AddDepartment(Department insDept)
        {
            db.Department.Add(insDept);
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

        public string UpdateDepartment(Department UpdateDept)
        {
            db.Entry(UpdateDept).State = EntityState.Modified;
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

        public string DeleteDepartment(int? id)
        {
            Department remObj = db.Department.Where(e => e.DeptId == id).SingleOrDefault();
            if (remObj == null)
            {
                return "Failed";
            }
            db.Department.Remove(remObj);
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


        public Doctor IsExist(Doctor checkObj)
        {
            return db.Doctor.Where(e => e.D_Email == checkObj.D_Email).SingleOrDefault();
        }

        public string AddDoctor(Doctor insObj)
        {
            db.Doctor.Add(insObj);
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
        public Doctor DoctorById(int? id)
        {
            return db.Doctor.Find(id);
        }

        public string UpdateDoctor(Doctor updObj)
        {
            Doctor obj = db.Doctor.Where(e => e.DoctorID == updObj.DoctorID).SingleOrDefault();
            obj.D_Name = updObj.D_Name;
            obj.D_PhoneNo = updObj.D_PhoneNo;
            obj.D_Address = updObj.D_Address;
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

        public List<Doctor> DoctorsList()
        {
            return db.Doctor.Where(e => e.D_Status == "A").ToList();
        }
    }
}
