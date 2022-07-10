namespace Packbacker.MVVM.Commands
{
    public class DelegateCommand<T> : CommandBase where T : notnull
    {
        private readonly Action<T> execute;
        private readonly Func<T, bool>? canExecute;

        public DelegateCommand(Action<T> execute)
        {
            this.execute = execute;
        }

        public DelegateCommand(Action<T> execute, Func<T, bool> canExecute) : this(execute)
        {
            this.canExecute = canExecute;
        }

        protected override bool CanExecuteInternal(object? parameter)
        {
            if (canExecute == null)
            {
                return true;
            }

            if (parameter is T t)
            {
                return canExecute(t);
            }

            throw new InvalidOperationException($"Parameter was expected to be type {typeof(T)} in {nameof(CanExecuteInternal)}, but was {parameter ?? "null"}.");
        }

        protected override void ExecuteInternal(object? parameter)
        {
            if (parameter is T t)
            {
                execute(t);
            }
            else
            {
                throw new InvalidOperationException($"Parameter was expected to be type {typeof(T)} in {nameof(ExecuteInternal)}, but was {parameter ?? "null"}.");
            }
        }
    }
}
