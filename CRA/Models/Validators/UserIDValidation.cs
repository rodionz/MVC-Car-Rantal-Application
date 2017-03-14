using CarRental.BL;
using CarRental.MVC.Models;
using CRA.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class UserIDValidation : ValidationAttribute
    {
        private readonly ManagerBL _manager;

        private static IEnumerable<UserViewModel> allCustomers;

        public override bool IsValid(object value)
        {

            allCustomers = _manager.GetAllUsers().Select(u => new UserViewModel(u));

            if (value != null)
            {
                int customerID = int.Parse(value.ToString());

                var modeltoValidate = (from m in allCustomers
                                       where m.ID == customerID
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






        public UserIDValidation()
        {
            _manager = new ManagerBL();
            ErrorMessage = "Customer Does Not Exist";
        }
    }
}