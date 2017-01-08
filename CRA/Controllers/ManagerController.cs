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

      



        public JsonResult HelpAjax()
        {

            allCars = guest.GetAllCars().Select(c => new CarViewModel(c));

            allmodels = guest.GettAllModels().Select(c => new CarModelViewModel(c));

            allManufacturers = guest.GettAllManufacturers().Select(c => new ManufactorerViewModel(c));

            allDeals = _manager.GetAllDeals().Select(d => new DealViewModel(d));

            allCustomers = _manager.GetAllUsers().Select(u => new CustomerViewModel(u));

            var managerHelper = new HelpViewModel();

            managerHelper.AllManufacturers = allManufacturers;

            managerHelper.AllCarModels = allmodels;

            managerHelper.AllDeals = allDeals;

            managerHelper.AllCustomers = allCustomers;

            managerHelper.AllCars = allCars;

            return Json(managerHelper, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult ManagerActions(HelpViewModel hvm)
        {

            switch (hvm.ManagerAction)
            {

                   ///////// MODELS ///////////

                case "AddModel":
                    return PartialView("~/Views/Manager/Partials/AddNewModel.cshtml");


                case "EditModel":
                    var model = (from m in allmodels where m.ID == hvm.ID select m).FirstOrDefault();
                    return PartialView("~/Views/Manager/Partials/EditModel.cshtml", model);


                case "DeleteModel":
                    _manager.DeleteModel(hvm.ID);
                    return null;

                /////////////  CARS /////////////

                case "AddCar":
                    return PartialView("~/Views/Manager/Partials/AddNewCar.cshtml");


                case "EditCar":
                    var car = (from c in allCars where c.ID == hvm.ID select c).FirstOrDefault();
                    return PartialView("~/Views/Manager/Partials/EditCar.cshtml", car);


                case "DeleteCar":
                    _manager.DeleteCar(hvm.ID);
                    return null;

             /////////////// CUSTOMERS ////////////////////

                case "AddCustomer":
                    return PartialView("~/Views/Manager/Partials/AddNCustomer.cshtml");



                case "EditCustomer":
                    var customer = (from c in allCustomers where c.ID == hvm.ID select c).FirstOrDefault();
                    return PartialView("~/Views/Manager/Partials/EditCustomer.cshtml", customer);



                case "DeleteCustomer":
                    _manager.DeleteClient(hvm.ID);
                    return null;



                ///////////////////// MANUFACTORERS /////////////////////




                case "AddManufacturer":
                    return PartialView("~/Views/Manager/Partials/AddManufacturer.cshtml");


                case "EditManufactorer":
                    var manuf = (from m in allManufacturers where m.ID == hvm.ID select m).FirstOrDefault();
                    return PartialView("~/Views/Manager/Partials/EditManufacturer.cshtml", manuf);


                case "DeleteManufactorer":
                    _manager.DeleteManufactorer(hvm.ID);
                    return null;




             /////////////// DEALS ///////////////////////


                case "AddDeal":
                    return PartialView("~/Views/Manager/Partials/AddDeal.cshtml");

                case "EditDeal":
                    var deal = (from d in allDeals where d.ID == hvm.ID select d).FirstOrDefault();
                    return PartialView("~/Views/Manager/Partials/EditDeal.cshtml", deal);           

                case "DeleteDeal":
                    _manager.DeleteDeal(hvm.ID);
                    return null;
     
                default:
                    return null;

            }
        }






        //public ActionResult AddNewModel(CarModelViewModel cmvm)
        //{
        //    var originalModel = cmvm.toBaseModelDetail();
        //    _manager.AddModel(originalModel);

        //    return View();
        //}

        //public ActionResult UpdateModel(CarModelViewModel cmvm)
        //{
        //    var originalModel = cmvm.toBaseModelDetail();
        //    _manager.UpdateModel(originalModel);
        //    return View();
        //}

        //public ActionResult DeleteModel(CarModelViewModel cmvm)
        //{
        //    var originalModel = cmvm.toBaseModelDetail();
        //    _manager.DeleteModel(originalModel);
        //    return View();
        //}

      


        //public ActionResult AddCar(CarViewModel cvm)
        //{

        //    var originalCar = cvm.toBaseCarDetails();
        //    _manager.AddCar(originalCar);

        //    return View();
        //}

        //public ActionResult UpdateCar(CarViewModel cvm)
        //{
        //    var originalCar = cvm.toBaseCarDetails();
        //    _manager.UpdateCar(originalCar);
        //    return View();
        //}

        //public ActionResult DeleteCar(CarViewModel cvm)
        //{
        //    var originalCar = cvm.toBaseCarDetails();
        //    _manager.DeleteCar(originalCar);
        //    return View();
        //}


        

  


        //public ActionResult AddClient(CustomerViewModel client)
        //{
        //    var originalClient = client.toBaseClient_Details();
        //    _manager.AddClient(originalClient);
        //    return View();
        //}

        //public ActionResult UpdateClient(CustomerViewModel client)
        //{
        //    var originalClient = client.toBaseClient_Details();
        //    _manager.UpdateClient(originalClient);
        //    return View();
        //}

        //public ActionResult DeleteClient(CustomerViewModel client)
        //{
        //    var originalClient = client.toBaseClient_Details();
        //    _manager.DeleteClient(originalClient);
        //    return View();
        //}


    

        //public ActionResult AddDeal(DealViewModel dvm)
        //{
        //    var originalDeal = dvm.toBaseDateDetails();
        //    _manager.AddDeal(originalDeal);
        //    return View();
        //}

        //public ActionResult UpdateDeal(DealViewModel dvm)
        //{
        //    var originalDeal = dvm.toBaseDateDetails();
        //    _manager.UpdateDeal(originalDeal);
        //    return View();
        //}

        //public ActionResult DeleteDeal(DealViewModel dvm)
        //{
        //    var originalDeal = dvm.toBaseDateDetails();
        //    _manager.DeleteDeal(originalDeal);
        //    return View();
        //}
    }
}