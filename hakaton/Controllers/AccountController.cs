using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories.Model;
using hakaton.Models;
using hakaton.Models.Authentication;
using hakaton.Models.AccountModels;
using hakaton.Services;

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
                ModelState.Clear();
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
            return View(new RegisterModel());
        }

        //
        // POST: /Customers/Create

        [HttpPost]
        public ActionResult Registration(RegisterModel user)
        {
            if (ModelState.IsValid)
            {
                //CustomerService.AddUser(user);
                var res = UserService.CreateUser(user.Email, user.Password);
                if (res == Repositories.Enums.CreateUserEnum.Succeeded)
                {
                    Auth.Login(user.Email, false);
                    var userDB = UserService.GetUserByEmail(user.Email);
                    SenderSMTP.SendMessage(user.Email, "Congratulations, you've signed up for the service JsInquisitor",
                        "Now you can start working with the service.\r\nTo do this you need to include the following code to your site:\r\n<script>\r\n...\r\n" + userDB.Id.ToString() + "\r\n</script>");
                    return RedirectToAction("Index", "Home");
                }
                if (res == Repositories.Enums.CreateUserEnum.EmailExist)
                {
                    ModelState.AddModelError("", "User with this email already exists");
                }
                if (res == Repositories.Enums.CreateUserEnum.Failed)
                {
                    ModelState.AddModelError("", "An error occurred while saving the user");
                }


            }
            
            return View(user);
        }

        #endregion actions
    }

}

