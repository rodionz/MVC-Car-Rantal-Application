﻿using CarRent.Data;
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
        public int ClientID { get; set; }

       

        [Required]
        [StringLength(15)]      
        public string FirstName { get; set; }


        [Required]
        [StringLength(15)]      
        public string LastName { get; set; }


       
        public string UserName { get; set; }

        public DateTime? BirthData { get; set; }

        [Required]
        public Gender gender { get; set; }

        [Required]
        [StringLength(30)]      
        public string Email { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }


        [Column(TypeName = "image")]
        public byte?[] Picture { get; set; }


        public ICollection<Roles> Roles { get; set; }

    }
}