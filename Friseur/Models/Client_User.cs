using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Friseur.Models
{
    public class Client_User
    {
        public int Client_UserId { get; set; }

        public string AppUserId { get; set; } 

        public string  UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; } 

        public string CreatedBy { get; set; }

        public DateTime? LastLogOnDate { get; set; }

        public int  LogOnCount { get; set; }


        public int GenderId { get; set; }
        public Gender Gender { get; set; }

        public int UserTypeId { get; set; }
        public UserType UserType { get; set; } 

























    }
}