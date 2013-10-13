using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hakaton.Services;
using Repositories.EntityModel;
using hakaton.Models;
using hakaton.Models.Authentication;
using System.Web.Script.Serialization;

namespace hakaton.Controllers
{
    public class ErrorController : Controller
    {

        private IAuthentication _auth;

        public IAuthentication Auth
        {
            get
            {
                if (_auth == null)
                {
                    _auth = new CustomAuthentication();
                }
                return _auth;
            }
        }

        public User CurrentUser
        {
            get
            {
                return ((UserIndentity)Auth.CurrentUser.Identity).User;
            }
        }
        //
        // GET: /Error/
        [Authorize]
        [HttpPost]
        public ActionResult GetErrorsTable(int period)
        {
            var errors = ErrorService.GetErrorsBase(CurrentUser.Id, period);
            return PartialView(errors);
        }
        
        [Authorize]
        public ActionResult Error(Guid id)
        {
            var js = new JavaScriptSerializer();
            ViewBag.Id = id.ToString();
            ViewBag.JSON = js.Serialize(ErrorService.GetChartPoints(CurrentUser.Id, id));
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult GetErrorTable(Guid errorId, int period)
        {
            var errors = ErrorService.GetErrorsTable(errorId, period);
            return PartialView(errors);
        }

        [Authorize]
        public ActionResult Details(Guid id)
        {
            ViewBag.BackToList = ErrorService.GetErrorBaseIdByErrorId(id).ToString();
            //268b1442-eb74-42a6-925f-86fa3532bc83
            return View(ErrorService.GetErrorDetails(id));
        }

    }
}
