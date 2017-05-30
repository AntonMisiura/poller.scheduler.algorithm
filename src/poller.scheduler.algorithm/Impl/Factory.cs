using poller.scheduler.algorithm.Contract;
using poller.scheduler.algorithm.Impl.Command;

namespace poller.scheduler.algorithm.Impl
{
    public class Factory
    {
        public static IObdCommand GetCommand(string code)
        {
            switch (code)
            {
                case "0C":
                    return new EngineRpmCommand();
                case "0D":
                    return new RoadSpeedCommand();
                case "11":
                    return new ThrottlePositionCommand();
                case "05":
                    return new EngineTemperatureCommand();
                case "10":
                    return new MassAirflowCommand();
                default: return new SupportedPidsCommand();
            }
        }
    }
}