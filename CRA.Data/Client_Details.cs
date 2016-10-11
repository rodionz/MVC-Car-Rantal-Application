using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.Data
{

    public enum Gender {Male, Female };

   public class Client_Details
    {
        public int ClientID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthData { get; set; }

        public Gender gender { get; set; }

        public string Email { get; set; }

        public int Password { get; set; }

        public byte[] Picture { get; set; }


    }
}
