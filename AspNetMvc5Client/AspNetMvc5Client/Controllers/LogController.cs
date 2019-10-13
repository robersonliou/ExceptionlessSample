using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exceptionless;
using NLog;

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

        public ActionResult NLogTest()
        {
            var logger = LogManager.GetCurrentClassLogger();

            logger.Trace("NLog - Trace in Mvc5");
            logger.Debug("NLog - Debug in Mvc5");
            logger.Info("NLog - Info in Mvc5");
            logger.Warn("NLog - Warn in Mvc5");
            logger.Error("NLog - Error in Mvc5");
            logger.Fatal("NLog - Fatal in Mvc5");

            return View();
        }
    }
}