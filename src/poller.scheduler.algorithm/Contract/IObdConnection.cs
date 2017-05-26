using System;

namespace poller.scheduler.algorithm.Contract
{
    public interface IObdConnection : IDisposable
    {
        bool Open();
        void Close();

        int Read(byte[] buffer, int offset, int count);
        void Write(string data);
    }
}
