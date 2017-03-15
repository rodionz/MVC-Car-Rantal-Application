using CarRental.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Models.Validators
{
    public class UserNameValidation : ValidationAttribute
    {
        public readonly ManagerBL manager;



       

        public override bool IsValid(object value)
        {
            if (value != null)
            {

                IEnumerable<string> allusernames = manager.GetAllUsers().Select(u => u.UserName);

            var name = value.ToString();

            
                 if(allusernames.Contains(name))
                {
                    return false;
                }

                else
                {
                    return true;
                }
            }


            else return false;
        }

        public UserNameValidation()
        {
            manager = new ManagerBL();
            ErrorMessage = "Username already taken";
        }
    }
}