using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Filters;
using System.Web.Security;
using PozadavkyZakazniku.Service.Interfaces;
using PozadavkyZakazniku.Model;
using System.Security.Claims;

namespace PozadavkyZakazniku.Web.Filters
{
    public class GCAuthentication : IAuthenticationFilter
    {
        readonly IUserService userService;
        public GCAuthentication(IUserService userService)
        {
            this.userService = userService;
        }

        public void OnAuthentication(AuthenticationContext context)
        {
            if (context.ActionDescriptor.ControllerDescriptor.ControllerName == "Login") return;


            // pokud existuje autentizacni cookie, tak ji pouziji
            var authCookie = context.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                string encTicket = authCookie.Value;
                if (!String.IsNullOrEmpty(encTicket))
                {

                    FormsAuthenticationTicket aCookie = null;
                    try
                    {
                        aCookie = FormsAuthentication.Decrypt(encTicket);
                    }
                    catch (Exception e)
                    {
                        FormsAuthentication.SignOut();
                    }
                    UserModel user = null;

                    if (aCookie != null)
                    {
                        user = userService.GetUser(aCookie.Name);
                    }


                    if (user != null)
                    {
                        IList<Claim> listOfClaims = new List<Claim>() {
                        new Claim(ClaimTypes.Name,user.LoginName),
                        new Claim("Role", System.Convert.ToString(user.Role)),
                        new Claim("FirstName", user.FirstName),
                        new Claim("UserName", user.LastName + " " + user.FirstName),
                        new Claim("UserId", user.UserID.ToString())};
                        ClaimsIdentity identita = new ClaimsIdentity(listOfClaims, "User identity");
                        ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identita);
                        if (HttpContext.Current != null) HttpContext.Current.User = claimsPrincipal;
                    }
                }
            }

        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            
        }
    }
}