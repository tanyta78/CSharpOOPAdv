using Blobs.Entities;

namespace Blobs.Interfaces
{
   public interface IBehavior
    {
        bool IsTriggered { get; }

        void Trigger(Blob source);

        void ApplyPostTriggerEffect(Blob source);
    }
}
