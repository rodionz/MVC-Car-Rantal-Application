using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data;
using CarRent.Data;

namespace CarRental.Dal
{
   public class CarRentalContext : DbContext
    {
        public virtual DbSet<Branch> Branches { get; set; }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<User> Clients { get; set; }

        public virtual DbSet<Deal> Deals { get; set; }

        public virtual DbSet<Model> Models { get; set; }

        public virtual DbSet<Roles> Roles { get; set; }


    }
}
