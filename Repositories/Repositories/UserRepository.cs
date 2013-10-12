using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Repositories.Model;
using System.Data.Entity;
using Repositories.Enums;

namespace Repositories.Repositories
{
    public class UserRepository
    {
        JSInquisitorEntities _context = new JSInquisitorEntities();
        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(p => p.Email == email);
        }

        public CreateUserEnum CreateUser(string name, string password)
        {
            try
            {
                if(GetUserByEmail(name) != null) return CreateUserEnum.EmailExist;
                _context.Users.AddObject(new User() {Email = name, Password = password, Id = Guid.NewGuid()});
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return CreateUserEnum.Failed;
            }
            return CreateUserEnum.Succeeded;
        }
    }
}
