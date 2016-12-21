﻿using CarRental.BL;
using CarRental.Data;
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

        public EmployeeController()
        {

            _employee = new EmployeeBL();

        }


        // GET: CarReturn
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ReservationSearch(string carNumber)

        {

            var domainModel = _employee.ReservationSearch(carNumber);

            DealViewModel dvm = new DealViewModel(domainModel);

            return View(dvm);

        }


        public ActionResult CloseTheDeal(DealViewModel dvm)
        {

            Deal dd = dvm.toBaseDateDetails();

            _employee.ReservationClosing(dd);
            return View();
        }
    }
}