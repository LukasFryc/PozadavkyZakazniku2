using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PozadavkyZakazniku.Model;
using PozadavkyZakazniku.Service.Interfaces;
using System.Web.Security;

namespace PozadavkyZakazniku.Web.Controllers
{
    public class LoginController : Controller
    {

        readonly IUserService userService;

        public LoginController(IUserService userService) {
            this.userService = userService;

        }

        // GET: Login
        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            string token = userService.Login(model.LoginName, model.LoginPassword);
            

            if (!string.IsNullOrEmpty(token))
            {
                // FormsAuthenticationTicket - je v System.Web.Security
                var ticket = new FormsAuthenticationTicket(1, //version
                        model.LoginName, // user name
                        DateTime.Now,             //creation
                        DateTime.Now.AddMinutes(30), //Expiration
                        false, //Persistent
                        token
                        );

                string encTicket = FormsAuthentication.Encrypt(ticket);

                // Create the cookie.
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                return RedirectToAction("Index", "User");
                
            }

            ViewBag.Chyba = " Nejsi prihlaseny";
            return View("Index");

            
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}