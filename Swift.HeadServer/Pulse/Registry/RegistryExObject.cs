using System;
using Swift.HeadServer.App;

namespace Swift.HeadServer.Pulse.Registry
{
    public class RegistryService : ApplicationService
    {
        protected RegistryService()
            : base()
        {
            
        }
        
        public override string Name()
            => "[HEAD-SERVER-BRANCH] - Registry Service";

        public override Version Version()
            => System.Version.Parse("1.0.0.0");
    }
}