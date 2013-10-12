using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hakaton.Services;

namespace hakaton.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/
        [Authorize]
        [HttpPost]
        public ActionResult GetErrorsTable(Guid userId, int period)
        {
            var errors = ErrorService.GetErrors(userId, period);
            return PartialView(errors);
        }

    }
}
