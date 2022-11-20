using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Friseur.Models
{
    public class UserType
    {
        public int UserTypeId { get; set; }

        [Required]
        public string name { get; set; } 
    }
}