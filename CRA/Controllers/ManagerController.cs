﻿using CarRental.BL;
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

        private static IEnumerable<ModelView> allmodels;

        private static IEnumerable<ManufactorerViewModel> allManufacturers;

        private static IEnumerable<CarViewModel> allCars;

        private static IEnumerable<DealViewModel> allDeals;

        private static IEnumerable<CustomerViewModel> allCustomers;


        public ManagerController()
        {
            _manager = new ManagerBL();
            guest = new GuestBL();
        }


       [Authorize(Roles ="Manager")]
        public ActionResult Index()
        
        {       
            return View();
        }




        [Authorize(Roles = "Manager")]
        public JsonResult HelpAjax()
        {

            allCars = guest.GetAllCars().Select(c => new CarViewModel(c));

            allmodels = guest.GettAllModels().Select(c => new ModelView(c));

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
        [Authorize(Roles = "Manager")]
        public ActionResult ManagerActions(HelpViewModel hvm)
        {

            switch (hvm.ManagerAction)
            {

                   ///////// MODELS ///////////

                case "AddModel":
                    return PartialView("~/Views/Manager/Partials/AddModel.cshtml");


                case "EditModel":
                    var model = (from m in allmodels where m.ID == hvm.ID select m).FirstOrDefault();
                    return PartialView("~/Views/Manager/Partials/EditModel.cshtml", model);


                case "DeleteModel":
                    _manager.DeleteModel(hvm.ID);
                    var result = new HelpViewModel();
                    result.ActionResult = "Model Deleted";
                    return Json(result, JsonRequestBehavior.AllowGet);

                /////////////  CARS /////////////

                case "AddCar":
                    return PartialView("~/Views/Manager/Partials/AddCar.cshtml");


                case "EditCar":
                    var car = (from c in allCars where c.ID == hvm.ID select c).FirstOrDefault();
                    return PartialView("~/Views/Manager/Partials/EditCar.cshtml", car);


                case "DeleteCar":
                    _manager.DeleteCar(hvm.ID);
                    return null;

             /////////////// CUSTOMERS ////////////////////

                case "AddCustomer":
                    return PartialView("~/Views/Manager/Partials/AddCustomer.cshtml");



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

        [Authorize(Roles = "Manager")]
        public ActionResult SubmitNewModel (ModelView cmv)
        {
            var originalModel = cmv.toBaseModelDetail();
            _manager.AddModel(originalModel);
            var result = new HelpViewModel();
            result.ActionResult = "Model Added";

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Manager")]
        public ActionResult SubmitEditModel(ModelView cmv)
        {

            var originalModel = cmv.toBaseModelDetail();
            _manager.UpdateModel(originalModel);
            var result = new HelpViewModel();
            result.ActionResult = "Model Added";
            return Json(result, JsonRequestBehavior.AllowGet);

        }


        [Authorize(Roles = "Manager")]
        public ActionResult SubmitNewCustomer(CustomerViewModel cmv)
        {
            var managerHelper = new HelpViewModel();
            _manager.AddClient(cmv.toBaseClient_Details());
            return View();
        }

        [Authorize(Roles = "Manager")]
        public ActionResult SubmitEditCustomer(CustomerViewModel cmv)
        {
            var managerHelper = new HelpViewModel();
            _manager.UpdateClient(cmv.toBaseClient_Details());
            return View();
        }


        [Authorize(Roles = "Manager")]
        public ActionResult SubmitNewCar(CarViewModel cmv)
        {
            var managerHelper = new HelpViewModel();
            _manager.AddCar(cmv.toBaseCarDetails());
            return View();
        }

        [Authorize(Roles = "Manager")]
        public ActionResult SubmitEditCar(CarViewModel cmv)
        {
            var managerHelper = new HelpViewModel();
            _manager.UpdateCar(cmv.toBaseCarDetails());
            return View();
        }


        [Authorize(Roles = "Manager")]
        public ActionResult SubmitNewDeal(DealViewModel dvm)
        {
            var managerHelper = new HelpViewModel();
            _manager.AddDeal(dvm.toBaseDateDetails());
            return View();
        }

        [Authorize(Roles = "Manager")]
        public ActionResult SubmitEditDeal(DealViewModel dvm)
        {
            var managerHelper = new HelpViewModel();
            _manager.UpdateDeal(dvm.toBaseDateDetails());
            return View();
        }
        [Authorize(Roles = "Manager")]
        public ActionResult SubmitNewManufacturer(ManufactorerViewModel dvm)
        {
            var managerHelper = new HelpViewModel();
            _manager.AddManufactorer(dvm.toBaseManufacturer());
            return View();
        }

        [Authorize(Roles = "Manager")]
        public ActionResult SubmitEditManufactorer(ManufactorerViewModel dvm)
        {
            var managerHelper = new HelpViewModel();
            _manager.UpdateManufactorer(dvm.toBaseManufacturer());
            return View();
        }
         

    }
}