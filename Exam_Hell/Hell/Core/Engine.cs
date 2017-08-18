using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private IInputReader reader;
    private IOutputWriter writer;
    private ICommandInterpreter interpreter;

    public Engine(IInputReader reader, IOutputWriter writer, ICommandInterpreter interpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.interpreter = interpreter;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            string inputLine = this.reader.ReadLine();
            List<string> arguments = this.parseInput(inputLine);

            var result = this.interpreter.InterpretCommand(arguments);
            this.writer.WriteLine(result);

            isRunning = !this.ShouldEnd(inputLine);
        }
    }

    private List<string> parseInput(string input)
    {
        return input.Split(new []{' '},StringSplitOptions.RemoveEmptyEntries).ToList();
    }
    

    private bool ShouldEnd(string inputLine)
    {
        return inputLine.Equals("Quit");
    }
}