using Blobs.Entities;

namespace Blobs.Interfaces
{
   public interface IAttack
    {
        void Execute(Blob attacker, Blob target);
    }
}
