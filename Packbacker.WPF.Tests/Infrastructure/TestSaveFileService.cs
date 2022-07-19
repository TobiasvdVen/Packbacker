using Packbacker.Domain.Abstractions;
using System.IO.Abstractions;

namespace Packbacker.WPF.Tests.Infrastructure
{
    internal class TestSaveFileService : ISaveFileService
    {
        private readonly IFileSystem fileSystem;
        private readonly string filePath;

        public TestSaveFileService(IFileSystem fileSystem, string filePath)
        {
            this.fileSystem = fileSystem;
            this.filePath = filePath;
        }

        public async Task<bool> SaveAsync(byte[] content, string? defaultExtension = null, string? filter = null)
        {
            using Stream stream = fileSystem.File.Open(filePath, FileMode.OpenOrCreate);

            await stream.WriteAsync(new ReadOnlyMemory<byte>(content));

            return true;
        }
    }
}
