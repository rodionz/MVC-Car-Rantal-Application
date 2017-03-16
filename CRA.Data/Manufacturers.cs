using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data
{
   public class Manufacturers
    {
        public int ID { get; set; }

        [Required]
        public string Manufacturer { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}
