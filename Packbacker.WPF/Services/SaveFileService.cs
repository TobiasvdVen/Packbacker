using Microsoft.Win32;
using Packbacker.Domain.Abstractions;
using System;
using System.IO;
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

        public async Task<bool> SaveAsync(byte[] content, string? defaultExtension = null, string? filter = null)
        {
            SaveFileDialog saveFileDialog = new()
            {
                AddExtension = defaultExtension != null,
                DefaultExt = defaultExtension ?? string.Empty,
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
                await file.WriteAsync(new ReadOnlyMemory<byte>(content));
            }

            return fileSelected;
        }
    }
}
