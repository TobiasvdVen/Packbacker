namespace Packbacker.MVVM.Commands.Nullable
{
    public class DelegateCommandNullableRef<T> : CommandBase where T : class?
    {
        private readonly Action<T?> execute;
        private readonly Func<T?, bool>? canExecute;

        public DelegateCommandNullableRef(Action<T?> execute)
        {
            this.execute = execute;
        }

        public DelegateCommandNullableRef(Action<T?> execute, Func<T?, bool> canExecute) : this(execute)
        {
            this.canExecute = canExecute;
        }

        protected override bool CanExecuteInternal(object? parameter)
        {
            if (canExecute == null)
            {
                return true;
            }

            T? t = parameter as T;

            return canExecute(t);
        }

        protected override void ExecuteInternal(object? parameter)
        {
            T? t = parameter as T;

            execute(t);
        }
    }
}
