namespace Packbacker.MVVM.Commands.Nullable
{
    public abstract class CommandNullableRef<T> : CommandBase where T : class?
    {
        protected override bool CanExecuteInternal(object? parameter)
        {
            return CanExecute(parameter as T);
        }

        protected override void ExecuteInternal(object? parameter)
        {
            Execute(parameter as T);
        }

        protected virtual bool CanExecute(T? parameter)
        {
            return true;
        }

        protected abstract void Execute(T? parameter);
    }
}
