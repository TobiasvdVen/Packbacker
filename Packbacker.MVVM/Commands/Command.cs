namespace Packbacker.MVVM.Commands
{
    public abstract class Command<T> : CommandBase where T : notnull
    {
        protected override bool CanExecuteInternal(object? parameter)
        {
            if (parameter is T t)
            {
                return CanExecute(t);
            }

            throw new InvalidOperationException($"Parameter was expected to be type {typeof(T)} in {nameof(CanExecuteInternal)}, but was {parameter ?? "null"}.");
        }

        protected override void ExecuteInternal(object? parameter)
        {
            if (parameter is T t)
            {
                Execute(t);
            }
            else
            {
                throw new InvalidOperationException($"Parameter was expected to be type {typeof(T)} in {nameof(ExecuteInternal)}, but was {parameter ?? "null"}.");
            }
        }

        protected virtual bool CanExecute(T parameter)
        {
            return true;
        }

        protected abstract void Execute(T parameter);
    }
}
