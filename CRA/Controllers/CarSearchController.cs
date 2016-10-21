using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRA.BL;
using CRA.MVC.Models;

namespace CRA.Controllers
{
    public class CarSearchController : Controller
    {
        private readonly CustomerBL manager = new CustomerBL();
        // GET: CarSearch
        public ActionResult Index()
        {
            var allCars = manager.GetAllCars();

            var modelCars = allCars.Select(c => new CarViewModel());

            return View(modelCars);
        }
    }
}