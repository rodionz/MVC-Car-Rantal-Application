using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.Data
{
  public  class Car_Details
    {
        public  int CarID { get; set; }

        public Model_Details Model { get; set; }

        public double Mileage { get; set; }

        public byte[] Picture { get; set; }

        public bool ProperState { get; set; }

        public string CarNumber { get; set; }

        public Branch_Details Branch { get; set; }
    }
}
