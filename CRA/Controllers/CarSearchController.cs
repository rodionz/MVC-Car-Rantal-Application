using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRental.BL;
using CarRental.MVC.Models;
using CarRental.Data;
using CarRental.Dal;

namespace CarRental.Controllers
{
    public class CarSearchController : Controller
    {
        private readonly CustomerBL manager;

        public CarSearchController()
        {

            manager = new CustomerBL();
        }






        public ActionResult Index()
        {
            var allCars = manager.GetAllCars();

            var modelCars = allCars.Select(c => new CarViewModel(c));

            return View(modelCars);
        }


        //public ActionResult SearchbyGear(Gear gear)
        //{
        //    var allCars = manager.SearchByGear(gear);

        //    return View();
        //}


        public ActionResult ManufacturerSearch(string manuf)
        {
            var allCars = manager.SearchByManufacrurer(manuf);

            var modelCars = allCars.Select(c => new CarViewModel(c));

            return View();

        }

        public ActionResult FreeTextSearch (string text)
        {
            var allCars = manager.SearchbyFreeText(text);

            var modelCars = allCars.Select(c => new CarViewModel(c));

            return View();
        }

        public ActionResult Image()
        {
            byte[] img;

            using (var context = new CarRentalContext())
            {
                img = context.Cars.FirstOrDefault().Picture;
            }
                return File(img, "image/jpeg");
        }
    }
}