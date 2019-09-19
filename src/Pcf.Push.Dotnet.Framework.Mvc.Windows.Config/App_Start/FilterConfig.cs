using System.Web;
using System.Web.Mvc;

namespace Pcf.Push.Dotnet.Framework.Mvc.Windows.Config
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
