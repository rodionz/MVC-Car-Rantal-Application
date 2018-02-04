using CarRental.Dal;
using CarRental.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CRA.BL
{
  public class GuestBL
    {

        public IEnumerable<Car> GetAllCarsinProperState()
        {
            IEnumerable<Car> allCars;

            using (var context = new CarRentalContext())
            {
                allCars = (from car in context.Cars
                           .Include(c => c.Model.Manufacturer)
                           where car.ProperState == true
                           orderby car.Model.NameofModel descending
                           select car).ToArray();
            }

            return allCars;
        }



        public byte[] GetImage(int id)
        {
            using (var context = new CarRentalContext())
            {
                var img = (from c in context.Cars
                           where c.ModelID == id
                           select c.Picture).FirstOrDefault();
                return img;
            }
           
        }

        public IEnumerable<Model> GettAllModels()
        {
            using (var context = new CarRentalContext())
            {
                var all = (from m in context.Models
                           select m).ToArray();

                return all;               
            }
        }

        public IEnumerable<Manufacturers> GettAllManufacturers()
        {
            using (var context = new CarRentalContext())
            {
                var all = (from m in context.Manufacturer
                           select m).ToArray();
                return all;
            }
        }


        public IEnumerable<Branch> GetAllBranches()
        {
            using (var context = new CarRentalContext())
            {
                var all = (from m in context.Branches
                           select m).ToArray();
                return all;

            }
        }



        public bool ClientExist(User user)
        {
            using (var context = new CarRentalContext())
            {
                var result = context.Users.FirstOrDefault(u => u.UserName == user.UserName);
                if (result == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }




        public bool PasswordMatches(User user)
        {
            using (var context = new CarRentalContext())
            {
                var usertoTest = context.Users.FirstOrDefault(u => u.UserName == user.UserName);

                if (usertoTest.Password != user.Password)
                {
                    return false;
                }

                else
                {
                    return true;
                }
            }
        }
    }
}
