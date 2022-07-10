using FlaUI.Core;
using Xunit;

namespace Packbacker.WPF.Tests
{
    public class PackViewTests
    {
        private const string PackbackerExePathEnvironmentVariable = "PACKBACKER_WPF_EXE_PATH";

        [Fact]
        public void Test1()
        {
            string packbackerExePath = GetPackbackerExePath();

            using Application packbacker = Application.Launch(packbackerExePath, arguments: null);

            try
            {

            }
            finally
            {
                packbacker.Close();
            }
        }

        private string GetPackbackerExePath()
        {
            return Environment.GetEnvironmentVariable(PackbackerExePathEnvironmentVariable) ?? throw new FileNotFoundException($"Unable to find environment variable specifying executable path: {PackbackerExePathEnvironmentVariable}");
        }
    }
}