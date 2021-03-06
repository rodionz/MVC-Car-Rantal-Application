﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data
{
  public  class Car
    {
        [Key]
        public  int CarID { get; set; }

        public double? Mileage { get; set; }

        [Column(TypeName = "image")]
        public byte[] Picture { get; set; }

        public bool ProperState { get; set; }
       
        [StringLength(15)]
        public string CarNumber { get; set; }

        [Required]
        public int BranchID { get; set; }

        public virtual Branch Branch { get; set; }

        [Required]
        public int ModelID { get; set; }

        public virtual Model Model { get; set; }
    }
}
