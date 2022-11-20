using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Friseur.Models
{
    public class ClientClientType
    {
        public int ClientClientTypeId { get; set; } 

        public int ClientId { get; set; }

        public int ClientTypeId { get; set; } 

        public Client Client { get; set; }

        public ClientType ClientType { get; set; }










    }
}