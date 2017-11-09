public class StartUp
{
    public static void Main()
    {
        IInputReader reader = new ConsoleReader();
        IOutputWriter writer = new ConsoleWriter();
       ItemFactory itemFactory = new ItemFactory();
        IHeroManager heroManager = new HeroManager(itemFactory);
        ICommandInterpreter interpreter = new CommandInterpreter(heroManager);

        Engine engine = new Engine(reader, writer, interpreter);
        engine.Run();
    }
}