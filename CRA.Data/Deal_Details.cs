using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.Data
{
   public class Deal_Details
    {
        public DateTime Start { get; set; }

        public DateTime SupposedReturn { get; set; }

        public DateTime RealReturn { get; set; }

        public Client_Details Client { get; set; }

        public Car_Details Car { get; set; }


    }
}
