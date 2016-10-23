﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CarRental.Data;

namespace CarRental.MVC.Models
{
    public class ClientViewModel
    {
       
        public int ClientID { get; set; }
        
        public string FirstName { get; set; }
      
        public string LastName { get; set; }


        [Display (Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }



        public DateTime? BirthData { get; set; }

        public Gender gender { get; set; }

       [RegularExpression(@"/[a-z0-9._%+-]+@[a-z0-9.-]+.[a-z]{2,4}/", ErrorMessage ="Email is invalid")]
        public string Email { get; set; }

      [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Minimum 8 characters at least 1 Alphabet and 1 Number")]
        public string Password { get; set; }


        public byte?[] Picture { get; set; }




       


        public static implicit operator Client_Details(ClientViewModel vm)
        {
            return new Client_Details
            {
                ClientID = vm.ClientID,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                BirthData = vm.BirthData,
                gender = vm.gender,
                Email = vm.Email,
                Password = vm.Password,
                Picture = vm.Picture

            };
        }



        public ClientViewModel(Client_Details domainClieentDetails)
        {

            this.ClientID = domainClieentDetails.ClientID;

            this.FirstName = domainClieentDetails.FirstName;

            this.LastName = domainClieentDetails.LastName;

            this.BirthData = domainClieentDetails.BirthData;

            this.gender = domainClieentDetails.gender;

            this.Email = domainClieentDetails.Email;

            this.Password = domainClieentDetails.Password;

            this.Picture = domainClieentDetails.Picture;

        }

    }
}