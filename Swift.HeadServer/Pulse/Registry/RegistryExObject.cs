using System.Collections.Concurrent;
using System.Collections.Generic;
using Extensions.Object;
using Swift.HeadServer.Pulse.Contracts;

namespace Swift.HeadServer.Pulse.Registry
{
    public class RegistryExObject : ExObject
    {
        private readonly ConcurrentDictionary<string, IChildServer> _store;
        
        public RegistryExObject()
            : base()
        {
            _store = new ConcurrentDictionary<string, IChildServer>();
        }

        public void Push(string name, IChildServer server)
        {
            if (!Exists(name))
            {
                if (!_store.TryAdd(name, server))
                {
                    FindObjectOfType<PulseService>().Error($"Can't push the child server: " +
                                                                 $"{server.Guid()}, " +
                                                                 $"{server.Ip()}, " +
                                                                 $"{server.Signature()}, " +
                                                                 $"{server.Country()}");
                }
            }
        }

        public IChildServer Reject(string name)
        {
            if (!Exists(name)) return null;
            if (!_store.Remove(name, out var child))
            {
                if (child != null)
                    FindObjectOfType<PulseService>().Error($"Can't reject the child server: " +
                                                           $"{child.Guid()}, " +
                                                           $"{child.Ip()}, " +
                                                           $"{child.Signature()}, " +
                                                           $"{child.Country()}");
            }
            else
            {
                return child;
            }

            return null;
        }

        public IChildServer Get(string name)
        {
            return Exists(name) ? _store[name] : null;
        }

        private bool Exists(string name)
            => _store.ContainsKey(name);

        public ConcurrentDictionary<string, IChildServer> Store()
            => _store;
    }
}