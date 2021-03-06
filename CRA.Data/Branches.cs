﻿using Microsoft.SqlServer.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarRental.Data
{
  public  class Branch
    {
        [Key]
        public int BranchID { get; set; }

        [StringLength(15)]
        public string BranchName { get; set; }

        [StringLength(15)]
        public string City { get; set; }

        [StringLength(15)]
        public string District { get; set; }

        public DbGeography Location { get; set; }

    }
}
