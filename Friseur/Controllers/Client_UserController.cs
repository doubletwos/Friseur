using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Friseur.Helpers;
using Friseur.Models;
using Friseur.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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

        [ChildActionOnly]
        public ActionResult AddNewClientAdminUser()
        {
            try
            {


                var gender = db.Genders.ToList();
                var usertype = db.UserTypes.ToList();
                var client = db.Clients.ToList();

                var viewmodel = new NewClientAdminUserViewModel
                {
                    Genders = gender,
                    UserTypes = usertype,
                    Clients = client
                };

                return PartialView("~/Views/Shared/PartialViewsForms/_AddNewClientAdminUser.cshtml", viewmodel);

            }

            catch (Exception e)
            {
                throw e;
            }


        }


        [ChildActionOnly]
        public ActionResult AddNewClientCustomer()
        {
            try
            {
                var gender = db.Genders.ToList();
                var usertype = db.UserTypes.ToList();
                var client = db.Clients.ToList();

                var viewmodel = new NewClientCustomerViewModel
                {
                    Genders = gender,
                    UserTypes = usertype,
                    Clients = client
                };

                return PartialView("~/Views/Shared/PartialViewsForms/_AddNewClientCustomer.cshtml", viewmodel);
            }

            catch (Exception e)
            {
                throw e;
            }

        }





        // POST: Client_User/CreateNphu
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.SuperUser_CanDoEverything)]
        public ActionResult CreateNphu(NewPowerHouseUserViewModel viewmodel)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                    var user = new ApplicationUser() { Email = viewmodel.Client_User.Email, UserName = viewmodel.Client_User.Email, ClientId = "1" };
                    var result = manager.Create(user, "ThisisatestPw1!");

                    if (result.Succeeded)
                    {
                        string newId = user.Id;
                    }

                    viewmodel.Client_User.CreatedBy = User.Identity.GetUserId();
                    viewmodel.Client_User.LastLogOnDate = null;
                    viewmodel.Client_User.LogOnCount = 0;
                    viewmodel.Client_User.AppUserId = user.Id;
                    viewmodel.Client_User.DateAdded = DateTime.Now;


                    // Assign role to user
                    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                    var assignrole = UserManager.AddToRole(user.Id, "SuperUser_CanDoEverything");


                    db.Client_Users.Add(viewmodel.Client_User);
                    db.SaveChanges();

                    return RedirectToAction("ClientAdminHome", "Home");
                }

            }
            catch (Exception e)
            {

                throw e;
            }
            return View("Index");
        }


        // POST: Client_User/CreateNcau
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult CreateNcau(NewClientAdminUserViewModel viewmodel)
        {

            try
            {
                //User added by SysAdmin
                if (User.IsInRole(RoleName.SuperUser_CanDoEverything))
                {

                    var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                    var user = new ApplicationUser() { Email = viewmodel.Client_User.Email, UserName = viewmodel.Client_User.Email, ClientId = viewmodel.Client_User.ClientId.ToString() };
                    var result = manager.Create(user, "ThisisatestPw1!");

                    if (result.Succeeded)
                    {
                        string newId = user.Id;
                    }

                    viewmodel.Client_User.CreatedBy = User.Identity.GetUserId();
                    viewmodel.Client_User.LastLogOnDate = null;
                    viewmodel.Client_User.LogOnCount = 0;
                    viewmodel.Client_User.AppUserId = user.Id;
                    viewmodel.Client_User.UserTypeId = 3;
                    viewmodel.Client_User.DateAdded = DateTime.Now;


                    db.Client_Users.Add(viewmodel.Client_User);
                    db.SaveChanges();

                    // Assign role to user
                    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                    var assignrole = UserManager.AddToRole(user.Id, "ClientUser_ClientLevelTasks");


                    return RedirectToAction("ClientAdminHome", "Home");

                }

                //User added by ClientAdmin
                if (User.IsInRole(RoleName.ClientUser_ClientLevelTasks))
                {

                    var clientid = User.Identity.GetUserClientId();

                    var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                    var user = new ApplicationUser() { Email = viewmodel.Client_User.Email, UserName = viewmodel.Client_User.Email, ClientId = clientid };
                    var result = manager.Create(user, "ThisisatestPw1!");

                    if (result.Succeeded)
                    {
                        string newId = user.Id;
                    }


                    //Convert ClientId to Int
                    var cid = Convert.ToInt32(clientid);

                    viewmodel.Client_User.CreatedBy = User.Identity.GetUserId();
                    viewmodel.Client_User.LastLogOnDate = null;
                    viewmodel.Client_User.LogOnCount = 0;
                    viewmodel.Client_User.AppUserId = user.Id;
                    viewmodel.Client_User.ClientId = cid;
                    viewmodel.Client_User.DateAdded = DateTime.Now;


                    // Assign role to user
                    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                    var assignrole = UserManager.AddToRole(user.Id, "ClientUser_ClientLevelTasks");

                    db.Client_Users.Add(viewmodel.Client_User);
                    db.SaveChanges();

                    return RedirectToAction("ClientAdminHome", "Home");

                }

                return View();
            }
            catch (Exception e)
            {
                throw e;
            }
        }



        // POST: Client_User/CreateNcc
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult CreateNcc(NewClientAdminUserViewModel viewmodel) 
        {
            try
            {
                //User added by ClientAdmin
                if (User.IsInRole(RoleName.ClientUser_ClientLevelTasks))
                {
                    var clientid = User.Identity.GetUserClientId();

                    var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                    var user = new ApplicationUser() { Email = viewmodel.Client_User.Email, UserName = viewmodel.Client_User.Email, ClientId = clientid };
                    var result = manager.Create(user, "ThisisatestPw1!");

                    if (result.Succeeded)
                    {
                        string newId = user.Id;
                    }


                    //Convert ClientId to Int
                    var cid = Convert.ToInt32(clientid);

                    viewmodel.Client_User.CreatedBy = User.Identity.GetUserId();
                    viewmodel.Client_User.LastLogOnDate = null;
                    viewmodel.Client_User.LogOnCount = 0;
                    viewmodel.Client_User.AppUserId = user.Id;
                    viewmodel.Client_User.ClientId = cid;
                    viewmodel.Client_User.DateAdded = DateTime.Now;


                    db.Client_Users.Add(viewmodel.Client_User);
                    db.SaveChanges();

                    return RedirectToAction("ClientAdminHome", "Home");

                }
                return View();
            }
            catch (Exception e)
            {

                throw e;
            }
               
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
