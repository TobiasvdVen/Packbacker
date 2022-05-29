using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Packbacker.WPF
{
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new();

            ConfigureServices(services);

            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<I, A>();
            services.AddSingleton<MainWindow>();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }
    }
}
