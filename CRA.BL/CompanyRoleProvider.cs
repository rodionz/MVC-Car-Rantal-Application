using CarRent.Data;
using CarRental.Dal;
using CarRental.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Data.Entity;

namespace CarRent.BL
{
  public  class CompanyRoleProvider : RoleProvider
    {


        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }



        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            using (var context = new CarRentalContext())
            {
                foreach(string role in roleNames)
                {
                    var _role = context.CompanyRoles.Include(r => r.Users).Where(r => r.RoleName == role).FirstOrDefault();


                    foreach(string user in usernames)
                    {
                        var _user = context.Users.Where(u => u.UserName == user).FirstOrDefault();

                        _role.Users.Add(_user);
                    }
                    
                }

                context.SaveChanges();

            }
        }

        public override void CreateRole(string roleName)
        {
            using (var context = new CarRentalContext())
            {
                context.CompanyRoles.Add(new Data.Roles() { RoleName = roleName });
                context.SaveChanges();

            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            using (var context = new CarRentalContext())
            {
                var roletoRemove = context.CompanyRoles.FirstOrDefault(r => r.RoleName == roleName);
                context.CompanyRoles.Remove(roletoRemove);
                context.SaveChanges();
            }
            return true;
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {

            string[] matchingusers;

            using (var context = new CarRentalContext())
            {
                matchingusers = context.CompanyRoles.Where(r => r.RoleName == roleName)
                    .FirstOrDefault()
                    .Users.Select(u => u.UserName).ToArray();
                
            }

            return matchingusers;
        }

        public override string[] GetAllRoles()
        {
            using (var context = new CarRentalContext())
            {

                var allroles = context.CompanyRoles.Select(r => r.RoleName);

                return allroles.ToArray();
            }
        }

     

        public override string[] GetRolesForUser(string username)
        {

            

            using (var context = new CarRentalContext())
            {
                var roles = (from r in context.Users
                             where r.UserName == username
                             select r.Roles.Select(u => u.RoleName)).FirstOrDefault();


                string[] result = roles.ToArray();

              

                return result;

            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            using (var context = new CarRentalContext())
            {
                var role = context.CompanyRoles.Select(r => r.RoleName).FirstOrDefault();

                if (role == null)
                {
                    return false;
                }

                else
                    return true;

            }
        }

        public  bool UserExists (string username)
        {
            using (var context = new CarRentalContext())
            {
                var user = (from u in context.Users
                            where u.UserName == username
                            select u).FirstOrDefault();

                if (user == null)
                {
                    return false;
                }

                else
                    return true;

            }

        }

        public bool ModelExists(string modelName) {

            using (var context = new CarRentalContext()) {

                var model = (from m in context.Models
                             where m.NameofModel == modelName
                             select m).FirstOrDefault();

                if (model == null)
                {
                    return false;
                }

                else
                    return true;
            }

        }


        public bool ManufactorerExists(string manName) {

            using (var context = new CarRentalContext()) {

                var manuf = (from m in context.Manufacturer
                             where m.Manufacturer == manName
                             select m).FirstOrDefault();

                if (manuf == null)
                {
                    return false;
                }

                else
                    return true;

            }

        }


    }
}
