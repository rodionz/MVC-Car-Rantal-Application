using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRA.Dal;
using CRA.Data;
using System.Data.Entity;

namespace CRA.BL
{
    class CustomerBL
    {
        public IEnumerable<Car_Details> GetAllCars()
        {
            IEnumerable<Car_Details> allCars;

            using (var context = new CRA_Context())
            {
                allCars = from car in context.Cars
                          where car.ProperState == true
                          orderby car.Model descending
                          select car;
            }

            return allCars;
        }

        public IEnumerable<Car_Details> SearchByGear (Gear g)
        {
            IEnumerable<Car_Details> allCars;

            using (var context = new CRA_Context())
            {
                allCars = from car in context.Cars
                          where car.ProperState == true
                          where car.Model.gear == g
                          orderby car.Model descending
                          select car;
            }

            return allCars;

        }


        public IEnumerable<Car_Details > SearchByManufacrurer (string manufac)
        {
            IEnumerable<Car_Details> allCars;

            using (var context = new CRA_Context())
            {
                allCars = from car in context.Cars
                          where car.ProperState == true
                          where car.Model.Manufacturer == manufac
                          orderby car.Model descending
                          select car;
            }

            return allCars;


        }

        public void Confirmation(Deal_Details dd)
        {
            using (var context = new CRA_Context())
            {
                context.Deals.Attach(dd);
                context.Entry(dd).State = EntityState.Added;
                context.SaveChanges();

            }
        }

    }
}
