using CarRent.BL;
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

        private readonly CompanyRoleProvider _roleprovider;

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
            _roleprovider = new CompanyRoleProvider();
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

            var managerHelper = new HelpModel();

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
         * Based on the usage of the universal HelpModel i decided to combine all those functions in one.
         */
        [HttpGet]
        [Authorize(Roles = "Manager")]
        public ActionResult ManagerActions(HelpModel hvm)
        {
            HelpModel result = new HelpModel();


            switch (hvm.ManagerAction)
            {
                
                   ///////// MODELS ///////////

                case "AddModel":
                    return PartialView("AddModel");


                case "EditModel":
                    var model = (from m in allmodels where m.ID == hvm.ID select m).FirstOrDefault();
                    return PartialView("EditModel", model);


                case "DeleteModel":
                    _manager.DeleteModel(hvm.ID);
                    HelpModel modelresult = new HelpModel();
                    modelresult.ActionResult = "Model Deleted";
                    return Json(modelresult, JsonRequestBehavior.AllowGet);

                /////////////  CARS /////////////

                case "AddCar":
                    return PartialView("AddCar");


                case "EditCar":
                    var car = (from c in allCars where c.ID == hvm.ID select c).FirstOrDefault();
                    return PartialView("EditCar", car);


                case "DeleteCar":
                    _manager.DeleteCar(hvm.ID);
                    HelpModel carresult = new HelpModel();
                    carresult.ActionResult = "Model Deleted";
                    return Json(carresult, JsonRequestBehavior.AllowGet);


                /////////////// USERS ////////////////////

                case "AddUser":
                    return PartialView("AddUser");

             

                case "EditUser":
                    var customer = (from c in allCustomers where c.ID == hvm.ID select c).FirstOrDefault();
                    return PartialView("EditUser", customer);



                case "EditEmployee":
                    var employee = (from c in allEmployees where c.ID == hvm.ID select c).FirstOrDefault();
                    return PartialView("EditUser", employee);


                case "DeleteCustomer":
                    _manager.DeleteClient(hvm.ID);
                    HelpModel customerresult = new HelpModel();
                    customerresult.ActionResult = "Model Deleted";
                    return Json(customerresult, JsonRequestBehavior.AllowGet);



                ///////////////////// MANUFACTORERS /////////////////////




                case "AddManufacturer":
                    return PartialView("AddManufacturer");


                case "EditManufactorer":
                    var manuf = (from m in allManufacturers where m.ID == hvm.ID select m).FirstOrDefault();
                    return PartialView("EditManufacturer", manuf);


                case "DeleteManufactorer":
                    _manager.DeleteManufactorer(hvm.ID);
                    HelpModel manrresult = new HelpModel();
                    manrresult.ActionResult = "Model Deleted";
                    return Json(manrresult, JsonRequestBehavior.AllowGet);




                /////////////// DEALS ///////////////////////


                case "AddDeal":
                    return PartialView("AddDeal");

                case "EditDeal":
                    var deal = (from d in allDeals where d.ID == hvm.ID select d).FirstOrDefault();
                    return PartialView("EditDeal", deal);           

                case "DeleteDeal":
                    _manager.DeleteDeal(hvm.ID);
                    HelpModel dealresult = new HelpModel();
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
                var result = new HelpModel();
                result.ActionResult = "Model Added";

                return Json(result, JsonRequestBehavior.AllowGet);
            }

            else
            {
                  return PartialView("AddModel");
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
                var result = new HelpModel();
                result.ActionResult = "Model Edited";
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return PartialView("EditModel", cmv);
            }
        }



        /// //////////////////////////////////////////////////////////////////////////////////////




        ///////////////Customers//////////////////////////    



        [Authorize(Roles = "Manager")]
        public ActionResult SubmitNewCustomer(UserViewModel cmv)
        {
            if (ModelState.IsValid)
            {


                if (_roleprovider.UserExists(cmv.UserName))
                {
                    ModelState.AddModelError(string.Empty, "Username already in use");

                    return PartialView("AddUser");
                }

                var managerHelper = new HelpModel();
                _manager.AddClient(cmv.toBaseClient_Details());
                managerHelper.ActionResult = "New Customer Submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return PartialView("AddUser");
            }
        }


        
     

        [Authorize(Roles = "Manager")]
        public ActionResult SubmitEditCustomer(UserViewModel cmv)
        {
            if (ModelState.IsValid)
            {
                var managerHelper = new HelpModel();
                _manager.UpdateClient(cmv.toBaseClient_Details());
                managerHelper.ActionResult = "Customer edit submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return PartialView("EditUser", cmv);
            }
        }



        ////////////////////////////////////////////////////////////////////////////////////////



        //////////////////////////////EMPLOYEES/////////////////////////

        [Authorize(Roles = "Manager")]
        public ActionResult SubmitNewEmployee(UserViewModel cmv)
        {
            if (ModelState.IsValid)
            {

                if (_roleprovider.UserExists(cmv.UserName))
                {
                    ModelState.AddModelError(string.Empty, "Username already in use");

                    return PartialView("AddUser");
                }



                var managerHelper = new HelpModel();

                var domainclient = cmv.toBaseClient_Details();

                _manager.AddClient(domainclient);

                string[] users = { cmv.UserName };

                string[] roles = { "Employee" };

                _roleprovider.AddUsersToRoles(users, roles);


                managerHelper.ActionResult = "New Employee Submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return PartialView("AddUser");
            }
        }





        [Authorize(Roles = "Manager")]
        public ActionResult SubmitEditEmployee(UserViewModel cmv)
        {
            if (ModelState.IsValid)
            {
                var managerHelper = new HelpModel();
                _manager.UpdateClient(cmv.toBaseClient_Details());
                managerHelper.ActionResult = "Customer edit submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }
            else
            {
                
                return PartialView("EditUser", cmv);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////





        //////////////////////CARS////////////////////////////////////

        [Authorize(Roles = "Manager")]
        public ActionResult SubmitNewCar(CarViewModel cmv)
        {
            if (ModelState.IsValid)
            {
                var managerHelper = new HelpModel();
                _manager.AddCar(cmv.toBaseCarDetails());
                managerHelper.ActionResult = "New car submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return PartialView("AddCar");
            }
        }



        [Authorize(Roles = "Manager")]
        public ActionResult SubmitEditCar(CarViewModel cmv)
        {
            if (ModelState.IsValid)
            {
                var managerHelper = new HelpModel();
                _manager.UpdateCar(cmv.toBaseCarDetails());
                managerHelper.ActionResult = "Car edit submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return PartialView("EditCar",cmv);
            }
        }





/// /////////////////////////////////////////////////////////////////////////////////////


            /////////////////////DEALS//////////////////////////////////////////////



        [Authorize(Roles = "Manager")]
        public ActionResult SubmitNewDeal(DealViewModel dvm)
        {
            if (ModelState.IsValid)
            {
                var managerHelper = new HelpModel();
                _manager.AddDeal(dvm.toBaseDateDetails());
                managerHelper.ActionResult = "New deal submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return PartialView("AddDeal");
            }
        }



        [Authorize(Roles = "Manager")]
        public ActionResult SubmitEditDeal(DealViewModel dvm)
        {
            if (ModelState.IsValid)
            {
                var managerHelper = new HelpModel();
                _manager.UpdateDeal(dvm.toBaseDateDetails());
                managerHelper.ActionResult = "Deal edit submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return PartialView("EditDeal",dvm);
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
                var managerHelper = new HelpModel();
                _manager.AddManufactorer(dvm.toBaseManufacturer());
                managerHelper.ActionResult = "New manufactorer submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }

            else
            {
                IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return PartialView("AddManufacturer");
            }
        }




        [Authorize(Roles = "Manager")]
        public ActionResult SubmitEditManufactorer(ManufactorerViewModel dvm)
        {
            if (ModelState.IsValid)
            {
                var managerHelper = new HelpModel();
                _manager.UpdateManufactorer(dvm.toBaseManufacturer());
                managerHelper.ActionResult = "Manufactorer edit submitted";
                return Json(managerHelper, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return PartialView("EditManufacturer",dvm);
            }
        }
         

    }
}