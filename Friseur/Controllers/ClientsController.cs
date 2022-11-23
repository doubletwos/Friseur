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
    [Authorize(Roles = RoleName.SuperUser_CanDoEverything)]
    public class ClientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ClientsTable
        public ActionResult ClientsTable()
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
        public ActionResult AddNewClient()
        {
            try
            {
                var clientTypes = db.ClientTypes.ToList();
                var viewmodel = new NewClientViewModel
                {
                    ClientTypes = clientTypes,

                };

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
                    return RedirectToAction("ClientsTable");
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ClientsTable");
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
            return RedirectToAction("ClientsTable");
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
