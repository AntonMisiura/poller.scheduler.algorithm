using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using poller.scheduler.algorithm.Contract;
using poller.scheduler.algorithm.Impl;

namespace poller.scheduler.algorithm
{
    public class Program
    {
        public static IConfigurationSection Configuration { get; set; }
        public static void Main(string[] args)
        {
            // create service collection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // create service provider
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // entry to run app
            serviceProvider.GetService<App>().Run();         
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // add logging
            serviceCollection.AddSingleton(new LoggerFactory()
                .AddConsole()
                .AddDebug());
            serviceCollection.AddLogging();

            // build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("app.settings.json", false)
                .Build();
            serviceCollection.AddOptions();

            //IConfigurationSection pidsConfigurationSection = configuration.GetSection("Pids");
            //IEnumerable<IConfigurationSection> pidsChildren = pidsConfigurationSection.GetChildren();
            //List<string> pids = (from c in pidsChildren select c.Value).ToList();

            serviceCollection.Configure<AppSettings>(configuration.GetSection("Pids"));
            serviceCollection.Configure<AppSettings>(configuration.GetSection("Config"));
            serviceCollection.Configure<AppSettings>(configuration.GetSection("Configuration"));

            // add services
            serviceCollection.AddTransient<IObdService, ObdService>();

            // add app
            serviceCollection.AddTransient<App>();
        }
    }
}
