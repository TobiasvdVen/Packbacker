namespace Packbacker.Domain.Abstractions
{
    public interface ISaveFileService
    {
        Task<bool> SaveAsync(byte[] content, string? defaultExtension = null, string? filter = null);
    }
}
