using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using hakaton.Models.Authentication;
using Repositories.EntityModel;

namespace hakaton.Models
{
    public interface IAuthentication
    {
        HttpContext HttpContext { get; set; }

        User Login(string login, string password, bool rememberMe);

        void Login(string login, bool rememberMe);

        void LogOut();

        UserProvider CurrentUser { get; }

    }
}