using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hakaton.Models;
using hakaton.Models.Authentication;
using hakaton.Services;
using Repositories.Model;

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
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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

        #endregion
    }
}
