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
     
        private static ModelView customerModel;

        private static CarViewModel customerCar;

        private  static double totallPrice;

        private static DateTime startDate;

        private static DateTime supposedReturn;

      

        public CustomerController() {

            _customer = new CustomerBL();
        }


        // GET: Customer
        [Authorize(Roles = "Employee, Manager, Customer")]
        [HttpPost]
        public ActionResult GetInfo(HelpViewModel hvm)
        {
            var date1 = hvm.StartDate.Split('-');

            var date2 = hvm.SupposedReturn.Split('-');

            startDate = new DateTime(int.Parse(date1[0]), int.Parse(date1[1]), int.Parse(date1[2]));

            supposedReturn = new DateTime(int.Parse(date2[0]), int.Parse(date2[1]), int.Parse(date2[2]));

            customerCar = new CarViewModel(_customer.GetCar(hvm.carID));

            customerModel = new ModelView(_customer.GetModel(hvm.modelID));

            totallPrice = hvm.totallPrice;

            return Json(JsonRequestBehavior.AllowGet);
        }




        [Authorize(Roles = "Employee, Manager, Customer")]
        public ActionResult Index()
        {
            var UserID = _customer.GetUserId(User.Identity.Name);

            ViewBag._Model = customerModel;

            ViewBag._Car = customerCar;

            ViewBag.price = totallPrice;

            ViewBag.userId = UserID; 

            ViewBag.startDate = startDate;

            ViewBag.supposedReturn = supposedReturn;

            var model = new DealViewModel();

            return View(model);
        }

        [Authorize(Roles = "Employee, Manager, Customer")]
        [HttpPost]
        public ActionResult Confirmation(DealViewModel deal)
        {
            _customer.ConfirmDeal(deal.toBaseDateDetails());

            TempData["Success"] = "Reservation Succeded!";

            return  RedirectToAction("PreviousReservations");
        }

        [Authorize(Roles = "Employee, Manager, Customer")]
        public ActionResult MyBusket()
        {

            return View();
        }


        public ActionResult PreviousReservations()
        {
            var UserID = _customer.GetUserId(User.Identity.Name);

            var myDeals = _customer.GetPreviousDeals(UserID).Select(d => new DealViewModel(d));



            return View(myDeals);
        }
    }
}