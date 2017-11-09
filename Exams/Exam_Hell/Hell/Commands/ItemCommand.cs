using System;
using System.Collections.Generic;

public class ItemCommand:AbstractCommand
    {
       public ItemCommand(List<string> args, IHeroManager manager) : base(args, manager)
        {
        }

        public override string Execute()
        {
            return this.Manager.AddItemToHero(Args);
        }
}

