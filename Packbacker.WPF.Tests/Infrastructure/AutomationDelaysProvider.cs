using FlaUI.UIA3.Async;

namespace Packbacker.WPF.Tests.Infrastructure
{
    public class AutomationDelaysProvider
    {
        public AutomationDelaysProvider()
        {
            TeamCityDetector teamCityDetector = new();

            if (teamCityDetector.TeamCityDetected)
            {
                AutomationDelays = new NoDelays();
            }
            else
            {
                AutomationDelays = new SimulateUserDelays();
            }
        }

        public IAutomationDelays AutomationDelays { get; }
    }
}
