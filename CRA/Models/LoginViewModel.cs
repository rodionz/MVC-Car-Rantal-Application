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
        [StringLength(12 , MinimumLength = 3, ErrorMessage = "Username must have minimum 3-12 characters")]
        public string Username { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "Password must have 6-12 characters")]
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