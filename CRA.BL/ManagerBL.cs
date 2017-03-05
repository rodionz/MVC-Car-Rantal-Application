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

        public void DeleteModel(int modelID)
        {
            using (var context = new CarRentalContext())
            {
                var model = (from m in context.Models
                             where m.ModelID == modelID
                             select m).FirstOrDefault();

                context.Models.Attach(model);
                context.Entry(model).State = EntityState.Deleted;
                context.SaveChanges();
            }

        }






        public void AddManufactorer(Manufacturers man)

        {
            using (var context = new CarRentalContext())
            {
                context.Manufacturer.Attach(man);
                context.Entry(man).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void UpdateManufactorer(Manufacturers man)
        {
            using (var context = new CarRentalContext())
            {
                context.Manufacturer.Attach(man);
                context.Entry(man).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteManufactorer(int manlID)
        {
            using (var context = new CarRentalContext())
            {
                var manufactorer = (from m in context.Manufacturer
                             where m.ID == manlID
                                    select m).FirstOrDefault();

                context.Manufacturer.Attach(manufactorer);
                context.Entry(manufactorer).State = EntityState.Deleted;
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

        public void DeleteCar(int carId)
        {
            using (var context = new CarRentalContext())
            {

                var car = (from c in context.Cars
                                    where c.CarID == carId
                                    select c).FirstOrDefault();


                context.Cars.Attach(car);
                context.Entry(car).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }




        public IEnumerable<User> GetAllUsers ()
        {
            using (var context = new CarRentalContext())
            {
                var allusers = (from u in context.Users
                                select u).ToArray();

                return allusers;
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

        public void DeleteClient(int clientID)
        {
            using (var context = new CarRentalContext())
            {

                var user = (from m in context.Users
                                    where m.ID == clientID
                                    select m).FirstOrDefault();


                context.Users.Attach(user);
                context.Entry(user).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }






        public IEnumerable<Deal> GetAllDeals()
        {
            using (var context = new CarRentalContext())
            {
                var alldeals = (from u in context.Deals
                                select u).ToArray();

                return alldeals;
            }

        }

        public void AddDeal(Deal deal)
        {
            using (var context = new CarRentalContext())
            {
                context.Deals.Attach(deal);
                context.Entry(deal).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void UpdateDeal(Deal deal)
        {
            using (var context = new CarRentalContext())
            {
                context.Deals.Attach(deal);
                context.Entry(deal).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        public void DeleteDeal(int dealId)
        {
            using (var context = new CarRentalContext())
            {

                var deal = (from m in context.Deals
                                    where m.ID == dealId
                                    select m).FirstOrDefault();

                context.Deals.Attach(deal);
                context.Entry(deal).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

    }
}
