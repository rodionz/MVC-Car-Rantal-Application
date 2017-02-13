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
     

        //public IEnumerable<Car> SearchByGear (Gear g)
        //{
        //    IEnumerable<Car> allCars;

        //    using (var context = new CarRentalContext())
        //    {
        //        allCars = from car in context.Cars.Include(c => c.Model)
        //                  where car.ProperState == true
        //                  where car.Model.gear == g
        //                  orderby car.Model descending
        //                  select car;
        //    }

        //    return allCars;

        //}


        //public IEnumerable<Car > SearchByManufacrurer (int manufac)
        //{
        //    IEnumerable<Car> allCars;

        //    using (var context = new Dal.CarRentalContext())
        //    {
        //        allCars = from car in context.Cars.Include(c => c.Model)
        //                  where car.ProperState == true
        //                  where car.Model.ManufId == manufac
        //                  orderby car.Model descending
        //                  select car;
        //    }

        //    return allCars;


        //}


        //public IEnumerable<Car> SearchbyModel(string carModel)
        //{
        //    IEnumerable<Car> allCars;

        //    using (var context = new Dal.CarRentalContext())
        //    {
        //        allCars = from car in context.Cars.Include(c => c.Model)
        //                  where car.ProperState == true
        //                  where car.Model.NameofModel == carModel
        //                  orderby car.Model descending
        //                  select car;
        //    }

        //        return allCars;

        //}



        //public IEnumerable<Car> SearchbyFreeText(string text)
        //{

        //    if (!string.IsNullOrWhiteSpace(text))
        //    {
        //        IEnumerable<Car> allCars;

        //        using (var context = new Dal.CarRentalContext())
        //        {
        //            allCars = from car in context.Cars
        //                      .Include(c => c.Model)
        //                      .Include(p => p.Branch)
        //                      where car.Model.NameofModel.ToLower().Contains(text.ToLower()) ||
        //                      //car.Model.Manufacturer.ToLower().Contains(text.ToLower()) ||
        //                      car.Model.gear.ToString().ToLower().Contains(text.ToLower()) ||
        //                      car.Model.DailyPrice.ToString().Contains(text.ToLower()) ||
        //                      car.Branch.City.ToLower().Contains(text.ToLower()) ||
        //                      car.Branch.BranchName.ToLower().Contains(text.ToLower()) ||
        //                      car.Branch.District.ToLower().Contains(text.ToLower())
        //                      select car;



        //        }


        //        return allCars;
        //    }
        //    else
        //        return null;
           
        //}

        //public IEnumerable<Car> SearchbyDateRange (DateTime start, DateTime end)
        //{


        //    return null;
        //}

        //public void Confirmation(Deal dd)
        //{
        //    using (var context = new Dal.CarRentalContext())
        //    {
        //        context.Deals.Attach(dd);
        //        context.Entry(dd).State = EntityState.Added;
        //        context.SaveChanges();

        //    }
        //}

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

    }
}
