using CarRental.MVC.Models;
using CRA.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class ModelIDValidation : ValidationAttribute
    {
        private static IEnumerable<ModelView> allmodels;

        private readonly GuestBL guest;


        public override bool IsValid(object value)
        {

            allmodels = guest.GettAllModels().Select(c => new ModelView(c));

            if (value != null)
            {
                int modelID = int.Parse(value.ToString());

                var modeltoValidate = (from m in allmodels
                                              where m.ID == modelID
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




        public ModelIDValidation() {

            ErrorMessage = "Model does not exist";

            guest = new GuestBL();
        }
    }
}