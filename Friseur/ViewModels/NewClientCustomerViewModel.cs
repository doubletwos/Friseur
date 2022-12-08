using Friseur.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Friseur.ViewModels
{
    public class NewClientCustomerViewModel
    {

        public Client_User Client_User { get; set; }

        public IEnumerable<Gender> Genders { get; set; }

        public IEnumerable<UserType> UserTypes { get; set; }

        public IEnumerable<Client> Clients { get; set; }
    }
}