using Packbacker.MVVM.Commands;
using System;
using System.Windows.Input;
using Xunit;

namespace Packbacker.MVVM.Tests.Commands
{
    public class CommandTests
    {
        private class TestParameter
        {
            public bool Check { get; set; }
        }

        private class CheckParameterCommand : Command<TestParameter>
        {
            protected override void Execute(TestParameter parameter)
            {
                parameter.Check = true;
            }
        }

        private class CanExecuteCommand : Command<TestParameter>
        {
            protected override void Execute(TestParameter parameter)
            {
                throw new NotImplementedException();
            }

            protected override bool CanExecute(TestParameter parameter)
            {
                return false;
            }
        }

        readonly ICommand checkParameterCommand = new CheckParameterCommand();
        readonly ICommand canExecuteCommand = new CanExecuteCommand();

        [Fact]
        public void Execute()
        {
            TestParameter parameter = new()
            {
                Check = false
            };

            checkParameterCommand.Execute(parameter);

            Assert.True(parameter.Check);
        }

        [Fact]
        public void DefaultCanExecuteTrue()
        {
            Assert.True(checkParameterCommand.CanExecute(new TestParameter()));
        }

        [Fact]
        public void CanExecuteOverride()
        {
            Assert.False(canExecuteCommand.CanExecute(new TestParameter()));
        }

        [Fact]
        public void NullExecuteThrows()
        {
            Assert.Throws<InvalidOperationException>(() => checkParameterCommand.Execute(null));
        }

        [Fact]
        public void WrongTypeExecuteThrows()
        {
            Assert.Throws<InvalidOperationException>(() => checkParameterCommand.Execute("a string"));
        }

        [Fact]
        public void NullCanExecuteThrows()
        {
            Assert.Throws<InvalidOperationException>(() => checkParameterCommand.CanExecute(null));
        }

        [Fact]
        public void WrongTypeCanExecuteThrows()
        {
            Assert.Throws<InvalidOperationException>(() => checkParameterCommand.CanExecute(32));
        }
    }
}
