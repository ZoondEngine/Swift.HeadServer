using Extensions.Object;
using Swift.HeadServer.Pulse.Registry;

namespace Swift.HeadServer.Pulse
{
    public class PulseExObject : ExObject
    {
        private readonly RegistryExObject _registry;
        
        protected PulseExObject()
            : base()
        {
            _registry = new RegistryExObject();
        }
    }
}