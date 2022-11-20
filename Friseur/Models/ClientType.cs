using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Friseur.Models
{
    public class ClientType
    {
        public int ClientTypeId { get; set; }

        [Display(Name ="Client Type Name")]
        public string ClientTypeName { get; set; }
    }
}