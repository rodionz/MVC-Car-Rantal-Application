﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CarRental.Data;

namespace CarRental.MVC.Models
{

  

    public class CustomerViewModel
    {
       

        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Display (Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }          
        }

        [Required]
        [Display(Name = "Birth Data")]
        [RegularExpression(@"/^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/",ErrorMessage = "Please enter the date in MM/DD/YYYY")]
        public DateTime? BirthData { get; set; }

        [Required]
        [Display(Name = "Gender")]
        [RegularExpression("/^ Male$|^ Female$/", ErrorMessage = "Gender Invalid")]
        public Gender? gender { get; set; }





        
        [EmailAddress]       
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Minimum 8 characters at least 1 Alphabet and 1 Number")]
        public string Password { get; set; }


        public byte?[] Picture { get; set; }




       


        public   User toBaseClient_Details()
        {
            return new User
            {
                ID = ID,
                FirstName = FirstName,
                LastName = LastName,
                BirthData = BirthData,
                gender = gender.Value,
                Email = Email,
                UserName = UserName,
                Password = Password,
                Picture = Picture

            };
        }


        public CustomerViewModel() { }


        public CustomerViewModel(User domainClieentDetails)
        {
            

            this.ID = domainClieentDetails.ID;

            this.FirstName = domainClieentDetails.FirstName;

            this.LastName = domainClieentDetails.LastName;

            this.BirthData = domainClieentDetails.BirthData;

            this.UserName = domainClieentDetails.UserName;

            this.gender = domainClieentDetails.gender;

            this.Email = domainClieentDetails.Email;

            this.Password = domainClieentDetails.Password;

            this.Picture = domainClieentDetails.Picture;

        }

    }
}