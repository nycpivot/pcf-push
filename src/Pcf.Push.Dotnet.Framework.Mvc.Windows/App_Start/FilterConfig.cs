using System.Web.Mvc;

namespace Pcf.Push.Dotnet.Framework.Mvc.Windows
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}