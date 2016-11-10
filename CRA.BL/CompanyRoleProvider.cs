using CarRent.Data;
using CarRental.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace CarRent.BL
{
    class CompanyRoleProvider : RoleProvider
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
                    var _role = context.CompanyRoles.Where(r => r.RoleName == role).FirstOrDefault();


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
                context.CompanyRoles.Add(new CompanyRoles() {RoleName = roleName });
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
    }
}
