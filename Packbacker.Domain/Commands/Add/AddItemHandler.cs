using Packbacker.Domain.Abstractions;

namespace Packbacker.Domain.Commands.Add
{
    public class AddItemHandler : ICommandHandler<AddItemCommand, AddItemUndo>
    {
        private readonly IItemStore itemStore;

        public AddItemHandler(IItemStore itemStore)
        {
            this.itemStore = itemStore;
        }

        public Task ExecuteAsync(AddItemCommand command)
        {
            return itemStore.AddItemAsync(command.Item);
        }

        public Task UndoAsync(AddItemUndo undoData)
        {
            throw new NotImplementedException();
        }
    }
}
