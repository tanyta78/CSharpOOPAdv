using System;
using System.Collections.Generic;

public class QuitCommand : AbstractCommand
{
   
    public QuitCommand(List<string> args, IHeroManager manager) : base(args,manager)
    {
    }

    public override string Execute()
    {
        return this.Manager.PrintAllHeroes();

    }
}