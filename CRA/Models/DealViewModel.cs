using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRental.Data;
using System.ComponentModel.DataAnnotations;

namespace CarRental.MVC.Models
{
    public class DealViewModel
    {

     
        public int ID { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? SupposedReturn { get; set; }

        public DateTime? RealReturn { get; set; }

        [Display(Name = "Id of Client")]
        public int? ClientID { get; set; }
        
        [Display(Name = "Id of Car")]
        public int? CarID { get; set; }



        public  Deal toBaseDateDetails ()
        {
            return new Deal
            {
                ID = ID,
                Start = StartDate,
                SupposedReturn = SupposedReturn,
                RealReturn = RealReturn,
                UserId = ClientID,
                CarID = CarID

            };
        }


        public DealViewModel() { }


        public DealViewModel(Deal domainDealDetails)


        {
            this.ID = domainDealDetails.ID;

            this.StartDate = domainDealDetails.Start;

            this.SupposedReturn = domainDealDetails.SupposedReturn;

            this.RealReturn = domainDealDetails.RealReturn;

            this.ClientID = domainDealDetails.UserId;

            this.CarID = domainDealDetails.CarID;



        }



    }
}