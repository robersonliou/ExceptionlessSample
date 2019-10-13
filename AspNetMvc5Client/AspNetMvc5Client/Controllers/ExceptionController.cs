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

        public ActionResult Additional()
        {
            var order = GetFakeOrder();
            try
            {
                throw new ApplicationException("Unable to create order from quote.");
            }
            catch (Exception ex)
            {
                ex.ToExceptionless()
                    .SetReferenceId(Guid.NewGuid().ToString("N"))
                    .AddObject(order, "Order", excludedPropertyNames: new[] {"CreditCardNumber"}, maxDepth: 1)
                    .SetProperty("Quote", 122)
                    .AddTags("Order")
                    .MarkAsCritical()
                    .SetGeo(42.595089, -88.444602)
                    .Submit();
            }

            return View();
        }

        private object GetFakeOrder()
        {
            var order = new
            {
                orderId = 0,
                orderItem = "Pencil",
                orderName = "Roberson",
                employeeName = "James",
                CreditCardNumber = "1233-5678-8765-4321"
            };
            return order;
        }
    }
}