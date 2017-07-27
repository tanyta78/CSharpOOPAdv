using System;

public class Program
{
    public static void Main(string[] args)
    {
        var myStack = new Stack<string>();

        string input;

        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            switch (tokens[0])
            {
                case "Push":
                    for (int i = 1; i < tokens.Length; i++)
                    {
                        myStack.Push(tokens[i]);
                    }

                    break;

                case "Pop":
                    try
                    {
                        myStack.Pop();
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
            }
        }

        for (int i = 0; i < 2; i++)
        {
            foreach (var element in myStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}