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

        public bool CreateUser(string name, Guid password)
        {
            try
            {
                _context.Users.AddObject(new User() {Email = name, Password = password, Id = Guid.NewGuid()});
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
