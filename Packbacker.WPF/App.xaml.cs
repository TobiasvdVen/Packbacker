using Microsoft.Extensions.DependencyInjection;
using Packbacker.ViewModels;
using System;
using System.Windows;

namespace Packbacker.WPF
{
    public partial class App : Application
    {
        private readonly IServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = ServiceConfiguration.ConfigureDefault();

            serviceProvider = services.BuildServiceProvider();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.DataContext = serviceProvider.GetRequiredService<MainWindowViewModel>();

            mainWindow.Show();
        }
    }
}
