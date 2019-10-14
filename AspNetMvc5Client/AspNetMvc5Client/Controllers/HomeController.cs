using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exceptionless;

namespace AspNetMvc5Client.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ExceptionlessClient.Default.CreateFeatureUsage("My Home Page").AddTags("mvc5").Submit();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}