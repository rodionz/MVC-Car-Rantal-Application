using CarRental.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.Data
{
    class Roles
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public ICollection<User> users { get; set; }


    }
}
