namespace Packbacker.Domain.Abstractions
{
    public interface ICommandService
    {
        Task ExecuteAsync<T>(T command);
        Task UndoLastCommandAsync();
    }
}
