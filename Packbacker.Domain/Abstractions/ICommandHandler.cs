namespace Packbacker.Domain.Abstractions
{
    public interface ICommandHandler<TCommand, TUndoData>
    {
        Task ExecuteAsync(TCommand command);
        Task UndoAsync(TUndoData undoData);
    }
}
