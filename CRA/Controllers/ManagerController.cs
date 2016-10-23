using CarRental.BL;
using CarRental.Data;
using CarRental.MVC.Models;
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


        public ManagerController()
        {
            _manager = new ManagerBL();
        }


       
        public ActionResult Index()
        
        {       
            return View();
        }




        public ActionResult AddModel(CarModelViewModel cmvm)
        {
            var originalModel = (Model_Details)cmvm;
            _manager.AddModel(originalModel);

            return RedirectToAction("Index");
        }

        public ActionResult UpdateModel(CarModelViewModel cmvm)
        {
            var originalModel = (Model_Details)cmvm;
            _manager.UpdateModel(originalModel);
            return View();
        }

        public ActionResult DeleteModel(CarModelViewModel cmvm)
        {
            var originalModel = (Model_Details)cmvm;
            _manager.DeleteModel(originalModel);
            return View();
        }

        public ActionResult AddCar(CarViewModel cvm)
        {

            var originalCar = (Car_Details)cvm;
            _manager.AddCar(originalCar);

            return View();
        }

        public ActionResult UpdateCar(CarViewModel cvm)
        {
            var originalCar = (Car_Details)cvm;
            _manager.UpdateCar(originalCar);
            return View();
        }

        public ActionResult DeleteCar(CarViewModel cvm)
        {
            var originalCar = (Car_Details)cvm;
            _manager.DeleteCar(originalCar);
            return View();
        }


        public ActionResult AddClient(ClientViewModel client)
        {
            var originalClient = (Client_Details)client;
            _manager.AddClient(originalClient);
            return View();
        }

        public ActionResult UpdateClient(ClientViewModel client)
        {
            var originalClient = (Client_Details)client;
            _manager.UpdateClient(originalClient);
            return View();
        }

        public ActionResult DeleteClient(ClientViewModel client)
        {
            var originalClient = (Client_Details)client;
            _manager.DeleteClient(originalClient);
            return View();
        }

        public ActionResult AddDeal(DealViewModel dvm)
        {
            var originalDeal = (Deal_Details)dvm;
            _manager.AddReservation(originalDeal);
            return View();
        }

        public ActionResult UpdateDeal(DealViewModel dvm)
        {
            var originalDeal = (Deal_Details)dvm;
            _manager.UpdateReservation(originalDeal);
            return View();
        }

        public ActionResult DeleteDeal(DealViewModel dvm)
        {
            var originalDeal = (Deal_Details)dvm;
            _manager.DeleteReservation(originalDeal);
            return View();
        }
    }
}