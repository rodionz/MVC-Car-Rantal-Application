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
              
            helper.AllDeals = allDeals;
          
           return Json(helper, JsonRequestBehavior.AllowGet);
        }



        [Authorize(Roles = "Employee, Manager")]
        public ActionResult CloseTheDeal(DealViewModel dvm)
        {

            Deal dd = dvm.toBaseDateDetails();

            _employee.ReservationClosing(dd);
            return View();
        }
    }
}