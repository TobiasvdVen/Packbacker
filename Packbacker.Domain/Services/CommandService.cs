using Packbacker.Domain.Abstractions;

namespace Packbacker.Domain.Services
{
    public class CommandService : ICommandService
    {
        public Task ExecuteAsync<T>(T command)
        {
            throw new NotImplementedException();
        }

        public Task UndoLastCommandAsync()
        {
            throw new NotImplementedException();
        }
    }
}
