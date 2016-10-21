using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CRA.Data;

namespace CRA.Models
{
    public class ClientViewModel
    {
       
        public int ClientID { get; set; }
        
        public string FirstName { get; set; }
      
        public string LastName { get; set; }

        public DateTime? BirthData { get; set; }

        public Gender gender { get; set; }

       
        public string Email { get; set; }

      
        public int Password { get; set; }


        public byte?[] Picture { get; set; }


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