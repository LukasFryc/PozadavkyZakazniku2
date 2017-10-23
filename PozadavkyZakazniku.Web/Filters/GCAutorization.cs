using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;

namespace PozadavkyZakazniku.Web.Filters
{
    public class GCAutorization : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase filterContext)
        {

            string urcenoProRole = "," + this.Roles + ",";

            ClaimsPrincipal principal = (ClaimsPrincipal)HttpContext.Current.User;
            string Roles = System.Convert.ToString(principal.Claims.SingleOrDefault(c => c.Type == "Role").Value);


            return false;

        }
    }
}