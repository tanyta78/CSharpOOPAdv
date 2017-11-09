using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blobs.Entities.Attacks
{
   public class PutridFartAttack:Attack
    {
        public override void Execute(Blob attacker, Blob target)
        {
            target.Health -= attacker.Damage;
        }
    }
}
