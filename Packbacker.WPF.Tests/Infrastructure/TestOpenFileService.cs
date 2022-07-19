using Packbacker.Domain.Abstractions;
using System.IO.Abstractions;

namespace Packbacker.WPF.Tests.Infrastructure
{
    internal class TestOpenFileService : IOpenFileService
    {
        private readonly IFileSystem fileSystem;
        private readonly string filePath;

        public TestOpenFileService(IFileSystem fileSystem, string filePath)
        {
            this.fileSystem = fileSystem;
            this.filePath = filePath;
        }

        public Task<byte[]?> OpenFileAsync(string? defaultExtension = null, string? filter = null)
        {
            return fileSystem.File.ReadAllBytesAsync(filePath);
        }
    }
}
