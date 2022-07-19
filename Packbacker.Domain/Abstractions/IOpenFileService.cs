namespace Packbacker.Domain.Abstractions
{
    public interface IOpenFileService
    {
        Task<byte[]?> OpenFileAsync(string? defaultExtension = null, string? filter = null);
    }
}
