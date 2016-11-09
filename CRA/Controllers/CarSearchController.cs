using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRental.BL;
using CarRental.MVC.Models;
using CarRental.Data;

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

            return View();
        }


        public IEnumerable<CarViewModel> CarModelConvertor(IEnumerable<Car> collection)
        {
            List<CarViewModel> convertedList = new List<CarViewModel>();

            foreach(var car in collection)
            {
                convertedList.Add(new CarViewModel(car));

            }

            return convertedList;
        }

        public ActionResult GettAll()
        {
            var allCars = manager.GetAllCars();

            var modelCars = CarModelConvertor(allCars);

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

            var modelCars = CarModelConvertor(allCars);

            return View();

        }

        public ActionResult FreeTextSearch (string text)
        {
            var allCars = manager.SearchbyFreeText(text);

            var modelCars = CarModelConvertor(allCars);

            return View();
        }
    }
}