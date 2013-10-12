using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories.Model;
using hakaton.Models;
using hakaton.Models.Authentication;

namespace hakaton.Controllers
{
    public class AccountController : Controller
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


        #region constructors

        public AccountController()
        {
        }

        #endregion constructrs

        #region actions

        public PartialViewResult LogOn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("LogOn");
        }

        [HttpPost]
        public ActionResult LogOn(hakaton.Models.AccountModels.LogOnModel model, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Auth.Login(model.UserName, model.Password, true) != null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");

                }

                // If we got this far, something failed, redisplay form
                return PartialView(model);
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "Can't connect to the server!");
                return PartialView(model);
            }
        }

        public ActionResult LogOff()
        {
            //FormsAuthentication.SignOut();
            Auth.LogOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Registration()
        {
            return View(new User());
        }

        //
        // POST: /Customers/Create

        [HttpPost]
        public ActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                //CustomerService.AddUser(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        #endregion actions
    }

}

