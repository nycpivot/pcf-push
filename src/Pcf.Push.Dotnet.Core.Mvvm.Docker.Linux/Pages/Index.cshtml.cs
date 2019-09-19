using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Net;

namespace Pcf.Push.Dotnet.Core.Mvvm.Docker.Linux.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            var hostAddresses = Dns.GetHostAddresses(Environment.MachineName);
            
            if(hostAddresses != null && hostAddresses.Length > 0)
            {
                IpAddress = hostAddresses[0].ToString();
            }
        }

        public string IpAddress
        {
            get; set;
        }
    }
}