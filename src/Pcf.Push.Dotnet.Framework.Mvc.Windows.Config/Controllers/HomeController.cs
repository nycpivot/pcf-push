using System.Configuration;
using System.Web.Mvc;

namespace Pcf.Push.Dotnet.Framework.Mvc.Windows.Config.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.AppName = ConfigurationManager.AppSettings["appName"];
            ViewBag.AppVersion = ConfigurationManager.AppSettings["appVersion"];
            ViewBag.ConnectionString = ConfigurationManager.ConnectionStrings["DefaultDatabase"];

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}