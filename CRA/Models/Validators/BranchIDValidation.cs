using CarRental.MVC.Models;
using CRA.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class BranchIDValidation : ValidationAttribute
    {
        private static IEnumerable<BranchViewModel> allBranches;

        private readonly GuestBL guest;

        public override bool IsValid(object value)
        {

            allBranches = guest.GetAllBranches().Select(b => new BranchViewModel(b));

            if (value != null)
            {
                int branchId = int.Parse(value.ToString());

                var modeltoValidate = (from m in allBranches
                                       where m.ID == branchId
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







        public  BranchIDValidation(){

            guest = new GuestBL();

            ErrorMessage = "Branch does not exist";

        }
    }
}