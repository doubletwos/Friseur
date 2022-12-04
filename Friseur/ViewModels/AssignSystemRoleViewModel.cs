using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Friseur.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Friseur.ViewModels
{
    public class AssignSystemRoleViewModel
    {

        public IEnumerable<ApplicationUser> Users { get; set; }


        public int? Id { get; set; }  

        public IEnumerable<IdentityRole> Roles { get; set; } 

    }
}