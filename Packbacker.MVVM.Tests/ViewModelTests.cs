using Xunit;

namespace Packbacker.MVVM.Tests
{
    public class ViewModelTests
    {
        private class TestViewModel : ViewModel
        {
            private string? myProperty;

            public string? MyProperty
            {
                get => myProperty;
                set => SetProperty(ref myProperty, value);
            }
        }

        [Fact]
        public void RaisePropertyChangedWhenSet()
        {
            TestViewModel viewModel = new();

            bool raised = false;

            viewModel.PropertyChanged += (sender, e) => raised = true;

            viewModel.MyProperty = "Raise the event!";

            Assert.True(raised);
        }
    }
}