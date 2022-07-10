using Packbacker.MVVM.Commands;
using System;
using System.Windows.Input;
using Xunit;

namespace Packbacker.MVVM.Tests.Commands
{
    public class DelegateCommandTests
    {
        [Fact]
        public void NullSafeExecute()
        {
            string parameter = "parameter";

            void execute(string p)
            {
                Assert.NotNull(p);
                Assert.Equal(parameter, p);
            }

            ICommand command = new DelegateCommand<string>(execute);

            command.Execute(parameter);
        }

        [Fact]
        public void NullSafeCanExecute()
        {
            string parameter = "cheese";
            bool canExecuteCalled = false;

            bool canExecute(string o)
            {
                Assert.NotNull(o);
                Assert.Equal(parameter, o);

                canExecuteCalled = true;

                return true;
            }

            CommandBase baseCommand = new DelegateCommand<string>(o => { }, canExecute);
            ICommand command = baseCommand;

            command.CanExecuteChanged += (sender, args) => command.CanExecute(parameter);

            baseCommand.RaiseCanExecuteChanged();

            Assert.True(canExecuteCalled);
        }

        [Fact]
        public void NoCanExecuteIsTrue()
        {
            ICommand command = new DelegateCommand<string>(p => { });

            Assert.True(command.CanExecute(null));
        }

        [Fact]
        public void WrongTypeExecuteThrows()
        {
            ICommand command = new DelegateCommand<string>(p => { });

            Assert.Throws<InvalidOperationException>(() => command.Execute(10));
        }

        [Fact]
        public void WrongTypeCanExecuteThrows()
        {
            ICommand command = new DelegateCommand<int>(p => { }, p => true);

            Assert.Throws<InvalidOperationException>(() => command.CanExecute("Hello"));
        }
    }
}
