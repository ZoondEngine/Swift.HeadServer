using System;
using Extensions.Object;

namespace Swift.HeadServer.Pulse.Behaviours
{
    public class PulseServersBehaviour : ExBehaviour
    {
        private PulseService _service;
        private TimeSpan _lastPulseTime = TimeSpan.Zero;
        private bool _shouldUpdated = true;
        
        public void UpdateFlag(bool val)
        {
            _shouldUpdated = val;
        }

        public override void Awake()
        {
            _service = ParentObject.Unbox<PulseService>();
        }

        public override void Update()
        {
            if (NeedUpdate())
            {
                //TODO: Update the child servers ...
                //get ping, system data and etc ...
            }
        }

        private bool NeedUpdate()
        {
            if (_lastPulseTime == TimeSpan.Zero)
                _lastPulseTime = CurrentTickTime;

            var delta = CurrentTickTime - _lastPulseTime;
            if (delta.Seconds <= 5) return false;
            if (!_shouldUpdated) return false;
            
            _lastPulseTime = CurrentTickTime;
            return true;
        }
    }
}