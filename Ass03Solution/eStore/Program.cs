using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eStore
{
    public class Program
    {

        public static void Main(string[] args)
        {
            ConnectionString = getConnectionString();


            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        public static string ConnectionString;

        public static object Configuration { get; internal set; }

        private static string getConnectionString()
        {
            Dictionary<string, string> defaultAdmin = new Dictionary<string, string>();
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            string cn = config["ConnectionStrings:AppDatabase"];
            return cn;
        }
    }
}
