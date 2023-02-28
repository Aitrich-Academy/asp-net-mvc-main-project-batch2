using DAL.Manager;
using DAL.Models;
using Electra_HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Electra_HMS.Controllers
{
    public class LoginController : Controller
    {
        // GET: Home
            LoginManger LogMgr = new LoginManger();
            public ActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Login(Ent_Login objUser)
            {
                tbl_Login Login_Obj = new tbl_Login();
                Login_Obj.Email = objUser.Email;
                Login_Obj.UserPassword = objUser.UserPassword;

            tbl_Login user = LogMgr.LoginUser(Login_Obj);
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            Session["UserId"] = objUser.LoginId;
            int roleId = user.UserRole.Value;
                if (roleId == 1)
                {
                    Session["Admin"] = objUser.Email;

                    return RedirectToAction("ListDoctor", "Admin");
                }
                else if (roleId == 2)
                {

                    Session["Doctor"] = objUser.Email;
                    Doctor D_Obj = LogMgr.DoctorDetails(objUser.Email.ToString());

                    if (D_Obj.D_Status != "A")
                    {
                        ViewBag.statusDoc = "Account not found";
                        return View();
                    }
                    Session["DoctorDetails"] = new string[] { D_Obj.D_Name };
                    return RedirectToAction("ProfileView", "Doctor");
                }
                else if (roleId == 3)
                {
                    Session["Patient"] = objUser.Email;
                    Patient P_Obj = LogMgr.PatientDetails(objUser.Email.ToString());

                    if (P_Obj.P_Status != "A")
                    {
                        ViewBag.statusPat = "Account not found";
                        return View();
                    }
                    Session["PatientDetails"] = new string[] { P_Obj.P_Name };
                    return RedirectToAction("ProfileView", "Patient");
                }
                else
                {
                    ViewBag.msg = "User not found";
                    return View();
                }
            }

        }
    }