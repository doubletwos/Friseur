using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Friseur.Models;
using Microsoft.AspNet.Identity;



namespace Friseur.Controllers
{
    public class HomeController : Controller
    {
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

        [Authorize(Roles = "SuperUser_CanDoEverything")]
        public ActionResult SysAdminHome() 
        {
            return View();
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