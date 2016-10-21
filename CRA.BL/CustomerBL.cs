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
   public class CustomerBL
    {
        public IEnumerable<Car_Details> GetAllCars()
        {
            IEnumerable<Car_Details> allCars;

            using (var context = new CRA_Context())
            {
                allCars = (from car in context.Cars
                          where car.ProperState == true
                          orderby car.Model.Model descending
                          select car).ToArray();
            }

            return allCars;
        }

        public IEnumerable<Car_Details> SearchByGear (Gear g)
        {
            IEnumerable<Car_Details> allCars;

            using (var context = new CRA_Context())
            {
                allCars = from car in context.Cars.Include(c=>c.Model)
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
                allCars = from car in context.Cars.Include(c=>c.Model)
                          where car.ProperState == true
                          where car.Model.Manufacturer == manufac
                          orderby car.Model descending
                          select car;
            }

            return allCars;


        }

        public IEnumerable<Car_Details> SearchbyModel(string carModel)
        {
            IEnumerable<Car_Details> allCars;

            using (var context = new CRA_Context())
            {
                allCars = from car in context.Cars.Include(c=>c.Model)
                          where car.ProperState == true
                          where car.Model.Model == carModel
                          orderby car.Model descending
                          select car;
            }

                return allCars;

        }



        public IEnumerable<Car_Details> SearchbyFreeText(string text)
        {

            if (!string.IsNullOrWhiteSpace(text))
            {
                IEnumerable<Car_Details> allCars;

                using (var context = new CRA_Context())
                {
                    allCars = from car in context.Cars
                              .Include(c=>c.Model)
                              .Include(p=>p.Branch)
                              where car.Model.Model.ToLower().Contains(text.ToLower()) ||
                              car.Model.Manufacturer.ToLower().Contains(text.ToLower()) ||
                              car.Model.gear.ToString().ToLower().Contains(text.ToLower()) ||
                              car.Model.DailyPrice.ToString().Contains(text.ToLower()) ||
                              car.Branch.City.ToLower().Contains(text.ToLower()) ||
                              car.Branch.BranchName.ToLower().Contains(text.ToLower()) ||
                              car.Branch.District.ToLower().Contains(text.ToLower())
                              select car;



                }


                return allCars;
            }
            else
                return null;
           
        }

        public IEnumerable<Car_Details> SearchbyDateRange (DateTime start, DateTime end)
        {


            return null;
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
