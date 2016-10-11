using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRA.Data;

namespace CRA.Dal
{
   public class CRA_Context : DbContext
    {
        public virtual DbSet<Branch_Details> Branches { get; set; }

        public virtual DbSet<Car_Details> Cars { get; set; }

        public virtual DbSet<Client_Details> Clients { get; set; }

        public virtual DbSet<Deal_Details> Deals { get; set; }

        public virtual DbSet<Model_Details> Models { get; set; }


    }
}
