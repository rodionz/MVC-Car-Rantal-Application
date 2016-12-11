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




        public ActionResult AddModel(CarModelVM cmvm)
        {
            var originalModel = cmvm.toBaseModelDetail();
            _manager.AddModel(originalModel);

            return RedirectToAction("Index");
        }

        public ActionResult UpdateModel(CarModelVM cmvm)
        {
            var originalModel = cmvm.toBaseModelDetail();
            _manager.UpdateModel(originalModel);
            return View();
        }

        public ActionResult DeleteModel(CarModelVM cmvm)
        {
            var originalModel = cmvm.toBaseModelDetail();
            _manager.DeleteModel(originalModel);
            return View();
        }

        public ActionResult AddCar(CarVM cvm)
        {

            var originalCar = cvm.toBaseCarDetails();
            _manager.AddCar(originalCar);

            return View();
        }

        public ActionResult UpdateCar(CarVM cvm)
        {
            var originalCar = cvm.toBaseCarDetails();
            _manager.UpdateCar(originalCar);
            return View();
        }

        public ActionResult DeleteCar(CarVM cvm)
        {
            var originalCar = cvm.toBaseCarDetails();
            _manager.DeleteCar(originalCar);
            return View();
        }


        public ActionResult AddClient(ClientVM client)
        {
            var originalClient = client.toBaseClient_Details();
            _manager.AddClient(originalClient);
            return View();
        }

        public ActionResult UpdateClient(ClientVM client)
        {
            var originalClient = client.toBaseClient_Details();
            _manager.UpdateClient(originalClient);
            return View();
        }

        public ActionResult DeleteClient(ClientVM client)
        {
            var originalClient = client.toBaseClient_Details();
            _manager.DeleteClient(originalClient);
            return View();
        }

        public ActionResult AddDeal(DealVM dvm)
        {
            var originalDeal = dvm.toBaseDateDetails();
            _manager.AddReservation(originalDeal);
            return View();
        }

        public ActionResult UpdateDeal(DealVM dvm)
        {
            var originalDeal = dvm.toBaseDateDetails();
            _manager.UpdateReservation(originalDeal);
            return View();
        }

        public ActionResult DeleteDeal(DealVM dvm)
        {
            var originalDeal = dvm.toBaseDateDetails();
            _manager.DeleteReservation(originalDeal);
            return View();
        }
    }
}