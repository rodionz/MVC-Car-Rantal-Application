using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.Data
{

    public enum Gear {Automatic, Manual };

   public class Model_Details
    {
        [Key]
        public int ModelID { get; set; }

        [StringLength(30)]
        public string Manufacturer { get; set; }

        [StringLength(30)]
        public string Model { get; set; }

        [Column(TypeName = "money")]
        public decimal DailyPrice { get; set; }

        public decimal LateReturnFine { get; set; }

        public Gear gear { get; set; }

    }
}
