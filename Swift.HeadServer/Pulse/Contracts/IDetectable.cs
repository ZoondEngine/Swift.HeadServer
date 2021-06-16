namespace Swift.HeadServer.Pulse.Contracts
{
    public interface IDetectable
    {
        public int Pid();
        public string Country();
        public string MachineName();
        public string OperatingSystem();
    }
}