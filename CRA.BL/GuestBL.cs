using CarRental.Dal;
using CarRental.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRA.BL
{
  public class GuestBL
    {
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
    }
}
