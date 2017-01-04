﻿using System;
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

        public string StartDate { get; set; }

        public string SupposedReturn { get; set; }

        public string RealReturn { get; set; }

        public int? ClientID { get; set; }
        
        public int? CarID { get; set; }



        public  Deal toBaseDateDetails ()
        {
            return new Deal
            {
                ID = ID,
                Start = new DateTime(long.Parse(StartDate)),
                SupposedReturn = new DateTime(long.Parse(SupposedReturn)),
                RealReturn = new DateTime(long.Parse(RealReturn)),
                //UserId = ClientID,
                CarID = CarID

            };
        }





        public DealViewModel(Deal domainDealDetails)


        {
            this.ID = domainDealDetails.ID;

            this.StartDate = domainDealDetails.Start.Value.ToShortDateString();

            this.SupposedReturn = domainDealDetails.SupposedReturn.Value.ToShortDateString();

            this.RealReturn = domainDealDetails.RealReturn.Value.ToShortDateString();

            //this.ClientID = domainDealDetails.UserId;

            this.CarID = domainDealDetails.CarID;



        }



    }
}