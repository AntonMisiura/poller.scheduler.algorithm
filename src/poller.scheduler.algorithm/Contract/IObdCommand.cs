namespace poller.scheduler.algorithm.Contract
{
    public interface IObdCommand
    {
        string Name { get; }

        string Pid { get; }

        string ToString();

        bool Execute(IObdConnection connection);
    }
}
