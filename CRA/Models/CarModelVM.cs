using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CarRental.Data;

namespace CarRental.MVC.Models
{

    public enum ModelGear { Automatic, Manual };


    public class CarModelVM
    {

        
        public int ModelID { get; set; }

       
        public string Manufacturer { get; set; }

        
        public string NameofModel { get; set; }

        
        public decimal DailyPrice { get; set; }

       
        public decimal LateReturnFine { get; set; }

        public ModelGear gear { get; set; }



        public  Model toBaseModelDetail()
        {
            return new Model
            {
                ModelID = ModelID,
                Manufacturer = Manufacturer,
                NameofModel = NameofModel,
                DailyPrice = DailyPrice,
                LateReturnFine = LateReturnFine,
                gear = (Gear)gear


            };
        }




        public CarModelVM(Model domainModelDetails)

        {
            this.ModelID = domainModelDetails.ModelID;

            this.Manufacturer = domainModelDetails.Manufacturer;

            this.NameofModel = domainModelDetails.NameofModel
                ;

            this.DailyPrice = domainModelDetails.DailyPrice;

            this.LateReturnFine = domainModelDetails.LateReturnFine;

        //TODO
              this.gear = (ModelGear)domainModelDetails.gear;
    }

    }
}