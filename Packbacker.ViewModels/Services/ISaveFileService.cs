namespace Packbacker.ViewModels.Services
{
    public interface ISaveFileService
    {
        Task<bool> SaveAsync(string content, string? defaultExtension = null, string? filter = null);
    }
}
