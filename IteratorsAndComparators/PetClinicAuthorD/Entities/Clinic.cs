﻿using System;

public class Clinic
{
    private int roomsNumber;
    private RoomsRegister roomsRegister;

    public Clinic(string name, int roomsNumber)
    {
        this.RoomsNumber = roomsNumber;
        this.Name = name;
        this.roomsRegister = new RoomsRegister(roomsNumber);
    }

    public string Name { get; set; }

    public int RoomsNumber
    {
        get { return this.roomsNumber; }
        set
        {
            if (value % 2 == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
            this.roomsNumber = value;
        }
    }

    public bool TryAddPet(Pet currentPet)
    {
        foreach (var roomIndex in roomsRegister)
        {
            if (roomsRegister[roomIndex] == null)
            {
                this.roomsRegister[roomIndex] = currentPet;
                return true;
            }
        }

        return false;
    }

    public bool TryReleasePet()
    {
        int centerRoom = this.RoomsNumber / 2;
        for (int i = 0; i < this.roomsNumber; i++)
        {
            int currentIndex = (i + centerRoom) % this.roomsNumber;
            if (this.roomsRegister[currentIndex] != null)
            {
                this.roomsRegister[currentIndex] = null;
                return true;
            }
        }

        return false;
    }
}