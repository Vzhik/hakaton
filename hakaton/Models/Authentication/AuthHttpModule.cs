﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace hakaton.Models.Authentication
{
    public class AuthHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += new EventHandler(this.Authenticate);
        }

        private void Authenticate(Object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpContext context = app.Context;

            var auth = new CustomAuthentication();
            auth.HttpContext = context;
            context.User = auth.CurrentUser;
        }

        public void Dispose()
        {
        }
    } 
}