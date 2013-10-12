using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repositories.Models;
using Repositories.Repositories;

namespace hakaton.Services
{
    public static class ErrorService
    {
        public static void SaveError(ErrorModel error)
        {
            var repo = new ErrorsRepository();
            repo.AddError(error);
        }
    }
}