using Microsoft.Win32;
using Packbacker.Domain.Abstractions;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Packbacker.WPF.Services
{
    internal class OpenFileService : IOpenFileService
    {
        private readonly Dispatcher dispatcher;

        public OpenFileService(Dispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public async Task<byte[]?> OpenFileAsync(string? defaultExtension = null, string? filter = null)
        {
            OpenFileDialog openFileDialog = new()
            {
                DefaultExt = defaultExtension ?? string.Empty,
                Filter = filter ?? string.Empty,
                CheckFileExists = true
            };

            bool fileSelected = await dispatcher.InvokeAsync(() =>
            {
                return openFileDialog.ShowDialog() ?? false;
            });

            if (fileSelected)
            {
                return await File.ReadAllBytesAsync(openFileDialog.FileName);
            }

            return null;
        }
    }
}
