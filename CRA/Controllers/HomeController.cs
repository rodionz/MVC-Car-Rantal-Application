using CarRent.BL;
using CarRental.BL;
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

        private readonly GuestBL _guest;

        private readonly ManagerBL _manager;

        private readonly CompanyRoleProvider _roleprovider;

        private static IEnumerable<DealViewModel> allDeals;



        public HomeController()
        {
            _guest = new GuestBL();
            _manager = new ManagerBL();
            _roleprovider = new CompanyRoleProvider();
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

            //var validation = Validate(login);

            if (Validate(login))
            {
                var roles = _roleprovider.GetRolesForUser(login.Username);

                foreach (var role in roles)
                {
                    User.IsInRole(role);
                }

                FormsAuthentication.SetAuthCookie(login.Username, false);
                return Redirect(FormsAuthentication.DefaultUrl);
            }
            else
            {

                return View(login);
            }
        }



        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


        private bool Validate(LoginViewModel login)
        {



            bool userExists = _guest.ClientExist(login.converttoUser(login));


            if (!userExists)
            {
                ModelState.AddModelError(string.Empty, "User does not exist");
                return false;
            }

            else if (!_guest.PasswordMatches(login.converttoUser(login)))
            {

                ModelState.AddModelError(string.Empty, "Password does not match");
                return false;
            }

            else
            {


                return true;

            }
        }





        public ActionResult SignUp()
        {

            return View();
        }

        /////////Bug whith Gender
        [HttpPost]
        public ActionResult SignUp(CustomerViewModel CVM)
        {


           

            if (_roleprovider.UserExists(CVM.UserName))
            {
                ModelState.AddModelError(string.Empty, "User Already Exists");

                return View(CVM);
            }

            else
            {


                _manager.AddClient(CVM.toBaseClient_Details());

                TempData["Success"] = "You were Signed Up Successfully!";
                ModelState.Clear();
                var model = new CustomerViewModel();
                return View(model);
            }


        }






    }
}