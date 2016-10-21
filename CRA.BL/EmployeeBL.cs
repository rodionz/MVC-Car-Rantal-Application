using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CRA.Data;
using CRA.Dal;

namespace CRA.BL
{
    class EmployeeBL
    {
        public Deal_Details ReservationSearch(string carNum)
        {
            Deal_Details dd;

            using (var context = new CRA_Context())
            {
                dd = (from d in context.Deals
                      where d.Car.CarNumber == carNum
                      select d).SingleOrDefault();

            }
            return dd;
        }

        public void ReservationClosing(Deal_Details dd)
        {
            using (var context = new CRA_Context())
            {
                context.Deals.Attach(dd);
                context.Entry(dd).State = EntityState.Modified;
                context.SaveChanges();



            }


        }


    }
}
