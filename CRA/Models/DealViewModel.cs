using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRental.Data;
using System.ComponentModel.DataAnnotations;
using CarRental.Models;
using System.Globalization;

namespace CarRental.MVC.Models
{
    public class DealViewModel
    {

     
        public int ID { get; set; }

        [Required]
        public string StartDate { get; set; }


        [Required]
        public string SupposedReturn { get; set; }

       
        public string RealReturn { get; set; }

        [Required]
        [UserIDValidation]
        [Display(Name = "Id of Client")]
        public int? ClientID { get; set; }
        
        [Required]
        [CarIDValidation]
        [Display(Name = "Id of Car")]
        public int? CarID { get; set; }



        public  Deal toBaseDateDetails ()
        {

            if (RealReturn != null)
            {
                return new Deal
                {
                    ID = ID,

                    Start = DateTime.ParseExact(StartDate, "dd-mm-yy", CultureInfo.InvariantCulture),
                    SupposedReturn =  DateTime.ParseExact(SupposedReturn, "dd-mm-yy", CultureInfo.InvariantCulture),
                    Realreturn =  DateTime.ParseExact(RealReturn, "dd-mm-yy", CultureInfo.InvariantCulture),   
                    UserId = ClientID,
                    CarID = CarID

                };
            }

            else
            {
                return new Deal
                {
                    ID = ID,
                    Start = DateTime.ParseExact(StartDate, "dd-mm-yy", CultureInfo.InvariantCulture),
                    SupposedReturn = DateTime.ParseExact(SupposedReturn, "dd-mm-yy", CultureInfo.InvariantCulture),
                    Realreturn = null,
                    UserId = ClientID,
                    CarID = CarID

                };
            }
        }


        public DealViewModel() { }


        public DealViewModel(Deal domainDealDetails)


        {
            this.ID = domainDealDetails.ID;

            this.StartDate = domainDealDetails.Start.Value.ToShortDateString();

            this.SupposedReturn = domainDealDetails.SupposedReturn.Value.ToShortDateString();

            if(domainDealDetails.Realreturn.HasValue)
            {
                this.RealReturn = domainDealDetails.Realreturn.Value.ToShortDateString();
            }
            

            this.ClientID = domainDealDetails.UserId;

            this.CarID = domainDealDetails.CarID;



        }



    }
}