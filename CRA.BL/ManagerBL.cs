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
   public class ManagerBL
    {

        public void AddModel(Model_Details model)

        {
            using (var context = new CRA_Context())
            {
                context.Models.Attach(model);
                context.Entry(model).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void UpdateModel(Model_Details model)
        {
            using (var context = new CRA_Context())
            {
                context.Models.Attach(model);
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteModel(Model_Details model)
        {
            using (var context = new CRA_Context())
            {
                context.Models.Attach(model);
                context.Entry(model).State = EntityState.Deleted;
                context.SaveChanges();
            }

        }


        public void AddCar(Car_Details car)
        {
            using (var context = new CRA_Context())
            {
                context.Cars.Attach(car);
                context.Entry(car).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void UpdateCar(Car_Details car)
        {
            using (var context = new CRA_Context())
            {
                context.Cars.Attach(car);
                context.Entry(car).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCar(Car_Details car)
        {
            using (var context = new CRA_Context())
            {
                context.Cars.Attach(car);
                context.Entry(car).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }






        public void AddClient(Client_Details client)
        {
            using (var context = new CRA_Context())
            {
                context.Clients.Attach(client);
                context.Entry(client).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void UpdateClient(Client_Details client)
        {
            using (var context = new CRA_Context())
            {
                context.Clients.Attach(client);
                context.Entry(client).State = EntityState.Modified; 
                context.SaveChanges();
            }
        }

        public void DeleteClient(Client_Details client)
        {
            using (var context = new CRA_Context())
            {
                context.Clients.Attach(client);
                context.Entry(client).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }





        public void AddReservation(Deal_Details deal)
        {
            using (var context = new CRA_Context())
            {
                context.Deals.Attach(deal);
                context.Entry(deal).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void UpdateReservation(Deal_Details deal)
        {
            using (var context = new CRA_Context())
            {
                context.Deals.Attach(deal);
                context.Entry(deal).State = EntityState.Modified;
                context.SaveChanges();
            }
        }


        public void DeleteReservation(Deal_Details deal)
        {
            using (var context = new CRA_Context())
            {
                context.Deals.Attach(deal);
                context.Entry(deal).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

    }
}
