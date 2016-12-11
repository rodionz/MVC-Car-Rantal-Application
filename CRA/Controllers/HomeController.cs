using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CarRental.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View(new LoginVM());
        }


        [HttpPost]
        public ActionResult Login(LoginVM login)
        {

            if (Validate(login))
            {
                FormsAuthentication.SetAuthCookie(login.Username, false);
                return Redirect(FormsAuthentication.DefaultUrl);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login failed.");
                return View(login);
            }
        }



        public ActionResult SignUp()
        {

            return View();
        }







        private bool Validate(LoginVM login)
        {
            return true;
        }
    }
}