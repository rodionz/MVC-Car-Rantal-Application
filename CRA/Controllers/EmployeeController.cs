using CarRental.BL;
using CarRental.Data;
using CarRental.Models;
using CarRental.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class EmployeeController : Controller
    {
        public readonly EmployeeBL _employee;

        private static IEnumerable<DealViewModel> allDeals;

        private static IEnumerable<CarViewModel> allCars;

        private static IEnumerable<ModelView> allModels;

        public EmployeeController()
        {

            _employee = new EmployeeBL();

        }


        // GET: CarReturn
        [Authorize(Roles = "Employee, Manager")]
        public ActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "Employee, Manager")]
        public JsonResult HelpAjax()
        {
            var helper = new HelpViewModel();

            allDeals =_employee.GetAllDeals().Select(d => new DealViewModel(d));

            allCars = _employee.GettAllCars().Select(c => new CarViewModel(c));

            allModels = _employee.GettAllModels().Select(m => new ModelView(m));
              
            helper.AllDeals = allDeals;

            helper.AllCars = allCars;

            helper.AllCarModels = allModels;
          
           return Json(helper, JsonRequestBehavior.AllowGet);
        }



        [Authorize(Roles = "Employee, Manager")]
        public ActionResult CloseTheDeal(HelpViewModel hvm)
        {
            var helper = new HelpViewModel();

            _employee.ReservationClosing(hvm.dealID,hvm.RealReturn);

            helper.ActionResult = "Deal Deleted";

            return Json(helper,JsonRequestBehavior.AllowGet);
        }
    }
}