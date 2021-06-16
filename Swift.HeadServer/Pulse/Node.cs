using System;
using System.Net;
using Swift.HeadServer.Pulse.Contracts;

namespace Swift.HeadServer.Pulse
{
    public class Node 
        : IAccessable, IDetectable, IMetricable, INetworkable, ISecurable
    {
        public bool Update()
        {
            
        }
        
        public int Pid()
        {
            throw new NotImplementedException();
        }

        public string Country()
        {
            throw new NotImplementedException();
        }

        public string MachineName()
        {
            throw new NotImplementedException();
        }

        public string OperatingSystem()
        {
            throw new NotImplementedException();
        }

        public Guid Guid()
        {
            throw new NotImplementedException();
        }

        public DateTime ConnectedAt()
        {
            throw new NotImplementedException();
        }

        public TimeSpan ConnectionTime()
        {
            throw new NotImplementedException();
        }

        public TimeSpan WorkTime()
        {
            throw new NotImplementedException();
        }

        public int LoadPercentage()
        {
            throw new NotImplementedException();
        }

        public IPAddress Ip()
        {
            throw new NotImplementedException();
        }

        public short Port()
        {
            throw new NotImplementedException();
        }

        public int Ping()
        {
            throw new NotImplementedException();
        }

        public string Signature()
        {
            throw new NotImplementedException();
        }
    }
}