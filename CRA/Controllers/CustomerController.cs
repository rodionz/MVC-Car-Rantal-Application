﻿using CarRental.BL;
using CarRental.Models;
using CarRental.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerBL _customer;

        private HelpViewModel customerHelper;

        private ModelView customerModel;

        private CarViewModel customerCar;

        public CustomerController() {

            _customer = new CustomerBL();
        }


        // GET: Customer
        [Authorize(Roles = "Employee, Manager, Customer")]
        [HttpPost]
        public ActionResult GetInfo(HelpViewModel hvm)
        {
           
            return Json(JsonRequestBehavior.AllowGet);
        }




        [Authorize(Roles = "Employee, Manager, Customer")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Employee, Manager, Customer")]
        public ActionResult MyBusket()
        {

            return View();
        }
    }
}