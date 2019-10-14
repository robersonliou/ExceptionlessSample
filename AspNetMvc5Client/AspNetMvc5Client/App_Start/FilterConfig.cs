using System.Web;
using System.Web.Mvc;
using AspNetMvc5Client.Filters;

namespace AspNetMvc5Client
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new FeatureUsageAttribute());
        }
    }
}
