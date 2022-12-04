using Friseur.Models;
using Friseur.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Friseur.Controllers
{
    [Authorize(Roles = RoleName.SuperUser_CanDoEverything)]

    public class RoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();



        [ChildActionOnly]
        public ActionResult AddNewSystemUserRole()
        {
            try
            {
                return PartialView("~/Views/Shared/PartialViewsForms/_AddNewSystemUserRole.cshtml");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: Role
        public ActionResult Index()
        {

            var Roles = db.Roles.ToList();
            return View(Roles);

        }

        public ActionResult Create(string role)
        {

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!roleManager.RoleExists(role))
            {

                // Create role
                var newrole = new IdentityRole()
                {
                    Name = role,
                };
                roleManager.Create(newrole);

            }
            return RedirectToAction("Index");
        }


        [ChildActionOnly]
        [Authorize(Roles = RoleName.SuperUser_CanDoEverything)]
        public ActionResult AssignRoleToUser() 
        {
            try
            {
                var role = db.Roles.ToList();  
                var users = db.Users.ToList();



                var viewmodel = new AssignSystemRoleViewModel
                {
                    Roles = role,
                    Users = users,


               };
                ViewBag.Id = new SelectList(db.Roles, "Id", "Name");
                return PartialView("~/Views/Shared/PartialViewsForms/_AssignRoleToUser.cshtml", viewmodel);

            }
            catch (Exception e)
            {
                throw e;
            }
        }



        // POST: Client_User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.SuperUser_CanDoEverything)]
        public ActionResult AssignRole(AssignSystemRoleViewModel viewmodel) 
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

                    var roleStore = new RoleStore<IdentityRole>(db);
                    var roleManager = new RoleManager<IdentityRole>(roleStore);
                    //ApplicationUserManager.AddToRoleAsync(viewmodel.Users, "Test");


                    return RedirectToAction("Index");
                }

            }
            catch (Exception e)
            {

                throw e;
            }
            return View("Index");
        }


    }
}