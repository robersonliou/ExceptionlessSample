using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace AspNetMvc5Client.Controllers
{
    public class ExternalController : Controller
    {
        public void Integration()
        {
            var request = Request.InputStream;
            request.Seek(0, System.IO.SeekOrigin.Begin);
            var json = new StreamReader(request).ReadToEnd();
            var data = JsonConvert.DeserializeObject<WebHookModel>(json);
        }
    }

    public class WebHookModel
    {
        public string id { get; set; }
        public string url { get; set; }
        public DateTime occurrence_date { get; set; }
        public string type { get; set; }
        public string message { get; set; }
        public string project_id { get; set; }
        public string project_name { get; set; }
        public string organization_id { get; set; }
        public string organization_name { get; set; }
        public string stack_id { get; set; }
        public string stack_url { get; set; }
        public string stack_title { get; set; }
        public int total_occurrences { get; set; }
        public DateTime first_occurrence { get; set; }
        public DateTime last_occurrence { get; set; }
        public DateTime date_fixed { get; set; }
        public bool is_new { get; set; }
        public bool is_regression { get; set; }
        public bool is_critical { get; set; }
    }


}