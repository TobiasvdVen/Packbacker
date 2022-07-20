using Microsoft.Extensions.DependencyInjection;
using Packbacker.Domain.Abstractions;
using Packbacker.Domain.Services;
using Packbacker.ViewModels;
using Packbacker.WPF.Services;
using System;
using System.IO;
using System.IO.Abstractions;
using System.Windows.Threading;

namespace Packbacker.WPF
{
    internal static class ServiceConfiguration
    {
        public static ServiceCollection ConfigureDefault()
        {
            ServiceCollection services = new();

            services.AddSingleton<MainWindow>();

            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<GearEditorViewModel>();
            services.AddTransient<GearListViewModel>();

            services.AddTransient<ISaveFileService, SaveFileService>();
            services.AddTransient<IOpenFileService, OpenFileService>();

            services.AddSingleton<IFileSystem, FileSystem>();
            services.AddSingleton(_ => Dispatcher.CurrentDispatcher);
            services.AddSingleton<IItemStore, FileItemStore>(s =>
            {
                return new FileItemStore(
                    s.GetRequiredService<IFileSystem>(),
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Packbacker"));
            });

            return services;
        }
    }
}
