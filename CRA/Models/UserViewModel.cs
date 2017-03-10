using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CarRental.Data;

namespace CarRental.MVC.Models
{


    public enum Roles { Manager, Employee, Customer };
  

    public class UserViewModel
    {
       

        public int ID { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2,ErrorMessage = "Firstname must contain at least 2 chatracters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Lastname must contain at least 2 chatracters")]
        public string LastName { get; set; }


        [Required]
        [Display(Name = "User's Role")]
        [EnumDataType(typeof(Roles), ErrorMessage = "Please enter a valid Role of the user")]
        public Roles role { get; set; }

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
        [RegularExpression(@"^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2})$|^(([0-2]\d|[3][0-1])\/([0]\d|[1][0-2])\/[2][0]\d{2}\s([0-1]\d|[2][0-3])\:[0-5]\d\:[0-5]\d)$", ErrorMessage = "Not A DateTime")]
        public DateTime? BirthData { get; set; }

        [Required]
        [Display(Name = "Gender")]
        [EnumDataType(typeof(Gender), ErrorMessage = "Please select a valid gender")]
        public Gender? gender { get; set; }





        [Required]
        [EmailAddress]       
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6,ErrorMessage = "Username must contain at least 6 chatracters")]        
        public string UserName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Password must contain  at least 6 characters")]
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
                Picture = Picture,
                


            };
        }


        public UserViewModel() { }


        public UserViewModel(User domainClieentDetails)
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