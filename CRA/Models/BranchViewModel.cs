using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CarRental;
using CarRental.Data;

namespace CarRental.MVC.Models
{
    public class BranchViewModel
    {

      
        public int BranchID { get; set; }

      
        public string BranchName { get; set; }

        
        public string City { get; set; }

       
        public string District { get; set; }

        //Location




        public static implicit operator Branch_Details (BranchViewModel vm)
        {
            return new Branch_Details
            {
                BranchID = vm.BranchID,
                BranchName = vm.BranchName,
                City = vm.City,
                District = vm.District
            };
        }




        public BranchViewModel(Branch_Details domainBranch)
        {
            this.BranchID = domainBranch.BranchID;

            this.BranchName = domainBranch.BranchName;

            this.City = domainBranch.City;

            this.District = domainBranch.City;

        }

    }
}