namespace poller.scheduler.algorithm.Contract
{
    public interface IOdbCommand
    {
        string Name { get; }

        string ToString();

        bool Execute(IOdbConnection connection);
    }
}
