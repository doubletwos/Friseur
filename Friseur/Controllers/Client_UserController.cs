﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Friseur.Models;
using Friseur.ViewModels;


namespace Friseur.Controllers
{
    public class Client_UserController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Client_User
        public ActionResult Index()
        {
            var client_Users = db.Client_Users.Include(c => c.Gender).Include(c => c.UserType);
            return View(client_Users.ToList());
        }

        // GET: Client_User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_User client_User = db.Client_Users.Find(id);
            if (client_User == null)
            {
                return HttpNotFound();
            }
            return View(client_User);
        }

        // GET: Client_User/Create
        public ActionResult Create()
        {
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "name");
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "name");
            return View();
        }


        [ChildActionOnly]
        [Authorize(Roles = RoleName.SuperUser_CanDoEverything)]
        public ActionResult AddNewPowerHouseUser() 
        {
            try
            {
                var gender = db.Genders.ToList();
                var usertype = db.UserTypes.ToList();
                var client = db.Clients.ToList();

                var viewmodel = new NewPowerHouseUserViewModel
                {
                    Genders = gender,
                    UserTypes = usertype,
                    Clients = client

                };

                return PartialView("~/Views/Shared/PartialViewsForms/_AddNewPowerHouseUser.cshtml", viewmodel);

            }
            catch (Exception e)
            {
                throw e;
            }
        }



        // POST: Client_User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client_User client_User)
        {
            if (ModelState.IsValid)
            {
                db.Client_Users.Add(client_User);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "name", client_User.GenderId);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "name", client_User.UserTypeId);
            return View(client_User);
        }

        // GET: Client_User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_User client_User = db.Client_Users.Find(id);
            if (client_User == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "name", client_User.GenderId);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "name", client_User.UserTypeId);
            return View(client_User);
        }

        // POST: Client_User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client_User client_User)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client_User).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "name", client_User.GenderId);
            ViewBag.UserTypeId = new SelectList(db.UserTypes, "UserTypeId", "name", client_User.UserTypeId);
            return View(client_User);
        }

        // GET: Client_User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client_User client_User = db.Client_Users.Find(id);
            if (client_User == null)
            {
                return HttpNotFound();
            }
            return View(client_User);
        }

        // POST: Client_User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client_User client_User = db.Client_Users.Find(id);
            db.Client_Users.Remove(client_User);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}