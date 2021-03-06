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
        private const string DEALS_IN_THE_BUSKET = "dealsinfo";
      

        public CustomerController() {
            _customer = new CustomerBL();         
        }


       
        [Authorize(Roles = "Employee, Manager, Customer")]
        [HttpPost]
        public ActionResult GetInfo(HelpModel hvm)
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
        public ActionResult AddtoBusket(DealViewModel deal)
        {
            TempData["Success"] = "Reservation Succeded!";
            var deals = Session[DEALS_IN_THE_BUSKET] as List<DealViewModel>;

            if (deals == null) {

                deals = new List<DealViewModel>();
            }

            deals.Add(deal);
            Session[DEALS_IN_THE_BUSKET] = deals;
            return  RedirectToAction("MyBusket");
        }



        [Authorize(Roles = "Employee, Manager, Customer")]
        public ActionResult MyBusket()
        {
            var deals = Session[DEALS_IN_THE_BUSKET] as List<DealViewModel>;                   
            return View(deals);
        }


        [Authorize(Roles = "Employee, Manager, Customer")]
        public ActionResult PreviousReservations()
        {
            var UserID = _customer.GetUserId(User.Identity.Name);
            var myDeals = _customer.GetPreviousDeals(UserID).Select(d => new DealViewModel(d));
            return View(myDeals);
        }

        public ActionResult Confimation(int dealID)
        {
            var deals = Session[DEALS_IN_THE_BUSKET] as List<DealViewModel>;
            var currenDeal = deals.Where(d => d.ID == dealID).FirstOrDefault();
            deals.Remove(currenDeal);
            Session[DEALS_IN_THE_BUSKET] = deals;
           _customer.ConfirmDeal(currenDeal.toBaseDateDetails());
            TempData["Success"] = "Reservation Completed!";

            return RedirectToAction("PreviousReservations");
        }

        public ActionResult RemoveItemFromBusket(int dealID)
        {
            var deals = Session[DEALS_IN_THE_BUSKET] as List<DealViewModel>;
            var dealtoRemove = deals.Where(d => d.ID == dealID).FirstOrDefault();
            deals.Remove(dealtoRemove);
            Session[DEALS_IN_THE_BUSKET] = deals;
            TempData["Success"] = "Order Removed! ";

            return RedirectToAction("MyBusket");
        }

        public ActionResult ClearBusket()
        {
            Session[DEALS_IN_THE_BUSKET] = new List<DealViewModel>();
            return RedirectToAction("MyBusket");
        }

        public ActionResult QuantityOfItemsInBusket()
        {
            int count;
            var deals = Session[DEALS_IN_THE_BUSKET] as List<DealViewModel>;
            if(deals == null)
            {
                count = 0;
            }
            else
            {
                count = deals.Count;
            }
           return Json(count,JsonRequestBehavior.AllowGet);
        }
    }
}