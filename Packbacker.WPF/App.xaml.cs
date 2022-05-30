using Microsoft.Extensions.DependencyInjection;
using Packbacker.ViewModels;
using System.Collections.Generic;
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
            services.AddSingleton<MainWindow>();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = serviceProvider.GetRequiredService<MainWindow>();

            mainWindow.DataContext = new MainWindowViewModel(
                new PackViewModel(new List<string>() { "Backpack", "Tent", "Sleeping bag", "MSR Guardian" })
                );

            mainWindow.Show();
        }
    }
}
