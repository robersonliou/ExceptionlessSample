using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exceptionless;

namespace AspNetMvc5Client.Controllers
{
    public class LogController : Controller
    {
        public ActionResult Manually()
        {

            ExceptionlessClient.Default.SubmitLog($"Loggin Now - {DateTime.Now}");
            ExceptionlessClient.Default.SubmitLog("Log Source", $"Loggin Now - {DateTime.Now}", "Info");
            ExceptionlessClient.Default.CreateLog("Log Source", $"Loggin Now - {DateTime.Now}", "Info")
                .AddTags("Exceptionless").Submit();

            return View();
        }
    }
}