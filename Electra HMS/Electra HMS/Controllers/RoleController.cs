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
    public class RoleController : Controller
    {
        RoleManager roleManager = new RoleManager();
        // GET: Role
        public ActionResult Index()
        {
           List<tbl_Role> roles= roleManager.GetAllRoles();
            List<Ent_Role> entRoles = new List<Ent_Role>();
            foreach(var role in roles)
            {
                Ent_Role rl = new Ent_Role();
                rl.RoleId = role.RoleId;
                rl.RollName = role.RollName;
                entRoles.Add(rl);
            }
            return View(entRoles);
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
