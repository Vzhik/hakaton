using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hakaton.Models;
using hakaton.Models.Authentication;
using hakaton.Services;
using Repositories.EntityModel;
using System.Web.Script.Serialization;

namespace hakaton.Controllers
{
    public class HomeController : Controller
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

        #region Actions

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult FAQ()
        {
            var retId = Guid.Empty;
            if (User.Identity.IsAuthenticated)
            {
                retId = CurrentUser.Id;
            }
            return View(retId);
        }

        [Authorize]
        public ActionResult Chart()
        {
            var js = new JavaScriptSerializer();

            ViewBag.JSON = js.Serialize(ErrorService.GetChartPointsBase(CurrentUser.Id));
            return View("Chart");
        }

        #endregion
    }
}
