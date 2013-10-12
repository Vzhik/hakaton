using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using hakaton.Models;

namespace hakaton.Controllers
{
    public class JSInquisitorController : ApiController
    {
        // POST api/jsinquisitor
        [HttpPost]
        public void PushError(ErrorModel error)
        {
            error.Init();
            int i;
            i = 0;
        }
    }
}
