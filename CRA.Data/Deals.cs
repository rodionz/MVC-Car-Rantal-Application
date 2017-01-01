using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data
{
   public class Deal
    {
        [Key]
        public int ID { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? SupposedReturn { get; set; }

        public DateTime? RealReturn { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }

        public int? CarID { get; set; }

        public virtual Car Car { get; set; }


    }
}
