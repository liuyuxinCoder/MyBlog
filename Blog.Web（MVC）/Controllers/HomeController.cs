using Blog.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Web_MVC_.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            BlogUser user = new BlogUser() { UserName = "liuyuxin" };
            
            return View();
        }

    }
}
