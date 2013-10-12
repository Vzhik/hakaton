using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hakaton.Models;
using hakaton.Enums;
using Repositories.Repositories;
using Repositories.Model;

namespace hakaton.Services
{
    public static class UserService
    {
        public static User Authorize(string login, string password)
        {
            UserRepository repo = new UserRepository();
            var user = repo.GetUserByEmail(login);
            if (user == null) return null;
            if (password != user.Password) return null;
            return user;
        }

        public static User GetUserByEmail(string email)
        {
            UserRepository repo = new UserRepository();
            return repo.GetUserByEmail(email);
        }


    }
}