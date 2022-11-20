using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Friseur.Models
{
    public class Gender
    {
        public int GenderId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }    


    }
}