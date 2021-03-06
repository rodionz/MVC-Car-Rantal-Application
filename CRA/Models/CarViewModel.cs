﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CarRental.Data;
using CarRental.Models;

namespace CarRental.MVC.Models {

    public class CarViewModel {
        [Required]
        public int ID { get; set; }

        [Required]
        public double? Mileage { get; set; }

        [Required]
        [Display (Name = "Car Number")]
        public string CarNumber { get; set; }

        [Required]
        [Display (Name = "Id of Branch")]
        [BranchIDValidation]
        public int BranchID { get; set; }

        [Required]
        [Display (Name = "Id of Model")]
        [ModelIDValidation]
        public int ModelID { get; set; }

        [Required]
        [Display (Name = "Car is in proper state")]
        public bool ProperState { get; set; }

        [Column (TypeName = "Picture")]
        public HttpPostedFileBase Picture { get; set; }

        public CarViewModel () { }

        public Car toBaseCarDetails () {
            return new Car {
                CarID = ID,
                    Mileage = Mileage,
                    CarNumber = CarNumber,
                    BranchID = BranchID,
                    ModelID = ModelID,
                    ProperState = ProperState
            };
        }

        public CarViewModel (Car domainCarDetails) {
            this.ID = domainCarDetails.CarID;
            this.Mileage = domainCarDetails.Mileage;
            this.CarNumber = domainCarDetails.CarNumber;
            this.BranchID = domainCarDetails.BranchID;
            this.ModelID = domainCarDetails.ModelID;
            this.ProperState = domainCarDetails.ProperState;
        }

    }
}