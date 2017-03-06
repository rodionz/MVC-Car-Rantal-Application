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


    public class ModelView
    {

        [Required]
        public int ID { get; set; }

        [Required]
        [Display(Name ="Id of Manufacturer")]
        public int? ManufacturerId { get; set; }

        [Display(Name = "Name of Model")]
        public string NameofModel { get; set; }

        [Display(Name = "Daily Price")]
        public decimal DailyPrice { get; set; }

       [Display(Name = "Late Return Fine")]
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






        public ModelView() { }


        public ModelView(Model domainModelDetails)

        {
            this.ID = domainModelDetails.ModelID;
            this.ManufacturerId = domainModelDetails.ManufacturerId;           
            this.NameofModel = domainModelDetails.NameofModel;              
            this.DailyPrice = domainModelDetails.DailyPrice;
            this.LateReturnFine = domainModelDetails.LateReturnFine;  
            this.gear = (ModelGear)domainModelDetails.gear;
    }





    }
}