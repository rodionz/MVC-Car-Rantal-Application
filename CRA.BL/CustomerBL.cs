using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Dal;
using CarRental.Data;
using System.Data.Entity;

namespace CarRental.BL
{
   public class CustomerBL
    {
     

       

        public Car GetCar(int carID)
        {
            using (var context = new CarRentalContext())
            {
                var car = (from c in context.Cars
                           where c.CarID == carID
                           select c).FirstOrDefault();

                return car;
            }
        }

        public Model GetModel(int modelID)
        {
            using (var context = new CarRentalContext())
            {
                var model = (from m in context.Models
                             where m.ModelID == modelID
                             select m).FirstOrDefault();
                return model;

            }
        }

        public int GetUserId (string name)
        {
            using (var context = new CarRentalContext())
            {
                var id = (from i in context.Users
                          where i.UserName == name
                          select i).FirstOrDefault().ID;

                return id;
            }
        }

        public void ConfirmDeal(Deal deal)
        {
            using (var context = new CarRentalContext())
            {
                context.Deals.Attach(deal);
                context.Entry(deal).State = EntityState.Added;
                context.SaveChanges();
            }

        } 

        public IEnumerable<Deal> GetPreviousDeals(int userId)
        {
            using (var context = new CarRentalContext())
            {
                var deals = (from d in context.Deals
                             where d.UserId == userId
                             select d).ToArray();

                return deals;
            }

        }

    }
}
