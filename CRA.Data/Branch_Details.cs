using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.Data
{
  public  class Branch_Details
    {
        [Key]
        public int BranchID { get; set; }

        [StringLength(15)]
        public string BranchName { get; set; }

        [StringLength(15)]
        public string City { get; set; }

        [StringLength(15)]
        public string District { get; set; }

        //Location

    }
}
