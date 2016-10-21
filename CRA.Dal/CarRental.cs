using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Data;

namespace CarRental.Dal
{
   public class CarRentalContext : DbContext
    {
        public virtual DbSet<Branch_Details> Branches { get; set; }

        public virtual DbSet<Car_Details> Cars { get; set; }

        public virtual DbSet<Client_Details> Clients { get; set; }

        public virtual DbSet<Deal_Details> Deals { get; set; }

        public virtual DbSet<Model_Details> Models { get; set; }


    }
}
