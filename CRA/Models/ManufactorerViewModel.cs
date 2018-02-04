using CarRental.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class ManufactorerViewModel
    {

        public int ID { get; set; }

        [Required]
        [Display (Name ="Manufactorer Name")]
        public string manufacturerName { get; set; }


        public ManufactorerViewModel(Manufacturers domainManuf) {

            this.ID = domainManuf.ID;
            this.manufacturerName = domainManuf.Manufacturer;           
        }

        public Manufacturers toBaseManufacturer() {

            return new Manufacturers
            {
                ID = ID,
                Manufacturer = manufacturerName,               
            };
        }

        public ManufactorerViewModel() { }

    }
}