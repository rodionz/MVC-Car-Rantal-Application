using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CarRental.Data;
using CarRental.Dal;

namespace CarRental.BL
{
    class EmployeeBL
    {
        public Deal_Details ReservationSearch(string carNum)
        {
            Deal_Details dd;

            using (var context = new Dal.CarRentalContext())
            {
                dd = (from d in context.Deals.Include(w => w.Car)                      
                      where d.Car.CarNumber == carNum
                      select d).SingleOrDefault();

            }
            return dd;
        }

        public void ReservationClosing(Deal_Details dd)
        {
            using (var context = new Dal.CarRentalContext())
            {
                context.Deals.Attach(dd);
                context.Entry(dd).State = EntityState.Modified;
                context.SaveChanges();



            }


        }


    }
}
