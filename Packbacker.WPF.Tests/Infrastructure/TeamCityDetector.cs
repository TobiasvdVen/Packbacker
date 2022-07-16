namespace Packbacker.WPF.Tests.Infrastructure
{
    public class TeamCityDetector
    {
        public bool TeamCityDetected => Environment.GetEnvironmentVariable("TEAMCITY_VERSION") != null;
    }
}
