using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repositories.Model;

namespace hakaton.Models.Authentication
{
    public interface IUserProvider
    {
        User User { get; set; }
    } 
}