using Blobs.Interfaces;

namespace Blobs.Entities.Attacks
{
    public abstract class Attack : IAttack
    {
        public abstract void Execute(Blob attacker, Blob target);
    }
}