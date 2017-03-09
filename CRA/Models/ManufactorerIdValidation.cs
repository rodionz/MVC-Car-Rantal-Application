using CRA.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class ManufactorerIdValidation : ValidationAttribute
    {

        private static IEnumerable<ManufactorerViewModel> allManufacturers;

        private readonly GuestBL guest;


        public override bool IsValid(object value)
        {
           
        allManufacturers = guest.GettAllManufacturers().Select(c => new ManufactorerViewModel(c));

            if (value != null)
            {
                int manufactorerID = int.Parse(value.ToString());

                var manufactorertoValidate = (from m in allManufacturers
                                              where m.ID == manufactorerID
                                              select m).FirstOrDefault();


                if (manufactorertoValidate != null)
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






        public ManufactorerIdValidation() {
            guest = new GuestBL();
            ErrorMessage = "Manufactorer does not exist";
        }
    }
}