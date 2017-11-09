using System.Collections.Generic;

public class HeroCommand : AbstractCommand
{
    public HeroCommand(List<string> args, IHeroManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        return this.Manager.AddHero(Args);
    }
}