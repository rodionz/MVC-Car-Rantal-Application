using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class DateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                DateTime dt;
                bool isValid = DateTime.TryParseExact(value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);

                return isValid;
            }

            else return true;
        }


        public DateValidation() {

            ErrorMessage = "Please enter date in dd/mm/yyyy format";

        }

    }
}