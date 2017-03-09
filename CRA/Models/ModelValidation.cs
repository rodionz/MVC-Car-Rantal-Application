using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class ModelValidation : ValidationAttribute
    {

        public override bool IsValid(object value)
        {

            if (value != null)
            {
                string writersFullname = value.ToString();

                if (writersFullname.IndexOf(' ') != -1)
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






        public ModelValidation() {

            ErrorMessage = "Manufactorer does not exist";
        }
    }
}