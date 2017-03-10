using CarRental.MVC.Models;
using CRA.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class CarIDValidation : ValidationAttribute
    {
        private static IEnumerable<CarViewModel> allCars;

        private readonly GuestBL guest;

        public override bool IsValid(object value)
        {

            allCars = guest.GetAllCarsinProperState().Select(c => new CarViewModel(c));

            if (value != null)
            {
                int carlID = int.Parse(value.ToString());

                var modeltoValidate = (from m in allCars
                                       where m.ID == carlID
                                       select m).FirstOrDefault();


                if (modeltoValidate != null)
                {
                    return true;
                }

                else
                {

                    return false;
                }
            }
            else return false;
        }





        public CarIDValidation() {
            ErrorMessage = "Car does not exist";

            guest = new GuestBL();


        }
    }
}