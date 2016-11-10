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
   public class ManagerBL
    {

      
        public void AddModel(Model model)

        {
            using (var context = new CarRentalContext())
            {
                context.Models.Attach(model);
                context.Entry(model).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void UpdateModel(Model model)
        {
            using (var context = new CarRentalContext())
            {
                context.Models.Attach(model);
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteModel(Model model)
        {
            using (var context = new CarRentalContext())
            {
                context.Models.Attach(model);
                context.Entry(model).State = EntityState.Deleted;
                context.SaveChanges();
            }

        }


        public void AddCar(Car car)
        {
            using (var context = new CarRentalContext())
            {
                context.Cars.Attach(car);
                context.Entry(car).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void UpdateCar(Car car)
        {
            using (var context = new CarRentalContext())
            {
                context.Cars.Attach(car);
                context.Entry(car).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCar(Car car)
        {
            using (var context = new CarRentalContext())
            {
                context.Cars.Attach(car);
                context.Entry(car).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }






        public void AddClient(User client)
        {
            using (var context = new CarRentalContext())
            {
                context.Users.Attach(client);
                context.Entry(client).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void UpdateClient(User client)
        {
            using (var context = new CarRentalContext())
            {
                context.Users.Attach(client);
                context.Entry(client).State = EntityState.Modified; 
                context.SaveChanges();
            }
        }

        public void DeleteClient(User client)
        {
            using (var context = new CarRentalContext())
            {
                context.Users.Attach(client);
                context.Entry(client).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }





        public void AddReservation(Deal deal)
        {
            using (var context = new CarRentalContext())
            {
                context.Deals.Attach(deal);
                context.Entry(deal).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void UpdateReservation(Deal deal)
        {
            using (var context = new CarRentalContext())
            {
                context.Deals.Attach(deal);
                context.Entry(deal).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        public void DeleteReservation(Deal deal)
        {
            using (var context = new CarRentalContext())
            {
                context.Deals.Attach(deal);
                context.Entry(deal).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

    }
}
