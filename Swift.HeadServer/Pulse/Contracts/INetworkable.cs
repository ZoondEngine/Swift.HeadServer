using System.Net;

namespace Swift.HeadServer.Pulse.Contracts
{
    public interface INetworkable
    {
        public IPAddress Ip();
        public short Port();
        public int Ping();
    }
}