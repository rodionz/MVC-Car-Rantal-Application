using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CRA;
using CRA.Data;

namespace CRA.MVC.Models
{
    public class BranchViewModel
    {

      
        public int BranchID { get; set; }

      
        public string BranchName { get; set; }

        
        public string City { get; set; }

       
        public string District { get; set; }

        //Location

        public BranchViewModel(Branch_Details domainBranch)
        {
            this.BranchID = domainBranch.BranchID;

            this.BranchName = domainBranch.BranchName;

            this.City = domainBranch.City;

            this.District = domainBranch.City;

        }

    }
}