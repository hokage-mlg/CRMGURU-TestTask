using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TestTask.WebUI
{
    public class Program
    {
        /// <summary>
        /// Main() method is the entry point of the program
        /// </summary>
        /// <param name="args"> The argument to the Main() method </param>
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();
        /// <summary>
        /// To create and configure a builder object
        /// </summary>
        /// <param name="args"> The argument to the CreateHostBuilder() method </param>
        /// <returns> Universal site (IHostBuilder) </returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
