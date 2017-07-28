using System;
using System.Collections;
using System.Collections.Generic;

public class Clinic : IEnumerable<Pet>
{
    private string name;
    private List<Pet> pets;
    private int rooms;
    private int centerRoom;
    private int freeRooms;

    public Clinic(string name, int rooms)
    {
        this.Name = name;
        this.Pets = new List<Pet>();
        this.Rooms = rooms;
        this.FreeRooms = rooms;
        this.CenterRoom = this.Rooms / 2;
    }

    public string Name { get => name; set => name = value; }
    public List<Pet> Pets { get => pets; set => pets = value; }

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

    public int FreeRooms
    {
        get { return freeRooms; }
        set { freeRooms = value; }
    }

    public bool Add(Pet pet)
    {
        int position = this.CenterRoom;
    }

    public bool Release()
    {
    }

    public bool HasEmptyRooms()
    {
    }

    public void Print()
    {
    }

    public void Print(int indexOfRoom)
    {
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