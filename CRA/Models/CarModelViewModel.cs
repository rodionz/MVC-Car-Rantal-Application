using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CRA.Data;

namespace CRA.MVC.Models
{
    public class CarModelViewModel
    {

        
        public int ModelID { get; set; }

       
        public string Manufacturer { get; set; }

        
        public string Model { get; set; }

        
        public decimal DailyPrice { get; set; }

       
        public decimal LateReturnFine { get; set; }

        public Gear gear { get; set; }



        public CarModelViewModel(Model_Details domainModelDetails)

        {
            this.ModelID = domainModelDetails.ModelID;

            this.Manufacturer = domainModelDetails.Manufacturer;

            this.Model = domainModelDetails.Model;

            this.DailyPrice = domainModelDetails.DailyPrice;

            this.LateReturnFine = domainModelDetails.LateReturnFine;

            this.gear = domainModelDetails.gear;
        }

    }
}