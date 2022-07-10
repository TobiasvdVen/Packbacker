using Packbacker.MVVM.Commands.Nullable;
using System.Windows.Input;
using Xunit;

namespace Packbacker.MVVM.Tests.Commands.Nullable
{
    public class CommandNullableRefTests
    {
        private class TestParameter
        {
            public bool Check { get; set; }
        }

        private class NullParameterCommand : CommandNullableRef<TestParameter>
        {
            protected override void Execute(TestParameter? parameter)
            {
                Assert.Null(parameter);
            }
        }

        private class CheckParameterCommand : CommandNullableRef<TestParameter>
        {
            protected override void Execute(TestParameter? parameter)
            {
                parameter!.Check = true;
            }
        }

        private class CanExecuteCommand : CommandNullableRef<TestParameter>
        {
            protected override void Execute(TestParameter? parameter)
            {
                throw new System.NotImplementedException();
            }

            protected override bool CanExecute(TestParameter? parameter)
            {
                return false;
            }
        }

        [Fact]
        public void ExecuteNullOk()
        {
            ICommand command = new NullParameterCommand();

            command.Execute(null);
        }

        [Fact]
        public void Execute()
        {
            ICommand command = new CheckParameterCommand();

            TestParameter parameter = new()
            {
                Check = false
            };

            command.Execute(parameter);

            Assert.True(parameter.Check);
        }

        [Fact]
        public void DefaultCanExecuteTrue()
        {
            ICommand command = new CheckParameterCommand();

            Assert.True(command.CanExecute(null));
        }

        [Fact]
        public void CanExecuteOverride()
        {
            ICommand command = new CanExecuteCommand();

            Assert.False(command.CanExecute(null));
        }
    }
}
