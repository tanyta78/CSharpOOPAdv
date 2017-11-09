using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var lightInput = Console.ReadLine().Split().ToList();

        List<Light> lights = new List<Light>();

        foreach (var light in lightInput)
        {
            lights.Add((Light)Enum.Parse(typeof(Light), light));
        }

        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < lights.Count; j++)
            {
                var currentLight = lights[j];

                if ((int)currentLight + 1 > 2)
                {
                    currentLight = 0;
                }
                else
                {
                    currentLight += 1;
                }

                lights[j] = currentLight;
            }

            Console.WriteLine(string.Join(" ", lights));
        }
    }
}