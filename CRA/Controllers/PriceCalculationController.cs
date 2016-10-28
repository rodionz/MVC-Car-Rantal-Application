using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRental.BL;
using CarRental.MVC.Models;

namespace CarRental.Controllers
{
    public class PriceCalculationController : Controller
    {
        // GET: PriceCalculation
        public ActionResult Index()
        {
            return View();
        }
    }
}