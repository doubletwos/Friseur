using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Friseur.Models;
using Friseur.ViewModels;
using Microsoft.AspNet.Identity;


namespace Friseur.Controllers
{
    public class ClientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        [Authorize(Roles="SuperUser_CanDoEverything")]
        public ActionResult Create()
        {

            var clientTypes = db.ClientTypes.ToList();
            var viewmodel = new NewClientViewModel
            {
                ClientTypes = clientTypes,

            };
            return View(viewmodel);
        }

        [ChildActionOnly]
        [Authorize(Roles ="SuperUser_CanDoEverything")]
        public ActionResult AddNewClient()
        {
            try
            {
                var clientTypes = db.ClientTypes.ToList();
                var viewmodel = new NewClientViewModel
                {
                    ClientTypes = clientTypes,

                };

                //ViewBag.ClientTypeId = new SelectList(db.ClientTypes, "ClientTypeId", "ClientTypeName");
                return PartialView("~/Views/Shared/PartialViewsForms/_AddNewClient.cshtml", viewmodel);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

            // POST: Clients/Create
            [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "SuperUser_CanDoEverything")]
        public ActionResult Create(NewClientViewModel viewmodel) 
        {

            try
            {
                if (ModelState.IsValid || (!ModelState.IsValid))
                {
                    viewmodel.Client.Created_By = User.Identity.GetUserId();
                    viewmodel.Client.CreationDate = DateTime.Now;

                    db.Clients.Add(viewmodel.Client);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return View(viewmodel);

        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,Name,Client_Address,Created_By,CreationDate")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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
