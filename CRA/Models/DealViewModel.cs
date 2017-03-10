using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRental.Data;
using System.ComponentModel.DataAnnotations;
using CarRental.Models;

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
                    Start = Convert.ToDateTime(StartDate),
                    SupposedReturn = Convert.ToDateTime(SupposedReturn),
                    Realreturn = Convert.ToDateTime(RealReturn),
                    UserId = ClientID,
                    CarID = CarID

                };
            }

            else
            {
                return new Deal
                {
                    ID = ID,
                    Start = Convert.ToDateTime(StartDate),
                    SupposedReturn = Convert.ToDateTime(SupposedReturn),
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