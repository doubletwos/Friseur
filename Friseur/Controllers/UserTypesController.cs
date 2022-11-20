using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Friseur.Models;

namespace Friseur.Controllers
{
    [Authorize(Roles = RoleName.SuperUser_CanDoEverything)]
    public class UserTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserTypes
        public ActionResult UserTypesTable() 
        {
            return View(db.UserTypes.ToList());
        }

        // GET: UserTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserType userType = db.UserTypes.Find(id);
            if (userType == null)
            {
                return HttpNotFound();
            }
            return View(userType);
        }

        // GET: UserTypes/Create
        [ChildActionOnly]
        public ActionResult AddNewUserType()
        {
            try
            {
                return PartialView("~/Views/Shared/PartialViewsForms/_AddNewUserType.cshtml");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // POST: UserTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserType userType)
        {
            if (ModelState.IsValid)
            {
                db.UserTypes.Add(userType);
                db.SaveChanges();
                return RedirectToAction("UserTypesTable");
            }

            return View(userType);
        }

        // GET: UserTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserType userType = db.UserTypes.Find(id);
            if (userType == null)
            {
                return HttpNotFound();
            }
            return View(userType);
        }

        // POST: UserTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserTypeId,name")] UserType userType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("UserTypesTable");
            }
            return View(userType);
        }

        // GET: UserTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserType userType = db.UserTypes.Find(id);
            if (userType == null)
            {
                return HttpNotFound();
            }
            return View(userType);
        }

        // POST: UserTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserType userType = db.UserTypes.Find(id);
            db.UserTypes.Remove(userType);
            db.SaveChanges();
            return RedirectToAction("UserTypesTable");
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
