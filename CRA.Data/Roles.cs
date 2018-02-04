using CarRental.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent.Data
{
   public class Roles
    {
        [Key]
        [ForeignKey("Users")]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
