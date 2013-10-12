using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repositories.EntityModel;

namespace hakaton.Models.Authentication
{
    public interface IUserProvider
    {
        User User { get; set; }
    } 
}