using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.Data
{
  public  class Car_Details
    {
        [Key]
        public  int CarID { get; set; }

        public Model_Details Model { get; set; }

        public double Mileage { get; set; }

        public byte[] Picture { get; set; }

        public bool ProperState { get; set; }

        [StringLength(15)]
        public string CarNumber { get; set; }

        public Branch_Details Branch { get; set; }
    }
}
