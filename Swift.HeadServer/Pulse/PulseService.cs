using System;
using System.Collections.Concurrent;
using System.Linq;
using Extensions.Object.Attributes;
using Extensions.Object.Exceptions;
using Swift.HeadServer.App;
using Swift.HeadServer.Pulse.Behaviours;
using Swift.HeadServer.Pulse.Contracts;
using Swift.HeadServer.Pulse.Registry;

namespace Swift.HeadServer.Pulse
{
    [RequiredBehaviour(typeof(PulseServersBehaviour))]
    public class PulseService : ApplicationService
    {
        /// <summary>
        /// Registry object instance
        /// </summary>
        private readonly RegistryExObject _registry;
        
        protected PulseService()
            : base()
        {
            _registry = Instantiate<RegistryExObject>();

            ThrowIf(_registry == null, new ExException("Cannot resolve the registry object!"));
        }

        /// <summary>
        /// Get the registry object
        /// </summary>
        /// <returns></returns>
        public RegistryExObject Registry()
            => _registry;

        /// <summary>
        /// Get the stored servers in registry
        /// </summary>
        /// <returns></returns>
        public ConcurrentDictionary<string, IChildServer> StoredServers()
            => _registry.Store();

        /// <summary>
        /// Get the server
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IChildServer Get(string name)
            => _registry.Get(name);

        /// <summary>
        /// Add server to registry
        /// </summary>
        /// <param name="name"></param>
        /// <param name="server"></param>
        public void Push(string name, IChildServer server)
            => _registry.Push(name, server);

        /// <summary>
        /// Get minimal loaded server for action
        /// </summary>
        /// <returns></returns>
        public IChildServer GetForAction()
        {
            var servers = StoredServers().Values.ToList();
            return servers.OrderBy(x => x.LoadPercentage()).First();
        }

        /// <summary>
        /// Pause pulsing, maybe usable for performance
        /// </summary>
        public void Pause()
            => GetComponent<PulseServersBehaviour>().UpdateFlag(false);

        /// <summary>
        /// Resume pulsing
        /// </summary>
        public void Resume()
            => GetComponent<PulseServersBehaviour>().UpdateFlag(true);
        
        public override string Name()
            => "[HEAD-SERVER] - Pulse service";

        public override Version Version()
            => System.Version.Parse("1.0.0.0");
    }
}