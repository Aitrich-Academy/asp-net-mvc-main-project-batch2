using DAL.Manager;
using DAL.Models;
using Electra_HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Electra_HMS.Controllers
{
    public class AdminController : Controller
    {
        AdminManager AdMngr = new AdminManager();
        // GET: Admin
        public ActionResult DepList()
        {
            if (Session["Admin"] != null)
            {
                List<Department> returnList = AdMngr.DepartmentList();
                List<Ent_Dept> DeptList = new List<Ent_Dept>();
                foreach (var item in returnList)
                {
                    DeptList.Add(new Ent_Dept
                    {
                        DeptId = item.DeptId,
                        DeptName = item.DeptName,
                        Description = item.Description,
                        Status = item.Status
                    });
                }

                return View(DeptList);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult AddDepartment(int id = 0)
        {
            if (Session["Admin"] != null)
            {
                if (id == 0)
                {
                    return View(new Ent_Dept { DeptId = 0 });
                }
                else
                {
                    Department obj = AdMngr.DepartmentById(id);
                    Ent_Dept Ent_DepObj = new Ent_Dept();
                    Ent_DepObj.DeptId = obj.DeptId;
                    Ent_DepObj.DeptName = obj.DeptName;
                    Ent_DepObj.Description = obj.Description;
                    Ent_DepObj.Status = obj.Status;
                    return View(Ent_DepObj);
                }

            }
            else
            {
                return RedirectToAction("Login", "Home");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDepartment(Ent_Dept model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Department insObj = new Department();
            if (ModelState.IsValid)
            {
                string result;
                insObj.Description = model.Description;
                insObj.DeptName = model.DeptName;
                insObj.Status = "A";
                if (model.DeptId > 0)
                {
                    insObj.DeptId = model.DeptId;
                    result = AdMngr.UpdateDepartment(insObj);
                    if (result == "Success")
                    {
                        ViewBag.Success = "Updated Successfully";
                        return RedirectToAction("DepList", "Admin");
                    }
                    else
                    {
                        ViewBag.Failed = "Failed to Update Department!";
                        return View();
                    }
                }
                else
                {
                    result = AdMngr.AddDepartment(insObj);
                    if (result == "Success")
                    {
                        ViewBag.Success = "Inserted Successfully";
                        return RedirectToAction("DepList", "Admin");
                    }
                    else
                    {
                        ViewBag.Failed = "Failed";
                        return View();
                    }
                }

            }
            else
            {
                ViewBag.Status = "Please fill all fields";
                return View();
            }
        }

        public ActionResult AddDoctor()
        {
            ViewBag.DeptId = new SelectList(AdMngr.DepartmentList(), "DeptId", "DeptName");
            return View();
        }

        [HttpPost]
        public ActionResult AddDoctor(Ent_Doctor obj)
        {

            if (obj == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = new Doctor();
            doctor.D_Email = obj.D_Email;
            var isExist = AdMngr.IsExist(doctor);
            if (isExist != null)
            {
                ModelState.AddModelError("EmailId", "Email already exists");
            }


            if (ModelState.IsValid)
            {
                doctor.D_Name = obj.D_Name;
                doctor.D_PhoneNo = obj.D_PhoneNo;
                doctor.Designation = obj.Designation;
                doctor.D_Status = "A";
                doctor.D_Address = obj.D_Address;
                doctor.D_Specialization = obj.D_Specialization;
                doctor.D_Gender = obj.D_Gender;
                doctor.D_DOB = DateTime.Now;
                doctor.DeptId = obj.DeptId;
                doctor.D_Email = obj.D_Email;
                doctor.D_Password = obj.D_Password;

                string result = AdMngr.AddDoctor(doctor);
                if (result == "Success")
                {
                    TempData["msg"] = "Inserted successfully";
                    return RedirectToAction("ListDoctor", "Admin");
                }
                else if (result == "Failed")
                {
                    return View();
                }
                else if (result == "Exist")
                {
                    ViewBag.exist = "Email already exists. Please login !";
                    return View();
                }
                else
                {
                    return View();
                }

            }
            return View();
        }


        public ActionResult UpdateDoctor(int? id)
        {
            if (Session["Doctor"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            Doctor retObj = AdMngr.DoctorById(Convert.ToInt32(id));
            if (retObj == null)
            {
                return HttpNotFound();
            }
            Ent_Doctor disObj = new Ent_Doctor();
            disObj.D_Name = retObj.D_Name;
            disObj.DeptId = retObj.DeptId;

            return View(disObj);

        }

        [HttpPost]
        public ActionResult UpdateDoctor(Ent_Doctor obj)
        {
            if (obj == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (ModelState.IsValid)
            {
                Doctor updObj = new Doctor();
                updObj.D_Name = obj.D_Name;

                updObj.DeptId = obj.DeptId;
                updObj.D_Email = Session["Doctor"].ToString();
                string result = AdMngr.UpdateDoctor(updObj);
                if (result == "Success")
                {
                    return RedirectToAction("UserProfile", "Doctor");
                }
                else
                {
                    ViewBag.msg = "Failed to insert";
                    return View();
                }

            }
            return View();
        }

        public ActionResult ListDoctor()
        {
            List<Doctor> Doc_List = AdMngr.DoctorsList();
            List<Ent_Doctor> Ent_List = new List<Ent_Doctor>();
            foreach (var item in Doc_List)
            {
                Ent_List.Add(new Ent_Doctor
                {
                    D_Name = item.D_Name,
                    D_PhoneNo = item.D_PhoneNo,
                    D_Email = item.D_Email,
                    Designation = item.Designation,
                    DeptId = item.DeptId,
                    D_Address = item.D_Address,
                    D_Specialization = item.D_Specialization,
                    D_Gender = item.D_Gender,
                    D_DOB = DateTime.Now,
                    D_Status = item.D_Status,
                    D_Password = item.D_Password

                });
            }
            return View(Ent_List);
        }

        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Ent_Dept obj = db.Ent_Dept.Find(id);
        //    if (obj == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    Ent_Dept Ent_DepObj = new Ent_Dept();
        //    return_Obj.Name = obj.Name;
        //    return_Obj.Phone = obj.Phone;
        //    return_Obj.DOB = obj.DOB;
        //    return_Obj.Pid = Convert.ToInt32(obj.Pid);
        //    return_Obj.PlaceName = obj.Table_Place.PlaceName;
        //    return_Obj.Image = obj.Image;

        //    return View(return_Obj);
        //}


        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ViewBag.deleted = "Deleted Successfully";
        //    try
        //    {
        //        tbl_People obj = db.tbl_People.Find(id);
        //        this.db.tbl_People.Remove(obj);
        //        db.SaveChanges();
        //        return View();
        //    }
        //    catch (Exception)
        //    {
        //        return View();
        //    }

        //}

    }
}
