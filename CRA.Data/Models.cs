using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data
{

    public enum Gear {Automatic, Manual, Robotic };

   public class Model
    {
        [Key]
        public int ModelID { get; set; }

      

        public int ManufacturerId { get; set; }

        public Manufacturers Manufacturer { get; set; }


        [StringLength(30)]
        public string NameofModel { get; set; }

        [Column(TypeName = "money")]
        public decimal DailyPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal LateReturnFine { get; set; }

        public Gear gear { get; set; }

    }
}
