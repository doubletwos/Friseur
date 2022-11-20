using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Friseur.Models;

namespace Friseur.ViewModels
{
    public class NewClientViewModel
    {
        public IEnumerable<ClientType> ClientTypes { get; set; }

        public Client Client { get; set; } 


    }
}