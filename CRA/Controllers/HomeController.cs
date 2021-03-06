﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CarRent.BL;
using CarRental.BL;
using CarRental.Models;
using CarRental.MVC.Models;
using CRA.BL;

namespace CarRental.Controllers {
    public class HomeController : Controller {

        private readonly GuestBL _guest;

        private readonly ManagerBL _manager;

        private readonly CompanyRoleProvider _roleprovider;

        public HomeController () {
            _guest = new GuestBL ();
            _manager = new ManagerBL ();
            _roleprovider = new CompanyRoleProvider ();
        }

        // GET: Home
        public ActionResult Index () {
            return View ();
        }

        public ActionResult Login () {
            return View (new LoginViewModel ());
        }

        [HttpPost]
        public ActionResult Login (LoginViewModel login) {
            if (ModelState.IsValid) {

                if (Validate (login)) {
                    var roles = _roleprovider.GetRolesForUser (login.Username);

                    foreach (var role in roles) {
                        User.IsInRole (role);
                    }

                    FormsAuthentication.SetAuthCookie (login.Username, false);
                    return Redirect (FormsAuthentication.DefaultUrl);
                } else {

                    return View (login);
                }
            } else {
                return View ("Login");
            }
        }

        public ActionResult LogOut () {
            FormsAuthentication.SignOut ();
            return RedirectToAction ("Login");
        }

        private bool Validate (LoginViewModel login) {

            bool userExists = _guest.ClientExist (login.converttoUser (login));
            if (!userExists) {
                ModelState.AddModelError (string.Empty, "User does not exist");
                return false;
            } else if (!_guest.PasswordMatches (login.converttoUser (login))) {

                ModelState.AddModelError (string.Empty, "Password does not match");
                return false;
            } else {
                return true;
            }
        }

        public ActionResult SignUp () {
            return View ();
        }

        [HttpPost]
        public ActionResult SignUp (UserViewModel CVM) {
            if (ModelState.IsValid) {
                if (_roleprovider.UserExists (CVM.UserName)) {
                    ModelState.AddModelError (string.Empty, "User Already Exists");
                    return View (CVM);
                } else {
                    var domainclient = CVM.toBaseClient_Details ();
                    _manager.AddClient (domainclient);
                    string[] users = { CVM.UserName };
                    string[] roles = { "Customer" };
                    _roleprovider.AddUsersToRoles (users, roles);
                    TempData["Success"] = "You were Signed Up Successfully! Please Log In";
                    ModelState.Clear ();
                    var model = new UserViewModel ();
                    return RedirectToAction ("Login");
                }
            } else {
                return View ("SignUp");
            }
        }
    }
}