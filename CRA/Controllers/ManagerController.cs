using CarRent.Data;
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

        private static IEnumerable<ModelView> allmodels;

        private static IEnumerable<ManufactorerViewModel> allManufacturers;

        private static IEnumerable<CarViewModel> allCars;

        private static IEnumerable<DealViewModel> allDeals;

        private static IEnumerable<UserViewModel> allCustomers;

        private static IEnumerable<UserViewModel> allEmployees;


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



        //This function creates Json object that serves all possible needs of manager's interface

        [Authorize(Roles = "Manager")]
        public JsonResult HelpAjax()
        {

            allCars = _manager.GetAllCars().Select(c => new CarViewModel(c));

            allmodels = guest.GettAllModels().Select(c => new ModelView(c));

            allManufacturers = guest.GettAllManufacturers().Select(c => new ManufactorerViewModel(c));

            allDeals = _manager.GetAllDeals().Select(d => new DealViewModel(d));

            allCustomers = _manager.GetAllCustomers().Select(u => new UserViewModel(u));

            allEmployees = _manager.GetAllEmployees().Select(u => new UserViewModel(u));

            var managerHelper = new HelpViewModel();

            managerHelper.AllManufacturers = allManufacturers;

            managerHelper.AllCarModels = allmodels;

            managerHelper.AllDeals = allDeals;

            managerHelper.AllCustomers = allCustomers;

            managerHelper.AllEmployees = allEmployees;

            managerHelper.AllCars = allCars;

            return Json(managerHelper, JsonRequestBehavior.AllowGet);
        }






        /*This function accepts 3 kinds of requests for all entities in the manager's UI:
         * - request for the form for adding new entiy.
         * - request for the form for editing entity.
         * - deleteting entity
         */
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public ActionResult ManagerActions(HelpViewModel hvm)
        {
            HelpViewModel result = new HelpViewModel();


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
                    HelpViewModel modelresult = new HelpViewModel();
                    modelresult.ActionResult = "Model Deleted";
                    return Json(modelresult, JsonRequestBehavior.AllowGet);

                /////////////  CARS /////////////

                case "AddCar":
                    return PartialView("~/Views/Manager/Partials/AddCar.cshtml");


                case "EditCar":
                    var car = (from c in allCars where c.ID == hvm.ID select c).FirstOrDefault();
                    return PartialView("~/Views/Manager/Partials/EditCar.cshtml", car);


                case "DeleteCar":
                    _manager.DeleteCar(hvm.ID);
                    HelpViewModel carresult = new HelpViewModel();
                    carresult.ActionResult = "Model Deleted";
                    return Json(carresult, JsonRequestBehavior.AllowGet);


                /////////////// CUSTOMERS ////////////////////

                case "AddCustomer":
                    return PartialView("~/Views/Manager/Partials/AddCustomer.cshtml");



                case "EditCustomer":
                    var customer = (from c in allCustomers where c.ID == hvm.ID select c).FirstOrDefault();
                    return PartialView("~/Views/Manager/Partials/EditCustomer.cshtml", customer);



                case "DeleteCustomer":
                    _manager.DeleteClient(hvm.ID);
                    HelpViewModel customerresult = new HelpViewModel();
                    customerresult.ActionResult = "Model Deleted";
                    return Json(customerresult, JsonRequestBehavior.AllowGet);



                ///////////////////// MANUFACTORERS /////////////////////




                case "AddManufacturer":
                    return PartialView("~/Views/Manager/Partials/AddManufacturer.cshtml");


                case "EditManufactorer":
                    var manuf = (from m in allManufacturers where m.ID == hvm.ID select m).FirstOrDefault();
                    return PartialView("~/Views/Manager/Partials/EditManufacturer.cshtml", manuf);


                case "DeleteManufactorer":
                    _manager.DeleteManufactorer(hvm.ID);
                    HelpViewModel manrresult = new HelpViewModel();
                    manrresult.ActionResult = "Model Deleted";
                    return Json(manrresult, JsonRequestBehavior.AllowGet);




                /////////////// DEALS ///////////////////////


                case "AddDeal":
                    return PartialView("~/Views/Manager/Partials/AddDeal.cshtml");

                case "EditDeal":
                    var deal = (from d in allDeals where d.ID == hvm.ID select d).FirstOrDefault();
                    return PartialView("~/Views/Manager/Partials/EditDeal.cshtml", deal);           

                case "DeleteDeal":
                    _manager.DeleteDeal(hvm.ID);
                    HelpViewModel dealresult = new HelpViewModel();
                    dealresult.ActionResult = "Model Deleted";
                    return Json(dealresult, JsonRequestBehavior.AllowGet);

                default:
                    return null;

            }
        }






        [Authorize(Roles = "Manager")]
        public ActionResult SubmitNewModel (ModelView cmv)
        {
            if (ModelState.IsValid)
            {
                var originalModel = cmv.toBaseModelDetail();
                _manager.AddModel(originalModel);
                var result = new HelpViewModel();
                result.ActionResult = "Model Added";

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            else
            {
                  return PartialView("~/Views/Manager/Partials/AddModel.cshtml");
            }
        }


   

        //CarModel
        [Authorize(Roles = "Manager")]
        public ActionResult SubmitEditModel(ModelView cmv)
        {
            if (ModelState.IsValid)
            {
                var originalModel = cmv.toBaseModelDetail();
                _manager.UpdateModel(originalModel);
                var result = new HelpViewModel();
                result.ActionResult = "Model Edited";
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return PartialView("~/Views/Manager/Partials/EditModel.cshtml", cmv);
            }
        }



        /// //////////////////////////////////////////////////////////////////////////////////////




        ///////////////Customers//////////////////////////    



        [Authorize(Roles = "Manager")]
        public ActionResult SubmitNewCustomer(UserViewModel cmv)
        {
            if (ModelState.IsValid)
            {
                var managerHelper = new HelpViewModel();
                _manager.AddClient(cmv.toBaseClient_Details());
                managerHelper.ActionResult = "New Customer Submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return PartialView("~/Views/Manager/Partials/AddCustomer.cshtml");
            }
        }


        
     

        [Authorize(Roles = "Manager")]
        public ActionResult SubmitEditCustomer(UserViewModel cmv)
        {
            if (ModelState.IsValid)
            {
                var managerHelper = new HelpViewModel();
                _manager.UpdateClient(cmv.toBaseClient_Details());
                managerHelper.ActionResult = "Customer edit submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return PartialView("~/Views/Manager/Partials/EditCustomer.cshtml",cmv);
            }
        }



        ////////////////////////////////////////////////////////////////////////////////////////



        //////////////////////////////EMPLOYEES/////////////////////////

        [Authorize(Roles = "Manager")]
        public ActionResult SubmitNewEmployee(UserViewModel cmv)
        {
            if (ModelState.IsValid)
            {
                var managerHelper = new HelpViewModel();

                var domainclient = cmv.toBaseClient_Details();

                //Need testing
                domainclient.Roles.Add(new CarRent.Data.Roles { RoleName = "Employee", RoleId = (domainclient.Roles.Count + 1) });

                _manager.AddClient(domainclient);
                managerHelper.ActionResult = "New Employee Submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return PartialView("~/Views/Manager/Partials/AddCustomer.cshtml");
            }
        }





        [Authorize(Roles = "Manager")]
        public ActionResult SubmitEditEmployee(UserViewModel cmv)
        {
            if (ModelState.IsValid)
            {
                var managerHelper = new HelpViewModel();
                _manager.UpdateClient(cmv.toBaseClient_Details());
                managerHelper.ActionResult = "Customer edit submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return PartialView("~/Views/Manager/Partials/EditCustomer.cshtml", cmv);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////





        //////////////////////CARS////////////////////////////////////

        [Authorize(Roles = "Manager")]
        public ActionResult SubmitNewCar(CarViewModel cmv)
        {
            if (ModelState.IsValid)
            {
                var managerHelper = new HelpViewModel();
                _manager.AddCar(cmv.toBaseCarDetails());
                managerHelper.ActionResult = "New car submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return PartialView("~/Views/Manager/Partials/AddCar.cshtml");
            }
        }



        [Authorize(Roles = "Manager")]
        public ActionResult SubmitEditCar(CarViewModel cmv)
        {
            if (ModelState.IsValid)
            {
                var managerHelper = new HelpViewModel();
                _manager.UpdateCar(cmv.toBaseCarDetails());
                managerHelper.ActionResult = "Car edit submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return PartialView("~/Views/Manager/Partials/EditCar.cshtml",cmv);
            }
        }





/// /////////////////////////////////////////////////////////////////////////////////////


            /////////////////////DEALS//////////////////////////////////////////////



        [Authorize(Roles = "Manager")]
        public ActionResult SubmitNewDeal(DealViewModel dvm)
        {
            if (ModelState.IsValid)
            {
                var managerHelper = new HelpViewModel();
                _manager.AddDeal(dvm.toBaseDateDetails());
                managerHelper.ActionResult = "New deal submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return PartialView("~/Views/Manager/Partials/AddDeal.cshtml");
            }
        }



        [Authorize(Roles = "Manager")]
        public ActionResult SubmitEditDeal(DealViewModel dvm)
        {
            if (ModelState.IsValid)
            {
                var managerHelper = new HelpViewModel();
                _manager.UpdateDeal(dvm.toBaseDateDetails());
                managerHelper.ActionResult = "Deal edit submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return PartialView("~/Views/Manager/Partials/EditDeal.cshtml",dvm);
            }
        }



/// ///////////////////////////////////////////////////////////////////////////////////////////////
/// 

   ///// ////////////////////MANUFACTORERS//////////////////////


        [Authorize(Roles = "Manager")]
        public ActionResult SubmitNewManufacturer(ManufactorerViewModel dvm)
        {
            if (ModelState.IsValid)
            {
                var managerHelper = new HelpViewModel();
                _manager.AddManufactorer(dvm.toBaseManufacturer());
                managerHelper.ActionResult = "New manufactorer submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }

            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return PartialView("~/Views/Manager/Partials/AddManufacturer.cshtml");
            }
        }




        [Authorize(Roles = "Manager")]
        public ActionResult SubmitEditManufactorer(ManufactorerViewModel dvm)
        {
            if (ModelState.IsValid)
            {
                var managerHelper = new HelpViewModel();
                _manager.UpdateManufactorer(dvm.toBaseManufacturer());
                managerHelper.ActionResult = "Manufactorer edit submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return PartialView("~/Views/Manager/Partials/EditManufacturer.cshtml",dvm);
            }
        }
         

    }
}