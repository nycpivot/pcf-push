﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Pcf.Push.Dotnet.Core.Mvc.Linux
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}