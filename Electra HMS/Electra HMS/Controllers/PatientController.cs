using DAL.Manager;
using DAL.Models;
using Electra_HMS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Electra_HMS.Controllers
{
    public class PatientController : Controller
    {
        PatientManager PatMgr = new PatientManager();
        // GET: Patient

        public ActionResult List_Pat()
        {
            List<Patient> retList = PatMgr.PatientList();
            List<Ent_Patient> Ent_List = new List<Ent_Patient>();
            foreach (var item in retList)
            {
                Ent_List.Add(new Ent_Patient
                {
                    PatientID = item.PatientID,
                    P_Name = item.P_Name,
                    P_PhoneNo = item.P_PhoneNo,
                    P_Email = item.P_Email,
                    P_Address = item.P_Address,
                    P_BloodGroup = item.P_BloodGroup,
                    P_Gender = item.P_Gender,

                    P_DOB = (DateTime)item.P_DOB,
                    P_Status = item.P_Status,
                    P_Image = item.P_Image,
                    P_Password = item.P_Password,
                });
            }
            return View(Ent_List);
        }
        


    }
}





