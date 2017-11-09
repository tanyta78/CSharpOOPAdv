using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Clinic : IEnumerable<Pet>
{
    private string name;
    private Pet[] pets;
    private int rooms;
    private int centerRoom;

    public Clinic(string name, int rooms)
    {
        this.Name = name;
        this.Pets = new Pet[rooms];
        this.Rooms = rooms;

        this.CenterRoom = rooms / 2;
    }

    public string Name { get => name; set => name = value; }
    public Pet[] Pets { get => pets; set => pets = value; }

    public int Rooms
    {
        get => rooms;
        set
        {
            if (value % 2 == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            this.rooms = value;
        }
    }

    public int CenterRoom { get => centerRoom; set => centerRoom = value; }

    public int CompareTo(Clinic other)
    {
        return this.Name.CompareTo(other.Name);
    }

    public bool Add(Pet pet)
    {
        for (int i = 0; i <= CenterRoom; i++)
        {
            if (this.Pets[CenterRoom - i] == null)
            {
                this.Pets[CenterRoom - i] = pet;
                return true;
            }

            if (this.Pets[CenterRoom + i] == null)
            {
                this.Pets[CenterRoom + i] = pet;
                return true;
            }
        }
        return false;
    }

    public bool Release()
    {
        for (int i = this.CenterRoom; i < this.Rooms; i++)
        {
            if (this.Pets[i] != null)
            {
                this.Pets[i] = null;
                return true;
            }
        }

        for (int i = 0; i < this.CenterRoom; i++)
        {
            if (this.Pets[i] != null)
            {
                this.Pets[i] = null;
                return true;
            }
        }

        return false;
    }

    public bool HasEmptyRooms()
    {
        return this.Pets.Any(r => r == null);
    }

    public string Print()
    {
        var sb = new StringBuilder();

        foreach (Pet pet in pets)
        {
            if (pet == null)
            {
                sb.AppendLine("Room empty");
            }
            else
            {
                sb.AppendLine(pet.ToString());
            }
        }

        return sb.ToString().Trim();
    }

    public IEnumerator<Pet> GetEnumerator()
    {
        throw new System.NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}