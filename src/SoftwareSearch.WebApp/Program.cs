using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SoftwareSearch.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseDefaultServiceProvider(options =>
                    options.ValidateScopes = false)
                .Build()
                .Run();
        }
    }
}
