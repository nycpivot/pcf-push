using Microsoft.AspNetCore.Mvc;
using Pcf.Push.Dotnet.Core.Mvc.Linux.Models;
using System.Diagnostics;

namespace Pcf.Push.Dotnet.Core.Mvc.Linux.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}