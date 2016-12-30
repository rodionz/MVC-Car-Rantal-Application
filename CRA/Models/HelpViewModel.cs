using CarRental.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class HelpViewModel
    {
        public int modelId { get; set; }

        public IEnumerable<CarModelViewModel> carModels {get;set;}

        public IEnumerable<ManufactorerViewModel> carManufacturers { get; set; }

        public IEnumerable<CarViewModel> allCars { get; set; }

        public string ManagerAction { get; set; }
    }
}