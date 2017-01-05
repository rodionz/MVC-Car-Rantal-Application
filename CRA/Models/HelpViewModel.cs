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

        public IEnumerable<CarModelViewModel> AllCarModels {get;set;}

        public IEnumerable<ManufactorerViewModel> AllManufacturers { get; set; }

        public IEnumerable<CarViewModel> AllCars { get; set; }

        public IEnumerable<CustomerViewModel> AllCustomers { get; set; }

        public IEnumerable<DealViewModel> AllDeals { get; set; }

        public string ManagerAction { get; set; }
    }
}