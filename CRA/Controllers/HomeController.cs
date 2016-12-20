using CarRental.Models;
using CarRental.MVC.Models;
using CRA.BL;
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

        private readonly GuestBL guest;

        internal static IEnumerable <CarModelViewModel> allmodels;

        internal static  IEnumerable <ManufactorerViewModel> allManufacturers;


        public HomeController()
        {
            guest = new GuestBL();

            allmodels = guest.GettAllModels().Select(c => new CarModelViewModel(c));

            allManufacturers = guest.GettAllManufacturers().Select(c => new ManufactorerViewModel(c));

            ViewBag.models = allmodels;

            ViewBag.manufacturers = allManufacturers;

        }
            




        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel login)
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







        private bool Validate(LoginViewModel login)
        {
            return true;
        }
    }
}