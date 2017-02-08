using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class CustomerController : Controller
    {
        private HelpViewModel customerHelper;

        // GET: Customer
        [Authorize(Roles = "Employee, Manager, Customer")]
        [HttpPost]
        public ActionResult GetInfo(HelpViewModel hvm)
        {
            customerHelper = hvm;
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