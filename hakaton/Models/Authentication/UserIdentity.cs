using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using hakaton.Services;
using Repositories.EntityModel;

namespace hakaton.Models.Authentication
{
    public class UserIndentity : IIdentity, IUserProvider
    {
        public User User { get; set; }

        public string AuthenticationType
        {
            get
            {
                return typeof(User).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.Email;
                }
                //иначе аноним 
                return "anonym";
            }
        }

        public void Init(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                User = UserService.GetUserByEmail(email);
            }
        }

        public IAuthentication Auth { get; set; }

        public User CurrentUser
        {
            get
            {
                return ((IUserProvider)Auth.CurrentUser.Identity).User;
            }
        } 
    } 
}