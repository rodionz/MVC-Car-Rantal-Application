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

        internal IEnumerable<CarModelViewModel> carModels {get;set;}

        internal IEnumerable<ManufactorerViewModel> carManufacturers { get; set; }
    }
}