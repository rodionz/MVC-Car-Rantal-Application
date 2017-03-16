using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CarRental;
using CarRental.Data;
using System.Data.Entity.Spatial;

namespace CarRental.MVC.Models
{
    public class BranchViewModel
    {

      
        public int ID { get; set; }

       [Display(Name = "Branch Name")]
        [Required]
        public string BranchName { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string District { get; set; }

        public DbGeography Location { get; set; }



        public BranchViewModel() { }


        public  Branch toBaseBranchDetails ()
        {
            return new Branch
            {
                BranchID = ID,
                BranchName = BranchName,
                City = City,
                District = District,
                Location = Location
                
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