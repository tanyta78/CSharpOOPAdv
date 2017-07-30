using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    private static Dictionary<string, Pet> allPets = new Dictionary<string, Pet>();
    private static Dictionary<string, Clinic> allClinics = new Dictionary<string, Clinic>();

    public static void Main(string[] args)
    {
        int cmdCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < cmdCount; i++)
        {
            var cmdArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var command = cmdArgs[0];
            cmdArgs.RemoveAt(0);

            switch (command)
            {
                case "Create":
                    CreateEntity(cmdArgs);
                    break;

                case "Add":
                    AddPetToClinic(cmdArgs[0], cmdArgs[1]);
                    break;

                case "Release":
                    ReleasePetFromClinic(cmdArgs[0]);
                    break;

                case "HasEmptyRooms":
                    CheckForEmptyRooms(cmdArgs[0]);
                    break;

                case "Print":
                    PrintInfo(cmdArgs);
                    break;
            }
        }
    }

    private static void PrintInfo(List<string> cmdArgs)
    {
        var currentClinic = allClinics[cmdArgs[0]];
        string result = null;
        if (cmdArgs.Count == 1)
        {
            result = currentClinic.Print();
        }
        else
        {
            int roomIndex = int.Parse(cmdArgs[1]) - 1;
            result = currentClinic.Print(roomIndex);
        }
        Console.WriteLine(result);
    }

    private static void CheckForEmptyRooms(string clinicName)
    {
        var currentClinic = allClinics[clinicName];

        Console.WriteLine(currentClinic.HasEmptyRooms());
    }

    private static void ReleasePetFromClinic(string clinicName)
    {
        var currentClinic = allClinics[clinicName];

        Console.WriteLine(currentClinic.TryReleasePet());
    }

    private static void AddPetToClinic(string petName, string clinicName)
    {
        var currentPet = allPets[petName];
        var currentClinic = allClinics[clinicName];

        if (currentClinic.TryAddPet(currentPet))
        {
            Console.WriteLine(true);
            allPets.Remove(petName);
            return;
        }

        Console.WriteLine(false);
    }

    private static void CreateEntity(List<string> cmdArgs)
    {
        var entityType = cmdArgs[0];

        if (entityType == "Pet")
        {
            string name = cmdArgs[1];
            int age = int.Parse(cmdArgs[2]);
            string kind = cmdArgs[3];
            allPets.Add(name, new Pet(name, age, kind));
        }
        else if (entityType == "Clinic")
        {
            string name = cmdArgs[1];
            int roomsNum = int.Parse(cmdArgs[2]);
            try
            {
                allClinics.Add(name, new Clinic(name, roomsNum));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}