using CarRental.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class ManufactorerViewModel
    {

        public int ID { get; set; }

        public string Manufacturer { get; set; }

        public ICollection<Model> Models { get; set; }


        public ManufactorerViewModel(Manufacturers domainManuf) {

            this.ID = domainManuf.ID;
            this.Manufacturer = domainManuf.Manufacturer;
            //this.Models = domainManuf.Models;

        }

        public Manufacturers toBaseManufacturer() {

            return new Manufacturers
            {
                ID = ID,
                Manufacturer = Manufacturer,
                //Models = Models
            };
        }

    }
}