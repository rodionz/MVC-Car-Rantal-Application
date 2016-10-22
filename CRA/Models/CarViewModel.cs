using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRental.Data;
using System.ComponentModel.DataAnnotations;

namespace CarRental.MVC.Models
{

   

    public class CarViewModel
    {
       
        public int CarID { get; set; }

        public double? Mileage { get; set; }
       
        public byte[] Picture { get; set; }

        public bool ProperState { get; set; }

        public string CarNumber { get; set; }

        public int? BranchID { get; set; }
    
        public int? ModelID { get; set; }




        public static implicit operator Car_Details(CarViewModel vm)
        {
            return new Car_Details
            {
                CarID = vm.CarID,
                Mileage = vm.Mileage,
                Picture = vm.Picture,
                ProperState = vm.ProperState,
                CarNumber = vm.CarNumber,
                BranchID = vm.BranchID,
                ModelID = vm.ModelID


            };
        }

        public CarViewModel(Car_Details domainCarDetails)
        {
            this.CarID = domainCarDetails.CarID;

            this.Mileage = domainCarDetails.Mileage;

            this.Picture = domainCarDetails.Picture;

            this.ProperState = domainCarDetails.ProperState;

            this.CarNumber = domainCarDetails.CarNumber;

            this.BranchID = domainCarDetails.BranchID;

            this.ModelID = domainCarDetails.ModelID;



        }

    }
}