using System.Collections.Generic;

public abstract class AbstractCommand : ICommand
{
    private List<string> args;
    private IHeroManager manager;

    protected AbstractCommand(List<string> args, IHeroManager manager)
    {
        this.Args = args;
        this.Manager = manager;
    }

    public List<string> Args
    {
        get { return this.args; }
        set { this.args = value; }
    }

    public IHeroManager Manager
    {
        get { return this.manager; }
        set { this.manager = value; }
    }

    public abstract string Execute();
}