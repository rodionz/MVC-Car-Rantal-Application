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












         

        private static IEnumerable<DealViewModel> allDeals;

        private CompanyRoleProvider _roleprovider;

        public HomeController()
        {
            _guest = new GuestBL();

            _manager = new ManagerBL();

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
                FormsAuthentication.SetAuthCookie(login.Username, false);
                return Redirect(FormsAuthentication.DefaultUrl);
            }
            else
            {
                //ModelState.AddModelError(string.Empty,ModelState.);
                return View(login);
            }
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
            _roleprovider = new CompanyRoleProvider();

            var userrole = _roleprovider.GetRolesForUser(CVM.UserName);

            if(userrole.Length != 0)
            {
                ModelState.AddModelError(string.Empty, "User Already Exists");

                return View(CVM);
            }

            else
            {
                

                _manager.AddClient(CVM.toBaseClient_Details());

                TempData["Success"] = "You were Signed Up Successfully!";
                ModelState.Clear();
                var  model = new CustomerViewModel();
                return View();
            }

           
        }




        
    }
}