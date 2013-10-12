using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using hakaton.Models.Authentication;
using hakaton.Services;
using Repositories.EntityModel;

namespace hakaton.Models
{
    public class CustomAuthentication : IAuthentication
    {
        private const string cookieName = "__AUTH_COOKIE";


        public HttpContext HttpContext
        {
            get
            {
                return HttpContext.Current;
            }
            set
            {
                HttpContext.Current = value;
            }
        }

        #region IAuthentication Members
        
        public User Login(string userName, string password, bool rememberMe)
        {
            User retUser = UserService.Authorize(userName, password);
            if (retUser != null)
            {
                CreateCookie(userName, rememberMe);
            }
            return retUser;
        }

        public void Login(string userName, bool rememberMe)
        {
            CreateCookie(userName, rememberMe);
        }

        private void CreateCookie(string userName, bool isPersistent = false)
        {
            var ticket = new FormsAuthenticationTicket(
                1,
                userName,
                DateTime.Now,
                DateTime.Now.Add(FormsAuthentication.Timeout),
                isPersistent,
                string.Empty,
                FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket. 
            var encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie. 
            var AuthCookie = new HttpCookie(cookieName)
                             {
                                 Value = encTicket,
                                 Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
                             };
            HttpContext.Response.Cookies.Set(AuthCookie);
        }

        public void LogOut()
        {
            var httpCookie = HttpContext.Response.Cookies[cookieName];
            if (httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }
        }
        
        private UserProvider _currentUser;

        public UserProvider CurrentUser
        {
            get
            {
                if (_currentUser == null)
                {
                    try
                    {
                        HttpCookie authCookie =
                            HttpContext.Request.Cookies.Get(cookieName);
                        if (authCookie != null &&
                            !string.IsNullOrEmpty(authCookie.Value))
                        {
                            var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                            _currentUser = new UserProvider(ticket.Name);
                        }
                        else
                        {
                            _currentUser = new UserProvider(null);
                        }
                    }
                    catch (Exception ex)
                    {
                        //logger.Error("Failed authentication: " + ex.Message);
                        _currentUser = new UserProvider(null);
                    }
                }
                return _currentUser;
            }
        }

        #endregion
    }
}