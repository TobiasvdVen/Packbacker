using Microsoft.Win32;
using Packbacker.ViewModels.Services;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Packbacker.WPF.Services
{
    internal class SaveFileService : ISaveFileService
    {
        private readonly Dispatcher dispatcher;

        public SaveFileService(Dispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public async Task<bool> SaveAsync(string content, string? defaultExtension = null, string? filter = null)
        {
            SaveFileDialog saveFileDialog = new()
            {
                AddExtension = defaultExtension != null,
                DefaultExt = defaultExtension,
                ValidateNames = true,
                Filter = filter ?? string.Empty
            };

            bool fileSelected = await dispatcher.InvokeAsync(() =>
            {
                return saveFileDialog.ShowDialog() ?? false;
            });

            if (fileSelected)
            {
                using FileStream file = File.OpenWrite(saveFileDialog.FileName);
                using StreamWriter writer = new(file, Encoding.UTF8);

                await writer.WriteAsync(content);
            }

            return fileSelected;
        }
    }
}
