using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.Data
{

    public enum Gender {Male, Female };

   public class Client_Details
    {
        [Key]
        public int ClientID { get; set; }

        [StringLength(15)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(15)]
        [Required]
        public string LastName { get; set; }

        public DateTime? BirthData { get; set; }

        [Required]
        public Gender gender { get; set; }


        [StringLength(30)]
        [Required]
        public string Email { get; set; }

        [Required]
        public int Password { get; set; }


        [Column(TypeName = "image")]
        public byte?[] Picture { get; set; }


    }
}
