using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRental.BL;
using CarRental.MVC.Models;
using CarRental.Data;
using CarRental.Dal;
using CRA.BL;
using CarRental.Models;

namespace CarRental.Controllers
{
    public class GuestController : Controller
    {
        private readonly CustomerBL manager;

        private readonly GuestBL guest;

       private static IEnumerable<CarModelViewModel> allmodels;

        private static IEnumerable<ManufactorerViewModel> allManufacturers;

        private static IEnumerable<CarViewModel> allCars;

        public GuestController()
        {

            manager = new CustomerBL();
            guest = new GuestBL();
        }



        public ActionResult Index()
        {
            var domaninCars = guest.GetAllCars();

            allCars = domaninCars.Select(c => new CarViewModel(c));

            allmodels = guest.GettAllModels().Select(c => new CarModelViewModel(c));

            allManufacturers = guest.GettAllManufacturers().Select(c => new ManufactorerViewModel(c));

            List<SelectListItem> modelsItems = new List<SelectListItem>();

            List<SelectListItem> manufacturersItems = new List<SelectListItem>();

            foreach (var model in allmodels)
            {
                modelsItems.Add(new SelectListItem { Text = model.NameofModel, Value = model.ModelID.ToString() });
            }

            foreach (var man in allManufacturers)
            {
                manufacturersItems.Add(new SelectListItem { Text = man.manufacturerName, Value = man.ID.ToString() });
            }

            ViewBag.model = modelsItems;

            ViewBag.manufac = manufacturersItems;






            return View(domaninCars);
        }


        public ActionResult HelpAjax()
        {
            var helper = new HelpViewModel();

            helper.AllManufacturers = allManufacturers;

            helper.AllCarModels = allmodels;

           

            return Json(helper, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult SearchbyGear(Gear gear)
        //{
        //    var allCars = manager.SearchByGear(gear);

        //    return View();
        //}


        //public ActionResult ManufacturerSearch(int manuf)
        //{
        //    var allCars = manager.SearchByManufacrurer(manuf);

        //    var modelCars = allCars.Select(c => new CarViewModel(c));

        //    return View();

        //}

        public ActionResult FreeTextSearch (string text)
        {
            var allCars = manager.SearchbyFreeText(text);

            var modelCars = allCars.Select(c => new CarViewModel(c));

            return View();
        }


       
        public ActionResult GetImage(int id)
        {
            
                var image = guest.GetImage(id);

                return File(image, "image/jpeg");
           
          
        }
    }
}