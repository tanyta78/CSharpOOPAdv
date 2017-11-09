using System;
using System.Collections.Generic;
using System.Linq;

public class ClinicManager
{
    private IList<Pet> pets;
    private IList<Clinic> clinics;

    public ClinicManager()
    {
        this.Pets = new List<Pet>();
        this.Clinics = new List<Clinic>();
    }

    public IList<Pet> Pets
    {
        get { return pets; }
        set { pets = value; }
    }

    public IList<Clinic> Clinics
    {
        get { return clinics; }
        set { clinics = value; }
    }

    public void CreatePet(params string[] args)
    {
        string name = args[0];
        int age = int.Parse(args[1]);
        string kind = args[2];
        var currentPet = new Pet(name, age, kind);
        this.Pets.Add(currentPet);
    }

    public void CreateClinic(params string[] args)
    {
        string name = args[0];
        int rooms = int.Parse(args[1]);
        var currentClinic = new Clinic(name, rooms);
        this.Clinics.Add(currentClinic);
    }

    public bool Add(params string[] args)
    {
        string petName = args[0];
        string clinicName = args[1];
        var currentClinic = Clinics.FirstOrDefault(c => c.Name == clinicName);
        var currentPet = this.Pets.FirstOrDefault(p => p.Name == petName);
        return currentClinic.Add(currentPet);
    }

    public bool Release(params string[] args)
    {
        string clinicName = args[0];
        var currentClinic = Clinics.FirstOrDefault(c => c.Name == clinicName);

        return currentClinic.Release();
    }

    public bool HasEmptyRooms(string clinicName)
    {
        var clinic = Clinics.FirstOrDefault(c => c.Name == clinicName);
        if (clinic == null)
        {
            throw new ArgumentException("Invalid Operation!");
        }
        else
        {
            return clinic.HasEmptyRooms();
        }
    }

    public string Print(string clinicName)
    {
        var clinic = Clinics.FirstOrDefault(c => c.Name == clinicName);
        if (clinic == null)
        {
            throw new ArgumentException("Invalid Operation!");
        }
        else
        {
            return clinic.Print();
        }
    }

    public string Print(string clinicName, int room)
    {
        var clinic = Clinics.FirstOrDefault(c => c.Name == clinicName);
        if (clinic == null)
        {
            throw new ArgumentException("Invalid Operation!");
        }
        else
        {
            var currentRoom = clinic.Pets[room - 1];
            return currentRoom.ToString();
        }
    }
}