using CarRental.BL;
using CarRental.Data;
using CarRental.Models;
using CarRental.MVC.Models;
using CRA.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class ManagerController : Controller
    {

        private readonly ManagerBL _manager;

        private readonly GuestBL guest;

        private static IEnumerable<CarModelViewModel> allmodels;

        private static IEnumerable<ManufactorerViewModel> allManufacturers;

        private static IEnumerable<CarViewModel> allCars;

        private static IEnumerable<DealViewModel> allDeals;

        private static IEnumerable<CustomerViewModel> allCustomers;


        public ManagerController()
        {
            _manager = new ManagerBL();
            guest = new GuestBL();
        }


       
        public ActionResult Index()
        
        {       
            return View();
        }

        [HttpGet]
        public ActionResult ManagerActions(HelpViewModel hvm)
        {

            switch (hvm.ManagerAction)
                {

                case "AddModel":
                return PartialView("~/Views/Manager/Partials/AddNewModel.cshtml");

                case "AddCar":
                    return PartialView("~/Views/Manager/Partials/AddNewCar.cshtml");

                default:
                    return PartialView("~/Views/Manager/Partials/AddNewCustomer.cshtml");

                }


        }



        public ActionResult HelpAjax()
        {

            allCars = guest.GetAllCars().Select(c => new CarViewModel(c));

            allmodels = guest.GettAllModels().Select(c => new CarModelViewModel(c));

            allManufacturers = guest.GettAllManufacturers().Select(c => new ManufactorerViewModel(c));


            var helper = new HelpViewModel();

            helper.AllManufacturers = allManufacturers;

            helper.AllCarModels = allmodels;



            return Json(helper, JsonRequestBehavior.AllowGet);
        }




        public ActionResult AddNewModel(CarModelViewModel cmvm)
        {
            var originalModel = cmvm.toBaseModelDetail();
            _manager.AddModel(originalModel);

            return View();
        }

        public ActionResult UpdateModel(CarModelViewModel cmvm)
        {
            var originalModel = cmvm.toBaseModelDetail();
            _manager.UpdateModel(originalModel);
            return View();
        }

        public ActionResult DeleteModel(CarModelViewModel cmvm)
        {
            var originalModel = cmvm.toBaseModelDetail();
            _manager.DeleteModel(originalModel);
            return View();
        }

        [HttpGet]
        public ActionResult AddCar()
        {
            return PartialView();
        }


        public ActionResult AddCar(CarViewModel cvm)
        {

            var originalCar = cvm.toBaseCarDetails();
            _manager.AddCar(originalCar);

            return View();
        }

        public ActionResult UpdateCar(CarViewModel cvm)
        {
            var originalCar = cvm.toBaseCarDetails();
            _manager.UpdateCar(originalCar);
            return View();
        }

        public ActionResult DeleteCar(CarViewModel cvm)
        {
            var originalCar = cvm.toBaseCarDetails();
            _manager.DeleteCar(originalCar);
            return View();
        }


        public ActionResult Users()
        {
            return View("UsersEdit");
        }

  


        public ActionResult AddClient(CustomerViewModel client)
        {
            var originalClient = client.toBaseClient_Details();
            _manager.AddClient(originalClient);
            return View();
        }

        public ActionResult UpdateClient(CustomerViewModel client)
        {
            var originalClient = client.toBaseClient_Details();
            _manager.UpdateClient(originalClient);
            return View();
        }

        public ActionResult DeleteClient(CustomerViewModel client)
        {
            var originalClient = client.toBaseClient_Details();
            _manager.DeleteClient(originalClient);
            return View();
        }


        public ActionResult DealIndex()
        {

            return View("DealsEdit");
        }

        public ActionResult AddDeal(DealViewModel dvm)
        {
            var originalDeal = dvm.toBaseDateDetails();
            _manager.AddReservation(originalDeal);
            return View();
        }

        public ActionResult UpdateDeal(DealViewModel dvm)
        {
            var originalDeal = dvm.toBaseDateDetails();
            _manager.UpdateReservation(originalDeal);
            return View();
        }

        public ActionResult DeleteDeal(DealViewModel dvm)
        {
            var originalDeal = dvm.toBaseDateDetails();
            _manager.DeleteReservation(originalDeal);
            return View();
        }
    }
}