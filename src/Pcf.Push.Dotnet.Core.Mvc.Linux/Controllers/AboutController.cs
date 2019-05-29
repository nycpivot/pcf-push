using Microsoft.AspNetCore.Mvc;

namespace Pcf.Push.Dotnet.Core.Mvc.Linux.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}