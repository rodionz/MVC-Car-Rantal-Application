using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRental.Data;
using System.ComponentModel.DataAnnotations;

namespace CarRental.MVC.Models
{
    public class DealVM

    {

     
        public int ID { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? SupposedReturn { get; set; }

        public DateTime? RealReturn { get; set; }

        public int? ClientID { get; set; }
        
        public int? CarID { get; set; }



        public  Deal toBaseDateDetails ()
        {
            return new Deal
            {
                ID = ID,
                Start = Start,
                SupposedReturn = SupposedReturn,
                RealReturn = RealReturn,
                ClientID = ClientID,
                CarID = CarID

            };
        }





        public DealVM(Deal domainDealDetails)


        {
            this.ID = domainDealDetails.ID;

            this.Start = domainDealDetails.Start;

            this.SupposedReturn = domainDealDetails.SupposedReturn;

            this.RealReturn = domainDealDetails.RealReturn;

            this.ClientID = domainDealDetails.ClientID;

            this.CarID = domainDealDetails.CarID;



        }



    }
}