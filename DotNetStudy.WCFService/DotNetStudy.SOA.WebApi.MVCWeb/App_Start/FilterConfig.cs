using System.Web;
using System.Web.Mvc;

namespace DotNetStudy.SOA.WebApi.MVCWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
