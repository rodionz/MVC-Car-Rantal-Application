using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.Data
{
   public class Deal_Details
    {
        [Key]
        public int ID { get; set; }

        public DateTime Start { get; set; }

        public DateTime SupposedReturn { get; set; }

        public DateTime RealReturn { get; set; }

        public Client_Details Client { get; set; }

        public Car_Details Car { get; set; }


    }
}
