﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.Data
{

    public enum Gear {Automatic, Manual };

   public class Model_Details
    {
        public int ModelID { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public decimal DailyPrice { get; set; }

        public decimal LateReturnFine { get; set; }

        public Gear gear { get; set; }

    }
}
