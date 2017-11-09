using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blobs.Interfaces;

namespace Blobs.Entities.Behaviors
{
    public abstract class Behavior : IBehavior
    {
        protected Behavior()
        {
            this.IsTriggered = false;
        }

        protected abstract void ApplyTriggerEffect(Blob source);

        public bool IsTriggered { get; protected set; }

        public abstract void Trigger(Blob source);

        public abstract void ApplyPostTriggerEffect(Blob source);
    }
}
