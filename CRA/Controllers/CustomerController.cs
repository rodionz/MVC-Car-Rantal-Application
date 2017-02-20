using CarRental.BL;
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

        public CustomerController() {

            _customer = new CustomerBL();
        }


        // GET: Customer
        [Authorize(Roles = "Employee, Manager, Customer")]
        [HttpPost]
        public ActionResult GetInfo(HelpViewModel hvm)
        {
            customerCar = new CarViewModel(_customer.GetCar(hvm.carID));

            customerModel = new ModelView(_customer.GetModel(hvm.modelID));

            totallPrice = hvm.totallPrice;

            return Json(JsonRequestBehavior.AllowGet);
        }




        [Authorize(Roles = "Employee, Manager, Customer")]
        public ActionResult Index()
        {
            ViewBag._Model = customerModel;

            ViewBag._Car = customerCar;

            ViewBag.price = totallPrice;

            ViewBag.userId = User.Identity.

            return View();
        }

        [Authorize(Roles = "Employee, Manager, Customer")]
        [HttpPost]
        public ActionResult Confirmation(DealViewModel deal)
        {

            return View();
        }

        [Authorize(Roles = "Employee, Manager, Customer")]
        public ActionResult MyBusket()
        {

            return View();
        }


        public ActionResult PreviousReservations()
        {

            return View();
        }
    }
}