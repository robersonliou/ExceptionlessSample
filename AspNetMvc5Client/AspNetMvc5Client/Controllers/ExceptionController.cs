using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exceptionless;

namespace AspNetMvc5Client.Controllers
{
    public class ExceptionController : Controller
    {
        public ActionResult Null()
        {
            throw new NullReferenceException("send null exception to Exceptionless");
        }

        public ActionResult Manually()
        {
            try
            {
                new InvalidOperationException("manually throw exception");
            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();
            }
            return View();
        }
    }
}