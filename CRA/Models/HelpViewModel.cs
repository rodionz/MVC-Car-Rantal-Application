using CarRental.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class HelpViewModel
    {
        public int ID { get; set; }

        public IEnumerable<ModelView> AllCarModels {get;set;}

        public IEnumerable<ManufactorerViewModel> AllManufacturers { get; set; }

        public IEnumerable<CarViewModel> AllCars { get; set; }

        public IEnumerable<UserViewModel> AllCustomers { get; set; }

        private static IEnumerable<UserViewModel> allEmployees;

        public IEnumerable<DealViewModel> AllDeals { get; set; }

        public string ManagerAction { get; set; }

        public string ActionResult { get; set; }

        public int? ClientID { get; set; }

        public int carID { get; set; }

        public int modelID { get; set; }

        public int dealID { get; set; }

        public string StartDate { get; set; }

        public string SupposedReturn { get; set; }

        public string RealReturn { get; set; }

        public int totallPrice { get; set; }

        public string modelName { get; set; }

       
    }
}