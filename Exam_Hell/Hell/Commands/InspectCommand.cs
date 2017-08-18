using System;
using System.Collections.Generic;

public class InspectCommand:AbstractCommand
    {
        public InspectCommand(List<string> args, IHeroManager manager) : base(args, manager)
        {
        }

        public override string Execute()
        {
            return this.Manager.Inspect(Args);
        }
    }

