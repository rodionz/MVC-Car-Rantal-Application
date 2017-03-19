using CarRent.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Data
{

    public enum Gender {Male, Female };

   public class User
    {
        [Key]
        [ForeignKey("Roles")]
        [Display(Name = "User's ID")]
        public int ID
        { get; set; }

       

        [Required]          
        public string FirstName { get; set; }


        [Required]       
        public string LastName { get; set; }

        [Required]       
        public string UserName { get; set; }

        public DateTime? BirthData { get; set; }

        [Required]
        public Gender gender { get; set; }

        [Required]                  
        public string Email { get; set; }

        [Required]       
        public string Password { get; set; }


       
        public byte[] Picture { get; set; }


        public ICollection<Roles> Roles { get; set; }

    }
}
