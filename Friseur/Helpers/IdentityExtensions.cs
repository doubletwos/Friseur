using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using Microsoft.AspNet.Identity;


namespace Friseur.Helpers
{
    public static class IdentityExtensions
    {
        public static string GetUserClientId(this IIdentity identity) 
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci.FindFirstValue("ClientId"); 
            }
            return null;
        }
    }
}