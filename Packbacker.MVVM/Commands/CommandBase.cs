using System.Windows.Input;

namespace Packbacker.MVVM.Commands
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        bool ICommand.CanExecute(object? parameter)
        {
            return CanExecuteInternal(parameter);
        }

        void ICommand.Execute(object? parameter)
        {
            ExecuteInternal(parameter);
        }

        protected abstract bool CanExecuteInternal(object? parameter);
        protected abstract void ExecuteInternal(object? parameter);

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
