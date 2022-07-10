using Packbacker.MVVM.Commands.Nullable;
using System.Windows.Input;
using Xunit;

namespace Packbacker.MVVM.Tests.Commands.Nullable
{
    public class DelegateCommandNullableRefTests
    {
        [Fact]
        public void NullableReferenceTypeExecute()
        {
            string? parameter = "yoobie";

            void execute(string? p)
            {
                Assert.NotNull(p);
                Assert.Equal(parameter, p);
            }

            ICommand command = new DelegateCommandNullableRef<string?>(execute);

            command.Execute(parameter);
        }

        [Fact]
        public void NullableReferenceTypeExecuteNullOk()
        {
            string? parameter = null;

            void execute(string? p)
            {
                Assert.Null(p);
                Assert.Equal(parameter, p);
            }

            ICommand command = new DelegateCommandNullableRef<string?>(execute);

            command.Execute(parameter);
        }

        [Fact]
        public void NullableReferenceTypeCanExecuteNullOk()
        {
            string? parameter = null;
            bool canExecuteCalled = false;

            bool canExecute(string? p)
            {
                Assert.Null(p);
                Assert.Equal(parameter, p);

                canExecuteCalled = true;

                return true;
            }

            DelegateCommandNullableRef<string?> command = new(p => { }, canExecute);
            ICommand iCommand = command;

            command.CanExecuteChanged += (sender, args) => iCommand.CanExecute(parameter);

            command.RaiseCanExecuteChanged();

            Assert.True(canExecuteCalled);
        }

        [Fact]
        public void NoCanExecuteIsTrue()
        {
            ICommand command = new DelegateCommandNullableRef<string?>(p => { });

            Assert.True(command.CanExecute(null));
        }
    }
}
