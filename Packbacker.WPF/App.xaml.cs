using Microsoft.Extensions.DependencyInjection;
using Packbacker.ViewModels;
using Packbacker.ViewModels.Services;
using Packbacker.WPF.Services;
using System.Windows;
using System.Windows.Threading;

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

            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<GearEditorViewModel>();
            services.AddTransient<GearListViewModel>();

            services.AddTransient<ISaveFileService, SaveFileService>();

            services.AddSingleton(_ => Dispatcher.CurrentDispatcher);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow mainWindow = serviceProvider.GetRequiredService<MainWindow>();

            mainWindow.DataContext = serviceProvider.GetRequiredService<MainWindowViewModel>();
            mainWindow.Show();
        }
    }
}
