using System;
using System.Linq;
using System.Text;

public class Engine
{
    private ClinicManager clinicManager;
    private StringBuilder resultString;

    public Engine()
    {
        this.clinicManager = new ClinicManager();
        this.resultString = new StringBuilder();
    }

    public void Start()
    {
        var numberOfCommands = int.Parse(Console.ReadLine());

        while (numberOfCommands > 0)
        {
            var commandArgs = Console.ReadLine().Split();
            var command = commandArgs[0];
            commandArgs = commandArgs.Skip(1).ToArray();
            string result;
            try
            {
                switch (command)
                {
                    case "Create":
                        var type = commandArgs[0];
                        commandArgs = commandArgs.Skip(1).ToArray();
                        if (type == "Pet")
                        {
                            clinicManager.CreatePet(commandArgs);
                        }
                        else
                        {
                            clinicManager.CreateClinic(commandArgs);
                        }

                        break;

                    case "Add":
                        result = this.clinicManager.Add(commandArgs).ToString();
                        this.resultString.AppendLine(result);
                        break;

                    case "Release":
                        result = clinicManager.Release(commandArgs).ToString();
                        this.resultString.AppendLine(result);
                        break;

                    case "HasEmptyRooms":
                        result = clinicManager.HasEmptyRooms(commandArgs[0]).ToString();
                        this.resultString.AppendLine(result);
                        break;

                    case "Print":
                        var clinicName = commandArgs[0];

                        if (commandArgs.Length > 1)
                        {
                            var roomNumber = int.Parse(commandArgs[1]);
                            result = this.clinicManager.Print(clinicName, roomNumber);
                            this.resultString.AppendLine(result);
                        }
                        else
                        {
                            result = this.clinicManager.Print(clinicName);
                            this.resultString.Append(result);
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                this.resultString.AppendLine(e.Message);
            }

            numberOfCommands--;
        }

        Console.WriteLine(this.resultString.ToString().Trim());
    }
}