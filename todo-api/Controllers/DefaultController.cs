using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    [Route("/")]
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Default()
        {
            // send users to index.html
            return Redirect("/index.html");
        }
    }
}
