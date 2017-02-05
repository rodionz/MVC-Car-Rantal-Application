using CarRental.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRental.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(12)]
        public string Username { get; set; }

        [Required]
        [StringLength(12)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$", ErrorMessage = "Password must have 6-12 characters at least 1 Alphabet and 1 Number")]
        public string Password { get; set; }


        public User converttoUser(LoginViewModel lvm)
        {
            return new User
            {
                UserName = Username,

                Password = Password

            };
        }

    }
}