using System;

namespace Swift.HeadServer.Pulse.Contracts
{
    public interface IMetricable
    {
        public Guid Guid();
        public DateTime ConnectedAt();
        public TimeSpan ConnectionTime();
        public TimeSpan WorkTime();
        public int LoadPercentage();
    }
}