using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Friseur.Helpers;
using Friseur.Models;
using Microsoft.AspNet.Identity;



namespace Friseur.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {

            if (User.IsInRole(RoleName.SuperUser_CanDoEverything))
            {
                var check = true;
                Console.WriteLine(check);
            }
            else
            {
                var not = false;

                Console.WriteLine(not);
            }

            return View();
        }


        public ActionResult GateKeeper()
        {

            if (User.IsInRole(RoleName.SuperUser_CanDoEverything))
            {
                return RedirectToAction("SysAdminHome", "Home");
            }
            else
            {
                var c_id = User.Identity.GetUserClientId();
                return RedirectToAction("AdminHome", "Home", new { id = c_id });
            }

        }




        [Authorize(Roles = "SuperUser_CanDoEverything")]
        public ActionResult SysSetUp()
        {

            return View();

        }




        [Authorize(Roles = "SuperUser_CanDoEverything")]
        public ActionResult SysAdminHome()
        {

            return View(db.Clients.ToList());

        }


        public ActionResult ClientAdminHome() 
        {

            return View(db.Client_Users.ToList());

        }


        public ActionResult AdminHome(int? clientid)
        {
            try
            {
                var c_id = User.Identity.GetUserClientId();
                var id = Convert.ToInt32(clientid);
                var conv = Convert.ToInt32(c_id); 

                Client client = db.Clients.Find(id);

                if (id != conv)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}