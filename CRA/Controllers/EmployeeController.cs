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
        public ActionResult Index()
        {
            return View();
        }



        public JsonResult HelpAjax()
        {
            var helper = new HelpViewModel();

            allDeals =_employee.GetAllDeals().Select(d => new DealViewModel(d));
              
            helper.AllDeals = allDeals;
          
           return Json(helper, JsonRequestBehavior.AllowGet);
        }















        //public ActionResult ReservationSearch(string carNumber)

        //{

        //    var domainModel = _employee.ReservationSearch(carNumber);

        //    DealViewModel dvm = new DealViewModel(domainModel);

        //    return View(dvm);

        //}


        public ActionResult CloseTheDeal(DealViewModel dvm)
        {

            Deal dd = dvm.toBaseDateDetails();

            _employee.ReservationClosing(dd);
            return View();
        }
    }
}