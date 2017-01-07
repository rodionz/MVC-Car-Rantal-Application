using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CarRental.Data;
using System.Web.Mvc;

namespace CarRental.MVC.Models
{

    public enum ModelGear { Automatic, Manual, Robotic };


    public class CarModelViewModel
    {

        
        public int ID { get; set; }


        public int? ManufacturerId { get; set; }


        public string NameofModel { get; set; }

        
        public decimal DailyPrice { get; set; }

       
        public decimal LateReturnFine { get; set; }

        public ModelGear gear { get; set; }



        public  Model toBaseModelDetail()
        {
            return new Model
            {
                ModelID = ID,
                ManufacturerId = ManufacturerId,
                NameofModel = NameofModel,
                DailyPrice = DailyPrice,
                LateReturnFine = LateReturnFine,
                gear = (Gear)gear


            };
        }




        public CarModelViewModel(Model domainModelDetails)

        {
            this.ID = domainModelDetails.ModelID;

            this.ManufacturerId = domainModelDetails.ManufacturerId;
             
            this.NameofModel = domainModelDetails.NameofModel;
               

            this.DailyPrice = domainModelDetails.DailyPrice;

            this.LateReturnFine = domainModelDetails.LateReturnFine;

        //TODO
              this.gear = (ModelGear)domainModelDetails.gear;
    }





    }
}