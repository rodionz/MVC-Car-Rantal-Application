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

        [Required]
        public DateTime? Start { get; set; }

        [Required]
        public DateTime? SupposedReturn { get; set; }

        public DateTime? Realreturn { get; set; }

        [Required]
        public int? UserId { get; set; }
      
        public User User { get; set; }

        [Required]
        public int? CarID { get; set; }

        public virtual Car Car { get; set; }


    }
}
