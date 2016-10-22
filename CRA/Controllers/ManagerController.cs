using CarRental.BL;
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


        // GET: Manager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddModel()
        {


            return View();
        }
    }
}