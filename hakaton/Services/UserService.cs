using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hakaton.Models;
using hakaton.Enums;
using Repositories.Repositories;
using Repositories.Model;
using Repositories.Enums;
using System.Security.Cryptography;
using System.Text;

namespace hakaton.Services
{
    public static class UserService
    {
        public static User Authorize(string login, string password)
        {
            UserRepository repo = new UserRepository();
            var user = repo.GetUserByEmail(login);
            if (user == null) return null;
            if (ToGuid(password) != user.Password) return null;
            return user;
        }

        public static User GetUserByEmail(string email)
        {
            UserRepository repo = new UserRepository();
            return repo.GetUserByEmail(email);
        }

        public static CreateUserEnum CreateUser(string name, string password)
        {
            UserRepository repo = new UserRepository();
            var user = repo.GetUserByEmail(name);
            if (user != null) return CreateUserEnum.EmailExist;
            try
            {
                if (!repo.CreateUser(name, ToGuid(password))) return CreateUserEnum.Failed;
                
            }
            catch (Exception)
            {
                return CreateUserEnum.Failed;
            }
            return CreateUserEnum.Succeeded;
        }

        private static Guid ToGuid(this string str)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(str);
            var cryptoServiceProvider = new SHA1Managed();
            byte[] byteHash = cryptoServiceProvider.ComputeHash(bytes);
            return new Guid(byteHash.Take(16).ToArray());
        }

    }
}