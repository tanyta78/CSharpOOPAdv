using System;
using System.Collections.Generic;

public class RecipeCommand:AbstractCommand
    {
        public RecipeCommand(List<string> args, IHeroManager manager) : base(args, manager)
        {
        }

        public override string Execute()
        {
            return this.Manager.AddRecipeToHero(Args);
        }
    }

