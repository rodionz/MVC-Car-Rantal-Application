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

      

        public string CarNumber { get; set; }

        public int? BranchID { get; set; }
    
        public int? ModelID { get; set; }




        public  Car toBaseCarDetails ()
        {
            return new Car
            {
                CarID = CarID,
                Mileage = Mileage,
                Picture = Picture,
               
                CarNumber = CarNumber,
                BranchID = BranchID,
                ModelID = ModelID


            };
        }

        public CarViewModel(Car domainCarDetails)
        {
            this.CarID = domainCarDetails.CarID;

            this.Mileage = domainCarDetails.Mileage;

            this.Picture = domainCarDetails.Picture;

            

            this.CarNumber = domainCarDetails.CarNumber;

            this.BranchID = domainCarDetails.BranchID;

            this.ModelID = domainCarDetails.ModelID;



        }

    }
}