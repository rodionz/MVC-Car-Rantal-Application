﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CarRental.Data;
using System.Web.Mvc;
using CarRental.Models;

namespace CarRental.MVC.Models
{

    public class ModelView
    {
      
        public int ID { get; set; }

        [Required]
        [Display(Name ="Manufacturer's ID")]
        [ManufactorerIdValidation]
        public int ManufacturerId { get; set; }

        [Required]
        [Display(Name = "Name of Model")]
        public string NameofModel { get; set; }

        [Required]
        [Display(Name = "Daily Price")]
        public decimal DailyPrice { get; set; }

        [Required]
       [Display(Name = "Late Return Fine")]
        public decimal LateReturnFine { get; set; }

        [Required]
        [Display(Name = "Transmission")]
        [EnumDataType(typeof(Gear), ErrorMessage = "Please enter a valid Gear")]
        public Gear? gear { get; set; }

        public  Model toBaseModelDetail()
        {
            return new Model
            {
                ModelID = ID,
                ManufacturerId = ManufacturerId,
                NameofModel = NameofModel,
                DailyPrice = DailyPrice,
                LateReturnFine = LateReturnFine,
                gear = gear.Value
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
            this.gear = domainModelDetails.gear;
    }

    }
}