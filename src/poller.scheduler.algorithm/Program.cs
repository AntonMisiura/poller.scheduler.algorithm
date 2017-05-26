using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using poller.scheduler.algorithm.Contract;
using poller.scheduler.algorithm.Impl;
using poller.scheduler.algorithm.Impl.Entities;
using poller.scheduler.algorithm.Impl.Service;

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
                .AddJsonFile("pids.settings.json", false)
                .Build();
            serviceCollection.AddOptions();

            var serialPortSettings = configuration.GetSection("SerialPortSettings");
            serviceCollection.Configure<SerialPortSettings>(serialPortSettings);

            var pidsSettings = configuration.GetSection("Car");
            serviceCollection.Configure<Car>(pidsSettings);

            // add services
            serviceCollection.AddTransient<IObdService, ObdService>();

            // add app
            serviceCollection.AddTransient<App>();
        }
    }
}
