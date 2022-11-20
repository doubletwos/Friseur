using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Friseur.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Client name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Client address is required")]
        [Display(Name = "Address")]
        public string Client_Address { get; set; } 

        public string Created_By { get; set; }


        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreationDate { get; set; }


        [Required(ErrorMessage = "Client type is required")]
        public int ClientTypeId { get; set; }
        public ClientType ClientType { get; set; }











    }
}