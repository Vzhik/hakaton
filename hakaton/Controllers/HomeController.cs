using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hakaton.Models;
using hakaton.Models.Authentication;
using hakaton.Services;
using Repositories.EntityModel;

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
            ViewBag.JSON = "[{\"id\":\"Error 1\",\"mass\":[23,10,56,15,12,45,36,66,32,41,56,23,32,11,22,34,40,40,23,10,10,20,30,45,12,0,0,32,41,10,11]},{\"id\":\"Error 2\",\"mass\":[12,21,34,43,45,45,12,21,11,20,30,40,55,34,50,10,20,30,60,45,12,21,0,0,0,11,0,0,11,0,21]},{\"id\":\"Error 3\",\"mass\":[10,20,30,40,11,23,45,56,56,56,56,65,10,20,30,70,11,45,34,23,32,32,23,12,45,55,56,65,78,90,0]}]";
            return View("Chart");
        }

        #endregion
    }
}
