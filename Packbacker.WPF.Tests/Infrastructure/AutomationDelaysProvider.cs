using FlaUI.UIA3.Async;

namespace Packbacker.WPF.Tests.Infrastructure
{
    public class AutomationDelaysProvider
    {
        public AutomationDelaysProvider()
        {
            bool isTeamCity = Environment.GetEnvironmentVariable("TEAMCITY_VERSION") != null;

            if (isTeamCity)
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
