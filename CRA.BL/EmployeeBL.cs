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
  public  class EmployeeBL
    {

       
        public IEnumerable<Deal> GetAllDeals()
        {
            IEnumerable<Deal> alldeals;

            using (var context = new CarRentalContext())
            {
                alldeals = (from d in context.Deals
                            select d).ToArray();

            }

            return alldeals;
        }

        public IEnumerable<Car> GettAllCars()
        {
            IEnumerable<Car> allcars;

            using (var context = new CarRentalContext())
            {
                allcars = (from c in context.Cars
                           select c).ToArray();
            }

            return allcars;
        }



        public IEnumerable<Model> GettAllModels()
        {
            IEnumerable<Model> allModels;

            using (var context = new CarRentalContext())
            {
                allModels = (from m in context.Models
                           select m).ToArray();
            }

            return allModels;
        }








        public Deal ReservationSearch(string carNum)
        {
            Deal dd;

            using (var context = new CarRentalContext())
            {
                dd = (from d in context.Deals.Include(w => w.Car)                      
                      where d.Car.CarNumber == carNum
                      select d).SingleOrDefault();

            }
            return dd;
        }

        public void ReservationClosing(int dealid)
        {

            Deal dealToClose;

            using (var context = new CarRentalContext())
            {
                dealToClose = (from d in context.Deals
                               where d.ID == dealid
                               select d).FirstOrDefault();
                               
            }

            using (var context = new CarRentalContext())
            {
                context.Deals.Attach(dealToClose);
                context.Entry(dealToClose).State = EntityState.Modified;
                context.SaveChanges();



            }


        }


    }
}
