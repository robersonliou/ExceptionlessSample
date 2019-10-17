using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exceptionless;

namespace AspNetMvc5Client.Filters
{
    public class FeatureUsageAttribute : ActionFilterAttribute
    {
        private string _featureTitle;
        private readonly string[] _featureTags;

        public FeatureUsageAttribute()
        {

        }

        public FeatureUsageAttribute(string featureTitle)
        {
            _featureTitle = featureTitle;
        }

        public FeatureUsageAttribute(string[] featureTags)
        {
            _featureTags = featureTags;
        }

        public FeatureUsageAttribute(string featureTitle, params string[] featureTags)
        {
            _featureTitle = featureTitle;
            _featureTags = featureTags;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
                var controllerName = (string)filterContext.RouteData.Values["controller"];
                var actionName = (string)filterContext.RouteData.Values["action"];
                var featureName = _featureTitle ??$"{controllerName}/{actionName}";

            ExceptionlessClient.Default.CreateFeatureUsage(featureName).AddTags(_featureTags).Submit();
            base.OnActionExecuted(filterContext);
        }

    }
}