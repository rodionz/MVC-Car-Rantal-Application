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
        private readonly ManagerBL manager;

        private readonly GuestBL guest;

       private  IEnumerable<ModelView> allmodels;

        private  IEnumerable<ManufactorerViewModel> allManufacturers;

        private IEnumerable<Car> domaninCars;

        private  IEnumerable<CarViewModel> allCars;

        private  IEnumerable<DealViewModel> allDeals;




        public GuestController()
        {

            manager = new ManagerBL();

            guest = new GuestBL();
        }



        public ActionResult Index()
        {
           domaninCars = guest.GetAllCars();

            allCars = domaninCars.Select(c => new CarViewModel(c));

            allmodels = guest.GettAllModels().Select(c => new ModelView(c));

            allManufacturers = guest.GettAllManufacturers().Select(c => new ManufactorerViewModel(c));

            allDeals = manager.GetAllDeals().Select(d => new DealViewModel(d));

            List<SelectListItem> modelsItems = new List<SelectListItem>();

            List<SelectListItem> manufacturersItems = new List<SelectListItem>();

            foreach (var model in allmodels)
            {
                modelsItems.Add(new SelectListItem { Text = model.NameofModel, Value = model.ID.ToString() });
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

            helper.AllDeals = allDeals;

            return Json(helper, JsonRequestBehavior.AllowGet);
        }

    

        //public ActionResult FreeTextSearch (string text)
        //{
        //    var allCars = manager.SearchbyFreeText(text);

        //    var modelCars = allCars.Select(c => new CarViewModel(c));

        //    return View();
        //}


       
        public ActionResult GetImage(int id)
        {           
                var image = guest.GetImage(id);
                return File(image, "image/jpeg");                  
        }

        public ActionResult PriceCalculation(int? id)
        {
            var car = (from c in domaninCars
                       where c.CarID == id.Value
                       select c).FirstOrDefault();

            return View(car);
        }
    }
}