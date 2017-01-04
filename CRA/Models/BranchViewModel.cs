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

      
        public int ID { get; set; }

      
        public string BranchName { get; set; }

        
        public string City { get; set; }

       
        public string District { get; set; }

        //Location




        public  Branch toBaseBranchDetails ()
        {
            return new Branch
            {
                BranchID = ID,
                BranchName = BranchName,
                City = City,
                District = District
            };
        }




        public BranchViewModel(Branch domainBranch)
        {
            this.ID = domainBranch.BranchID;

            this.BranchName = domainBranch.BranchName;

            this.City = domainBranch.City;

            this.District = domainBranch.City;

        }

    }
}